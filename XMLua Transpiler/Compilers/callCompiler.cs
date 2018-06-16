using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XMLua_Compiler.Compilers
{
    class CallCompiler : INodeCompiler
    {
        public string Compile(XmlNode node, int indent = 0)
        {
            string indentString = new string('\t', indent);
            string result = String.Format("{0}{1}(", indentString, node.Attributes["function"].InnerText);

            foreach(XmlNode child in node.ChildNodes)
            {
                INodeCompiler compiler = CompilerFactory.Create(child);
                result += compiler.Compile(child) + ", ";
            }

            if (node.ChildNodes.Count > 0)
            {
                return Utils.ReplaceLastOccurrence(result, ", ", "") + ")\n";
            }
            return result + ")\n";
        }
    }
}
