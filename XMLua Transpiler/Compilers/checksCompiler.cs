using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XMLua_Compiler.Compilers
{
    class ChecksCompiler : INodeCompiler
    {
        public string Compile(XmlNode node, int indent = 0)
        {
            string result = "";
            foreach (XmlNode child in node.ChildNodes)
            {
                INodeCompiler compiler = CompilerFactory.Create(child);
                if (result != "")
                {
                    result += " " + child.Attributes["operator"].InnerText + " ";
                }
                result += compiler.Compile(child);
            }
            return result;
        }
    }
}
