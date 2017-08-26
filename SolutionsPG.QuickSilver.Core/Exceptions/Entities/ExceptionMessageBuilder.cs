using System;
using System.Collections.Generic;
using System.Linq;

using SolutionsPG.QuickSilver.Core.Experimental.Exceptions.Interfaces;

namespace SolutionsPG.QuickSilver.Core.Experimental.Exceptions.Entities
{
    public class ExceptionMessageBuilder : IExceptionMessageBuilder
    {
        #region | Public methods |

        /// <summary>
        /// Explain what the surrounding code was trying to accomplish
        /// </summary>
        /// <param name="summary"></param>
        /// <returns></returns>
        public IExceptionMessageBuilder AddUserAction(string summary) => this;

        /// <summary>
        /// Explain what probably happened
        /// </summary>
        /// <param name="summary"></param>
        /// <returns></returns>
        public IExceptionMessageBuilder AddSummary(string summary) => this;

        public IExceptionMessageBuilder AddParameter<T>(string parameterName, T parameter) => this;

        public IExceptionMessageBuilder AddMoreInfo(string title, string info) => this;

        public IExceptionMessageBuilder AddMoreInfo(string title, IEnumerable<string> infos) => this.AddMoreInfo_(title, infos);

        public IExceptionMessageBuilder AddMoreInfo<T>(string title, IEnumerable<T> infos, Func<T, string> infoToString)
        {
            return this.AddMoreInfo_(title,
                infos.Select(CreateSecureInfoToString(infoToString ?? (i => i?.ToString()))));
        }

        public IExceptionMessageBuilder AddExceptionSource<T>(T source) => this;

        public string Build() => string.Empty;

        #endregion //Public methods

        #region | Private methods |

        private ExceptionMessageBuilder AddMoreInfo_(string title, IEnumerable<string> info) => this;

        private static Func<T, string> CreateSecureInfoToString<T>(Func<T, string> infoToString)
        {
            string SecureInfoToString(T i)
            {
                try
                {
                    return infoToString(i);
                }
                catch (Exception e)
                {
                    return $"Converting object of type <{TypeCache<T>.Type.FullName}> to string failed : " + e.Message;
                }
            }

            return SecureInfoToString;
        }

        #endregion //Private methods
    }
}
