using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XMLua_Compiler.Compilers
{
    class FunctionCompiler : INodeCompiler
    {
        public string Compile(XmlNode node, int indent = 0)
        {
            string indentString = new string('\t', indent);
            string result = string.Format("{0}function {1}(", indentString, node.Attributes["name"].InnerText);
            result += (new ParametersCompiler()).Compile(node.SelectSingleNode("parameters"));
            result += ")\n";
            result += (new BodyCompiler()).Compile(node.SelectSingleNode("body"), indent + 1);
            result += indentString + "\nend\n";
            return result;
        }
    }
}
