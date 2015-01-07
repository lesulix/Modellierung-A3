using HelixToolkit.SharpDX.Wpf;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Matrix = SharpDX.Matrix;
using Vector3 = SharpDX.Vector3;
using Transform3D = System.Windows.Media.Media3D.Transform3D ;
using MatrixTransform3D = System.Windows.Media.Media3D.MatrixTransform3D;
using Matrix3D = System.Windows.Media.Media3D.Matrix3D;
using Transform3DGroup = System.Windows.Media.Media3D.Transform3DGroup;
using BoundingBox = SharpDX.BoundingBox;
using SimpleCGA.Grammar;
using System.Reflection;
using PhongMaterial = SimpleCGA.Grammar.PhongMaterial;

namespace SimpleCGA
{
    public abstract class TerminalShape
    {
        public TerminalShape()
        {
            this.Material = PhongMaterial.Default.ToSharpDX;
            this.Transform = Transform3D.Identity;
        }

        public Transform3D Transform { get; set; }
        public Material Material { get; set; }
        public MeshGeometry3D Geometry { get; protected set; }
                
        protected static MeshGeometry3D Cube;
        protected static MeshGeometry3D Cylinder;
        protected static MeshGeometry3D Sphere;

        static TerminalShape()
        {
            var mb = new MeshBuilder(true, true, true);
            mb.AddCube();
            Cube = mb.ToMeshGeometry3D();

            mb = new MeshBuilder(true, true, true);
            mb.AddCylinder(new Vector3(0.5f, 0.0f, 0.5f), new Vector3(0.5f, 1.0f, 0.5f), 0.5);
            Cylinder =  mb.ToMeshGeometry3D();

            mb = new MeshBuilder(true, true, true);
            mb.AddSphere(new Vector3(0.5f, 0.5f, 0.5f), 0.5);
            Sphere = mb.ToMeshGeometry3D();
        }

        public void AppendTransform(Transform3D t)
        {
            var group = this.Transform as Transform3DGroup;
            if (group != null)
            {
                group.Children.Add(t);
            }
            else
            {
                group = new Transform3DGroup();
                group.Children.Add(this.Transform);
                group.Children.Add(t);
                this.Transform = group;
            }
        }

        public void PrepandTransform(Transform3D t)
        {
            var group = this.Transform as Transform3DGroup;
            if (group != null)
            {
                group.Children.Insert(0,t);
            }
            else
            {
                group = new Transform3DGroup();
                group.Children.Add(t);
                group.Children.Add(this.Transform);                
                this.Transform = group;
            }
        }
    }

    public class Cube : TerminalShape
    {
        public Cube()
        {
            this.Geometry = Cube;        
        }
    }

    public class Sphere : TerminalShape
    {
        public Sphere()
        {
            this.Geometry = Sphere;
        }
    }

    public class Cylinder : TerminalShape
    {
        public Cylinder()
        {
            this.Geometry = Cylinder;
        }
    }

    public class GrammarParser : ObservableObject
    {
        private GrammarParser()
        {
            this.ErrorText = string.Empty;
            this.DefaultGrammar();
        }

        private static GrammarParser instance = new GrammarParser();

        private string path = string.Empty;
        

        public static GrammarParser Instance { get { return instance; } }

        public string ProductionCode { get; set; }

        public CGAGrammar Grammar
        {
            get;
            set;
        }

        public string Path
        {
            get;
            set;
        }

        public bool HasError
        {
            get { return this.ErrorText.Length > 0; }
        }

        public string ErrorText
        {
            get;
            set;
        }

        public void ParseGrammar(IList<TerminalShape> shapes)
        {
            shapes.Clear();
            // Check if code is valid

            this.Grammar = BuildGrammar(this.ProductionCode);

            if (this.Grammar != null)
            {
                foreach (var item in this.Grammar.Evaluate())
                {
                    if (item.Symbol.Name != "Empty")
                    {
                        Type t = Type.GetType("SimpleCGA." + item.Symbol.Name);
                        if (t != null)
                        {
                            var s = (Activator.CreateInstance(t) as TerminalShape);
                            s.Material = item.Color.ToSharpDX;
                            s.Transform = new MatrixTransform3D(new Matrix3D(item.Scope.M11, item.Scope.M12, item.Scope.M13, item.Scope.M14,
                                    item.Scope.M21, item.Scope.M22, item.Scope.M23, item.Scope.M24,
                                    item.Scope.M31, item.Scope.M32, item.Scope.M33, item.Scope.M34,
                                    item.Scope.M41, item.Scope.M42, item.Scope.M43, item.Scope.M44));
                            shapes.Add(s);
                        }
                        else
                        {
                            ErrorText = String.Format("Terminal Error: No geometry matches the given terminal symbol {0}", item.Symbol.Name);
                        }
                    }
                }

                ErrorText += this.Grammar.EvaluationErrors;
            }
        }

