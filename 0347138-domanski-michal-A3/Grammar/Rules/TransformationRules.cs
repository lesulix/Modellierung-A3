//Grammar framework by Martin Ilcik. In case you are interested in PR/DA in this field, contact ilcik@cg.tuwien.ac.at
using System;
using System.Collections.Generic;
using SharpDX;

namespace SimpleCGA.Grammar.Rules
{
    //Here is an example of a transformation rule. Add more following the Task 2.

    /// <summary>
    /// Translates the rule using the given offset
    /// </summary>
    public class Translate : ProductionRule
    {
        /// <summary>
        /// Translation vector
        /// </summary>
        readonly Func<IDictionary<string, double>, Vector3> Translation;

        /// <summary>
        /// Applies a local transformation if true, a global if false
        /// </summary>
        readonly Func<IDictionary<string, double>, bool> LocalTransformation;

        //TODO Task 4a: Random variance of rule parameters
        //This might be implemented using the TranslationFunction template as well by wrappping the random function calls into a single function returning Vector3
        //   readonly System.Func<double> RandomX = null, RandomY = null, RandomZ = null;

        //TODO Task 4c: Parametric expresions on rule parameters
        //   readonly Func<IDictionary<string, double>, Vector3> TranslationFunction = null;

        public Translate(CGAGrammar grammar, double probability, string matches, double tx, double ty, double tz, bool local)
            : base(grammar, probability, matches)
        {
            Translation = x => new Vector3((float)tx, (float)ty, (float)tz);
            LocalTransformation = x => local;
        }

        //Examples for Task 4: Write additional constructors for random and parametric expressions
        //Example 4a
        public Translate(CGAGrammar grammar, double probability, string matches, System.Func<double> tx, System.Func<double> ty, System.Func<double> tz, bool local)
            : base(grammar, probability, matches)
        {
            Translation = x => new Vector3((float)tx(), (float)ty(), (float)tz());
            LocalTransformation = x => local;
        }

        //Example 4c
        public Translate(CGAGrammar grammar, double probability, string matches, Func<IDictionary<string, double>, Vector3> func, bool local)
            : base(grammar, probability, matches)
        {
            Translation = func;
            LocalTransformation = x => local;
        }

        public Translate(CGAGrammar grammar, double probability, string matches, Func<IDictionary<string, double>, Vector3> func, Func<IDictionary<string, double>, bool> localFunc)
            : base(grammar, probability, matches)
        {
            Translation = func;
            LocalTransformation = localFunc == null ? (x => false) : localFunc;
        }

        public override IList<Shape> Apply(Shape input)
        {
            //Translate scope of input shape and copy everything else
            //Hint: The matrices are multiplied from left to right

            //Get the translation vector. In task 4 it may be computed depending on the parameters vector. Therefore, we store it already as a function and pass the dictionary of parameters in.
            var translationVector = Translation(input.Symbol.Parameters);
            //Create the translation matrix from the translation vector
            var translationMatrix = Matrix.Translation(translationVector);
            
            //Apply the matrix to the curent scope and obtain the transformed one
            Matrix transformedScope;
            if (LocalTransformation(input.Symbol.Parameters))
                transformedScope = translationMatrix * input.Scope;
            else
                transformedScope = input.Scope * translationMatrix;

            //TODO Task 3c Add additional parameters to the constructor
            return new[] { new Shape(input.Symbol, transformedScope, input.Color) };
        }

        public override bool SingleShapeOutput { get { return true; } }
    }

    public class Rotate : ProductionRule
    {
        readonly Func<IDictionary<string, double>, Angle> Angle;
        readonly Func<IDictionary<string, double>, Axis> Axis;
        readonly Func<IDictionary<string, double>, bool> LocalTransformation;

        public Rotate(CGAGrammar grammar, double probability, string matches, Axis axis, Angle angle, bool local, bool scopeCenter = false)
            : base(grammar, probability, matches)
        {
            Angle = x => angle;
            Axis = x => axis;
            LocalTransformation = x => local;
        }

        public override IList<Shape> Apply(Shape input)
        {
            var angle = Angle(input.Symbol.Parameters);
            var axis = Axis(input.Symbol.Parameters);
            var rotationMatrix =
                axis == SimpleCGA.Grammar.Axis.X
                    ? Matrix.RotationX((float) angle.Radians)
                    : axis == SimpleCGA.Grammar.Axis.Y
                        ? Matrix.RotationY((float) angle.Radians)
                        : Matrix.RotationZ((float) angle.Radians);

            Matrix transformedScope;
            if (LocalTransformation(input.Symbol.Parameters))
                transformedScope = rotationMatrix * input.Scope;
            else
                transformedScope = input.Scope * rotationMatrix;

            return new[] { new Shape(input.Symbol, transformedScope, input.Color) };
        }

        public override bool SingleShapeOutput { get { return true; } }
    }

    public class Scale : ProductionRule
    {
        readonly Func<IDictionary<string, double>, Vector3> Scaling;
        readonly Func<IDictionary<string, double>, bool> LocalTransformation;

        public Scale(CGAGrammar grammar, double probability, string matches, double sx, double sy, double sz, bool local, bool scopeCenter = false)
            : base(grammar, probability, matches)
        {
            Scaling = x => new Vector3((float)sx, (float)sy, (float)sz);
            LocalTransformation = x => local;
        }

        public override IList<Shape> Apply(Shape input)
        {
            var scaling = Scaling(input.Symbol.Parameters);
            var scalingMatrix = Matrix.Scaling(scaling);

            Matrix transformedScope;
            if (LocalTransformation(input.Symbol.Parameters))
                transformedScope = scalingMatrix * input.Scope;
            else
                transformedScope = input.Scope * scalingMatrix;

            return new[] { new Shape(input.Symbol, transformedScope, input.Color) };
        }

        public override bool SingleShapeOutput { get { return true; } }
    }
    
    //TODO Task 4: Write additional constructors for random and parametric expressions
    //TODO 4a
    //   Rotate(CGAGrammar grammar, double probability, string matches, Axis axis, Func<double> angleRandom, bool local, bool scopeCenter = false)
    //TODO 4c
    //   Rotate(CGAGrammar grammar, double probability, string matches, Axis axis, Func<IDictionary<string, double>, Angle> angleFunc, bool local, bool scopeCenter = false)
    //   Rotate(CGAGrammar grammar, double probability, string matches, Func<IDictionary<string, double>, Axis> axisFunc, Func<IDictionary<string, double>, Angle> angleFunc, bool local, bool scopeCenter = false)
    //   Rotate(CGAGrammar grammar, double probability, string matches, Func<IDictionary<string, double>, Axis> axisFunc, Func<IDictionary<string, double>, Angle> angleFunc, Func<IDictionary<string, double>, bool> localFunc, bool scopeCenter = false)
    
    //TODO Task 4: Write additional constructors for random and parametric expressions
    //TODO 4a
    //   Scale(CGAGrammar grammar, double probability, string matches, System.Func<double> sxRandom, System.Func<double> syRandom, System.Func<double> szRandom, bool local, bool scopeCenter = false)
    //TODO 4c
    //   Scale(CGAGrammar grammar, double probability, string matches, Func<IDictionary<string, double>, Vector3> scaleFunc, bool local, bool scopeCenter = false)
    //   Scale(CGAGrammar grammar, double probability, string matches, Func<IDictionary<string, double>, Vector3> scaleFunc, Func<IDictionary<string, double>, bool> localFunc, bool scopeCenter = false)   
}