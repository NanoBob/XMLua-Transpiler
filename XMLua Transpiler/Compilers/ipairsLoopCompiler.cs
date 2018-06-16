using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XMLua_Compiler.Compilers
{
    class IpairsLoopCompiler : INodeCompiler
    {
        public string Compile(XmlNode node, int indent = 0)
        {
            string result = "";
            string indentString = new string('\t', indent);
            result += String.Format("{0}for {1},{2} in ipairs({3}) do\n", 
                indentString,
                node.Attributes["key"].InnerText,
                node.Attributes["value"].InnerText,
                node.Attributes["variable"].InnerText
            );

            foreach(XmlNode child in node.ChildNodes)
            {
                INodeCompiler compiler = CompilerFactory.Create(child);
                result += compiler.Compile(child, indent + 1);
            }

            result += indentString + "end\n";
            return result;
        }
    }
}
