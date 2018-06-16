using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XMLua_Compiler.Compilers
{
    class ElseCompiler : INodeCompiler
    {
        public string Compile(XmlNode node, int indent = 0)
        {
            string indentString = new string('\t', indent);
            string result = indentString + "else\n";

            XmlNode body = node.SelectSingleNode("body");
            INodeCompiler compiler = CompilerFactory.Create(body);
            result += compiler.Compile(body, indent + 1);

            return result;
        }
    }
}
