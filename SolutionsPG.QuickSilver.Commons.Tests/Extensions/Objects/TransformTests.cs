using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SolutionsPG.QuickSilver.Commons.Extensions;

namespace SolutionsPG.QuickSilver.Commons.Tests.Extensions
{
    [TestClass]
    public class TransformTests
    {
        const int ObjectReceivedWasNull = -1;

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

        #region " Transform "

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_Transform_ObjectNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = null;
            Func<string, int> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.Transform(action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_Transform_ObjectNotNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = "test";
            Func<string, int> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.Transform(action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_Transform_ObjectNull_ActionNotNull_ReturnExpectedResult()
        {
            //Arrange
            string obj = null;
            bool actionCalled = false;
            string objReceivedAction = "actionTest";
            int expectedResult = ObjectReceivedWasNull;
            Func<string, int> action = new Func<string, int>(o => { actionCalled = true; objReceivedAction = obj; return (o == null) ? ObjectReceivedWasNull : o.Length; });

            //Act       
            var result = obj.Transform(action);

            //Assert
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceivedAction);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_Transform_ObjectNotNull_ActionNotNull_ReturnExpectedResult()
        {
            //Arrange
            string obj = "test";
            bool actionCalled = false;
            string objReceivedAction = "actionTest";
            int expectedResult = obj.Length;
            Func<string, int> action = new Func<string, int>(o => { actionCalled = true; objReceivedAction = obj; return (o == null) ? ObjectReceivedWasNull : o.Length; });

            //Act       
            var result = obj.Transform(action);

            //Assert
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceivedAction);
            Assert.AreEqual(expectedResult, result);
        }

        #endregion //Transform

        #region " TransformIf<T, TResult>(this T obj, bool condition, Func<T, TResult> action) "

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIf_ObjectNull_ConditionTrue_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = null;
            bool condition = true;
            Func<string, int> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.TransformIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIf_ObjectNotNull_ConditionTrue_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = "test";
            bool condition = true;
            Func<string, int> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.TransformIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIf_ObjectNull_ConditionFalse_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = null;
            bool condition = false;
            Func<string, int> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.TransformIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIf_ObjectNotNull_ConditionFalse_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = "test";
            bool condition = false;
            Func<string, int> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.TransformIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIf_ObjectNull_ConditionTrue_ActionNotNull_ReturnExpectedResult()
        {
            //Arrange
            string obj = null;
            bool condition = true;
            bool actionCalled = false;
            string objReceivedAction = "actionTest";
            int expectedResult = ObjectReceivedWasNull;
            Func<string, int> action = new Func<string, int>(o => { actionCalled = true; objReceivedAction = obj; return (o == null) ? ObjectReceivedWasNull : o.Length; });

            //Act       
            var result = obj.TransformIf(condition, action);

            //Assert
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceivedAction);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIf_ObjectNotNull_ConditionTrue_ActionNotNull_ReturnExpectedResult()
        {
            //Arrange
            string obj = "test";
            bool condition = true;
            bool actionCalled = false;
            string objReceivedAction = "actionTest";
            int expectedResult = obj.Length;
            Func<string, int> action = new Func<string, int>(o => { actionCalled = true; objReceivedAction = obj; return (o == null) ? ObjectReceivedWasNull : o.Length; });

            //Act       
            var result = obj.TransformIf(condition, action);

            //Assert
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceivedAction);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIf_ObjectNull_ConditionFalse_ActionNotNull_ReturnExpectedResult()
        {
            //Arrange
            string obj = null;
            bool condition = false;
            bool actionCalled = false;
            int expectedResult = default(int);
            Func<string, int> action = new Func<string, int>(o => { actionCalled = true; return (o == null) ? ObjectReceivedWasNull : o.Length; });

            //Act       
            var result = obj.TransformIf(condition, action);

            //Assert
            Assert.IsFalse(actionCalled);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIf_ObjectNotNull_ConditionFalse_ActionNotNull_ReturnExpectedResult()
        {
            //Arrange
            string obj = "test";
            bool condition = false;
            bool actionCalled = false;
            int expectedResult = default(int);
            Func<string, int> action = new Func<string, int>(o => { actionCalled = true; return (o == null) ? ObjectReceivedWasNull : o.Length; });

            //Act       
            var result = obj.TransformIf(condition, action);

            //Assert
            Assert.IsFalse(actionCalled);
            Assert.AreEqual(expectedResult, result);
        }

        #endregion //TransformIf<T, TResult>(this T obj, bool condition, Func<T, TResult> action)

        #region " TransformIf<T, TResult>(this T obj, Func<T, bool> condition, Func<T, TResult> action) "

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIfFunc_ObjectNull_ConditionNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = null;
            Func<string, bool> condition = null;
            Func<string, int> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.TransformIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("condition"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIfFunc_ObjectNotNull_ConditionNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = "test";
            Func<string, bool> condition = null;
            Func<string, int> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.TransformIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("condition"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIfFunc_ObjectNull_ConditionTrue_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = null;
            bool conditionCalled = false;
            bool conditionValue = true;
            Func<string, bool> condition = o => { conditionCalled = true; return conditionValue; };
            Func<string, int> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.TransformIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
            Assert.IsFalse(conditionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIfFunc_ObjectNotNull_ConditionTrue_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = "test";
            bool conditionCalled = false;
            bool conditionValue = true;
            Func<string, bool> condition = o => { conditionCalled = true; return conditionValue; };
            Func<string, int> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.TransformIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
            Assert.IsFalse(conditionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIfFunc_ObjectNull_ConditionFalse_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = null;
            bool conditionCalled = false;
            bool conditionValue = false;
            Func<string, bool> condition = o => { conditionCalled = true; return conditionValue; };
            Func<string, int> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.TransformIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
            Assert.IsFalse(conditionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIfFunc_ObjectNotNull_ConditionFalse_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = "test";
            bool conditionCalled = false;
            bool conditionValue = false;
            Func<string, bool> condition = o => { conditionCalled = true; return conditionValue; };
            Func<string, int> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.TransformIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
            Assert.IsFalse(conditionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIfFunc_ObjectNull_ConditionTrue_ActionNotNull_ReturnExpectedResult()
        {
            //Arrange
            string obj = null;
            bool conditionCalled = false;
            string objReceivedCondition = "conditonTest";
            bool conditionValue = true;
            Func<string, bool> condition = o => { conditionCalled = true; objReceivedCondition = o; return conditionValue; };
            bool actionCalled = false;
            string objReceivedAction = "actionTest";
            int expectedResult = ObjectReceivedWasNull;
            Func<string, int> action = new Func<string, int>(o => { actionCalled = true; objReceivedAction = obj; return (o == null) ? ObjectReceivedWasNull : o.Length; });

            //Act       
            var result = obj.TransformIf(condition, action);

            //Assert
            Assert.IsTrue(conditionCalled);
            Assert.AreEqual(obj, objReceivedCondition);
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceivedAction);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIfFunc_ObjectNotNull_ConditionTrue_ActionNotNull_ReturnExpectedResult()
        {
            //Arrange
            string obj = "test";
            bool conditionCalled = false;
            string objReceivedCondition = "conditonTest";
            bool conditionValue = true;
            Func<string, bool> condition = o => { conditionCalled = true; objReceivedCondition = o; return conditionValue; };
            bool actionCalled = false;
            string objReceivedAction = "actionTest";
            int expectedResult = obj.Length;
            Func<string, int> action = new Func<string, int>(o => { actionCalled = true; objReceivedAction = obj; return (o == null) ? ObjectReceivedWasNull : o.Length; });

            //Act       
            var result = obj.TransformIf(condition, action);

            //Assert
            Assert.IsTrue(conditionCalled);
            Assert.AreEqual(obj, objReceivedCondition);
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceivedAction);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIfFunc_ObjectNull_ConditionFalse_ActionNotNull_ReturnExpectedResult()
        {
            //Arrange
            string obj = null;
            bool conditionCalled = false;
            string objReceivedCondition = "conditonTest";
            bool conditionValue = false;
            Func<string, bool> condition = o => { conditionCalled = true; objReceivedCondition = o; return conditionValue; };
            bool actionCalled = false;
            int expectedResult = default(int);
            Func<string, int> action = new Func<string, int>(o => { actionCalled = true; return (o == null) ? ObjectReceivedWasNull : o.Length; });

            //Act       
            var result = obj.TransformIf(condition, action);

            //Assert
            Assert.IsTrue(conditionCalled);
            Assert.AreEqual(obj, objReceivedCondition);
            Assert.IsFalse(actionCalled);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIfFunc_ObjectNotNull_ConditionFalse_ActionNotNull_ReturnExpectedResult()
        {
            //Arrange
            string obj = "test";
            bool conditionCalled = false;
            string objReceivedCondition = "conditonTest";
            bool conditionValue = false;
            Func<string, bool> condition = o => { conditionCalled = true; objReceivedCondition = o; return conditionValue; };
            bool actionCalled = false;
            int expectedResult = default(int);
            Func<string, int> action = new Func<string, int>(o => { actionCalled = true; return (o == null) ? ObjectReceivedWasNull : o.Length; });

            //Act       
            var result = obj.TransformIf(condition, action);

            //Assert
            Assert.IsTrue(conditionCalled);
            Assert.AreEqual(obj, objReceivedCondition);
            Assert.IsFalse(actionCalled);
            Assert.AreEqual(expectedResult, result);
        }

        #endregion //TransformIf<T, TResult>(this T obj, Func<T, bool> condition, Func<T, TResult> action)

        #region " TransformIfNotNull<T, TResult>(this T obj, Func<T, TResult> action) "

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIfNotNull_ObjectNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = null;
            Func<string, int> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.TransformIfNotNull(action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIfNotNull_ObjectNotNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = "test";
            Func<string, int> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.TransformIfNotNull(action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIfNotNull_ObjectNull_ActionNotNull_ReturnExpectedResult()
        {
            //Arrange
            string obj = null;
            bool actionCalled = false;
            int expectedResult = default(int);
            Func<string, int> action = new Func<string, int>(o => { actionCalled = true; return (o == null) ? ObjectReceivedWasNull : o.Length; });

            //Act       
            var result = obj.TransformIfNotNull(action);

            //Assert
            Assert.IsFalse(actionCalled);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_TransformIfNotNull_ObjectNotNull_ActionNotNull_ReturnExpectedResult()
        {
            //Arrange
            string obj = "test";
            bool actionCalled = false;
            string objReceivedAction = "actionTest";
            int expectedResult = obj.Length;
            Func<string, int> action = new Func<string, int>(o => { actionCalled = true; objReceivedAction = obj; return (o == null) ? ObjectReceivedWasNull : o.Length; });

            //Act       
            var result = obj.TransformIfNotNull(action);

            //Assert
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceivedAction);
            Assert.AreEqual(expectedResult, result);
        }

        #endregion //TransformIfNotNull<T, TResult>(this T obj, Func<T, TResult> action)
    }
}
