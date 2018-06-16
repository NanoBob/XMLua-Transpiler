using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using XMLua_Compiler.Compilers;

namespace XMLua_Compiler
{
    class CompilerFactory
    {
        public static INodeCompiler Create(XmlNode node)
        {
            switch (node.Name)
            {
                case "script":
                    return new ScriptCompiler();
                case "variable":
                    return new VariableCompiler();
                case "function":
                    return new FunctionCompiler();
                case "parameters":
                    return new ParametersCompiler();
                case "parameter":
                    return new ParameterCompiler();
                case "argument":
                    return new ArgumentCompiler();
                case "body":
                    return new BodyCompiler();
                case "call":
                    return new CallCompiler();
                case "if-statement":
                    return new IfStatementCompiler();
                case "if":
                    return new IfCompiler();
                case "elseif":
                    return new ElseifCompiler();
                case "else":
                    return new ElseCompiler();
                case "checks":
                    return new ChecksCompiler();
                case "check":
                    return new CheckCompiler();
                case "for-loop":
                    return new ForLoopCompiler();
                case "pairs-loop":
                    return new PairsLoopCompiler();
                case "ipairs-loop":
                    return new IpairsLoopCompiler();
                case "return":
                    return new ReturnCompiler();
            }
            Console.WriteLine("No compiler found for {0}", node.Name);
            return null;
        }
    }
}
