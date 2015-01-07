//Grammar framework by Martin Ilcik. In case you are interested in PR/DA in this field, contact ilcik@cg.tuwien.ac.at
using System;
using System.Collections.Generic;
using SharpDX;
using HelixToolkit.SharpDX.Wpf;

namespace SimpleCGA.Grammar
{
    public struct Axiom
    {
        /// <summary>
        /// Random for rules selection
        /// </summary>
        Random Rnd;

        /// <summary>
        /// Initial shape is the same for all axioms, except the symbbol
        /// </summary>
        Shape InitialShape;

        /// <summary>
        /// Grammar of the axiom
        /// </summary>
        readonly CGAGrammar Grammar;

        /// <summary>
        /// Creates a new axiom. Except the symbol, all attributes are default.
        /// </summary>
        /// <param name="grammar">Grammar of the axiom</param>
        /// <param name="initialSymbol">String symbol of the axiom</param>
        /// /// <param name="parallel">If true, the axiom will be derived using the parallel derivation paradigm</param>
        public Axiom(CGAGrammar grammar, string initialSymbol, bool parallel = false)
        {
            Rnd = new Random();
            InitialShape = Shape.Default(initialSymbol); //default shape            
			Grammar = grammar;
            //TODO Task 7 store the parallel derivation attribute for this axiom
        }

        /// <summary>
        /// Applies rules on the axiom while possible.
        /// </summary>
        /// <returns>Set of terminal shapes derived from the initial shape.</returns>
        public HashSet<Shape> Evaluate()
        {
            var result = new HashSet<Shape>(); //set of returned terminal rules

            var sentencialForm = new List<Shape>(); //sentencial form that will be derived step-by-step by applying matching rule
            sentencialForm.Add(InitialShape); //start with the initial shape

            int stepsCounter = 0;

            //Note: The sentencial form of shape grammars is unordered

            while ((sentencialForm.Count > 0)&&(stepsCounter < Grammar.StepsThreshold)) //while there are (nonterminal) shapes in the sentencial form
            {
                var index = Rnd.Next(sentencialForm.Count); //pick a random shape from the available ones
                //TODO Task 7: In case of parallel derivation for this axiom, the selected rule will be applied to all other shapes with the same symbol
                //Note: parallel derivation does not require multiple threads to perform the actual derivation, it only relates to the applicatoin of a single rule to all occurances of a symbol at once

                var newShapes = Grammar.DerivationStep(sentencialForm[index]); //derive a set of new shapes from the selected one
                sentencialForm.RemoveAt(index); //remove the processed shape

                if (newShapes.Count == 0) //report an error in case there is no rule applicable to a non-terminal shape
                    Grammar.ReportError(String.Format("Derivation error in axiom {0}: No shape can be derived from {1} with {2}.", InitialShape.Symbol.Name, sentencialForm[index].Symbol.Name, sentencialForm[index].Symbol.ParametersString));
                else
                {
                    ++stepsCounter;
                    foreach (var item in newShapes) //sort all derived shapes to terminals and nonterminals
                        if (Grammar.Terminals.Contains(item.Symbol.Name))
                            result.Add(item); //store the terminals in the result
                        else
                            sentencialForm.Add(item); //store the nonterminals to the sentencial form
                }
            }

            if (stepsCounter >= Grammar.StepsThreshold) //report an error if the derivation process was forced to terminate
                Grammar.ReportError(String.Format("Derivation error in axiom {0}: Threshold of {1} steps has been reached.", InitialShape.Symbol.Name, Grammar.StepsThreshold));

            return result;
        }
    }
}
