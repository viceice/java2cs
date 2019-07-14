using Antlr4.Runtime;
using NLog;

namespace Java2Cs.Java
{
    internal class LexerErrorHandler : IAntlrErrorListener<int>
    {
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();

        public static IAntlrErrorListener<int> Instance { get; private set; }

        static LexerErrorHandler() => Instance = new LexerErrorHandler();

        private LexerErrorHandler() { }

        public void SyntaxError(IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg,
            RecognitionException e)
        {
            if (e.Context == null || !Log.IsTraceEnabled)
                throw new SyntaxException(msg, line, charPositionInLine, e);

            var ctx = e.Context;
            while (ctx.Parent != null)
                ctx = ctx.Parent;

            Log.Trace("Current tree: {0}", ctx.ToStringTree(recognizer.RuleNames));

            throw new SyntaxException(msg, line, charPositionInLine, e);
        }
    }
}