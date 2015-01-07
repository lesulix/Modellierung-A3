using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using SharpDX;

namespace SimpleCGA.Grammar
{
    [Serializable]
    public enum ShadingModel { NoShading, FlatShading, SmoothShading };

    [Serializable]
    public class PhongMaterial
    {
        public double[] Diffuse;
        public double[] Ambient;
        public double[] Emissive;

        public ShadingModel Shading;

        public double[] Specular; //if Lambert ==null
        public double Shininess;

        public PhongMaterial()
        {
            Ambient = new double[] { 0.5, 0.5, 0.5 };
            Diffuse = new double[] { 0.7, 0.7, 0.7 };
            Emissive = null;

            Shading = ShadingModel.SmoothShading;

            Specular = null;
            Shininess = 1;
        }

        //http://globe3d.sourceforge.net/g3d_html/gl-materials__ads.htm
        public static PhongMaterial Glass
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 0, 0, 0 },
                    Diffuse = new double[] { 0.588235, 0.670588, 0.729412 },
                    Specular = new double[] { 0.9, 0.9, 0.9 },
                    Shininess = 27.8974
                };
            }
        }


        //http://www.nicoptere.net/dump/materials.html
        public static PhongMaterial Brass
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 0.329412, 0.223529, 0.027451 },
                    Diffuse = new double[] { 0.780392, 0.568627, 0.113725 },
                    Specular = new double[] { 0.992157, 0.941176, 0.807843 },
                    Shininess = 27.8974
                };
            }
        }

        public static PhongMaterial Bronze
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 0.2125, 0.1275, 0.054 },
                    Diffuse = new double[] { 0.714, 0.4284, 0.18144 },
                    Specular = new double[] { 0.393548, 0.271906, 0.807843 },
                    Shininess = 25.6
                };
            }
        }

        public static PhongMaterial PolishedBronze
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 0.25, 0.148, 0.06475 },
                    Diffuse = new double[] { 0.4, 0.2368, 0.1036 },
                    Specular = new double[] { 0.774597, 0.458561, 0.200621 },
                    Shininess = 76.8
                };
            }
        }

        public static PhongMaterial Chrome
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 0.25, 0.25, 0.25 },
                    Diffuse = new double[] { 0.4, 0.4, 0.4 },
                    Specular = new double[] { 0.774597, 0.774597, 0.774597 },
                    Shininess = 76.8
                };
            }
        }

        public static PhongMaterial Copper
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 0.19125, 0.0735, 0.0225 },
                    Diffuse = new double[] { 0.7038, 0.27048, 0.0828 },
                    Specular = new double[] { 0.256777, 0.137622, 0.086014 },
                    Shininess = 12.8
                };
            }
        }

        public static PhongMaterial PolishedCopper
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 0.2295, 0.08825, 0.0275 },
                    Diffuse = new double[] { 0.5508, 0.2118, 0.066 },
                    Specular = new double[] { 0.580594, 0.223257, 0.0695701 },
                    Shininess = 51.2
                };
            }
        }

        public static PhongMaterial Gold
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 0.24725, 0.1995, 0.0745 },
                    Diffuse = new double[] { 0.75164, 0.60648, 0.22648 },
                    Specular = new double[] { 0.628281, 0.555802, 0.366065 },
                    Shininess = 51.2
                };
            }
        }

        public static PhongMaterial PolishedGold
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 0.24725, 0.2245, 0.0645 },
                    Diffuse = new double[] { 0.34615, 0.3143, 0.0903 },
                    Specular = new double[] { 0.797357, 0.723991, 0.208006 },
                    Shininess = 83.2
                };
            }
        }

        public static PhongMaterial Pewter
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 0.105882, 0.058824, 0.113725 },
                    Diffuse = new double[] { 0.427451, 0.470588, 0.541176 },
                    Specular = new double[] { 0.333333, 0.333333, 0.521569 },
                    Shininess = 9.84615
                };
            }
        }

        public static PhongMaterial Silver
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 0.19225, 0.19225, 0.19225 },
                    Diffuse = new double[] { 0.50754, 0.50754, 0.50754 },
                    Specular = new double[] { 0.508273, 0.508273, 0.508273 },
                    Shininess = 51.2
                };
            }
        }

        public static PhongMaterial PolishedSilver
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 0.23125, 0.23125, 0.23125 },
                    Diffuse = new double[] { 0.2775, 0.2775, 0.2775 },
                    Specular = new double[] { 0.773911, 0.773911, 0.773911 },
                    Shininess = 89.6
                };
            }
        }

        public static PhongMaterial Emerald
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 0.0215, 0.1745, 0.0215 },
                    Diffuse = new double[] { 0.07568, 0.61424, 0.07568 },
                    Specular = new double[] { 0.633, 0.727811, 0.633 },
                    Shininess = 76.8
                };
            }
        }

        public static PhongMaterial Jade
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 0.135, 0.2225, 0.1575 },
                    Diffuse = new double[] { 0.54, 0.89, 0.63 },
                    Specular = new double[] { 0.316228, 0.316228, 0.316228 },
                    Shininess = 12.8
                };
            }
        }

        public static PhongMaterial Obsidian
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 0.05375, 0.05, 0.06625 },
                    Diffuse = new double[] { 0.18275, 0.17, 0.22525, 0.332741 },
                    Specular = new double[] { 0.332741, 0.328634, 0.346435 },
                    Shininess = 38.4
                };
            }
        }

        public static PhongMaterial Pearl
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 0.25, 0.20725, 0.20725 },
                    Diffuse = new double[] { 1, 0.829, 0.829 },
                    Specular = new double[] { 0.296648, 0.296648, 0.296648 },
                    Shininess = 11.264
                };
            }
        }

        public static PhongMaterial Ruby
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 0.1745, 0.01175, 0.01175 },
                    Diffuse = new double[] { 0.61424, 0.04136, 0.04136 },
                    Specular = new double[] { 0.727811, 0.626959, 0.626959 },
                    Shininess = 76.8
                };
            }
        }

        public static PhongMaterial Turquoise
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 0.1, 0.18725, 0.1745 },
                    Diffuse = new double[] { 0.396, 0.74151, 0.69102 },
                    Specular = new double[] { 0.297254, 0.30829, 0.306678 },
                    Shininess = 12.8
                };
            }
        }

        public static PhongMaterial BlackPlastic
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 0, 0, 0 },
                    Diffuse = new double[] { 0.01, 0.01, 0.01 },
                    Specular = new double[] { 0.5, 0.5, 0.5 },
                    Shininess = 32
                };
            }
        }

        public static PhongMaterial BlackRubber
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 0.02, 0.02, 0.02 },
                    Diffuse = new double[] { 0.01, 0.01, 0.01 },
                    Specular = new double[] { 0.4, 0.4, 0.4 },
                    Shininess = 10
                };
            }
        }

        public static double[] HexToColor(string hex)
        {
            if (hex[0] == '#')
                hex = hex.Remove(0, 1);

            switch (hex.Length)
            {
                default: return new double[] { HexToDouble(hex[0]), HexToDouble(hex[1]), HexToDouble(hex[2]) };
                case 4: return new double[] { HexToDouble(hex[0]), HexToDouble(hex[1]), HexToDouble(hex[2]), HexToDouble(hex[3]) };
                case 6: return new double[] { HexToDouble(hex[0], hex[1]), HexToDouble(hex[2], hex[3]), HexToDouble(hex[4], hex[5]) };
                case 8: return new double[] { HexToDouble(hex[0], hex[1]), HexToDouble(hex[2], hex[3]), HexToDouble(hex[4], hex[5]), HexToDouble(hex[6], hex[7]) };
            }
        }

        private static double HexToDouble(char val)
        {
            switch (char.ToLower(val))
            {
                default: return 0.0;
                case '1': return 1.0 / 15.0;
                case '2': return 2.0 / 15.0;
                case '3': return 0.2;
                case '4': return 4.0 / 15.0;
                case '5': return 5.0 / 15.0;
                case '6': return 0.4;
                case '7': return 7.0 / 15.0;
                case '8': return 8.0 / 15.0;
                case '9': return 0.6;
                case 'a': return 10.0 / 15.0;
                case 'b': return 11.0 / 15.0;
                case 'c': return 0.8;
                case 'd': return 13.0 / 15.0;
                case 'e': return 14.0 / 15.0;
                case 'f': return 1.0;
            }
        }

        private static double HexToDouble(char val1, char val2)
        {
            double result;
            switch (char.ToLower(val2))
            {
                default: result = 0.0; break;
                case '1': result = 1.0; break;
                case '2': result = 2.0; break;
                case '3': result = 3.0; break;
                case '4': result = 4.0; break;
                case '5': result = 5.0; break;
                case '6': result = 6.0; break;
                case '7': result = 7.0; break;
                case '8': result = 8.0; break;
                case '9': result = 9.0; break;
                case 'a': result = 10.0; break;
                case 'b': result = 11.0; break;
                case 'c': result = 12.0; break;
                case 'd': result = 13.0; break;
                case 'e': result = 14.0; break;
                case 'f': result = 15.0; break;
            }

            switch (char.ToLower(val1))
            {
                default: result = 0.0; break;
                case '1': result += 4368.0; break;
                case '2': result += 2.0 * 4368.0; break;
                case '3': result += 3.0 * 4368.0; break;
                case '4': result += 4.0 * 4368.0; break;
                case '5': result += 5.0 * 4368.0; break;
                case '6': result += 6.0 * 4368.0; break;
                case '7': result += 7.0 * 4368.0; break;
                case '8': result += 8.0 * 4368.0; break;
                case '9': result += 9.0 * 4368.0; break;
                case 'a': result += 10.0 * 4368.0; break;
                case 'b': result += 11.0 * 4368.0; break;
                case 'c': result += 12.0 * 4368.0; break;
                case 'd': result += 13.0 * 4368.0; break;
                case 'e': result += 14.0 * 4368.0; break;
                case 'f': result += 15.0 * 4368.0; break;
            }

            return result / 65535.0;
        }

        //http://www.google.com/design/spec/style/color.html#color-color-palette
        public static PhongMaterial Red(byte n = 5)
        {
            double[] dif;
            switch (n)
            {
                case 0: dif = HexToColor("#FFEBEE"); break;
                case 1: dif = HexToColor("#FFCDD2"); break;
                case 2: dif = HexToColor("#EF9A9A"); break;
                case 3: dif = HexToColor("#E57373"); break;
                case 4: dif = HexToColor("#EF5350"); break;
                default: dif = HexToColor("#F44336"); break;
                case 6: dif = HexToColor("#E53935"); break;
                case 7: dif = HexToColor("#D32F2F"); break;
                case 8: dif = HexToColor("#C62828"); break;
                case 9: dif = HexToColor("#B71C1C"); break;
                case 11: dif = HexToColor("#FF8A80"); break;
                case 12: dif = HexToColor("#FF5252"); break;
                case 14: dif = HexToColor("#FF1744"); break;
                case 17: dif = HexToColor("#D50000"); break;
            }

            return new PhongMaterial
            {
                Ambient = new double[] { dif[0], dif[1], dif[2] },
                Diffuse = dif
            };
        }

        public static PhongMaterial Pink(byte n = 5)
        {
            double[] dif;
            switch (n)
            {
                case 0: dif = HexToColor("#FCE4EC"); break;
                case 1: dif = HexToColor("#F8BBD0"); break;
                case 2: dif = HexToColor("#F48FB1"); break;
                case 3: dif = HexToColor("#F06292"); break;
                case 4: dif = HexToColor("#EC407A"); break;
                default: dif = HexToColor("#E91E63"); break;
                case 6: dif = HexToColor("#D81B60"); break;
                case 7: dif = HexToColor("#C2185B"); break;
                case 8: dif = HexToColor("#AD1457"); break;
                case 9: dif = HexToColor("#880E4F"); break;
                case 11: dif = HexToColor("#FF80AB"); break;
                case 12: dif = HexToColor("#FF4081"); break;
                case 14: dif = HexToColor("#F50057"); break;
                case 17: dif = HexToColor("#C51162"); break;
            }

            return new PhongMaterial
            {
                Ambient = new double[] { dif[0], dif[1], dif[2] },
                Diffuse = dif
            };
        }

        public static PhongMaterial Purple(byte n = 5)
        {
            double[] dif;
            switch (n)
            {
                case 0: dif = HexToColor("#F3E5F5"); break;
                case 1: dif = HexToColor("#E1BEE7"); break;
                case 2: dif = HexToColor("#CE93D8"); break;
                case 3: dif = HexToColor("#BA68C8"); break;
                case 4: dif = HexToColor("#AB47BC"); break;
                default: dif = HexToColor("#9C27B0"); break;
                case 6: dif = HexToColor("#8E24AA"); break;
                case 7: dif = HexToColor("#7B1FA2"); break;
                case 8: dif = HexToColor("#6A1B9A"); break;
                case 9: dif = HexToColor("#4A148C"); break;
                case 11: dif = HexToColor("#EA80FC"); break;
                case 12: dif = HexToColor("#E040FB"); break;
                case 14: dif = HexToColor("#D500F9"); break;
                case 17: dif = HexToColor("#AA00FF"); break;
            }

            return new PhongMaterial
            {
                Ambient = new double[] { dif[0], dif[1], dif[2] },
                Diffuse = dif
            };
        }

        public static PhongMaterial DeepPurple(byte n = 5)
        {
            double[] dif;
            switch (n)
            {
                case 0: dif = HexToColor("#EDE7F6"); break;
                case 1: dif = HexToColor("#D1C4E9"); break;
                case 2: dif = HexToColor("#B39DDB"); break;
                case 3: dif = HexToColor("#9575CD"); break;
                case 4: dif = HexToColor("#7E57C2"); break;
                default: dif = HexToColor("#673AB7"); break;
                case 6: dif = HexToColor("#5E35B1"); break;
                case 7: dif = HexToColor("#512DA8"); break;
                case 8: dif = HexToColor("#512DA8"); break;
                case 9: dif = HexToColor("#311B92"); break;
                case 11: dif = HexToColor("#B388FF"); break;
                case 12: dif = HexToColor("#7C4DFF"); break;
                case 14: dif = HexToColor("#651FFF"); break;
                case 17: dif = HexToColor("#6200EA"); break;
            }

            return new PhongMaterial
            {
                Ambient = new double[] { dif[0], dif[1], dif[2] },
                Diffuse = dif
            };
        }

        public static PhongMaterial Indigo(byte n = 5)
        {
            double[] dif;
            switch (n)
            {
                case 0: dif = HexToColor("#E8EAF6"); break;
                case 1: dif = HexToColor("#C5CAE9"); break;
                case 2: dif = HexToColor("#9FA8DA"); break;
                case 3: dif = HexToColor("#7986CB"); break;
                case 4: dif = HexToColor("#5C6BC0"); break;
                default: dif = HexToColor("#3F51B5"); break;
                case 6: dif = HexToColor("#3949AB"); break;
                case 7: dif = HexToColor("#303F9F"); break;
                case 8: dif = HexToColor("#283593"); break;
                case 9: dif = HexToColor("#1A237E"); break;
                case 11: dif = HexToColor("#8C9EFF"); break;
                case 12: dif = HexToColor("#536DFE"); break;
                case 14: dif = HexToColor("#3D5AFE"); break;
                case 17: dif = HexToColor("#304FFE"); break;
            }

            return new PhongMaterial
            {
                Ambient = new double[] { dif[0], dif[1], dif[2] },
                Diffuse = dif
            };
        }

        public static PhongMaterial Blue(byte n = 5)
        {
            double[] dif;
            switch (n)
            {
                case 0: dif = HexToColor("#E3F2FD"); break;
                case 1: dif = HexToColor("#BBDEFB"); break;
                case 2: dif = HexToColor("#90CAF9"); break;
                case 3: dif = HexToColor("#64B5F6"); break;
                case 4: dif = HexToColor("#42A5F5"); break;
                default: dif = HexToColor("#2196F3"); break;
                case 6: dif = HexToColor("#1E88E5"); break;
                case 7: dif = HexToColor("#1976D2"); break;
                case 8: dif = HexToColor("#1565C0"); break;
                case 9: dif = HexToColor("#0D47A1"); break;
                case 11: dif = HexToColor("#82B1FF"); break;
                case 12: dif = HexToColor("#448AFF"); break;
                case 14: dif = HexToColor("#2979FF"); break;
                case 17: dif = HexToColor("#2962FF"); break;
            }

            return new PhongMaterial
            {
                Ambient = new double[] { dif[0], dif[1], dif[2] },
                Diffuse = dif
            };
        }

        public static PhongMaterial LightBlue(byte n = 5)
        {
            double[] dif;
            switch (n)
            {
                case 0: dif = HexToColor("#E1F5FE"); break;
                case 1: dif = HexToColor("#B3E5FC"); break;
                case 2: dif = HexToColor("#81D4FA"); break;
                case 3: dif = HexToColor("#4FC3F7"); break;
                case 4: dif = HexToColor("#29B6F6"); break;
                default: dif = HexToColor("#03A9F4"); break;
                case 6: dif = HexToColor("#039BE5"); break;
                case 7: dif = HexToColor("#0288D1"); break;
                case 8: dif = HexToColor("#0277BD"); break;
                case 9: dif = HexToColor("#01579B"); break;
                case 11: dif = HexToColor("#80D8FF"); break;
                case 12: dif = HexToColor("#40C4FF"); break;
                case 14: dif = HexToColor("#00B0FF"); break;
                case 17: dif = HexToColor("#0091EA"); break;
            }

            return new PhongMaterial
            {
                Ambient = new double[] { dif[0], dif[1], dif[2] },
                Diffuse = dif
            };
        }

        public static PhongMaterial Cyan(byte n = 5)
        {
            double[] dif;
            switch (n)
            {
                case 0: dif = HexToColor("#E0F7FA"); break;
                case 1: dif = HexToColor("#B2EBF2"); break;
                case 2: dif = HexToColor("#80DEEA"); break;
                case 3: dif = HexToColor("#4DD0E1"); break;
                case 4: dif = HexToColor("#26C6DA"); break;
                default: dif = HexToColor("#00BCD4"); break;
                case 6: dif = HexToColor("#00ACC1"); break;
                case 7: dif = HexToColor("#0097A7"); break;
                case 8: dif = HexToColor("#00838F"); break;
                case 9: dif = HexToColor("#006064"); break;
                case 11: dif = HexToColor("#84FFFF"); break;
                case 12: dif = HexToColor("#18FFFF"); break;
                case 14: dif = HexToColor("#00E5FF"); break;
                case 17: dif = HexToColor("#00B8D4"); break;
            }

            return new PhongMaterial
            {
                Ambient = new double[] { dif[0], dif[1], dif[2] },
                Diffuse = dif
            };
        }

        public static PhongMaterial Teal(byte n = 5)
        {
            double[] dif;
            switch (n)
            {
                case 0: dif = HexToColor("#E0F2F1"); break;
                case 1: dif = HexToColor("#B2DFDB"); break;
                case 2: dif = HexToColor("#80CBC4"); break;
                case 3: dif = HexToColor("#4DB6AC"); break;
                case 4: dif = HexToColor("#26A69A"); break;
                default: dif = HexToColor("#009688"); break;
                case 6: dif = HexToColor("#00897B"); break;
                case 7: dif = HexToColor("#00796B"); break;
                case 8: dif = HexToColor("#00695C"); break;
                case 9: dif = HexToColor("#004D40"); break;
                case 11: dif = HexToColor("#A7FFEB"); break;
                case 12: dif = HexToColor("#64FFDA"); break;
                case 14: dif = HexToColor("#1DE9B6"); break;
                case 17: dif = HexToColor("#00BFA5"); break;
            }

            return new PhongMaterial
            {
                Ambient = new double[] { dif[0], dif[1], dif[2] },
                Diffuse = dif
            };
        }

        public static PhongMaterial Green(byte n = 5)
        {
            double[] dif;
            switch (n)
            {
                case 0: dif = HexToColor("#E8F5E9"); break;
                case 1: dif = HexToColor("#C8E6C9"); break;
                case 2: dif = HexToColor("#A5D6A7"); break;
                case 3: dif = HexToColor("#81C784"); break;
                case 4: dif = HexToColor("#66BB6A"); break;
                default: dif = HexToColor("#4CAF50"); break;
                case 6: dif = HexToColor("#43A047"); break;
                case 7: dif = HexToColor("#388E3C"); break;
                case 8: dif = HexToColor("#2E7D32"); break;
                case 9: dif = HexToColor("#1B5E20"); break;
                case 11: dif = HexToColor("#B9F6CA"); break;
                case 12: dif = HexToColor("#69F0AE"); break;
                case 14: dif = HexToColor("#00E676"); break;
                case 17: dif = HexToColor("#00C853"); break;
            }

            return new PhongMaterial
            {
                Ambient = new double[] { dif[0], dif[1], dif[2] },
                Diffuse = dif
            };
        }

        public static PhongMaterial LightGreen(byte n = 5)
        {
            double[] dif;
            switch (n)
            {
                case 0: dif = HexToColor("#F1F8E9"); break;
                case 1: dif = HexToColor("#DCEDC8"); break;
                case 2: dif = HexToColor("#C5E1A5"); break;
                case 3: dif = HexToColor("#AED581"); break;
                case 4: dif = HexToColor("#9CCC65"); break;
                default: dif = HexToColor("#8BC34A"); break;
                case 6: dif = HexToColor("#7CB342"); break;
                case 7: dif = HexToColor("#689F38"); break;
                case 8: dif = HexToColor("#558B2F"); break;
                case 9: dif = HexToColor("#33691E"); break;
                case 11: dif = HexToColor("#CCFF90"); break;
                case 12: dif = HexToColor("#B2FF59"); break;
                case 14: dif = HexToColor("#76FF03"); break;
                case 17: dif = HexToColor("#64DD17"); break;
            }

            return new PhongMaterial
            {
                Ambient = new double[] { dif[0], dif[1], dif[2] },
                Diffuse = dif
            };
        }

        public static PhongMaterial Lime(byte n = 5)
        {
            double[] dif;
            switch (n)
            {
                case 0: dif = HexToColor("#F9FBE7"); break;
                case 1: dif = HexToColor("#F0F4C3"); break;
                case 2: dif = HexToColor("#E6EE9C"); break;
                case 3: dif = HexToColor("#DCE775"); break;
                case 4: dif = HexToColor("#D4E157"); break;
                default: dif = HexToColor("#CDDC39"); break;
                case 6: dif = HexToColor("#C0CA33"); break;
                case 7: dif = HexToColor("#AFB42B"); break;
                case 8: dif = HexToColor("#9E9D24"); break;
                case 9: dif = HexToColor("#827717"); break;
                case 11: dif = HexToColor("#F4FF81"); break;
                case 12: dif = HexToColor("#EEFF41"); break;
                case 14: dif = HexToColor("#C6FF00"); break;
                case 17: dif = HexToColor("#AEEA00"); break;
            }

            return new PhongMaterial
            {
                Ambient = new double[] { dif[0], dif[1], dif[2] },
                Diffuse = dif
            };
        }

        public static PhongMaterial Yellow(byte n = 5)
        {
            double[] dif;
            switch (n)
            {
                case 0: dif = HexToColor("#FFFDE7"); break;
                case 1: dif = HexToColor("#FFF9C4"); break;
                case 2: dif = HexToColor("#FFF59D"); break;
                case 3: dif = HexToColor("#FFF176"); break;
                case 4: dif = HexToColor("#FFEE58"); break;
                default: dif = HexToColor("#FFEB3B"); break;
                case 6: dif = HexToColor("#FDD835"); break;
                case 7: dif = HexToColor("#FBC02D"); break;
                case 8: dif = HexToColor("#F9A825"); break;
                case 9: dif = HexToColor("#F57F17"); break;
                case 11: dif = HexToColor("#FFFF8D"); break;
                case 12: dif = HexToColor("#FFFF00"); break;
                case 14: dif = HexToColor("#FFEA00"); break;
                case 17: dif = HexToColor("#FFD600"); break;
            }

            return new PhongMaterial
            {
                Ambient = new double[] { dif[0], dif[1], dif[2] },
                Diffuse = dif
            };
        }

        public static PhongMaterial Amber(byte n = 5)
        {
            double[] dif;
            switch (n)
            {
                case 0: dif = HexToColor("#FFF8E1"); break;
                case 1: dif = HexToColor("#FFECB3"); break;
                case 2: dif = HexToColor("#FFE082"); break;
                case 3: dif = HexToColor("#FFD54F"); break;
                case 4: dif = HexToColor("#FFCA28"); break;
                default: dif = HexToColor("#FFC107"); break;
                case 6: dif = HexToColor("#FFB300"); break;
                case 7: dif = HexToColor("#FFA000"); break;
                case 8: dif = HexToColor("#FF8F00"); break;
                case 9: dif = HexToColor("#FF6F00"); break;
                case 11: dif = HexToColor("#FFE57F"); break;
                case 12: dif = HexToColor("#FFD740"); break;
                case 14: dif = HexToColor("#FFC400"); break;
                case 17: dif = HexToColor("#FFAB00"); break;
            }

            return new PhongMaterial
            {
                Ambient = new double[] { dif[0], dif[1], dif[2] },
                Diffuse = dif
            };
        }

        public static PhongMaterial Orange(byte n = 5)
        {
            double[] dif;
            switch (n)
            {
                case 0: dif = HexToColor("#FFF3E0"); break;
                case 1: dif = HexToColor("#FFE0B2"); break;
                case 2: dif = HexToColor("#FFCC80"); break;
                case 3: dif = HexToColor("#FFB74D"); break;
                case 4: dif = HexToColor("#FFA726"); break;
                default: dif = HexToColor("#FF9800"); break;
                case 6: dif = HexToColor("#FB8C00"); break;
                case 7: dif = HexToColor("#F57C00"); break;
                case 8: dif = HexToColor("#EF6C00"); break;
                case 9: dif = HexToColor("#E65100"); break;
                case 11: dif = HexToColor("#FFD180"); break;
                case 12: dif = HexToColor("#FFAB40"); break;
                case 14: dif = HexToColor("#FF9100"); break;
                case 17: dif = HexToColor("#FF6D00"); break;
            }

            return new PhongMaterial
            {
                Ambient = new double[] { dif[0], dif[1], dif[2] },
                Diffuse = dif
            };
        }

        public static PhongMaterial DeepOrange(byte n = 5)
        {
            double[] dif;
            switch (n)
            {
                case 0: dif = HexToColor("#FBE9E7"); break;
                case 1: dif = HexToColor("#FFCCBC"); break;
                case 2: dif = HexToColor("#FFAB91"); break;
                case 3: dif = HexToColor("#FF8A65"); break;
                case 4: dif = HexToColor("#FF7043"); break;
                default: dif = HexToColor("#FF5722"); break;
                case 6: dif = HexToColor("#F4511E"); break;
                case 7: dif = HexToColor("#E64A19"); break;
                case 8: dif = HexToColor("#D84315"); break;
                case 9: dif = HexToColor("#BF360C"); break;
                case 11: dif = HexToColor("#FF9E80"); break;
                case 12: dif = HexToColor("#FF6E40"); break;
                case 14: dif = HexToColor("#FF3D00"); break;
                case 17: dif = HexToColor("#DD2C00"); break;
            }

            return new PhongMaterial
            {
                Ambient = new double[] { dif[0], dif[1], dif[2] },
                Diffuse = dif
            };
        }

        public static PhongMaterial Brown(byte n = 5)
        {
            double[] dif;
            switch (n)
            {
                case 0: dif = HexToColor("#EFEBE9"); break;
                case 1: dif = HexToColor("#D7CCC8"); break;
                case 2: dif = HexToColor("#BCAAA4"); break;
                case 3: dif = HexToColor("#A1887F"); break;
                case 4: dif = HexToColor("#8D6E63"); break;
                default: dif = HexToColor("#FF5722"); break;
                case 6: dif = HexToColor("#6D4C41"); break;
                case 7: dif = HexToColor("#5D4037"); break;
                case 8: dif = HexToColor("#4E342E"); break;
                case 9: dif = HexToColor("#3E2723"); break;
                case 11: dif = HexToColor("#FF9E80"); break;
                case 12: dif = HexToColor("#FF6E40"); break;
                case 14: dif = HexToColor("#FF3D00"); break;
                case 17: dif = HexToColor("#DD2C00"); break;
            }

            return new PhongMaterial
            {
                Ambient = new double[] { dif[0], dif[1], dif[2] },
                Diffuse = dif
            };
        }

        public static PhongMaterial Grey(byte n = 5)
        {
            double[] dif;
            switch (n)
            {
                case 0: dif = HexToColor("#FAFAFA"); break;
                case 1: dif = HexToColor("#F5F5F5"); break;
                case 2: dif = HexToColor("#EEEEEE"); break;
                case 3: dif = HexToColor("#E0E0E0"); break;
                case 4: dif = HexToColor("#BDBDBD"); break;
                default: dif = HexToColor("#9E9E9E"); break;
                case 6: dif = HexToColor("#757575"); break;
                case 7: dif = HexToColor("#616161"); break;
                case 8: dif = HexToColor("#424242"); break;
                case 9: dif = HexToColor("#212121"); break;
            }

            return new PhongMaterial
            {
                Ambient = new double[] { dif[0], dif[1], dif[2] },
                Diffuse = dif
            };
        }

        public static PhongMaterial BlueGrey(byte n = 5)
        {
            double[] dif;
            switch (n)
            {
                case 0: dif = HexToColor("#ECEFF1"); break;
                case 1: dif = HexToColor("#CFD8DC"); break;
                case 2: dif = HexToColor("#B0BEC5"); break;
                case 3: dif = HexToColor("#90A4AE"); break;
                case 4: dif = HexToColor("#78909C"); break;
                default: dif = HexToColor("#607D8B"); break;
                case 6: dif = HexToColor("#546E7A"); break;
                case 7: dif = HexToColor("#455A64"); break;
                case 8: dif = HexToColor("#37474F"); break;
                case 9: dif = HexToColor("#263238"); break;
            }

            return new PhongMaterial
            {
                Ambient = new double[] { dif[0], dif[1], dif[2] },
                Diffuse = dif
            };
        }

        public static PhongMaterial White
        {
            get
            {
                return new PhongMaterial
                {
                    Ambient = new double[] { 1.0, 1.0, 1.0 },
                    Diffuse = new double[] { 1.0, 1.0, 1.0 }
                };
            }
        }

        public static PhongMaterial Default
        {
            get
            {
                return new PhongMaterial();
            }
        }

        public enum Shades { Any, Red, Pink, Purple, DeepPurple, Indigo, Blue, LightBlue, Cyan, Teal, Green, LightGreen, Lime, Yellow, Amber, Orange, DeepOrange, Brown, Grey, BlueGrey };

        protected static Random mRnd = new Random();

        public static PhongMaterial Random(Shades baseColor, Random rnd = null)
        {
            if (rnd == null)
                rnd = mRnd;
            //TODO add diffuse only materials
            //TODO add specular choice white/same_color/complementary_color
            PhongMaterial result;
            switch (baseColor)
            {
                case Shades.Red:
                    result = Red((byte)rnd.Next(0, 10)); break;

                case Shades.Pink:
                    result = Pink((byte)rnd.Next(0, 10)); break;

                case Shades.Purple:
                    result = Purple((byte)rnd.Next(0, 10)); break;

                case Shades.DeepPurple:
                    result = DeepPurple((byte)rnd.Next(0, 10)); break;

                case Shades.Indigo:
                    result = Indigo((byte)rnd.Next(0, 10)); break;

                case Shades.Blue:
                    result = Blue((byte)rnd.Next(0, 10)); break;

                case Shades.LightBlue:
                    result = LightBlue((byte)rnd.Next(0, 10)); break;

                case Shades.Cyan:
                    result = Cyan((byte)rnd.Next(0, 10)); break;

                case Shades.Teal:
                    result = Teal((byte)rnd.Next(0, 10)); break;

                case Shades.Green:
                    result = Green((byte)rnd.Next(0, 10)); break;

                case Shades.LightGreen:
                    result = LightGreen((byte)rnd.Next(0, 10)); break;

                case Shades.Lime:
                    result = Lime((byte)rnd.Next(0, 10)); break;

                case Shades.Yellow:
                    result = Yellow((byte)rnd.Next(0, 10)); break;

                case Shades.Amber:
                    result = Amber((byte)rnd.Next(0, 10)); break;

                case Shades.Orange:
                    result = Orange((byte)rnd.Next(0, 10)); break;

                case Shades.DeepOrange:
                    result = DeepOrange((byte)rnd.Next(0, 10)); break;

                case Shades.Brown:
                    result = Brown((byte)rnd.Next(0, 10)); break;

                case Shades.Grey:
                    result = Grey((byte)rnd.Next(0, 10)); break;

                case Shades.BlueGrey:
                    result = BlueGrey((byte)rnd.Next(0, 10)); break;

                default:
                    result = new PhongMaterial
                    {
                        Ambient = new double[] { rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble() },
                        Diffuse = new double[] { rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble() },
                        Specular = new double[] { rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble() },
                    };
                    break;
            }

            result.Shininess = rnd.NextDouble() * 64.0;

            return result;
        }

        public HelixToolkit.SharpDX.Wpf.Material ToSharpDX
        {
            get
            {
                //HelixToolkit.SharpDX.Wpf.Material result = new HelixToolkit.SharpDX.Wpf.PhongMaterial();

                if (Specular == null)
                    return new HelixToolkit.SharpDX.Wpf.PhongMaterial
                        {
                            Name = "MMD",
                            AmbientColor = HelixToolkit.SharpDX.Wpf.PhongMaterials.ToColor(Ambient[0], Ambient[1], Ambient[2]),
                            DiffuseColor = HelixToolkit.SharpDX.Wpf.PhongMaterials.ToColor(Diffuse[0], Diffuse[1], Diffuse[2])                           
                        }.Clone();
                else
                    return new HelixToolkit.SharpDX.Wpf.PhongMaterial
                    {
                        Name = "MMS",
                        AmbientColor = HelixToolkit.SharpDX.Wpf.PhongMaterials.ToColor(Ambient[0], Ambient[1], Ambient[2]),
                        DiffuseColor = HelixToolkit.SharpDX.Wpf.PhongMaterials.ToColor(Diffuse[0], Diffuse[1], Diffuse[2]),
                        SpecularColor = HelixToolkit.SharpDX.Wpf.PhongMaterials.ToColor(Specular[0], Specular[1], Specular[2]),
                        SpecularShininess = (float)Shininess
                    }.Clone();
            }
        }
    }
}