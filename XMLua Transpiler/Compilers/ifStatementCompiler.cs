using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XMLua_Compiler.Compilers
{
    class IfStatementCompiler : BodyCompiler
    {
        public override string Compile(XmlNode node, int indent = 0)
        {
            string indentString = new string('\t', indent);
            return base.Compile(node, indent) + indentString + "end\n";
        }
    }
}
