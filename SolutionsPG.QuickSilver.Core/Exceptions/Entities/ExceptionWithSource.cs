using System;
using System.Runtime.Serialization;

namespace SolutionsPG.QuickSilver.Core.Experimental.Exceptions.Entities
{
    [Serializable]
    public class ExceptionWithSource<T> : Exception
    {
        public T ExceptionSource { get; }

        public ExceptionWithSource(T exceptionSource) : base()
        {
            this.ExceptionSource = exceptionSource;
        }

        public ExceptionWithSource(string message, T exceptionSource) : base(message)
        {
            this.ExceptionSource = exceptionSource;
        }

        public ExceptionWithSource(string message, Exception innerException, T exceptionSource) : base(message, innerException)
        {
            this.ExceptionSource = exceptionSource;
        }

        protected ExceptionWithSource(SerializationInfo info, StreamingContext context, T exceptionSource) : base(info, context)
        {
            this.ExceptionSource = exceptionSource;
        }
    }
}