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
            return indentString + node.InnerText;
        }
    }
}
