using System;
using System.Collections.Generic;
using System.Linq;

using SolutionsPG.QuickSilver.Core.Experimental.Exceptions.Interfaces;

namespace SolutionsPG.QuickSilver.Core.Experimental.Exceptions.Entities
{
    public class ExceptionMessageBuilderFacade : IExceptionMessageBuilderFacade
    {

        #region | Variables |

        private readonly IExceptionMessageBuilder _messageBuilder;

        public ExceptionMessageBuilderFacade(IExceptionMessageBuilder messageBuilder)
        {
            _messageBuilder = messageBuilder;
        }

        #endregion //Variables

        #region | Public methods |

        public IExceptionMessageBuilderFacade AddSummary(string summary)
        {
            _messageBuilder.AddSummary(summary);
            return this;
        }

        public IExceptionMessageBuilderFacade AddParameter<T>(string parameterName, T parameter)
        {
            _messageBuilder.AddParameter(parameterName, parameter);
            return this;
        }

        public IExceptionMessageBuilderFacade AddMoreInfo(string title, string info)
        {
            _messageBuilder.AddMoreInfo(title, info);
            return this;
        }

        public IExceptionMessageBuilderFacade AddMoreInfo(string title, IEnumerable<string> infos)
        {
            _messageBuilder.AddMoreInfo(title, infos);
            return this;
        }

        public IExceptionMessageBuilderFacade AddMoreInfo<T>(string title, IEnumerable<T> infos, Func<T, string> infoToString)
        {
            _messageBuilder.AddMoreInfo(title, infos, infoToString);
            return this;
        }

        #endregion //Public methods
    }
}
