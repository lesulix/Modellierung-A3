G.StepsThreshold = 64;
G.AddTerminal("Cube");
G.AddTerminal("Sphere");
G.AddTerminal("Cylinder");
G.AddTerminal("Empty");

G.AddAxiom("A");

//sample extensions to rule constructors

new Rules.Material(G, 1, "A", PhongMaterial.Grey(2)).AddCondition(x => x["p"] > 1.0).AddCondition(x => x["r"] < 0.0); //parameter dependent conditions: the rule can be eapplied only if both conditions evaluate to true
new Rules.Translate(G, 1, "B", x => Vec3(x["t"] * 2.0, x["t"], x["t"] * 0.5), false) //rule parameters as a function of semantic parameters of the input shape
new Rules.Scale(G, 1, "C", Num(1), Rnd(1, 3), Num(1), true) //random parameters - 1 and 3 are numeric, 2 is a random value in the given range

//TODO finalize the grammar by adding terminal shapes