using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SolutionsPG.QuickSilver.Core.Tests.Async.AsyncExtensions
{
    [TestClass]
    public class FromResultTests
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

        #region " FromResult "

        [TestMethod, TestCategory("Core.Async"), TestCategory("_Unit")]
        public void AsyncExtensions_FromResult_ActionNull_ReturnArgumentNullExceptionThrown()
        {
            //Arrange

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => Core.Async.AsyncExtensions.FromResult((Func<int>) null),
                "ArgumentNullException should have been thrown");
        }

        [TestMethod, TestCategory("Core.Async"), TestCategory("_Unit")]
        public async Task AsyncExtensions_FromResult_ActionValid_ReturnTaskContainingException()
        {
            //Arrange
            bool actionCalled = false;
            Func<int> action = () =>
            {
                actionCalled = true;
                throw new NotSupportedException();
            };

            //Act
            Task<int> result = Core.Async.AsyncExtensions.FromResult(action);

            //Assert
            Assert.IsTrue(actionCalled, "The delegate should have been called");
            await Assert.ThrowsExceptionAsync<NotSupportedException>(async () => await result, "NotSupportedException should have been thrown");
        }

        [TestMethod, TestCategory("Core.Async"), TestCategory("_Unit")]
        public async Task AsyncExtensions_FromResult_ActionValid_ReturnTaskContainingValue()
        {
            //Arrange
            bool actionCalled = false;
            int returnValue = 4;

            int FuncAction()
            {
                actionCalled = true;
                return returnValue;
            }

            //Act
            int result = await Core.Async.AsyncExtensions.FromResult(FuncAction);

            //Assert
            Assert.IsTrue(actionCalled, "The delegate should have been called");
            Assert.AreEqual(returnValue, result, "The result should equals the value returned by the action");
        }

        #endregion //FromResult
    }
}
