G.StepsThreshold = 64;
G.AddTerminal("Cube");
G.AddTerminal("Sphere");
G.AddTerminal("Cylinder");
G.AddTerminal("Empty");

G.AddAxiom("A");

new Rules.Faces(G, 1, "A", "Empty", "f_left", "f_right", "f_bottom", "f_top", "f_back", "f_front"); //grammar, probability, matching symbol, symbols for the single faces. Can be used only on 3D shapes (volumes).
new Rules.Edges(G, 1, "Empty", "f_front", "e_left", "e_right", "e_bottom", "e_top");//Can be used only on 2D shapes (faces).
new Rules.Vertices(G, 1, "Empty", "e_top", "v_left", "v_right"); //Can be used only on 1D shapes (edges).

new Rules.Extrude(G, 1, "v_right", "ev_right", 0.5); //grammar, probability, matching symbol, output symbol, extrusion amount (direction must be determined automatically from the input shape)
new Rules.Extrude(G, 1, "v_left", "ëv_left", -0.5);

new Rules.Extrude(G, 1, "e_bottom", "ee_bottom", 0.5);
new Rules.Extrude(G, 1, "e_top", "ee_top", -0.5);

new Rules.Extrude(G, 1, "f_front", "ef_front", 0.5);
new Rules.Extrude(G, 1, "f_back", "ef_back", -0.5);

//TODO finalize the grammar by adding terminal shapes