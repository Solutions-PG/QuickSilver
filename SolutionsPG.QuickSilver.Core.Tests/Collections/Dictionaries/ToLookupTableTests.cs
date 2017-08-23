using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionsPG.QuickSilver.Core.Collections;

namespace SolutionsPG.QuickSilver.Core.Tests.Collections.Dictionaries
{
    [TestClass]
    public class ToLookupTableTests
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

        #region | IReadOnlyDictionary<TSourceValue, IReadOnlyList<TSourceKey>> ToLookupTable<TSourceKey, TSourceValue>(this IReadOnlyDictionary<TSourceKey, TSourceValue> dictionary) |

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTable_DictionaryNull_ReturnArgumentNullExceptionThrown()
        {
            //Arrange

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => ((IReadOnlyDictionary<string, object>)null).ToLookupTable(),
                "ArgumentNullException should have been thrown");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTable_DictionaryEmpty_ReturnLookupEmpty()
        {
            //Arrange
            IReadOnlyDictionary<string, object> dict = new Dictionary<string, object>(StringComparer.Ordinal);

            //Act
            IReadOnlyDictionary<object, IReadOnlyList<string>> result = dict.ToLookupTable();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTable_Dictionary1Key1Value_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            const int FirstValue = 4;
            IReadOnlyDictionary<string, int> dict = new Dictionary<string, int>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue
            };

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<string>> result = dict.ToLookupTable();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue, firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey, firstKvp.Value[0]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTable_Dictionary2Keys2Values_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            const int FirstValue = 4;
            const string SecondKey = "Test2";
            const int SecondValue = 8;
            IReadOnlyDictionary<string, int> dict = new Dictionary<string, int>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue
            };

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<string>> result = dict.ToLookupTable();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue, firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey, firstKvp.Value[0]);
            var secondKvp = result.Skip(1).First();
            Assert.AreEqual(SecondValue, secondKvp.Key);
            Assert.AreEqual(1, secondKvp.Value.Count);
            Assert.AreEqual(SecondKey, secondKvp.Value[0]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTable_Dictionary2Keys1Value_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            const int FirstValue = 4;
            const string SecondKey = "Test2";
            const int SecondValue = FirstValue;
            IReadOnlyDictionary<string, int> dict = new Dictionary<string, int>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue
            };

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<string>> result = dict.ToLookupTable();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue, firstKvp.Key);
            Assert.AreEqual(2, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey, firstKvp.Value[0]);
            Assert.AreEqual(SecondKey, firstKvp.Value[1]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTable_Dictionary3Keys2Values_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            const int FirstValue = 4;
            const string SecondKey = "Test2";
            const int SecondValue = 8;
            const string ThirdKey = "Test33";
            const int ThirdValue = SecondValue;
            IReadOnlyDictionary<string, int> dict = new Dictionary<string, int>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue,
                [ThirdKey] = ThirdValue
            };

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<string>> result = dict.ToLookupTable();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue, firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey, firstKvp.Value[0]);
            var secondKvp = result.Skip(1).First();
            Assert.AreEqual(SecondValue, secondKvp.Key);
            Assert.AreEqual(2, secondKvp.Value.Count);
            Assert.AreEqual(SecondKey, secondKvp.Value[0]);
            Assert.AreEqual(ThirdKey, secondKvp.Value[1]);
        }

        #endregion //IReadOnlyDictionary<TSourceValue, IReadOnlyList<TSourceKey>> ToLookupTable<TSourceKey, TSourceValue>(this IReadOnlyDictionary<TSourceKey, TSourceValue> dictionary)

        #region | IReadOnlyDictionary<TResultKey, IReadOnlyList<TSourceKey>> ToLookupTable<TSourceKey, TSourceValue, TResultKey>(this IReadOnlyDictionary<TSourceKey, TSourceValue> dictionary, Func<TSourceValue, TResultKey> keySelector) |

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithKeySelector_DictionaryNull_ReturnArgumentNullExceptionThrown()
        {
            //Arrange
            int KeySelector(object obj) => obj.ToString().Length;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => ((IReadOnlyDictionary<string, object>)null).ToLookupTable(KeySelector),
                "ArgumentNullException should have been thrown");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithKeySelector_KeySelectorNull_ReturnArgumentNullExceptionThrown()
        {
            //Arrange
            IReadOnlyDictionary<string, object> dict = new Dictionary<string, object>(StringComparer.Ordinal);

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => dict.ToLookupTable((Func<object, int>)null),
                "ArgumentNullException should have been thrown");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithKeySelector_DictionaryEmpty_ReturnLookupEmpty()
        {
            //Arrange
            IReadOnlyDictionary<string, object> dict = new Dictionary<string, object>(StringComparer.Ordinal);
            int KeySelector(object obj) => obj.ToString().Length;

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<string>> result = dict.ToLookupTable(KeySelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithKeySelector_Dictionary1Key1Value_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            const int FirstValue = 4;
            IReadOnlyDictionary<string, int> dict = new Dictionary<string, int>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue
            };
            double KeySelector(int obj) => obj;

            //Act
            IReadOnlyDictionary<double, IReadOnlyList<string>> result = dict.ToLookupTable(KeySelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue, firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey, firstKvp.Value[0]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithKeySelector_Dictionary2Keys2Values_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            const int FirstValue = 4;
            const string SecondKey = "Test2";
            const int SecondValue = 8;
            IReadOnlyDictionary<string, int> dict = new Dictionary<string, int>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue
            };
            double KeySelector(int obj) => obj;

            //Act
            IReadOnlyDictionary<double, IReadOnlyList<string>> result = dict.ToLookupTable(KeySelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue, firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey, firstKvp.Value[0]);
            var secondKvp = result.Skip(1).First();
            Assert.AreEqual(SecondValue, secondKvp.Key);
            Assert.AreEqual(1, secondKvp.Value.Count);
            Assert.AreEqual(SecondKey, secondKvp.Value[0]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithKeySelector_Dictionary2Keys1Value_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            const int FirstValue = 4;
            const string SecondKey = "Test2";
            const int SecondValue = FirstValue;
            IReadOnlyDictionary<string, int> dict = new Dictionary<string, int>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue
            };
            double KeySelector(int obj) => obj;

            //Act
            IReadOnlyDictionary<double, IReadOnlyList<string>> result = dict.ToLookupTable(KeySelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue, firstKvp.Key);
            Assert.AreEqual(2, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey, firstKvp.Value[0]);
            Assert.AreEqual(SecondKey, firstKvp.Value[1]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithKeySelector_Dictionary3Keys2Values_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            const int FirstValue = 4;
            const string SecondKey = "Test2";
            const int SecondValue = 8;
            const string ThirdKey = "Test33";
            const int ThirdValue = SecondValue;
            IReadOnlyDictionary<string, int> dict = new Dictionary<string, int>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue,
                [ThirdKey] = ThirdValue
            };
            double KeySelector(int obj) => obj;

            //Act
            IReadOnlyDictionary<double, IReadOnlyList<string>> result = dict.ToLookupTable(KeySelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue, firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey, firstKvp.Value[0]);
            var secondKvp = result.Skip(1).First();
            Assert.AreEqual(SecondValue, secondKvp.Key);
            Assert.AreEqual(2, secondKvp.Value.Count);
            Assert.AreEqual(SecondKey, secondKvp.Value[0]);
            Assert.AreEqual(ThirdKey, secondKvp.Value[1]);
        }

        #endregion //IReadOnlyDictionary<TResultKey, IReadOnlyList<TSourceKey>> ToLookupTable<TSourceKey, TSourceValue, TResultKey>(this IReadOnlyDictionary<TSourceKey, TSourceValue> dictionary, Func<TSourceValue, TResultKey> keySelector)

        #region | IReadOnlyDictionary<TSourceValue, IReadOnlyList<TResultValue>> ToLookupTable<TSourceKey, TSourceValue, TResultValue>(this IReadOnlyDictionary<TSourceKey, TSourceValue> dictionary, Func<TSourceKey, TResultValue> valueSelector) |

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithValueSelector_DictionaryNull_ReturnArgumentNullExceptionThrown()
        {
            //Arrange
            int ValueSelector(string obj) => obj.Length;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => ((IReadOnlyDictionary<string, object>)null).ToLookupTable(ValueSelector),
                "ArgumentNullException should have been thrown");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithValueSelector_ValueSelectorNull_ReturnArgumentNullExceptionThrown()
        {
            //Arrange
            IReadOnlyDictionary<string, object> dict = new Dictionary<string, object>(StringComparer.Ordinal);

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => dict.ToLookupTable((Func<string, int>)null),
                "ArgumentNullException should have been thrown");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithValueSelector_DictionaryEmpty_ReturnLookupEmpty()
        {
            //Arrange
            IReadOnlyDictionary<string, object> dict = new Dictionary<string, object>(StringComparer.Ordinal);
            int ValueSelector(string obj) => obj.ToString().Length;

            //Act
            IReadOnlyDictionary<object, IReadOnlyList<int>> result = dict.ToLookupTable(ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithValueSelector_Dictionary1Key1Value_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            const int FirstValue = 4;
            IReadOnlyDictionary<string, int> dict = new Dictionary<string, int>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue
            };
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<double>> result = dict.ToLookupTable(ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue, firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[0]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithValueSelector_Dictionary2Keys2Values_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            const int FirstValue = 4;
            const string SecondKey = "Test2";
            const int SecondValue = 8;
            IReadOnlyDictionary<string, int> dict = new Dictionary<string, int>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue
            };
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<double>> result = dict.ToLookupTable(ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue, firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[0]);
            var secondKvp = result.Skip(1).First();
            Assert.AreEqual(SecondValue, secondKvp.Key);
            Assert.AreEqual(1, secondKvp.Value.Count);
            Assert.AreEqual(SecondKey.Length, secondKvp.Value[0]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithValueSelector_Dictionary2Keys1Value_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            const int FirstValue = 4;
            const string SecondKey = "Test2";
            const int SecondValue = FirstValue;
            IReadOnlyDictionary<string, int> dict = new Dictionary<string, int>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue
            };
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<double>> result = dict.ToLookupTable(ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue, firstKvp.Key);
            Assert.AreEqual(2, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[0]);
            Assert.AreEqual(SecondKey.Length, firstKvp.Value[1]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithValueSelector_Dictionary3Keys2Values_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            const int FirstValue = 4;
            const string SecondKey = "Test2";
            const int SecondValue = 8;
            const string ThirdKey = "Test33";
            const int ThirdValue = SecondValue;
            IReadOnlyDictionary<string, int> dict = new Dictionary<string, int>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue,
                [ThirdKey] = ThirdValue
            };
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<double>> result = dict.ToLookupTable(ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue, firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[0]);
            var secondKvp = result.Skip(1).First();
            Assert.AreEqual(SecondValue, secondKvp.Key);
            Assert.AreEqual(2, secondKvp.Value.Count);
            Assert.AreEqual(SecondKey.Length, secondKvp.Value[0]);
            Assert.AreEqual(ThirdKey.Length, secondKvp.Value[1]);
        }

        #endregion //IReadOnlyDictionary<TSourceValue, IReadOnlyList<TResultValue>> ToLookupTable<TSourceKey, TSourceValue, TResultValue>(this IReadOnlyDictionary<TSourceKey, TSourceValue> dictionary, Func<TSourceKey, TResultValue> valueSelector)
        
        #region | IReadOnlyDictionary<TResultKey, IReadOnlyList<TResultValue>> ToLookupTable<TSourceKey, TSourceValue, TResultKey, TResultValue>(this IReadOnlyDictionary<TSourceKey, TSourceValue> dictionary, Func<TSourceValue, TResultKey> keySelector, Func<TSourceKey, TResultValue> valueSelector) |

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithKeySelectorAndValueSelector_DictionaryNull_ReturnArgumentNullExceptionThrown()
        {
            //Arrange
            int KeySelector(object obj) => obj.ToString().Length;
            double ValueSelector(string obj) => obj.Length;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => ((IReadOnlyDictionary<string, object>)null).ToLookupTable(KeySelector, ValueSelector),
                "ArgumentNullException should have been thrown");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithKeySelectorAndValueSelector_KeySelectorNull_ReturnArgumentNullExceptionThrown()
        {
            //Arrange
            IReadOnlyDictionary<string, object> dict = new Dictionary<string, object>(StringComparer.Ordinal);
            double ValueSelector(string obj) => obj.Length;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => dict.ToLookupTable((Func<object, int>)null, ValueSelector),
                "ArgumentNullException should have been thrown");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithKeySelectorAndValueSelector_ValueSelectorNull_ReturnArgumentNullExceptionThrown()
        {
            //Arrange
            IReadOnlyDictionary<string, object> dict = new Dictionary<string, object>(StringComparer.Ordinal);
            int KeySelector(object obj) => obj.ToString().Length;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => dict.ToLookupTable(KeySelector, (Func<string, double>)null),
                "ArgumentNullException should have been thrown");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithKeySelectorAndValueSelector_DictionaryEmpty_ReturnLookupEmpty()
        {
            //Arrange
            IReadOnlyDictionary<string, object> dict = new Dictionary<string, object>(StringComparer.Ordinal);
            int KeySelector(object obj) => obj.ToString().Length;
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<double>> result = dict.ToLookupTable(KeySelector, ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithKeySelectorAndValueSelector_Dictionary1Key1Value_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            const int FirstValue = 4;
            IReadOnlyDictionary<string, int> dict = new Dictionary<string, int>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue
            };
            double KeySelector(int obj) => obj;
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<double, IReadOnlyList<double>> result = dict.ToLookupTable(KeySelector, ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue, firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[0]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithKeySelectorAndValueSelector_Dictionary2Keys2Values_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            const int FirstValue = 4;
            const string SecondKey = "Test2";
            const int SecondValue = 8;
            IReadOnlyDictionary<string, int> dict = new Dictionary<string, int>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue
            };
            double KeySelector(int obj) => obj;
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<double, IReadOnlyList<double>> result = dict.ToLookupTable(KeySelector, ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue, firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[0]);
            var secondKvp = result.Skip(1).First();
            Assert.AreEqual(SecondValue, secondKvp.Key);
            Assert.AreEqual(1, secondKvp.Value.Count);
            Assert.AreEqual(SecondKey.Length, secondKvp.Value[0]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithKeySelectorAndValueSelector_Dictionary2Keys1Value_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            const int FirstValue = 4;
            const string SecondKey = "Test2";
            const int SecondValue = FirstValue;
            IReadOnlyDictionary<string, int> dict = new Dictionary<string, int>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue
            };
            double KeySelector(int obj) => obj;
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<double, IReadOnlyList<double>> result = dict.ToLookupTable(KeySelector, ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue, firstKvp.Key);
            Assert.AreEqual(2, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[0]);
            Assert.AreEqual(SecondKey.Length, firstKvp.Value[1]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableWithKeySelectorAndValueSelector_Dictionary3Keys2Values_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            const int FirstValue = 4;
            const string SecondKey = "Test2";
            const int SecondValue = 8;
            const string ThirdKey = "Test33";
            const int ThirdValue = SecondValue;
            IReadOnlyDictionary<string, int> dict = new Dictionary<string, int>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue,
                [ThirdKey] = ThirdValue
            };
            double KeySelector(int obj) => obj;
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<double, IReadOnlyList<double>> result = dict.ToLookupTable(KeySelector, ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue, firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[0]);
            var secondKvp = result.Skip(1).First();
            Assert.AreEqual(SecondValue, secondKvp.Key);
            Assert.AreEqual(2, secondKvp.Value.Count);
            Assert.AreEqual(SecondKey.Length, secondKvp.Value[0]);
            Assert.AreEqual(ThirdKey.Length, secondKvp.Value[1]);
        }

        #endregion //IReadOnlyDictionary<TResultKey, IReadOnlyList<TResultValue>> ToLookupTable<TSourceKey, TSourceValue, TResultKey, TResultValue>(this IReadOnlyDictionary<TSourceKey, TSourceValue> dictionary, Func<TSourceValue, TResultKey> keySelector, Func<TSourceKey, TResultValue> valueSelector)
        
        #region | IReadOnlyDictionary<TSourceValue, IReadOnlyList<TSourceKey>> ToLookupTable<TSourceKey, TSourceValue>(this IReadOnlyDictionary<TSourceKey, IReadOnlyList<TSourceValue>> dictionary) |

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfList_DictionaryNull_ReturnArgumentNullExceptionThrown()
        {
            //Arrange

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => ((IReadOnlyDictionary<string, IReadOnlyList<object>>)null).ToLookupTable(),
                "ArgumentNullException should have been thrown");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfList_DictionaryEmpty_ReturnLookupEmpty()
        {
            //Arrange
            IReadOnlyDictionary<string, IReadOnlyList<object>> dict = new Dictionary<string, IReadOnlyList<object>>(StringComparer.Ordinal);

            //Act
            IReadOnlyDictionary<object, IReadOnlyList<string>> result = dict.ToLookupTable();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfList_Dictionary1Key1Value_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4 };
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue
            };

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<string>> result = dict.ToLookupTable();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey, firstKvp.Value[0]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfList_Dictionary2Keys2Values_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4 };
            const string SecondKey = "Test2";
            IReadOnlyList<int> SecondValue = new List<int> { 8 };
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue
            };

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<string>> result = dict.ToLookupTable();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey, firstKvp.Value[0]);
            var secondKvp = result.Skip(1).First();
            Assert.AreEqual(SecondValue[0], secondKvp.Key);
            Assert.AreEqual(1, secondKvp.Value.Count);
            Assert.AreEqual(SecondKey, secondKvp.Value[0]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfList_Dictionary2Keys1Value_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4 };
            const string SecondKey = "Test2";
            IReadOnlyList<int> SecondValue = FirstValue;
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue
            };

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<string>> result = dict.ToLookupTable();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(2, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey, firstKvp.Value[0]);
            Assert.AreEqual(SecondKey, firstKvp.Value[1]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfList_Dictionary3Keys2Values_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4 };
            const string SecondKey = "Test2";
            IReadOnlyList<int> SecondValue = new List<int> { 8 };
            const string ThirdKey = "Test33";
            IReadOnlyList<int> ThirdValue = SecondValue;
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue,
                [ThirdKey] = ThirdValue
            };

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<string>> result = dict.ToLookupTable();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey, firstKvp.Value[0]);
            var secondKvp = result.Skip(1).First();
            Assert.AreEqual(SecondValue[0], secondKvp.Key);
            Assert.AreEqual(2, secondKvp.Value.Count);
            Assert.AreEqual(SecondKey, secondKvp.Value[0]);
            Assert.AreEqual(ThirdKey, secondKvp.Value[1]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfList_Dictionary1Key2TimesSameValue_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4, 4 };
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue
            };

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<string>> result = dict.ToLookupTable();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(2, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey, firstKvp.Value[0]);
            Assert.AreEqual(FirstKey, firstKvp.Value[1]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfList_Dictionary1Key2Values_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4, 8 };
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue
            };

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<string>> result = dict.ToLookupTable();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey, firstKvp.Value[0]);
            var secondKvp = result.Skip(1).First();
            Assert.AreEqual(FirstValue[1], secondKvp.Key);
            Assert.AreEqual(1, secondKvp.Value.Count);
            Assert.AreEqual(FirstKey, secondKvp.Value[0]);
        }

        #endregion //IReadOnlyDictionary<TSourceValue, IReadOnlyList<TSourceKey>> ToLookupTable<TSourceKey, TSourceValue>(this IReadOnlyDictionary<TSourceKey, IReadOnlyList<TSourceValue>> dictionary)

        #region | IReadOnlyDictionary<TResultKey, IReadOnlyList<TSourceKey>> ToLookupTable<TSourceKey, TSourceValue, TResultKey>(this IReadOnlyDictionary<TSourceKey, IReadOnlyList<TSourceValue>> dictionary, Func<TSourceValue, TResultKey> keySelector) |

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithKeySelector_DictionaryNull_ReturnArgumentNullExceptionThrown()
        {
            //Arrange
            int KeySelector(object obj) => obj.ToString().Length;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => ((IReadOnlyDictionary<string, IReadOnlyList<object>>)null).ToLookupTable(KeySelector),
                "ArgumentNullException should have been thrown");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithKeySelector_KeySelectorNull_ReturnArgumentNullExceptionThrown()
        {
            //Arrange
            IReadOnlyDictionary<string, IReadOnlyList<object>> dict = new Dictionary<string, IReadOnlyList<object>>(StringComparer.Ordinal);

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => dict.ToLookupTable((Func<object, int>)null),
                "ArgumentNullException should have been thrown");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithKeySelector_DictionaryEmpty_ReturnLookupEmpty()
        {
            //Arrange
            IReadOnlyDictionary<string, IReadOnlyList<object>> dict = new Dictionary<string, IReadOnlyList<object>>(StringComparer.Ordinal);
            int KeySelector(object obj) => obj.ToString().Length;

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<string>> result = dict.ToLookupTable(KeySelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithKeySelector_Dictionary1Key1Value_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4 };
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue
            };
            double KeySelector(int obj) => obj;

            //Act
            IReadOnlyDictionary<double, IReadOnlyList<string>> result = dict.ToLookupTable(KeySelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey, firstKvp.Value[0]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithKeySelector_Dictionary2Keys2Values_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4 };
            const string SecondKey = "Test2";
            IReadOnlyList<int> SecondValue = new List<int> { 8 };
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue
            };
            double KeySelector(int obj) => obj;

            //Act
            IReadOnlyDictionary<double, IReadOnlyList<string>> result = dict.ToLookupTable(KeySelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey, firstKvp.Value[0]);
            var secondKvp = result.Skip(1).First();
            Assert.AreEqual(SecondValue[0], secondKvp.Key);
            Assert.AreEqual(1, secondKvp.Value.Count);
            Assert.AreEqual(SecondKey, secondKvp.Value[0]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithKeySelector_Dictionary2Keys1Value_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4 };
            const string SecondKey = "Test2";
            IReadOnlyList<int> SecondValue = FirstValue;
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue
            };
            double KeySelector(int obj) => obj;

            //Act
            IReadOnlyDictionary<double, IReadOnlyList<string>> result = dict.ToLookupTable(KeySelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(2, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey, firstKvp.Value[0]);
            Assert.AreEqual(SecondKey, firstKvp.Value[1]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithKeySelector_Dictionary3Keys2Values_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4 };
            const string SecondKey = "Test2";
            IReadOnlyList<int> SecondValue = new List<int> { 8 };
            const string ThirdKey = "Test33";
            IReadOnlyList<int> ThirdValue = SecondValue;
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue,
                [ThirdKey] = ThirdValue
            };
            double KeySelector(int obj) => obj;

            //Act
            IReadOnlyDictionary<double, IReadOnlyList<string>> result = dict.ToLookupTable(KeySelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey, firstKvp.Value[0]);
            var secondKvp = result.Skip(1).First();
            Assert.AreEqual(SecondValue[0], secondKvp.Key);
            Assert.AreEqual(2, secondKvp.Value.Count);
            Assert.AreEqual(SecondKey, secondKvp.Value[0]);
            Assert.AreEqual(ThirdKey, secondKvp.Value[1]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithKeySelector_Dictionary1Key2TimesSameValue_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4, 4 };
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue
            };
            double KeySelector(int obj) => obj;

            //Act
            IReadOnlyDictionary<double, IReadOnlyList<string>> result = dict.ToLookupTable(KeySelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(2, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey, firstKvp.Value[0]);
            Assert.AreEqual(FirstKey, firstKvp.Value[1]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithKeySelector_Dictionary1Key2Values_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4, 8 };
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue
            };
            double KeySelector(int obj) => obj;

            //Act
            IReadOnlyDictionary<double, IReadOnlyList<string>> result = dict.ToLookupTable(KeySelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey, firstKvp.Value[0]);
            var secondKvp = result.Skip(1).First();
            Assert.AreEqual(FirstValue[1], secondKvp.Key);
            Assert.AreEqual(1, secondKvp.Value.Count);
            Assert.AreEqual(FirstKey, secondKvp.Value[0]);
        }

        #endregion //IReadOnlyDictionary<TResultKey, IReadOnlyList<TSourceKey>> ToLookupTable<TSourceKey, TSourceValue, TResultKey>(this IReadOnlyDictionary<TSourceKey, IReadOnlyList<TSourceValue>> dictionary, Func<TSourceValue, TResultKey> keySelector)

        #region | IReadOnlyDictionary<TSourceValue, IReadOnlyList<TResultValue>> ToLookupTable<TSourceKey, TSourceValue, TResultValue>(this IReadOnlyDictionary<TSourceKey, IReadOnlyList<TSourceValue>> dictionary, Func<TSourceKey, TResultValue> valueSelector) |

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithValueSelector_DictionaryNull_ReturnArgumentNullExceptionThrown()
        {
            //Arrange
            int ValueSelector(string obj) => obj.Length;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => ((IReadOnlyDictionary<string, IReadOnlyList<object>>)null).ToLookupTable(ValueSelector),
                "ArgumentNullException should have been thrown");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithValueSelector_ValueSelectorNull_ReturnArgumentNullExceptionThrown()
        {
            //Arrange
            IReadOnlyDictionary<string, IReadOnlyList<object>> dict = new Dictionary<string, IReadOnlyList<object>>(StringComparer.Ordinal);

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => dict.ToLookupTable((Func<string, int>)null),
                "ArgumentNullException should have been thrown");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithValueSelector_DictionaryEmpty_ReturnLookupEmpty()
        {
            //Arrange
            IReadOnlyDictionary<string, IReadOnlyList<object>> dict = new Dictionary<string, IReadOnlyList<object>>(StringComparer.Ordinal);
            int ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<object, IReadOnlyList<int>> result = dict.ToLookupTable(ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithValueSelector_Dictionary1Key1Value_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4 };
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue
            };
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<double>> result = dict.ToLookupTable(ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[0]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithValueSelector_Dictionary2Keys2Values_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4 };
            const string SecondKey = "Test2";
            IReadOnlyList<int> SecondValue = new List<int> { 8 };
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue
            };
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<double>> result = dict.ToLookupTable(ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[0]);
            var secondKvp = result.Skip(1).First();
            Assert.AreEqual(SecondValue[0], secondKvp.Key);
            Assert.AreEqual(1, secondKvp.Value.Count);
            Assert.AreEqual(SecondKey.Length, secondKvp.Value[0]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithValueSelector_Dictionary2Keys1Value_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4 };
            const string SecondKey = "Test2";
            IReadOnlyList<int> SecondValue = FirstValue;
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue
            };
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<double>> result = dict.ToLookupTable(ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(2, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[0]);
            Assert.AreEqual(SecondKey.Length, firstKvp.Value[1]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithValueSelector_Dictionary3Keys2Values_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4 };
            const string SecondKey = "Test2";
            IReadOnlyList<int> SecondValue = new List<int> { 8 };
            const string ThirdKey = "Test33";
            IReadOnlyList<int> ThirdValue = SecondValue;
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue,
                [ThirdKey] = ThirdValue
            };
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<double>> result = dict.ToLookupTable(ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[0]);
            var secondKvp = result.Skip(1).First();
            Assert.AreEqual(SecondValue[0], secondKvp.Key);
            Assert.AreEqual(2, secondKvp.Value.Count);
            Assert.AreEqual(SecondKey.Length, secondKvp.Value[0]);
            Assert.AreEqual(ThirdKey.Length, secondKvp.Value[1]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithValueSelector_Dictionary1Key2TimesSameValue_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4, 4 };
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue
            };
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<double>> result = dict.ToLookupTable(ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(2, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[0]);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[1]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithValueSelector_Dictionary1Key2Values_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4, 8 };
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue
            };
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<double>> result = dict.ToLookupTable(ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[0]);
            var secondKvp = result.Skip(1).First();
            Assert.AreEqual(FirstValue[1], secondKvp.Key);
            Assert.AreEqual(1, secondKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, secondKvp.Value[0]);
        }

        #endregion //IReadOnlyDictionary<TSourceValue, IReadOnlyList<TResultValue>> ToLookupTable<TSourceKey, TSourceValue, TResultValue>(this IReadOnlyDictionary<TSourceKey, IReadOnlyList<TSourceValue>> dictionary, Func<TSourceKey, TResultValue> valueSelector)

        #region | IReadOnlyDictionary<TResultKey, IReadOnlyList<TResultValue>> ToLookupTable<TSourceKey, TSourceValue, TResultKey, TResultValue>(this IReadOnlyDictionary<TSourceKey, IReadOnlyList<TSourceValue>> dictionary, Func<TSourceValue, TResultKey> keySelector, Func<TSourceKey, TResultValue> valueSelector) |

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithKeySelectorAndValueSelector_DictionaryNull_ReturnArgumentNullExceptionThrown()
        {
            //Arrange
            int KeySelector(object obj) => obj.ToString().Length;
            double ValueSelector(string obj) => obj.Length;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => ((IReadOnlyDictionary<string, IReadOnlyList<object>>)null).ToLookupTable(KeySelector, ValueSelector),
                "ArgumentNullException should have been thrown");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithKeySelectorAndValueSelector_KeySelectorNull_ReturnArgumentNullExceptionThrown()
        {
            //Arrange
            IReadOnlyDictionary<string, IReadOnlyList<object>> dict = new Dictionary<string, IReadOnlyList<object>>(StringComparer.Ordinal);
            double ValueSelector(string obj) => obj.Length;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => dict.ToLookupTable((Func<object, int>)null, ValueSelector),
                "ArgumentNullException should have been thrown");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithKeySelectorAndValueSelector_ValueSelectorNull_ReturnArgumentNullExceptionThrown()
        {
            //Arrange
            IReadOnlyDictionary<string, IReadOnlyList<object>> dict = new Dictionary<string, IReadOnlyList<object>>(StringComparer.Ordinal);
            int KeySelector(object obj) => obj.ToString().Length;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => dict.ToLookupTable(KeySelector, (Func<string, double>)null),
                "ArgumentNullException should have been thrown");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithKeySelectorAndValueSelector_DictionaryEmpty_ReturnLookupEmpty()
        {
            //Arrange
            IReadOnlyDictionary<string, IReadOnlyList<object>> dict = new Dictionary<string, IReadOnlyList<object>>(StringComparer.Ordinal);
            int KeySelector(object obj) => obj.ToString().Length;
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<int, IReadOnlyList<double>> result = dict.ToLookupTable(KeySelector, ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithKeySelectorAndValueSelector_Dictionary1Key1Value_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4 };
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue
            };
            double KeySelector(int obj) => obj;
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<double, IReadOnlyList<double>> result = dict.ToLookupTable(KeySelector, ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[0]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithKeySelectorAndValueSelector_Dictionary2Keys2Values_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4 };
            const string SecondKey = "Test2";
            IReadOnlyList<int> SecondValue = new List<int> { 8 };
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue
            };
            double KeySelector(int obj) => obj;
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<double, IReadOnlyList<double>> result = dict.ToLookupTable(KeySelector, ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[0]);
            var secondKvp = result.Skip(1).First();
            Assert.AreEqual(SecondValue[0], secondKvp.Key);
            Assert.AreEqual(1, secondKvp.Value.Count);
            Assert.AreEqual(SecondKey.Length, secondKvp.Value[0]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithKeySelectorAndValueSelector_Dictionary2Keys1Value_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4 };
            const string SecondKey = "Test2";
            IReadOnlyList<int> SecondValue = FirstValue;
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue
            };
            double KeySelector(int obj) => obj;
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<double, IReadOnlyList<double>> result = dict.ToLookupTable(KeySelector, ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(2, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[0]);
            Assert.AreEqual(SecondKey.Length, firstKvp.Value[1]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithKeySelectorAndValueSelector_Dictionary3Keys2Values_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4 };
            const string SecondKey = "Test2";
            IReadOnlyList<int> SecondValue = new List<int> { 8 };
            const string ThirdKey = "Test33";
            IReadOnlyList<int> ThirdValue = SecondValue;
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue,
                [SecondKey] = SecondValue,
                [ThirdKey] = ThirdValue
            };
            double KeySelector(int obj) => obj;
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<double, IReadOnlyList<double>> result = dict.ToLookupTable(KeySelector, ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[0]);
            var secondKvp = result.Skip(1).First();
            Assert.AreEqual(SecondValue[0], secondKvp.Key);
            Assert.AreEqual(2, secondKvp.Value.Count);
            Assert.AreEqual(SecondKey.Length, secondKvp.Value[0]);
            Assert.AreEqual(ThirdKey.Length, secondKvp.Value[1]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithKeySelectorAndValueSelector_Dictionary1Key2TimesSameValue_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4, 4 };
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue
            };
            double KeySelector(int obj) => obj;
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<double, IReadOnlyList<double>> result = dict.ToLookupTable(KeySelector, ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(2, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[0]);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[1]);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Collections.Dictionaries"), TestCategory("Core.Collections.Dictionaries.ToLookupTable")]
        public void DictionaryExtensions_ToLookupTableOfListWithKeySelectorAndValueSelector_Dictionary1Key2Values_ReturnValidLookup()
        {
            //Arrange
            const string FirstKey = "Test";
            IReadOnlyList<int> FirstValue = new List<int> { 4, 8 };
            IReadOnlyDictionary<string, IReadOnlyList<int>> dict = new Dictionary<string, IReadOnlyList<int>>(StringComparer.Ordinal)
            {
                [FirstKey] = FirstValue
            };
            double KeySelector(int obj) => obj;
            double ValueSelector(string obj) => obj.Length;

            //Act
            IReadOnlyDictionary<double, IReadOnlyList<double>> result = dict.ToLookupTable(KeySelector, ValueSelector);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            var firstKvp = result.First();
            Assert.AreEqual(FirstValue[0], firstKvp.Key);
            Assert.AreEqual(1, firstKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, firstKvp.Value[0]);
            var secondKvp = result.Skip(1).First();
            Assert.AreEqual(FirstValue[1], secondKvp.Key);
            Assert.AreEqual(1, secondKvp.Value.Count);
            Assert.AreEqual(FirstKey.Length, secondKvp.Value[0]);
        }

        #endregion //IReadOnlyDictionary<TResultKey, IReadOnlyList<TResultValue>> ToLookupTable<TSourceKey, TSourceValue, TResultKey, TResultValue>(this IReadOnlyDictionary<TSourceKey, IReadOnlyList<TSourceValue>> dictionary, Func<TSourceValue, TResultKey> keySelector, Func<TSourceKey, TResultValue> valueSelector)
    }
}
