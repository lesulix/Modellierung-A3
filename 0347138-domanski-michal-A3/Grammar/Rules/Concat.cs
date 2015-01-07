using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCGA.Grammar.Rules
{
    /// <summary>
    /// Executes several rules ordered in a fixed sequence on a single shape. All rules except the last one must produce exactly one shape as result.
    /// </summary>
    public class Concat : ProductionRule
    {
        ProductionRule[] Sequence;

        public Concat(CGAGrammar grammar, double probability, params ProductionRule[] sequence)
            : this(probability, sequence)
        { }

        public Concat(double probability, params ProductionRule[] sequence)
            : base((sequence != null) && (sequence.Length > 0) ? sequence[0].Grammar : null, probability, (sequence != null) && (sequence.Length > 0) ? sequence[0].Matches : "")
        {
            Debug.Assert(sequence.Length > 0);

            if (sequence.Length == 0)
                Grammar.ReportError("Derivation error: A concatenation rule must not be empty.");

            Sequence = sequence;

            //Very important check for production, we check here if all rules in the sequence produce only one result and if they belong to the same grammar
            for (int i = 0; i < Sequence.Length; ++i)
            {
                var rule = Sequence[i];

                //avoid the usage of this rule anywehre else
                rule.Probability = 0.0;

                if (i < Sequence.Length - 1)
                {
                    if (!Sequence[i].SingleShapeOutput)
                        Grammar.ReportError("Derivation error: Only rules producing a single shape may be concatenated.");

                    if (rule.Grammar != Sequence[i + 1].Grammar)
                        Grammar.ReportError("Derivation error: A production sequence must chain rules from the same grammar.");
                }
            }
        }

        public override IList<Shape> Apply(Shape input)
        {
            IList<Shape> result = null;
            var temp = input;
            for (int i = 0; i < Sequence.Length; ++i)
            {
                var rule = Sequence[i];
                var list = rule.Apply(temp);

                if (list.Count == 0)
                    Grammar.ReportError("Derivation error: ... a production sequence must chain shape symbol names.");
                
                //TODO Task 4d: Check if all conditions are fine
                
                if (i < Sequence.Length - 1)
                {
                    Debug.Assert(list.Count == 1); //Only a single shape can be produced ...
                    temp = list[0];
                }
                else
                    result = list; //...unless in the last rule of the sequence.
            }

            return result;
        }

        public override bool SingleShapeOutput { get { return Sequence[Sequence.Length - 1].SingleShapeOutput; } }
    }
}
