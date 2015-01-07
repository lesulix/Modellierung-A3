//Grammar framework by Martin Ilcik. In case you are interested in PR/DA in this field, contact ilcik@cg.tuwien.ac.at
using SharpDX;
using HelixToolkit.SharpDX.Wpf;
using System.Collections.Generic;

namespace SimpleCGA.Grammar
{   
    /// <summary>
    /// Shape, the object manipulated by the production rules
    /// </summary>
    public struct Shape
    {
        /// <summary>
        /// Semantics of the shape defines the string symbol and additional parameters.
        /// </summary>
        public readonly Semantics Symbol;        

        /// <summary>
        /// 4x4 Model matrix of the scope. Scaling of the scope defines the size of the terminal geometry.
        /// </summary>
        public readonly Matrix Scope;

        /// <summary>
        /// Color of the shape (use PhongMaterials, static members)
        /// </summary>
        public readonly PhongMaterial Color;

        //Please keep in mind that in C# there is a difference between a class and a struct. It is very important to remember that at the creation of new shapes!
        //TODO Task 4c add the dimensionality or the number of zeroed rows as a new parameter
        public Shape(Semantics symbol, Matrix scope)
        {
            Symbol = symbol;
            Scope = scope;
            Color = PhongMaterial.Grey(4);
        }

        public Shape(Semantics symbol, Matrix scope, PhongMaterial material)
        {
            Symbol = symbol;
            Scope = scope;
            Color = material;
        }

		//TODO Task 4c Pass the dimensionality 3 or the number of zeroed rows 0 in the constructor
		public static Shape Default(string name)
        {
            return new Shape(new Semantics(name), Matrix.Identity);
        }
		
        //TODO Task 3cd You will need a property returning the dimensionality of the shape. Make the following one work for shapes after aplying the component rules.
        public int Dimensionality
        {
            get { return 3; }
        }
    }
}
