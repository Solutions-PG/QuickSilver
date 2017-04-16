using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SolutionsPG.QuickSilver.Commons.Extensions;

namespace SolutionsPG.QuickSilver.Commons.Tests.Extensions
{
    [TestClass]
    public class ApplyTests
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

        #region " Apply "

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_Apply_ObjectNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = null;
            Action<object> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.Apply(action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_Apply_ObjectNotNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = new object();
            Action<object> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.Apply(action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_Apply_ObjectNull_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = null;
            bool actionCalled = false;
            object objReceived = new object();
            Action<object> action = new Action<object>(o => { actionCalled = true; objReceived = o; });

            //Act       
            var result = obj.Apply(action);

            //Assert
            Assert.AreEqual(obj, result);
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceived);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_Apply_ObjectNotNull_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = new object();
            bool actionCalled = false;
            object objReceived = new object();
            Action<object> action = new Action<object>(o => { actionCalled = true; objReceived = o; });

            //Act       
            var result = obj.Apply(action);

            //Assert
            Assert.AreEqual(obj, result);
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceived);
        }

        #endregion //Apply

        #region " ApplyIf<T>(this T obj, bool condition, Action<object> action) "

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIf_ObjectNull_ConditionTrue_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = null;
            bool condition = true;
            Action<object> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ApplyIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIf_ObjectNotNull_ConditionTrue_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = new object();
            bool condition = true;
            Action<object> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ApplyIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIf_ObjectNull_ConditionFalse_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = null;
            bool condition = false;
            Action<object> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ApplyIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIf_ObjectNotNull_ConditionFalse_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = new object();
            bool condition = false;
            Action<object> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ApplyIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIf_ObjectNull_ConditionTrue_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = null;
            bool condition = true;
            bool actionCalled = false;
            object objReceived = new object();
            Action<object> action = new Action<object>(o => { actionCalled = true; objReceived = o; });

            //Act       
            var result = obj.ApplyIf(condition, action);

            //Assert
            Assert.AreEqual(obj, result);
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceived);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIf_ObjectNotNull_ConditionTrue_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = new object();
            bool condition = true;
            bool actionCalled = false;
            object objReceived = new object();
            Action<object> action = new Action<object>(o => { actionCalled = true; objReceived = o; });

            //Act       
            var result = obj.ApplyIf(condition, action);

            //Assert
            Assert.AreEqual(obj, result);
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceived);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIf_ObjectNull_ConditionFalse_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = null;
            bool condition = false;
            bool actionCalled = false;
            Action<object> action = new Action<object>(o => { actionCalled = true; });

            //Act       
            var result = obj.ApplyIf(condition, action);

            //Assert
            Assert.AreEqual(obj, result);
            Assert.IsFalse(actionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIf_ObjectNotNull_ConditionFalse_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = new object();
            bool condition = false;
            bool actionCalled = false;
            Action<object> action = new Action<object>(o => { actionCalled = true; });

            //Act       
            var result = obj.ApplyIf(condition, action);

            //Assert
            Assert.AreEqual(obj, result);
            Assert.IsFalse(actionCalled);
        }

        #endregion //ApplyIf<T>(this T obj, bool condition, Action<object> action)

        #region " ApplyIf<T>(this T obj, Func<T, bool> condition, Action<object> action) "

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIfFunc_ObjectNull_ConditionNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = null;
            Func<object, bool> condition = null;
            Action<object> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ApplyIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("condition"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIfFunc_ObjectNotNull_ConditionNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = new object();
            Func<object, bool> condition = null;
            Action<object> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ApplyIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("condition"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIfFunc_ObjectNull_ConditionTrue_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = null;
            bool conditionCalled = false;
            bool conditionValue = true;
            Func<object, bool> condition = o => { conditionCalled = true; return conditionValue; };
            Action<object> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ApplyIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
            Assert.IsFalse(conditionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIfFunc_ObjectNotNull_ConditionTrue_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = new object();
            bool conditionCalled = false;
            bool conditionValue = true;
            Func<object, bool> condition = o => { conditionCalled = true; return conditionValue; };
            Action<object> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ApplyIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
            Assert.IsFalse(conditionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIfFunc_ObjectNull_ConditionFalse_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = null;
            bool conditionCalled = false;
            bool conditionValue = false;
            Func<object, bool> condition = o => { conditionCalled = true; return conditionValue; };
            Action<object> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ApplyIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
            Assert.IsFalse(conditionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIfFunc_ObjectNotNull_ConditionFalse_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = new object();
            bool conditionCalled = false;
            bool conditionValue = false;
            Func<object, bool> condition = o => { conditionCalled = true; return conditionValue; };
            Action<object> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ApplyIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
            Assert.IsFalse(conditionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIfFunc_ObjectNull_ConditionTrue_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = null;
            bool conditionCalled = false;
            object objReceivedCondition = new object();
            bool conditionValue = true;
            Func<object, bool> condition = o => { conditionCalled = true; objReceivedCondition = o; return conditionValue; };
            bool actionCalled = false;
            object objReceived = new object();
            Action<object> action = new Action<object>(o => { actionCalled = true; objReceived = o; });

            //Act       
            var result = obj.ApplyIf(condition, action);

            //Assert
            Assert.IsTrue(conditionCalled);
            Assert.AreEqual(obj, objReceivedCondition);
            Assert.AreEqual(obj, result);
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceived);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIfFunc_ObjectNotNull_ConditionTrue_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = new object();
            bool conditionCalled = false;
            object objReceivedCondition = new object();
            bool conditionValue = true;
            Func<object, bool> condition = o => { conditionCalled = true; objReceivedCondition = o; return conditionValue; };
            bool actionCalled = false;
            object objReceived = new object();
            Action<object> action = new Action<object>(o => { actionCalled = true; objReceived = o; });

            //Act       
            var result = obj.ApplyIf(condition, action);

            //Assert
            Assert.IsTrue(conditionCalled);
            Assert.AreEqual(obj, objReceivedCondition);
            Assert.AreEqual(obj, result);
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceived);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIfFunc_ObjectNull_ConditionFalse_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = null;
            bool conditionCalled = false;
            object objReceivedCondition = new object();
            bool conditionValue = false;
            Func<object, bool> condition = o => { conditionCalled = true; objReceivedCondition = o; return conditionValue; };
            bool actionCalled = false;
            Action<object> action = new Action<object>(o => { actionCalled = true; });

            //Act       
            var result = obj.ApplyIf(condition, action);

            //Assert
            Assert.IsTrue(conditionCalled);
            Assert.AreEqual(obj, objReceivedCondition);
            Assert.AreEqual(obj, result);
            Assert.IsFalse(actionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIfFunc_ObjectNotNull_ConditionFalse_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = new object();
            bool conditionCalled = false;
            object objReceivedCondition = new object();
            bool conditionValue = false;
            Func<object, bool> condition = o => { conditionCalled = true; objReceivedCondition = o; return conditionValue; };
            bool actionCalled = false;
            Action<object> action = new Action<object>(o => { actionCalled = true; });

            //Act       
            var result = obj.ApplyIf(condition, action);

            //Assert
            Assert.IsTrue(conditionCalled);
            Assert.AreEqual(obj, objReceivedCondition);
            Assert.AreEqual(obj, result);
            Assert.IsFalse(actionCalled);
        }

        #endregion //ApplyIf<T>(this T obj, Func<T, bool> condition, Action<object> action)

        #region " ApplyIfNotNull<T>(this T obj, Action<object> action) "

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIfNotNull_ObjectNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = null;
            Action<object> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ApplyIfNotNull(action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIfNotNull_ObjectNotNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = new object();
            Action<object> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ApplyIfNotNull(action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIfNotNull_ObjectNull_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = null;
            bool actionCalled = false;
            Action<object> action = new Action<object>(o => { actionCalled = true; });

            //Act       
            var result = obj.ApplyIfNotNull(action);

            //Assert
            Assert.AreEqual(obj, result);
            Assert.IsFalse(actionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ApplyIfNotNull_ObjectNotNull_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = new object();
            bool actionCalled = false;
            object objReceived = new object();
            Action<object> action = new Action<object>(o => { actionCalled = true; objReceived = o; });

            //Act       
            var result = obj.ApplyIfNotNull(action);

            //Assert
            Assert.AreEqual(obj, result);
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceived);
        }

        #endregion //ApplyIfNotNull<T>(this T obj, Action<object> action)
    }
}
