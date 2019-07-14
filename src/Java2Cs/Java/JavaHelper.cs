using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using System.IO;

namespace Java2Cs.Java
{
    class JavaHelper
    {
        private static JavaParser InitParser(string text)
        {
            var antlrInput = new AntlrInputStream(text);
            var lexer = new JavaLexer(antlrInput);
            lexer.AddErrorListener(LexerErrorHandler.Instance);
            var tokens = new CommonTokenStream(lexer);

            return new JavaParser(tokens)
            {
                Interpreter = { PredictionMode = PredictionMode.Sll },
                ErrorHandler = new BailErrorStrategy()
            };
        }

        public static JavaParser.CompilationUnitContext Parse(string path)
        {
            var p = InitParser(File.ReadAllText(path));

            return p.compilationUnit();
        }

        public static string Generate(JavaParser.CompilationUnitContext tree) => CodeGenerator.Run(tree);
    }
}
