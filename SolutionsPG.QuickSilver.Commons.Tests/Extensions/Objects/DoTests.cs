using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SolutionsPG.QuickSilver.Commons.Extensions;

namespace SolutionsPG.QuickSilver.Commons.Tests.Extensions
{
    [TestClass]
    public class DoTests
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

        #region " Do "

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_Do_ObjectNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = null;
            Action action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.Do(action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_Do_ObjectNotNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = new object();
            Action action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.Do(action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_Do_ObjectNull_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = null;
            bool actionCalled = false;
            Action action = new Action(() => { actionCalled = true; });

            //Act       
            var result = obj.Do(action);

            //Assert
            Assert.AreEqual(obj, result);
            Assert.IsTrue(actionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_Do_ObjectNotNull_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = new object();
            bool actionCalled = false;
            Action action = new Action(() => { actionCalled = true; });

            //Act       
            var result = obj.Do(action);

            //Assert
            Assert.AreEqual(obj, result);
            Assert.IsTrue(actionCalled);
        }

        #endregion //Do

        #region " DoIf<T>(this T obj, bool condition, Action action) "

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIf_ObjectNull_ConditionTrue_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = null;
            bool condition = true;
            Action action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.DoIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIf_ObjectNotNull_ConditionTrue_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = new object();
            bool condition = true;
            Action action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.DoIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIf_ObjectNull_ConditionFalse_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = null;
            bool condition = false;
            Action action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.DoIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIf_ObjectNotNull_ConditionFalse_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = new object();
            bool condition = false;
            Action action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.DoIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIf_ObjectNull_ConditionTrue_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = null;
            bool condition = true;
            bool actionCalled = false;
            Action action = new Action(() => { actionCalled = true; });

            //Act       
            var result = obj.DoIf(condition, action);

            //Assert
            Assert.AreEqual(obj, result);
            Assert.IsTrue(actionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIf_ObjectNotNull_ConditionTrue_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = new object();
            bool condition = true;
            bool actionCalled = false;
            Action action = new Action(() => { actionCalled = true; });

            //Act       
            var result = obj.DoIf(condition, action);

            //Assert
            Assert.AreEqual(obj, result);
            Assert.IsTrue(actionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIf_ObjectNull_ConditionFalse_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = null;
            bool condition = false;
            bool actionCalled = false;
            Action action = new Action(() => { actionCalled = true; });

            //Act       
            var result = obj.DoIf(condition, action);

            //Assert
            Assert.AreEqual(obj, result);
            Assert.IsFalse(actionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIf_ObjectNotNull_ConditionFalse_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = new object();
            bool condition = false;
            bool actionCalled = false;
            Action action = new Action(() => { actionCalled = true; });

            //Act       
            var result = obj.DoIf(condition, action);

            //Assert
            Assert.AreEqual(obj, result);
            Assert.IsFalse(actionCalled);
        }

        #endregion //DoIf<T>(this T obj, bool condition, Action action)

        #region " DoIf<T>(this T obj, Func<T, bool> condition, Action action) "

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIfFunc_ObjectNull_ConditionNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = null;
            object objReceived = new object();
            Func<object, bool> condition = null;
            Action action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.DoIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("condition"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIfFunc_ObjectNotNull_ConditionNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = new object();
            Func<object, bool> condition = null;
            Action action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.DoIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("condition"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIfFunc_ObjectNull_ConditionTrue_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = null;
            bool conditionCalled = false;
            bool conditionValue = true;
            Func<object, bool> condition = o => { conditionCalled = true; return conditionValue; };
            Action action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.DoIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
            Assert.IsFalse(conditionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIfFunc_ObjectNotNull_ConditionTrue_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = new object();
            bool conditionCalled = false;
            bool conditionValue = true;
            Func<object, bool> condition = o => { conditionCalled = true; return conditionValue; };
            Action action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.DoIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
            Assert.IsFalse(conditionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIfFunc_ObjectNull_ConditionFalse_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = null;
            bool conditionCalled = false;
            bool conditionValue = false;
            Func<object, bool> condition = o => { conditionCalled = true; return conditionValue; };
            Action action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.DoIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
            Assert.IsFalse(conditionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIfFunc_ObjectNotNull_ConditionFalse_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = new object();
            bool conditionCalled = false;
            bool conditionValue = false;
            Func<object, bool> condition = o => { conditionCalled = true; return conditionValue; };
            Action action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.DoIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("action"));
            Assert.IsFalse(conditionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIfFunc_ObjectNull_ConditionTrue_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = null;
            bool conditionCalled = false;
            object objReceived = new object();
            bool conditionValue = true;
            Func<object, bool> condition = o => { conditionCalled = true; objReceived = o; return conditionValue; };
            bool actionCalled = false;
            Action action = new Action(() => { actionCalled = true; });

            //Act       
            var result = obj.DoIf(condition, action);

            //Assert
            Assert.IsTrue(conditionCalled);
            Assert.AreEqual(obj, objReceived);
            Assert.AreEqual(obj, result);
            Assert.IsTrue(actionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIfFunc_ObjectNotNull_ConditionTrue_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = new object();
            bool conditionCalled = false;
            object objReceived = new object();
            bool conditionValue = true;
            Func<object, bool> condition = o => { conditionCalled = true; objReceived = o; return conditionValue; };
            bool actionCalled = false;
            Action action = new Action(() => { actionCalled = true; });

            //Act       
            var result = obj.DoIf(condition, action);

            //Assert
            Assert.IsTrue(conditionCalled);
            Assert.AreEqual(obj, objReceived);
            Assert.AreEqual(obj, result);
            Assert.IsTrue(actionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIfFunc_ObjectNull_ConditionFalse_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = null;
            bool conditionCalled = false;
            object objReceived = new object();
            bool conditionValue = false;
            Func<object, bool> condition = o => { conditionCalled = true; objReceived = o; return conditionValue; };
            bool actionCalled = false;
            Action action = new Action(() => { actionCalled = true; });

            //Act       
            var result = obj.DoIf(condition, action);

            //Assert
            Assert.IsTrue(conditionCalled);
            Assert.AreEqual(obj, objReceived);
            Assert.AreEqual(obj, result);
            Assert.IsFalse(actionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIfFunc_ObjectNotNull_ConditionFalse_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = new object();
            bool conditionCalled = false;
            object objReceived = new object();
            bool conditionValue = false;
            Func<object, bool> condition = o => { conditionCalled = true; objReceived = o; return conditionValue; };
            bool actionCalled = false;
            Action action = new Action(() => { actionCalled = true; });

            //Act       
            var result = obj.DoIf(condition, action);

            //Assert
            Assert.IsTrue(conditionCalled);
            Assert.AreEqual(obj, objReceived);
            Assert.AreEqual(obj, result);
            Assert.IsFalse(actionCalled);
        }

        #endregion //DoIf<T>(this T obj, Func<T, bool> condition, Action action)

        #region " DoIfNotNull<T>(this T obj, Action action) "

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIfNotNull_ObjectNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = null;
            Action action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.DoIfNotNull(action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIfNotNull_ObjectNotNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            object obj = new object();
            Action action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.DoIfNotNull(action));
            Assert.IsTrue(exception.Message.Contains("action"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIfNotNull_ObjectNull_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = null;
            bool actionCalled = false;
            Action action = new Action(() => { actionCalled = true; });

            //Act       
            var result = obj.DoIfNotNull(action);

            //Assert
            Assert.AreEqual(obj, result);
            Assert.IsFalse(actionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_DoIfNotNull_ObjectNotNull_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            object obj = new object();
            bool actionCalled = false;
            Action action = new Action(() => { actionCalled = true; });

            //Act       
            var result = obj.DoIfNotNull(action);

            //Assert
            Assert.AreEqual(obj, result);
            Assert.IsTrue(actionCalled);
        }

        #endregion //DoIfNotNull<T>(this T obj, Action action)
    }
}