        public void DefaultGrammar()
        {
            this.ProductionCode =
@"
G.StepsThreshold = 64;
G.AddTerminal(""Cube"");
G.AddTerminal(""Sphere"");
G.AddTerminal(""Cylinder"");

//a simple example (one box at z = 0 moved a bit on x and y)
G.AddAxiom(""A"");

new Rules.Translate(G, 3, ""A"", 0.3, 0, 0, false);
new Rules.Translate(G, 3, ""A"", -0.3, 0, 0, false);
new Rules.Translate(G, 3, ""A"", 0, 0.3, 0, false);
new Rules.Rename(G, 1, ""A"", ""Cube"");

//a more complex example (many boxes at z = 1 moved a bit on x and y)
for(int i = 0; i < 4; ++i)
    G.AddAxiom(""B"");

new Rules.Concat(G, 1,
        new Rules.Translate(G, 1, ""B"", 0, 0, 2, false),
        new Rules.Rename(G, 1, ""B"", ""A"")
);
";
        }

        private CGAGrammar BuildGrammar(string productionCode)
        {
            // Initialize compiler options.
            CompilerParameters compilerParameters = new CompilerParameters()
            {
                GenerateExecutable = true,
                GenerateInMemory = true,
                TreatWarningsAsErrors = true,
                CompilerOptions = "/nowarn:1633"
            };

            // Add ourselves.
            compilerParameters.ReferencedAssemblies.Add(Assembly.GetCallingAssembly().Location);
            compilerParameters.ReferencedAssemblies.Add("SharpDX.dll");
            compilerParameters.ReferencedAssemblies.Add("HelixToolkit.SharpDX.Wpf.dll");

            foreach (var assemblyName in typeof(PhongMaterials).Assembly.GetReferencedAssemblies())
            {
                compilerParameters.ReferencedAssemblies.Add(Assembly.ReflectionOnlyLoad(assemblyName.FullName).Location);
            }

            // Specify .NET version.
            var providerOptions = new Dictionary<string, string>();
            providerOptions.Add("CompilerVersion", "v4.0");
            var provider = new CSharpCodeProvider(providerOptions);

            string sourceFormat =
@"
using System;
using System.Collections.Generic;
using SharpDX;
using SimpleCGA;
using SimpleCGA.Grammar;
using Rules = SimpleCGA.Grammar.Rules;
using HelixToolkit.SharpDX.Wpf;
using PhongMaterial = SimpleCGA.Grammar.PhongMaterial;

public class GrammarProvider
{{    
    static void Main(string[] args){{}}
    public CGAGrammar GetGrammar
    {{
        get
        {{            
            var G = new CGAGrammar(); 
            {{ {0} }};
            return G;
        }}
    }}

    static Angle Rad(double rad)
    {{
        return new Angle(rad, true);
    }}

    static Angle Deg(double deg)
    {{
        return new Angle(deg, false);
    }}

    static Vector3 Vec3(float x, float y, float z)
    {{
        return new Vector3(x, y, z);
    }}

    static Vector3 Vec3(double x, double y, double z)
    {{
        return new Vector3((float)x, (float)y, (float)z);
    }}

    static SubdivisionPart Part(string name, double size, bool relative)
    {{
        return new SubdivisionPart(name, size, relative);
    }}

    static Random mRnd = new Random();
    static System.Func<double> RndFunc(double min, double max)
    {{
        return (() => min + (mRnd.NextDouble() * (max - min)));
    }}

    static double Rnd(double min, double max)
    {{
        return min + (mRnd.NextDouble() * (max - min));
    }}

    static float RndFloat(double min, double max)
    {{
        return (float)(min + (mRnd.NextDouble() * (max - min)));
    }}

    static int RndInt(int min, int max)
    {{
        return mRnd.Next(min, max+1);
    }}

    static byte RndByte(byte min, byte max)
    {{
        return (byte)mRnd.Next(min, max+1);
    }}

    static System.Func<PhongMaterial> RndMaterialFunc(PhongMaterial.Shades baseColor = PhongMaterial.Shades.Any)
    {{
        return () => PhongMaterial.Random(baseColor, mRnd);
    }}

    static System.Func<double> Num(double val)
    {{
        return (() => val);
    }}
}}";

            string source = string.Format(sourceFormat, productionCode);

            // Compile source.
            var results = provider.CompileAssemblyFromSource(compilerParameters, new string[] { source });

            // Show errors.
            if (results.Errors.HasErrors)
            {
                var sb = new StringBuilder();
                foreach (var err in results.Errors)
                {
                    sb.AppendLine(err.ToString());
                }

                this.ErrorText = sb.ToString();
                return default(CGAGrammar);
            }
            else
            {
                this.ErrorText = string.Empty;
            }

            var obj = results.CompiledAssembly.CreateInstance("GrammarProvider");

            // Get the desired property by name.
            var propertyInfo = obj.GetType().GetProperty("GetGrammar");

            // Use the instance to call the property.
            var grammar = (CGAGrammar)propertyInfo.GetValue(obj, null);
            this.ErrorText += grammar.EvaluationErrors;

            return grammar;
        }
    }
}
