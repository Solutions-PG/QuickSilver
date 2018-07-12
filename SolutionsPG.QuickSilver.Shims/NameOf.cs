using System;
using System.Linq.Expressions;

namespace SolutionsPG.QuickSilver.Shims
{
    public static partial class Cs60
    {
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// Shims for the keyword nameof from C# 6.0
        /// </summary>
        /// <typeparam name="T">Return type of the property</typeparam>
        /// <param name="propertyExpression">Expression returning the property name</param>
        /// <returns>Name of the property used in the expression</returns>
        public static string @nameof<T>(this Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException(Cs60.NameOfMember(() => propertyExpression));

            if (propertyExpression.Body is MemberExpression)
                return Cs60.NameOfMember(propertyExpression);
            if (propertyExpression.Body is MethodCallExpression)
                return Cs60.NameOfMethod(propertyExpression);
            throw new ArgumentException(Cs60.NameOfMember(() => propertyExpression.Body) + " is not a supported expression type", Cs60.NameOfMember(() => propertyExpression));
        }
#pragma warning restore IDE1006 // Naming Styles

        private static string NameOfMember<T>(Expression<Func<T>> propertyExpression)
        {
            return ((MemberExpression)propertyExpression.Body).Member.Name;
        }

        private static string NameOfMethod<T>(Expression<Func<T>> propertyExpression)
        {
            return ((MethodCallExpression)propertyExpression.Body).Method.Name;
        }
    }
}
