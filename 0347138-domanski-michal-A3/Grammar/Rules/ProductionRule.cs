//Grammar framework by Martin Ilcik. In case you are interested in PR/DA in this field, contact ilcik@cg.tuwien.ac.at
using System.Collections.Generic;
using System.Diagnostics;
using System;
using HelixToolkit.SharpDX.Wpf;

namespace SimpleCGA.Grammar.Rules
{
    /// <summary>
    /// Basis class for a production rule. Realizes the identity rule.
    /// </summary>
    public abstract partial class ProductionRule
    {
        #region Data
        /// <summary>
        /// Grammar this rule is assigned to
        /// </summary>
        protected internal readonly CGAGrammar Grammar;

        /// <summary>
        /// This rule can be appplied to shapes with the following symbol
        /// </summary>
        protected internal string Matches;

        /// <summary>
        /// Weight for non-deterministic selection of this rule
        /// </summary>
        protected internal double Probability;

        //TODO Task 4d
        //public IList<Func<IDictionary<string, double>, bool>> Conditions { get; set; }

        #endregion

        /// <summary>
        /// True when the rule lways produces only a single shape.
        /// </summary>
        public abstract bool SingleShapeOutput { get; }

        /// <summary>
        /// Base constructor for all rules
        /// </summary>
        /// <param name="grammar">Grammar the rule is assigned to</param>
        /// <param name="probability">Positive probability of the rule to </param>
        /// <param name="matches">Symbol name to match</param>
        public ProductionRule(CGAGrammar grammar, double probability, string matches)
        {
            Grammar = grammar;
            Grammar.Rules.RulesList.Add(this);
            Matches = matches;

            if (probability <= 0)
                Grammar.ReportError(string.Format("Rule error: Probability must be positive, but it is set to {0}.", probability));

            Probability = Math.Max(0, probability);
        }

        /// <summary>
        /// Applies the rule to a shape.
        /// </summary>
        /// <param name="input">The input shape and rule symbols must match.</param>
        /// <returns></returns>
        public virtual IList<Shape> Apply(Shape input)
        {
            Debug.Assert(input.Symbol.Name == Matches);
            return new Shape[] { input };
        }

        //TODO Task4d Implement a method for adding conditions to the rules. The rule counts as applicable to a shape only if all conditions are satisfied.
        //public ProceduralRule If(Func<IDictionary<string, double>, bool> condition) { ... }
    }
}
