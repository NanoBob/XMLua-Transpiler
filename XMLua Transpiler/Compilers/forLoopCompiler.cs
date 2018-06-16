using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XMLua_Compiler.Compilers
{
    class ForLoopCompiler : INodeCompiler
    {
        public string Compile(XmlNode node, int indent = 0)
        {
            string result = "";
            string indentString = new string('\t', indent);
            result += String.Format("{0}for {1} = {2}, {3}, {4}  do\n", 
                indentString,
                node.Attributes["variable"].InnerText,
                node.Attributes["start"].InnerText,
                node.Attributes["end"].InnerText,
                (node.Attributes["increments"] != null) ? node.Attributes["increments"].InnerText : "1"
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
