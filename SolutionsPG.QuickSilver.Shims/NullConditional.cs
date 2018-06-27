using System;
using SolutionsPG.QuickSilver.Shims.NullConditional;

namespace SolutionsPG.QuickSilver.Shims
{
    public static partial class Cs60
    {
#pragma warning disable IDE1006 // Naming Styles
        // ReSharper disable InconsistentNaming

        /// <summary>
        /// Shims for the Null-conditional operators from C# 6.0
        /// Take an object and use it to start the null-conditional chain.
        ///
        /// The name "nc" is lower case to look more like a keyword
        /// </summary>
        /// <typeparam name="T">Type of the object used to start the null-conditional chain</typeparam>
        /// <typeparam name="TResult">Type of the returned object</typeparam>
        /// <param name="this">Object used to start the null-conditional chain</param>
        /// <param name="map">Action executed if the object is not null</param>
        /// <returns>A NullConditional{TResult} object</returns>
        public static NullConditional<TResult> nc<T, TResult>(this T @this, Func<T, TResult> map)
        {
            return nc((NullConditional<T>)@this, map);
        }

        /// <summary>
        /// Shims for the Null-conditional operators from C# 6.0
        /// Usually used to continue a null-conditional chain.
        ///
        /// The name "nc" is lower case to look more like a keyword
        /// </summary>
        /// <typeparam name="T">Type of the object contained in the NullConditional{T} object.</typeparam>
        /// <typeparam name="TResult">Type of the returned object</typeparam>
        /// <param name="this">A NullConditional{T} object used to continue the null-conditional chain</param>
        /// <param name="map">Action executed if the object contained is not null</param>
        /// <returns>A NullConditional{TResult} object</returns>
        public static NullConditional<TResult> nc<T, TResult>(this NullConditional<T> @this, Func<T, TResult> map)
        {
            return @this.Match(NullConditional<TResult>.Null, t => (NullConditional<TResult>)map(t));
        }
        // ReSharper restore InconsistentNaming
#pragma warning restore IDE1006 // Naming Styles

        //public static NullConditional<T> NcTap<T>(this T @this, Action<T> action)
        //{
        //    return NcTap((NullConditional<T>)@this, action);
        //}

        //public static NullConditional<T> NcTap<T>(this NullConditional<T> @this, Action<T> action)
        //{
        //    return @this.Match(NullConditional<T>.Null, t => { action(t); return (NullConditional<T>) t; });
        //}

        /// <summary>
        /// Let the user get the value from the NullConditional{T} object if it exist. Else it return the value provided by the @default function.
        /// </summary>
        /// <typeparam name="T">Type of the object to get</typeparam>
        /// <param name="this">A NullConditional{T} object</param>
        /// <param name="default">Provide a default value if needed</param>
        /// <returns>The value from the NullConditional{T} object if it exist. Or else it return the value provided by the @default function.</returns>
        public static T GetOrElse<T>(this NullConditional<T> @this, Func<T> @default)
        {
            return @this.GetOrElseImpl(@default);
        }

        /// <summary>
        /// Let the user get the value from the NullConditional{T} object if it exist. Else it return the value provided with @default.
        /// </summary>
        /// <typeparam name="T">Type of the object to get</typeparam>
        /// <param name="this">A NullConditional{T} object</param>
        /// <param name="default">Provided value to use as default if needed</param>
        /// <returns>The value from the NullConditional{T} object if it exist. Or else it return the value provided with @default.</returns>
        public static T GetOrElse<T>(this NullConditional<T> @this, T @default)
        {
            return @this.GetOrElseImpl(() => @default);
        }

        private static T GetOrElseImpl<T>(this NullConditional<T> @this, Func<T> @default)
        {
            return @this.Match(@default, t => t);
        }
    }
}
