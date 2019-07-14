using System;
using System.Runtime.Serialization;
using Antlr4.Runtime;

namespace Java2Cs.Java
{
    internal class SyntaxException : Exception
    {
        private string msg;
        private int line;
        private int charPositionInLine;
        private RecognitionException e;

        public SyntaxException()
        {
        }

        public SyntaxException(string message) : base(message)
        {
        }

        public SyntaxException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public SyntaxException(string msg, int line, int charPositionInLine, RecognitionException e)
        {
            this.msg = msg;
            this.line = line;
            this.charPositionInLine = charPositionInLine;
            this.e = e;
        }

        protected SyntaxException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}