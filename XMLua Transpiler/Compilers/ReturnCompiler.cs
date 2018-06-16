using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XMLua_Compiler.Compilers
{
    class ReturnCompiler : INodeCompiler
    {
        public string Compile(XmlNode node, int indent = 0)
        {
            string indentString = new string('\t', indent);
            return String.Format("{0}return {1}\n", indentString, node.Attributes["value"].InnerText);
        }
    }
}
