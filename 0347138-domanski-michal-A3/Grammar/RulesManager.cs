//Grammar framework by Martin Ilcik. In case you are interested in PR/DA in this field, contact ilcik@cg.tuwien.ac.at
using System.Collections.Generic;
using System.Linq;
using SimpleCGA.Grammar.Rules;
using System;

namespace SimpleCGA.Grammar
{
    /// <summary>
    /// Axes for rotation, splits and repeats
    /// </summary>
    public enum Axis { X, Y, Z };

    /// <summary>
    /// Encapsulates angular values in both degrees and radians
    /// </summary>
    public struct Angle
    {
        static double radToDeg = 180.0 / Math.PI;
        static double degToRad = Math.PI / 180.0;

        readonly double Rad;

        public Angle(double value, bool isRad)
        {
            Rad = isRad ? value : value * degToRad;
        }

        public double Radians { get { return Rad; } }

        public double Degrees { get { return Rad * radToDeg; } }
    }

    /// <summary>
    /// Defines elements of a split
    /// </summary>
    public struct SubdivisionPart
    {
        /// <summary>
        /// New symbol name for the semantics
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Size along the split axis
        /// </summary>
        readonly double mSize;

        /// <summary>
        /// Random size along the split axis
        /// </summary>
        readonly Func<double> mRndSize;

        /// <summary>
        /// Parametric size along the split axis
        /// </summary>
        readonly Func<IDictionary<string, double>, double> mParamSize;

        /// <summary>
        /// Absolute valued size of relative part of the current scope size
        /// </summary>
        public readonly bool Relative;

        public SubdivisionPart(string name, double size, bool relative)
        {
            Name = name;
            mSize = size;
            mRndSize = null;
            mParamSize = null;
            Relative = relative;
        }

        public SubdivisionPart(string name, Func<double> sizeFunc, bool relative)
        {
            Name = name;
            mSize = -1.0;
            mRndSize = sizeFunc;
            mParamSize = null;
            Relative = relative;
        }

        /// <summary>
        /// Size along the split axis
        /// </summary>
        /// <param name="parameters">Semantic parameters as input, used only if a parametric size definition was used</param>
        /// <returns></returns>
        public double Size(IDictionary<string, double> parameters)
        {
            if (mParamSize == null)
            {
                if (mRndSize == null)
                    return mSize;
                else
                    return mRndSize();
            }
            else
                return mParamSize(parameters);            
        }
    }

    public class RulesManager
    {
        /// <summary>
        /// List of all rules in the grammar
        /// </summary>
        public List<ProductionRule> RulesList = new List<ProductionRule>();

        /// <summary>
        /// Seeks all rules possible to be applied to the given symbol
        /// </summary>
        /// <param name="symbolName">Symbol to match the rules with</param>
        /// <returns>List of accumulated probabilities (prefix sum) and candidate rules</returns>
        internal List<KeyValuePair<double, ProductionRule>> Matching(string symbolName)
        {
            //TODO Task 4d: Add checking of conditions (change the arguments of the methods as necessary)

            var result = new List<KeyValuePair<double,ProductionRule>>();
            double sum = 0.0;
            foreach(var rule in RulesList.Where(r => r.Matches == symbolName))
            {
                sum += rule.Probability;

                result.Add(new KeyValuePair<double, ProductionRule>(sum, rule));
            }

            return result;
        }
    }
}
