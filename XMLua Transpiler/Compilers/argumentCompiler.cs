using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XMLua_Compiler.Compilers
{
    class ArgumentCompiler : INodeCompiler
    {
        public string Compile(XmlNode node, int indent = 0)
        {
            string indentString = new string('\t', indent);
            var children = node.ChildNodes;
            if (children.Count > 0 && children[0].NodeType != XmlNodeType.Text)
            {
                string result = "\n";

                foreach(XmlNode child in children)
                {
                    INodeCompiler compiler = CompilerFactory.Create(child);
                    result += compiler.Compile(child,indent + 1);
                }

                return result;
            } else
            {
                return indentString + node.InnerText;
            }
        }
    }
}
