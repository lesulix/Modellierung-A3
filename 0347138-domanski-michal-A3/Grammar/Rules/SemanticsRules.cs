//Grammar framework by Martin Ilcik. In case you are interested in PR/DA in this field, contact ilcik@cg.tuwien.ac.at
using System;
using System.Collections.Generic;
using HelixToolkit.SharpDX.Wpf;

namespace SimpleCGA.Grammar.Rules
{
    /// <summary>
    /// Changes the symbol name and leaves the parameters
    /// </summary>
    public class Rename : ProductionRule
    {
        /// <summary>
        /// New symbol for the shape
        /// </summary>
        readonly string NewName;

        //TODO Task 4 add data, constructors and application of parametric expressions and conditionals
        //Define the Constructor and data as:
        //   readonly Func<IDictionary<string, double>, string> NameFunc;
        //   public Rename(CGAGrammar grammar, double probability, string matches, Func<IDictionary<string, double>, string> nameFunc)

        public Rename(CGAGrammar grammar, double probability, string matches, string name)
            : base(grammar, probability, matches)
        {
            NewName = name;
        }

        public override IList<Shape> Apply(Shape input)
        {
            //copy everything from the input, but change the symbol
			
			//TODO Task 4c Pass the dimensionality or the number of zeroed rows in the constructor
			
            return new[] { new Shape(new Semantics(NewName, input.Symbol.Parameters), input.Scope, input.Color) };
        }

        public override bool SingleShapeOutput { get { return true; } }

        protected override bool ChangesSymbolName { get { return true; } }
    }

    public class Material : ProductionRule
    {
        readonly PhongMaterial NewColor;
		
		public Material(CGAGrammar grammar, double probability, string matches, PhongMaterial material)
			: base(grammar, probability, matches)
		{
		    NewColor = material;
		}		
      
        //TODO Task 4 add data, constructors and application of random, parametric expressions and conditionals
        //Define the constructor as:
        //   public Material(CGAGrammar grammar, double probability, string matches) //assigns a random material
        //   public Material(CGAGrammar grammar, double probability, string matches, Func<IDictionary<string, double>, PhongMaterial> materialFunc)
        
        public override IList<Shape> Apply(Shape input)
        {
            return new[] {new Shape(input.Symbol, input.Scope, NewColor)};
        }

        protected override bool ChangesColor
        {
            get { return true; }
        }

        public override bool SingleShapeOutput
        {
            get { return true; }
        }
    }
    

    //TODO Task 4b The following comment contains the template for a rule which adds or alters parameters of the shape
    /*
    public class Parametrize : ProductionRule
    {
        readonly string ParameterName;
        readonly Func<double, double> Transformation;

        //The basic non-parametric constructors
        //public Parametrize(CGAGrammar grammar, double probability, string matches, string parameter, double value);
        //public Parametrize(CGAGrammar grammar, double probability, string matches, string parameter, Func<double, double> transformValue);
      
        //TODO Task 4 add data, constructors and application of random, parametric expressions and conditionals
        
        //TODO 4a
        //public Parametrize(CGAGrammar grammar, double probability, string matches, string parameter, Func<double> randomFunc); 
        
        //TODO 4c
        //the ordering of the last 2 arguments has to be changed, so that the compiler can distinguish it from the constructor with the Func<double, double> parameter
        //public Parametrize(CGAGrammar grammar, double probability, string matches, Func<IDictionary<string, double>, double> valueFunc, string parameter);

        //TODO Task 4c override the SingleShapesOutput and ChangesParameter properties
    }
    */
}
