
using HelixToolkit.SharpDX.Wpf;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;


namespace SimpleCGA
{
    using Transform3D = System.Windows.Media.Media3D.Transform3D ;
    using ScaleTransform3D = System.Windows.Media.Media3D.ScaleTransform3D;
    using TranslateTransform3D = System.Windows.Media.Media3D.TranslateTransform3D;
    using Color = SharpDX.Color;
    using BoundingBox = SharpDX.BoundingBox;
    using HelixToolkit.SharpDX;

    public class MainViewModel : BaseViewModel
    {
        // window administation
        public double GlobalFontSize { get; private set; }
        public ICommand WindowVisibilityCommand { get; private set; }
        public ICommand ControlsVisibilityCommand { get; private set; }
        public Visibility ControlsVisible { get; private set; }
        public Visibility WindowVisible { get; private set; }
        public WindowStyle WindowStyle { get; private set; }
        public ResizeMode WindowResizeMode { get; private set; }
        public ICommand ViewEnabledCommand { get; private set; }        
        public string FullFileName { get; private set; }
        public string FileName { get { return System.IO.Path.GetFileName(this.FullFileName); } }

        // commands        
        public ICommand AddCmd { get; private set; }        
        public ICommand DelCmd { get; private set; }
        public ICommand OpenCmd { get; private set; }
        public ICommand SaveCmd { get; private set; }
               
        // lights
        public Vector3 DirectionalLight1Direction { get; protected set; }
        public Color4 DirectionalLight1Color { get; protected set; }
        public Vector3 DirectionalLight2Direction { get; protected set; }
        public Color4 DirectionalLight2Color { get; protected set; }
        public Color4 AmbientLightColor { get; protected set; }

        // env map
        public bool IsEnvRendering { get; set; }
        public bool IsEnvReflecting { get; set; }

        // shadow map
        public bool HasShadowMap { get; set; }
        public double FactorPCF { get; set; }
        public double Bias { get; set; }
        public double Intensity { get; set; }
        public Vector2 ShadowMapResolution { get; set; }

        // axes
        public LineGeometry3D Axes { get; private set; }
        public double AxesThickness { get; set; }
        public double AxesSmoothness { get; set; }
        public SharpDX.Color AxesColor { get; set; }
        public Transform3D AxesTransform { get; private set; }
        public bool RenderAxes { get; set; }

        // plane
        public Transform3D PlaneTransform { get; private set; }
        public MeshGeometry3D Plane { get; private set; }
        public PhongMaterial GrayMaterial { get; private set; }

        // grid
        public LineGeometry3D GridXY { get; set; }
        public LineGeometry3D GridXZ { get; set; }
        public SharpDX.Color GridColor { get; set; }
        public double GridThickness { get; set; }
        public double GridSmoothness { get; set; }
        public bool RenderGridXY { get; set; }
        public bool RenderGridXZ { get; set; }

        // grammar & shapes
        public GrammarParser Parser { get { return GrammarParser.Instance; } }
        public ICommand ParseGrammarCmd { get; private set; }
        public ICommand UpdateGrammarCmd { get; private set; }
        public ICommand DefaultGrammarCmd { get; private set; }

        public MeshGeometry3D TestModel { get; private set; }
        public IList<TerminalShape> Shapes { get; private set; }
        public Transform3D MainTransform { get; private set; }
        public object SelectedItem { get; set; }
        public string Student { get; private set; }

