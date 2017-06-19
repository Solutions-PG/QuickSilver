using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.Tests.Extensions
{
    [TestClass]
    public class ThrowTests
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

        #region " Throw "

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_Throw_ObjectNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = null;
            Func<string, Exception> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.Throw(action));
            Assert.IsTrue(exception.Message.Contains("createException"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_Throw_ObjectNotNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = "test";
            Func<string, Exception> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.Throw(action));
            Assert.IsTrue(exception.Message.Contains("createException"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_Throw_ObjectNull_ActionNotNull_ThrowExpectedException()
        {
            //Arrange
            string obj = null;
            bool actionCalled = false;
            string objReceivedAction = "actionTest";
            Func<string, NotSupportedException> action = new Func<string, NotSupportedException>(o => { actionCalled = true;  objReceivedAction = o; return new NotSupportedException(); });

            //Act & Assert
            var result = Assert.ThrowsException<NotSupportedException>(() => obj.Throw(action));
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceivedAction);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_Throw_ObjectNotNull_ActionNotNull_ThrowExpectedException()
        {
            //Arrange
            string obj = "test";
            bool actionCalled = false;
            string objReceivedAction = "actionTest";
            Func<string, NotSupportedException> action = new Func<string, NotSupportedException>(o => { actionCalled = true; objReceivedAction = o; return new NotSupportedException(); });

            //Act & Assert
            var result = Assert.ThrowsException<NotSupportedException>(() => obj.Throw(action));
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceivedAction);
        }

        #endregion //Throw

        #region " ThrowIf<T, TException>(this T obj, bool condition, Func<T, TException> action) "

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIf_ObjectNull_ConditionTrue_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = null;
            bool condition = true;
            Func<string, Exception> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ThrowIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("createException"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIf_ObjectNotNull_ConditionTrue_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = "test";
            bool condition = true;
            Func<string, Exception> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ThrowIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("createException"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIf_ObjectNull_ConditionFalse_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = null;
            bool condition = false;
            Func<string, Exception> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ThrowIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("createException"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIf_ObjectNotNull_ConditionFalse_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = "test";
            bool condition = false;
            Func<string, Exception> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ThrowIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("createException"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIf_ObjectNull_ConditionTrue_ActionNotNull_ThrowExpectedException()
        {
            //Arrange
            string obj = null;
            bool condition = true;
            bool actionCalled = false;
            string objReceivedAction = "actionTest";
            Func<string, NotSupportedException> action = new Func<string, NotSupportedException>(o => { actionCalled = true; objReceivedAction = o; return new NotSupportedException(); });

            //Act & Assert
            var result = Assert.ThrowsException<NotSupportedException>(() => obj.ThrowIf(condition, action));
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceivedAction);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIf_ObjectNotNull_ConditionTrue_ActionNotNull_ThrowExpectedException()
        {
            //Arrange
            string obj = "test";
            bool condition = true;
            bool actionCalled = false;
            string objReceivedAction = "actionTest";
            Func<string, NotSupportedException> action = new Func<string, NotSupportedException>(o => { actionCalled = true; objReceivedAction = o; return new NotSupportedException(); });

            //Act & Assert
            var result = Assert.ThrowsException<NotSupportedException>(() => obj.ThrowIf(condition, action));
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceivedAction);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIf_ObjectNull_ConditionFalse_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            string obj = null;
            bool condition = false;
            bool actionCalled = false;
            Func<string, NotSupportedException> action = new Func<string, NotSupportedException>(o => { actionCalled = true; return new NotSupportedException(); });

            //Act       
            var result = obj.ThrowIf(condition, action);

            //Assert
            Assert.IsFalse(actionCalled);
            Assert.AreEqual(obj, result);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIf_ObjectNotNull_ConditionFalse_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            string obj = "test";
            bool condition = false;
            bool actionCalled = false;
            Func<string, NotSupportedException> action = new Func<string, NotSupportedException>(o => { actionCalled = true; return new NotSupportedException(); });

            //Act       
            var result = obj.ThrowIf(condition, action);

            //Assert
            Assert.IsFalse(actionCalled);
            Assert.AreEqual(obj, result);
        }

        #endregion //ThrowIf<T, TException>(this T obj, bool condition, Func<T, TException> action)

        #region " ThrowIf<T, TException>(this T obj, Func<T, bool> condition, Func<T, TException> action) "

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIfFunc_ObjectNull_ConditionNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = null;
            Func<string, bool> condition = null;
            Func<string, Exception> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ThrowIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("condition"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIfFunc_ObjectNotNull_ConditionNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = "test";
            Func<string, bool> condition = null;
            Func<string, Exception> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ThrowIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("condition"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIfFunc_ObjectNull_ConditionTrue_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = null;
            bool conditionCalled = false;
            bool conditionValue = true;
            Func<string, bool> condition = o => { conditionCalled = true; return conditionValue; };
            Func<string, Exception> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ThrowIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("createException"));
            Assert.IsFalse(conditionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIfFunc_ObjectNotNull_ConditionTrue_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = "test";
            bool conditionCalled = false;
            bool conditionValue = true;
            Func<string, bool> condition = o => { conditionCalled = true; return conditionValue; };
            Func<string, Exception> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ThrowIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("createException"));
            Assert.IsFalse(conditionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIfFunc_ObjectNull_ConditionFalse_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = null;
            bool conditionCalled = false;
            bool conditionValue = false;
            Func<string, bool> condition = o => { conditionCalled = true; return conditionValue; };
            Func<string, Exception> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ThrowIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("createException"));
            Assert.IsFalse(conditionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIfFunc_ObjectNotNull_ConditionFalse_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = "test";
            bool conditionCalled = false;
            bool conditionValue = false;
            Func<string, bool> condition = o => { conditionCalled = true; return conditionValue; };
            Func<string, Exception> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ThrowIf(condition, action));
            Assert.IsTrue(exception.Message.Contains("createException"));
            Assert.IsFalse(conditionCalled);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIfFunc_ObjectNull_ConditionTrue_ActionNotNull_ThrowExpectedException()
        {
            //Arrange
            string obj = null;
            bool conditionCalled = false;
            string objReceivedCondition = "conditonTest";
            bool conditionValue = true;
            Func<string, bool> condition = o => { conditionCalled = true; objReceivedCondition = o; return conditionValue; };
            bool actionCalled = false;
            string objReceivedAction = "actionTest";
            Func<string, NotSupportedException> action = new Func<string, NotSupportedException>(o => { actionCalled = true; objReceivedAction = o; return new NotSupportedException(); });

            //Act & Assert
            Assert.ThrowsException<NotSupportedException>(() => obj.ThrowIf(condition, action));
            Assert.IsTrue(conditionCalled);
            Assert.AreEqual(obj, objReceivedCondition);
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceivedAction);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIfFunc_ObjectNotNull_ConditionTrue_ActionNotNull_ThrowExpectedException()
        {
            //Arrange
            string obj = "test";
            bool conditionCalled = false;
            string objReceivedCondition = "conditonTest";
            bool conditionValue = true;
            Func<string, bool> condition = o => { conditionCalled = true; objReceivedCondition = o; return conditionValue; };
            bool actionCalled = false;
            string objReceivedAction = "actionTest";
            Func<string, NotSupportedException> action = new Func<string, NotSupportedException>(o => { actionCalled = true; objReceivedAction = o; return new NotSupportedException(); });

            //Act & Assert
            Assert.ThrowsException<NotSupportedException>(() => obj.ThrowIf(condition, action));
            Assert.IsTrue(conditionCalled);
            Assert.AreEqual(obj, objReceivedCondition);
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceivedAction);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIfFunc_ObjectNull_ConditionFalse_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            string obj = null;
            bool conditionCalled = false;
            string objReceivedCondition = "conditonTest";
            bool conditionValue = false;
            Func<string, bool> condition = o => { conditionCalled = true; objReceivedCondition = o; return conditionValue; };
            bool actionCalled = false;
            Func<string, NotSupportedException> action = new Func<string, NotSupportedException>(o => { actionCalled = true; return new NotSupportedException(); });

            //Act       
            var result = obj.ThrowIf(condition, action);

            //Assert
            Assert.IsTrue(conditionCalled);
            Assert.AreEqual(obj, objReceivedCondition);
            Assert.IsFalse(actionCalled);
            Assert.AreEqual(obj, result);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIfFunc_ObjectNotNull_ConditionFalse_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            string obj = "test";
            bool conditionCalled = false;
            string objReceivedCondition = "conditonTest";
            bool conditionValue = false;
            Func<string, bool> condition = o => { conditionCalled = true; objReceivedCondition = o; return conditionValue; };
            bool actionCalled = false;
            Func<string, NotSupportedException> action = new Func<string, NotSupportedException>(o => { actionCalled = true; return new NotSupportedException(); });

            //Act       
            var result = obj.ThrowIf(condition, action);

            //Assert
            Assert.IsTrue(conditionCalled);
            Assert.AreEqual(obj, objReceivedCondition);
            Assert.IsFalse(actionCalled);
            Assert.AreEqual(obj, result);
        }

        #endregion //ThrowIf<T, TException>(this T obj, Func<T, bool> condition, Func<T, TException> action)

        #region " ThrowIfNull<T, TException>(this T obj, Func<T, TException> action) "

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIfNull_ObjectNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = null;
            Func<string, Exception> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ThrowIfNull(action));
            Assert.IsTrue(exception.Message.Contains("createException"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIfNull_ObjectNotNull_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            string obj = "test";
            Func<string, Exception> action = null;

            //Act & Assert
            var exception = Assert.ThrowsException<ArgumentNullException>(() => obj.ThrowIfNull(action));
            Assert.IsTrue(exception.Message.Contains("createException"));
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIfNull_ObjectNull_ActionNotNull_ThrowExpectedException()
        {
            //Arrange
            string obj = null;
            bool actionCalled = false;
            string objReceivedAction = "actionTest";
            Func<string, NotSupportedException> action = new Func<string, NotSupportedException>(o => { actionCalled = true; objReceivedAction = o; return new NotSupportedException(); });

            //Act & Assert
            var result = Assert.ThrowsException<NotSupportedException>(() => obj.ThrowIfNull(action));
            Assert.IsTrue(actionCalled);
            Assert.AreEqual(obj, objReceivedAction);
        }

        [TestMethod, TestCategory("Commons.Extensions"), TestCategory("Commons.Extensions.Objects")]
        public void ObjectExtensions_ThrowIfNull_ObjectNotNull_ActionNotNull_ReturnCallerObject()
        {
            //Arrange
            string obj = "test";
            bool actionCalled = false;
            Func<string, NotSupportedException> action = new Func<string, NotSupportedException>(o => { actionCalled = true; return new NotSupportedException(); });

            //Act       
            var result = obj.ThrowIfNull(action);

            //Assert
            Assert.IsFalse(actionCalled);
            Assert.AreEqual(obj, result);
        }

        #endregion //ThrowIfNull<T, TException>(this T obj, Func<T, TException> action)
    }
}
