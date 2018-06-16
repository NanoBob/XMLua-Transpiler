using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XMLua_Compiler.Compilers
{
    class CheckCompiler : INodeCompiler
    {
        public string Compile(XmlNode node, int indent = 0)
        {
            return string.Format("{0} {1} {2}", node.Attributes["lefthand"].InnerText, node.Attributes["comparator"].InnerText, node.Attributes["righthand"].InnerText);
        }
    }
}
