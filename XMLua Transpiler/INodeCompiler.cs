using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XMLua_Compiler
{
    interface INodeCompiler
    {
        string Compile(XmlNode node, int indent = 0);
    }
}