        public MainViewModel()
        {
            this.Student = "034137-domanski-michal-A3";

            // commands                      
            this.OpenCmd = new RelayCommand((o) => OnOpen());
            this.SaveCmd = new RelayCommand((o) => OnSave());

            // camera
            //double znear = 1.0;
            //double zfar = 200;
            //this.defaultPerspectiveCamera = new PerspectiveCamera { Position = new Point3D(5, 5, 10), LookDirection = new Vector3D(-0, -0, -10), UpDirection = new Vector3D(0, 1, 0), NearPlaneDistance = znear, FarPlaneDistance = zfar };
            //this.defaultOrthographicCamera = new OrthographicCamera { Position = new Point3D(5, 5, 20), LookDirection = new Vector3D(-0, -0, -20), UpDirection = new Vector3D(0, 1, 0), NearPlaneDistance = 1, FarPlaneDistance = 100 };
            //this.Camera = defaultPerspectiveCamera;
            //this.Camera.AnimateTo(new Point3D(0, 0, 0), new Vector3D(0, 0, -10), new Vector3D(0, 1, 0), 5000);
            //this.CreatePointAnimationUsingPath(this.Camera, this.Camera.Position, new Point3D(0, 5, 10), 5);
            this.RenderTechnique = Techniques.RenderPhong;
            this.Title = "Simple CGA Modeler";

            // setup lighting            
            this.AmbientLightColor = new Color4(0.2f, 0.2f, 0.2f, 1f);
            this.DirectionalLight1Color = SharpDX.Color.White;
            this.DirectionalLight1Direction = 1 * new Vector3(-1, -3, -1);

            this.DirectionalLight2Color = new Color4(0.2f, 0.2f, 0.2f, 1f);
            this.DirectionalLight2Direction = 1 * new Vector3(0, 0, -1);

            // init env map
            this.IsEnvReflecting = true;
            this.IsEnvRendering = false;

            // shadow map
            this.HasShadowMap = false;
            this.FactorPCF = 2.0;
            this.Bias = 0.002;
            this.Intensity = 0.35;
            this.ShadowMapResolution = 6 * new Vector2(1024, 1024);

            // axes
            int axesLen = 50;
            this.AxesTransform = Transform3D.Identity; //new Media3D.ScaleTransform3D(1, 1, 0);
            var lb = new LineBuilder();
            lb.AddLine(new Vector3(-axesLen, 0, 0), new Vector3(+axesLen, 0, 0));
            lb.AddLine(new Vector3(0, -0, 0), new Vector3(0, +axesLen, 0));
            this.Axes = lb.ToLineGeometry3D();
            this.AxesColor = SharpDX.Color.Gray;
            this.AxesSmoothness = 0.0;
            this.AxesThickness = 0.5;
            this.RenderAxes = false;

            // plane
            var b2 = new MeshBuilder();
            b2.AddBox(new Vector3(0, 0, 0), 100, 0, 100, BoxFaces.PositiveY);
            this.Plane = b2.ToMeshGeometry3D();
            this.PlaneTransform = new TranslateTransform3D(-0, -0, -0);
            this.GrayMaterial = PhongMaterials.DefaultVRML;
            this.GrayMaterial = new PhongMaterial()
            {
                Name = "White",
                AmbientColor = Color.Black,
                DiffuseColor = Color.White,
                SpecularColor = Color.Black,
                EmissiveColor = new Color4(0.5f, 0.5f, 0.5f, 1.0f),
                ReflectiveColor = Color.Black,
                SpecularShininess = 10000f,
            };

            // grid
            this.GridXY = LineBuilder.GenerateGrid(Vector3.UnitZ, -axesLen, axesLen, -0, axesLen);
            this.GridXZ = LineBuilder.GenerateGrid(Vector3.UnitY, -axesLen, axesLen);
            this.GridColor = SharpDX.Color.LightGray;
            this.GridSmoothness = 0.0;
            this.GridThickness = 0.25;
            this.RenderGridXY = false;
            this.RenderGridXZ = true;

            // grammar parser
            this.ParseGrammarCmd = new RelayCommand((x) => Parser.ParseGrammar(this.Shapes));
            this.DefaultGrammarCmd = new RelayCommand((x) => Parser.DefaultGrammar());
           
            // shapes            
            this.MainTransform = Transform3D.Identity;
            this.Shapes = new ObservableCollection<TerminalShape>();
        }


        private void OnOpen()
        {
            try
            {
                var d = new Microsoft.Win32.OpenFileDialog()
                {
                    Filter = "C# files|*.cs",
                };
                if (d.ShowDialog().Value)
                {
                    if (File.Exists(d.FileName))
                    {
                        this.Parser.ProductionCode = File.ReadAllText(d.FileName);                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MVM: File open error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnSave()
        {
            try
            {
                var d = new Microsoft.Win32.SaveFileDialog()
                {
                    Filter = "C# files|*.cs",
                };
                if (d.ShowDialog().Value)
                {
                    File.WriteAllText(d.FileName, this.Parser.ProductionCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MVM: File save error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }        
    }
}
