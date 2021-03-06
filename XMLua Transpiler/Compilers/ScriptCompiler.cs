﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace XMLua_Compiler.Compilers
{
    class ScriptCompiler : INodeCompiler
    {
        public virtual string Compile(XmlNode node, int indent = 0)
        {
            string result = "";
            foreach (XmlNode child in node.ChildNodes)
            {
                INodeCompiler compiler = CompilerFactory.Create(child);
                result += compiler.Compile(child, indent);
            }
            return result;
        }
    }
}
