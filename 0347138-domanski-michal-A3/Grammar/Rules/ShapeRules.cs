//Grammar framework by Martin Ilcik. In case you are interested in PR/DA in this field, contact ilcik@cg.tuwien.ac.at
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCGA.Grammar.Rules
{
    //Note: For rules producing more than a single shape the following parameters are to be *replicated*: semantic parameters and material. Be careful in order not to loose points here.

    //TODO Task 3a: Implement the copy rule. It creates a number (at least one) of copies of the current shape, but with different semantic names. The original shape is of course preserved.
    //This rule acts very similar to the I rule in the paper, but also addition of non-terminals is possible.
    //Define the Constructor as:
    //    Copy(CGAGrammar grammar, double probability, string matches, params string[] copyNames);
    //TODO Task 4c: Write addional constructor for parametric expressions
    //    Copy(CGAGrammar grammar, double probability, string matches, Func<<IDictionary<string, double>, string[]> copyNames);


    //TODO Task 3b: Implement the split rule (only one direction at once, hence Axis.XY is not valid)
    //Please note that details on how this rule wors can be found on page 3 of the paper
    //Define the Constructor as:
    //    Split(CGAGrammar grammar, double probability, string matches, Axis splitAxis, params SubdivisionPart[] splitParts);
    //TODO Task 4c: Write addional constructors for parametric expressions
    //   Split(CGAGrammar grammar, double probability, string matches, Func<IDictionary<string, double>, Axis> axisFunc, params SubdivisionPart[] splitParts)
    //   Split(CGAGrammar grammar, double probability, string matches, Func<IDictionary<string, double>, Axis> axisFunc, params Func<IDictionary<string, double>, SubdivisionPart>[] splitParts)


    //TODO Task 3b: Implement the repeat rule (only one direction at once, hence something like Axis.XY is not valid)
    //Please note that details on how this rule wors can be found on page 3 of the paper
    //Define the Constructor as:
    //   Repeat(CGAGrammar grammar, double probability, string matches, Axis splitAxis, string newName, double size);
    //TODO Task 3c: Take care of 2D, 1D and 0D shapes, so that some split directions along zeroed axes will be disallowed. Report a grammar erro in that case.
    //TODO Task 4: Write addional constructors for random and parametric expressions
    //Task 4a
    //   Repeat(CGAGrammar grammar, double probability, string matches, Axis splitAxis, string newName, Func<double> sizeFunc)
    //Task 4c
    //   Repeat(CGAGrammar grammar, double probability, string matches, Axis splitAxis, string newName, Func<IDictionary<string, double>, double> sizeFunc)    
    //   Repeat(CGAGrammar grammar, double probability, string matches, Func<IDictionary<string, double>, Axis> axisFunc, Func<IDictionary<string, double>, string> newNameFunc, Func<IDictionary<string, double>, double> sizeFunc)


    //TODO Task 3c: Implement the component split a three rules, define the constructors as:
    //   Faces(CGAGrammar grammar, double probability, string matches, string newName, string leftName, string rightName, string bottomName, string topName, string backName, string frontName);
    //   Edges(CGAGrammar grammar, double probability, string matches, string newName, string leftName, string rightName, string bottomName, string topName);
    //   Vertices(CGAGrammar grammar, double probability, string matches, string newName, string leftName, string rightName);
    //
    //              The rules return not only the lower-dimensional structures, but also the input shape (otherwise it would be deleted this way) renamed to newName.
    //              It is very important to adapt (scale, rotate, translate, mirror) the new scopes so that they match their components. The new scope should point with the first "unused" axis (Z for faces, Y for edges, X for vertices) in the direction of the normal of the component and all its axes should be correctly scaled/sized. Also, it should be correctly placed in the lower-left-back corner of the component (with respect to its new coordinate system).
    //              E.g. the scope of top side in the Faces rule can be obtained by multiplying the original scope matrix with 
    //                  mat = new Matrix(1, 0, 0, 0,    
    //                                   0, 0, -1, 0,   //y becomes -z
    //                                   0, 1, 0, 0,    //z becomes y
    //                                   0, 1, 1, 1);   //translate by z and y

    //              Lower-dimensional shapes have have the scale of some scope axes set to zero. E.g. for edges, which are 2D, only the first scope row will be non-zero.
    //              However, we do not want to loose the information about the rest of the axes, so that we know in which direction to extrude later (if necessary). Thus, instead of throwing the information away, we will keep track of unused rows using a simple trick:
    //              By transforming the scope as described a few lines earlier and storing the number of valid rows (Dimensionality = validRows + 1) in a separate attribute, we will always be able to reconstruct the order of component rules application (and simultaneously the normal vecotrs of the components) and extrude back to full 3D. This way we will be also able to perform transformations on lower-dimensional shapes without any problem.
    //              Rember, let the component rules be applied only to suitable shapes, otherwise write an error message. Examples of errors: Vertices applied on a 3D shape, Faces on a 2D shape etc.
    //TODO Task 4c: Write addional constructor for parametric expressions
    //   Faces(CGAGrammar grammar, double probability, string matches, Func<IDictionary<string, double>, string> newName, Func<IDictionary<string, double>, string> leftName, Func<IDictionary<string, double>, string> rightName, Func<IDictionary<string, double>, string> bottomName, Func<IDictionary<string, double>, string> topName, Func<IDictionary<string, double>, string> backName, Func<IDictionary<string, double>, string> frontName)
    //   Edges(CGAGrammar grammar, double probability, string matches, Func<IDictionary<string, double>, string> newName, Func<IDictionary<string, double>, string> leftName, Func<IDictionary<string, double>, string> rightName, Func<IDictionary<string, double>, string> bottomName, Func<IDictionary<string, double>, string> topName)
    //   Vertices(CGAGrammar grammar, double probability, string matches, Func<IDictionary<string, double>, string> newName, Func<IDictionary<string, double>, string> leftName, Func<IDictionary<string, double>, string> rightName);

    
    //TODO Task 3d: Implement the extrusion rule (sets the scope so that the zero dimension becomes the size specified in the extrusion size)
    //Define the Constructor as:
    //   public Extrude(CGAGrammar grammar, double probability, string matches, string newName, double amount);
    //              You may suppose that amount is positive, otherwise write an error message.
    //              The extrusion dimension is determined by the normal of the component (the first invalid row of the scope matrix).    

    //TODO Task 4: Write addional constructors for random and parametric expressions
    //TODO 4a
    //   Extrude(CGAGrammar grammar, double probability, string matches, string newName, Func<double> amount)
    //TODO 4c
    //   Extrude(CGAGrammar grammar, double probability, string matches, string newName, Func<IDictionary<string, double>, double> amount)
    //   Extrude(CGAGrammar grammar, double probability, string matches, Func<IDictionary<string, double>, string> nameFunc, Func<IDictionary<string, double>, double> amountFunc)
}
