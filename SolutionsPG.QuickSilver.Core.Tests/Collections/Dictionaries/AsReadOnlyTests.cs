using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SolutionsPG.QuickSilver.Core.Collections;

namespace SolutionsPG.QuickSilver.Core.Tests.Collections.Dictionaries
{
    [TestClass]
    public class AsReadOnlyTests
    {
        #region | Tests management |

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        #endregion //Tests management

        #region | AsReadOnly |
        
        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.AsReadOnly")]
        public void DictionaryExtensions_AsReadOnly_DictionaryNull_ReturnArgumentNullExceptionThrown()
        {
            //Arrange

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => ((IDictionary<string, object>) null).AsReadOnly(),
                "ArgumentNullException should have been thrown");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.AsReadOnly")]
        public void DictionaryExtensions_AsReadOnly_DictionaryValid_VerifyCallerUnmodified()
        {
            //Arrange
            IDictionary<string, string> referenceDict = new Dictionary<string, string>
            {
                ["key"] = "value"
            };
            IDictionary<string, string> testDict = referenceDict.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            //Act
            var result = testDict.AsReadOnly();

            //Act & Assert
            Assert.AreEqual(referenceDict.Count, testDict.Count, "The original dictionary should have the same Count before and after the call to AsReadOnly");
            Assert.AreEqual(referenceDict["key"], testDict["key"], "The original dictionary should have the same keys and values before and after the call to AsReadOnly");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.AsReadOnly")]
        public void DictionaryExtensions_AsReadOnly_DictionaryValid_ReturnReadOnlyDictionaryWithSameValue()
        {
            //Arrange
            IDictionary<string, string> testDict = new Dictionary<string, string>
            {
                ["key"] = "value"
            };

            //Act
            var result = testDict.AsReadOnly();

            //Act & Assert
            Assert.IsNotNull(result, "The resulting ReadOnlyDictionary should not have been null");
            Assert.AreEqual(testDict.Count, result.Count, "The resulting ReadOnlyDictionary should have the same Count as the original dictionary");
            Assert.AreEqual(testDict["key"], result["key"], "The resulting ReadOnlyDictionary should have the same value for the same key as the original dictionary");
        }

        #endregion //AsReadOnly
    }
}
