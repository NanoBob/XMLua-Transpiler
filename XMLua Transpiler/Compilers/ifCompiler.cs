using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XMLua_Compiler.Compilers
{
    class IfCompiler : INodeCompiler
    {
        public string Compile(XmlNode node, int indent = 0)
        {
            string indentString = new string('\t', indent);
            XmlNode checks = node.SelectSingleNode("checks");
            INodeCompiler compiler = CompilerFactory.Create(checks);
            string result = indentString + "if (" + compiler.Compile(checks) + ") then\n";

            XmlNode body = node.SelectSingleNode("body");
            compiler = CompilerFactory.Create(body);
            result += compiler.Compile(body, indent + 1);

            return result;
        }
    }
}
