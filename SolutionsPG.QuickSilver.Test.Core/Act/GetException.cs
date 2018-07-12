using System;
using System.Collections.Generic;
using System.Text;

namespace SolutionsPG.QuickSilver.Test.Core
{
    public static partial class Act
    {
        public static TException GetException<TException>(Action action) where TException : Exception
        {
            TException result = null;

            try
            {
                action();
            }
            catch (TException e)
            {
                result = e;
            }

            return result;
        }
    }
}
