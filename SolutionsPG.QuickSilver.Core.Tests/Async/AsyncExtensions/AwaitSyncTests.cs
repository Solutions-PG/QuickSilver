using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionsPG.QuickSilver.Core.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SolutionsPG.QuickSilver.Core.System;
using SolutionsPG.QuickSilver.Test.Core;

namespace SolutionsPG.QuickSilver.Core.Async.Tests
{
    [TestClass()]
    public partial class AsyncExTests
    {
        #region " void AwaitSync(this Func<Task> action) "

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSync_ActionNull_ThrowArgumentNullException()
        {
            //Arrange


            //Act
            var exception = Act.GetException<ArgumentNullException>(() => ((Func<Task>)null).AwaitSync());

            //Assert
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSync_ActionWithoutAwait_ReturnDelegateRunWithoutError()
        {
            //Arrange
            bool hasRun = false;
            Task task = null;
            Func<Task> func = () =>
            {
                hasRun = true;
                return (task = Task.CompletedTask);
            };

            //Act
            func.AwaitSync();

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(task);
            Assert.IsTrue(task.IsCompleted);
            Assert.IsFalse(task.IsFaulted);
            Assert.IsFalse(task.IsCanceled);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSync_ActionThrowExceptionWithoutAwait_ReturnException()
        {
            //Arrange
            bool hasRun = false;
            Task task = null;
            Func<Task> func = () =>
            {
                hasRun = true;
                task = Task.CompletedTask;
                Throw<NotImplementedException>();
                return task;
            };

            //Act
            var exception = Act.GetException<NotImplementedException>(() => func.AwaitSync());

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(exception);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSync_ActionWithAwait_ReturnWithoutError()
        {
            //Arrange
            bool hasRun = false;
            Task task = null;
            Func<Task> func = async () =>
            {
                hasRun = true;
                await (task = Task.CompletedTask);
            };

            //Act
            func.AwaitSync();

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(task);
            Assert.IsTrue(task.IsCompleted);
            Assert.IsFalse(task.IsFaulted);
            Assert.IsFalse(task.IsCanceled);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSync_ActionThrowExceptionWithAwait_ReturnException()
        {
            //Arrange
            bool hasRun = false;
            Task task = null;
            Func<Task> func = async () =>
            {
                hasRun = true;
                task = Task.CompletedTask;
                Throw<NotImplementedException>();
                await task;
            };

            //Act
            var exception = Act.GetException<NotImplementedException>(() => func.AwaitSync());

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(exception);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSync_ActionWithTwoAwaitDeep_ReturnWithoutError()
        {
            //Arrange
            bool hasRun = false;
            Task task = null;
            Func<Task> func = async () =>
            {
                hasRun = true;
                await (task = Task.Run(async () => await Task.Yield()));
            };

            //Act
            func.AwaitSync();

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(task);
            Assert.IsTrue(task.IsCompleted);
            Assert.IsFalse(task.IsFaulted);
            Assert.IsFalse(task.IsCanceled);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSync_ActionThrowExceptionWithTwoAwaitDeep_ReturnException()
        {
            //Arrange
            bool hasRun = false;
            Task task = null;
            Func<Task> func = async () =>
            {
                hasRun = true;
                await (task = Task.Run(async () =>
                {
                    await Task.Yield();
                    Throw<NotImplementedException>();
                }));
            };

            //Act
            var exception = Act.GetException<NotImplementedException>(() => func.AwaitSync());

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(exception);
        }

        #endregion //void AwaitSync(this Func<Task> action)


        private static void Throw<TException>() where TException : Exception, new()
        {
            throw FastActivator<TException>.CreateInstance();
        }
    }
}