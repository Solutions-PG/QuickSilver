using System;
using SolutionsPG.QuickSilver.Core.Experimental.Exceptions.Entities;
using SolutionsPG.QuickSilver.Core.Experimental.Exceptions.Interfaces;

namespace SolutionsPG.QuickSilver.Core.Experimental.Exceptions
{
    public static partial class ThrowExtensions
    {
        #region | Public methods |

        public static void Throw<T>(this T obj, string message)
        {
            obj.Throw_(CreateFuncBuildMessageSummary<T>(message), (Func<string, T, Exception>)null);
        }

        public static void Throw<T>(this T obj, Action<IExceptionMessageBuilder, T> buildMessage)
        {
            obj.Throw_(buildMessage, (Func<string, T, Exception>)null);
        }

        public static void Throw<T>(this T obj, Func<string, T, Exception> createException)
        {
            obj.Throw_((Action<IExceptionMessageBuilder, T>)null, createException);
        }

        public static void Throw<T>(this T obj, string message, Func<string, T, Exception> createException)
        {
            obj.Throw_(message, createException);
        }

        public static void Throw<T>(this T obj, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            obj.Throw_(buildMessage, createException);
        }

        #endregion //Public methods

        #region | Private methods |

        private static void Throw_<T>(this T obj, string message, Func<string, T, Exception> createException)
        {
            obj.Throw_(CreateFuncBuildMessageSummary<T>(message), createException);
        }

        private static void Throw_<T>(this T obj, Action<IExceptionMessageBuilder, T> buildMessage, Func<string, T, Exception> createException)
        {
            var messageBuilder = new ExceptionMessageBuilder();
            buildMessage.DoBuildMessage(messageBuilder, obj);
            messageBuilder.AddExceptionSource(obj);
            throw createException.DoCreateException(messageBuilder, obj);
        }

        private static void DoBuildMessage<T>(this Action<IExceptionMessageBuilder, T> buildMessage, ExceptionMessageBuilder messageBuilder, T obj)
        {
            try
            {
                buildMessage?.Invoke(messageBuilder, obj);
            }
            catch (Exception e)
            {
                throw e.CreateInternalException_("Message creation failed", obj, messageBuilder);
            }
        }

        private static Exception DoCreateException<T>(this Func<string, T, Exception> createException, ExceptionMessageBuilder messageBuilder, T obj)
        {
            try
            {
                return (createException ?? CreateExceptionDefault)(messageBuilder.Build(), obj);
            }
            catch (Exception e)
            {
                throw e.CreateInternalException_("Exception creation failed", obj, messageBuilder);
            }
        }

        private static Exception CreateExceptionDefault<T>(string message, T obj)
        {
            return new ExceptionWithSource<T>(message, obj);
        }

        private static Exception CreateInternalException_<T>(this Exception innerException, string summary, T obj)
        {
            return innerException.CreateInternalException_(summary, obj, new ExceptionMessageBuilder());
        }

        private static Exception CreateInternalException_<T>(this Exception innerException, string summary, T obj, ExceptionMessageBuilder messageBuilder)
        {
            messageBuilder.AddSummary(summary);
            messageBuilder.AddExceptionSource(obj);
            return new InternalThrowException<T>(messageBuilder.Build(), innerException, obj);
        }

        private static Action<IExceptionMessageBuilder, T> CreateFuncBuildMessageSummary<T>(this string summary)
        {
            void BuildMessage(IExceptionMessageBuilder mb, T _) => mb.AddSummary(summary);
            return BuildMessage;
        }

        #endregion //Private methods
    }
}
