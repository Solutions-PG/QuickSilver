using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionsPG.QuickSilver.Core.Collections;

namespace SolutionsPG.QuickSilver.Core.Tests.Collections.Dictionaries
{
    [TestClass]
    public class TryGetValueAsDelegateTest
    {
        #region " Tests management "

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        #endregion //Tests management

        #region " TryGetValueAsDelegate "

        [TestMethod, TestCategory("Core.Collections.Dictionaries"), TestCategory("_Unit")]
        public void DictionaryExtensions_TryGetValueAsDelegate_DictionaryNull_ReturnArgumentNullExceptionThrown()
        {
            //Arrange

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => ((IDictionary<string, object>)null).TryGetValueAsDelegate(),
                "ArgumentNullException should have been thrown");
        }

        [TestMethod, TestCategory("Core.Collections.Dictionaries"), TestCategory("_Unit")]
        public void DictionaryExtensions_TryGetValueAsDelegate_DictionaryValid_ReturnDelegate()
        {
            //Arrange
            IDictionary<string, string> testDict = new Dictionary<string, string>
            {
                ["key"] = "value"
            };

            //Act
            var result = testDict.TryGetValueAsDelegate();

            //Act & Assert
            Assert.IsNotNull(result, "The resulting delegate should not have been null");
            Assert.IsTrue(result("key", out var resultValue));
            Assert.AreEqual("value", resultValue, "The resulting delegate should let the user acces the data like the original TryGetValue");
        }

        #endregion //TryGetValueAsDelegate
    }
}
