using System;
using System.Runtime.Serialization;
using SolutionsPG.QuickSilver.Core.Experimental.Exceptions.Entities;

namespace SolutionsPG.QuickSilver.Core.Experimental.Exceptions
{
    internal class InternalThrowException<T> : ExceptionWithSource<T>
    {
        public InternalThrowException(T exceptionSource) : base(exceptionSource)
        {
        }

        public InternalThrowException(string message, T exceptionSource) : base(message, exceptionSource)
        {
        }

        public InternalThrowException(string message, Exception innerException, T exceptionSource) : base(message, innerException, exceptionSource)
        {
        }

        protected InternalThrowException(SerializationInfo info, StreamingContext context, T exceptionSource) : base(info, context, exceptionSource)
        {
        }
    }
}