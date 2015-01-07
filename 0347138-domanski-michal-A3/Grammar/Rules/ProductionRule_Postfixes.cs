using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCGA.Grammar.Rules
{
    public partial class ProductionRule
    {
        /// <summary>
        /// If there is a single shape at output, its symbol can be overriden here.
        /// </summary>
        protected internal string NewSymbolName = "";

        /// <summary>
        /// If there is a single shape at output, its material can be overriden here.
        /// </summary>
        protected internal Func<PhongMaterial> NewMaterial = null;

        /// <summary>
        /// If there is a single shape at output, its parameters can be overriden here.
        /// </summary>
        protected internal Dictionary<string, double> NewParameters;

        /// <summary>
        /// Override this property and set to true if the rule changes the symbol name
        /// </summary>
        protected virtual bool ChangesSymbolName { get { return false; } }

        /// <summary>
        /// Override this property and set to true if the rule changes the color / material
        /// </summary>
        protected virtual bool ChangesColor { get { return false; } }

        /// <summary>
        /// Override this property and set to true if the rule changes the parameters
        /// </summary>
        protected virtual bool ChangesParameter { get { return false; } }

        /// <summary>
        /// Renames the shape symbol after the application of this rule.
        /// </summary>
        /// <param name="newName"></param>
        /// <returns></returns>
        public ProductionRule ThenRename(string newName)
        {
            if (ChangesSymbolName)
                Grammar.ReportError("Derivation warning: ThenRename would override the effect of a rename rule. Therefore it was not considered during the derivation.");
            else
            {
                if (!SingleShapeOutput)
                    Grammar.ReportError("Derivation error: ThenRename may be applied only to rules producing a single shape.");
                else
                    NewSymbolName = newName;
            }
            return this;
        }

        /// <summary>
        /// Changes material of the shape after application of this rule. Applies only to rules producing a single output shape.
        /// </summary>
        /// <param name="newMaterial"></param>
        /// <returns></returns>
        public ProductionRule ThenPaint(PhongMaterial newMaterial)
        {
            if (ChangesColor)
                Grammar.ReportError("Derivation warning: ThenPaint would override the effect of a material rule. Therefore it was not considered during the derivation.");
            else
            {
                if (!SingleShapeOutput)
                    Grammar.ReportError("Derivation error: ThenPaint may be applied only to rules producing a single shape.");
                else
                    NewMaterial = () => newMaterial;
            }
            return this;
        }

        /// <summary>
        /// Changes material of the shape after application of this rule. Applies only to rules producing a single output shape.
        /// </summary>
        /// <param name="newMaterial"></param>
        /// <returns></returns>
        public ProductionRule ThenPaint(Func<PhongMaterial> newMaterial)
        {
            if (ChangesColor)
                Grammar.ReportError("Derivation warning: ThenPaint would override the effect of a material rule. Therefore it was not considered during the derivation.");
            else
            {
                if (!SingleShapeOutput)
                    Grammar.ReportError("Derivation error: ThenPaint may be applied only to rules producing a single shape.");
                else
                    NewMaterial = newMaterial;
            }
            return this;
        }

        /// <summary>
        /// Changes a parameter of the shape after application of this rule. Applies only to rules producing a single output shape.
        /// </summary>
        /// <param name="newParameterName"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public ProductionRule ThenSetParameter(string newParameterName, double newValue)
        {
            if (ChangesParameter)
                Grammar.ReportError("Derivation warning: ThenSetParameter could override the effect of a parametrize rule. Therefore it was not considered during the derivation.");
            else
            {
                if (!SingleShapeOutput)
                    Grammar.ReportError("Derivation error: ThenSetParameter may be applied only to rules producing a single shape.");
                else
                {
                    if (NewParameters == null)
                        NewParameters = new Dictionary<string, double>();

                    NewParameters[newParameterName] =  newValue;
                }
            }
            return this;
        }

        public IList<Shape> ApplyRule(Shape input)
        {
            IList<Shape> result = null;
            try
            {
                result = Apply(input);
            }
            catch (KeyNotFoundException e)
            {
                Grammar.ReportError("Derivation Error: A parameter used in a lambda function was not present in the shape.");
            }

            if (result == null)
                result = new Shape[] { };

            if (result.Count == 1)
            {
                //TODOS FOR ALL THREE IFs:
                //TODO Task 3c Add the dimensionality parameter

                if (NewSymbolName.Length > 0)
                    result = new Shape[] { new Shape(new Semantics(NewSymbolName, result[0].Symbol.Parameters), result[0].Scope) };

                if (NewMaterial != null)
                    result = new Shape[] { new Shape(result[0].Symbol, result[0].Scope, NewMaterial()) };

                if (NewParameters != null)
                {
                    var newParam = new Dictionary<string, double>(result[0].Symbol.Parameters);
                    //copy all parameters
                    foreach(var item in NewParameters)
                        newParam[item.Key] = item.Value;
                    result = new Shape[] { new Shape(new Semantics(result[0].Symbol.Name, newParam), result[0].Scope) };
                }
            }

            return result;
        }
    }
}
