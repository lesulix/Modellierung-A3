G.StepsThreshold = 64;
G.AddTerminal("Cube");
G.AddTerminal("Sphere");
G.AddTerminal("Cylinder");
G.AddTerminal("Empty");

//a simple example (one box at z = 0 moved a bit on x and y)
G.AddAxiom("B");

new Rules.Concat(1,
        new Rules.Parametrize(G, 3, "B", "t", RndFunc(0.25, 0.75)),        
        new Rules.Translate(G, 1, "B", 1, 0, 0, false),
        new Rules.Rename(G, 1, "B", "A")
);

new Rules.Rotate(G, 10, "A", Axis.X, Rad(0.79), true); //axis, angle in radians, local left multiplication (true) or world right multiplication (false) rotation
new Rules.Rotate(G, 10, "A", Axis.Y, Deg(45), true);

new Rules.Concat(1,
    new Rules.Scale(G, 1, "A", 2, 1, 2, false),
    new Rules.Material(G, 1, "A", PhongMaterial.Green(4)),
    new Rules.Rename(G, 1, "A", "Cube")
);

//An equivallent of the rule is
new Rules.Scale(G, 1, "A", 2, 1, 2, false)
			.ThenPaint(PhongMaterial.Green(4))
			.ThenRename("Cube");

new Rules.Split(G, 1, "A", Axis.X, 
    Part("Cube", 0.1, true),
    Part("C", 0.5, false),
    Part("Cube", 0.1, true));

new Rules.Concat(1,
    new Rules.Translate(G, 1, "C", 0, 1, 0, true),
    new Rules.Material(G, 1, "C", PhongMaterial.Red()),
    new Rules.Rename(G, 1, "C", "Sphere")
);