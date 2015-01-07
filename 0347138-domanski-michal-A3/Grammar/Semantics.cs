//Grammar framework by Martin Ilcik. In case you are interested in PR/DA in this field, contact ilcik@cg.tuwien.ac.at
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCGA.Grammar
{
    /// <summary>
    /// Holds the string symbol and paramenters of shapes
    /// </summary>
    public struct Semantics
    {
        #region Data
        /// <summary>
        /// String symbol to steer the derivation process
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Parameters dictionary
        /// </summary>
        Dictionary<string, double> mParameter;

        #endregion
        /// <summary>
        /// Paramters dictionary (read only)
        /// </summary>
        public IDictionary<string, double> Parameters
        {
            get
            {
                return mParameter;
            }
        }   

        /// <summary>
        /// Creates a semantics with no parameters
        /// </summary>
        /// <param name="name">Symbol string</param>
        public Semantics(string name)
        {
            Name = name;
            mParameter = new Dictionary<string, double>();
        }

        /// <summary>
        /// Creates a semantics with parameters
        /// </summary>
        /// <param name="name">Symbol string</param>
        /// <param name="dict">Dictionary of numeric parameters</param>
        public Semantics(string name, IDictionary<string, double> dict)
        {
            Name = name;
            mParameter = new Dictionary<string, double>(dict);
        }

        /// <summary>
        /// String of parameters for debug output
        /// </summary>
        public string ParametersString
        {
            get
            {
                if (mParameter.Count == 0)
                    return "no parameters";
                else
                {
                    var sb = new StringBuilder();
                    foreach (var item in mParameter)
                    {
                        sb.Append(String.Format("{0}: {1};", item.Key, item.Value.ToString()));
                    }
                    return sb.ToString();
                }
            }
        }
    }
}
