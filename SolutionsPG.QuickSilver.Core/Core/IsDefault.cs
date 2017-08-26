using System;
using System.Collections.Generic;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core
{
    public static partial class ObjectExtensions
    {
        #region | Public methods |

        public static bool IsDefault<T>(this T obj)
        {
            return obj.IsDefault_();
        }

        public static bool IsDefault(this string obj)
        {
            return obj.IsDefault_();
        }

        public static bool IsNotDefault<T>(this T obj) => obj.IsDefault_() == false;

        public static bool IsNotDefault(this string obj) => obj.IsDefault_() == false;

        #endregion //Public methods

        #region | Private methods |

        public static bool IsDefault_<T>(this T obj)
        {
            return obj.Is_(default(T));
        }

        public static bool IsDefault_(this string obj)
        {
            return string.IsNullOrWhiteSpace(obj);
        }

        #endregion //Private methods
    }
}
