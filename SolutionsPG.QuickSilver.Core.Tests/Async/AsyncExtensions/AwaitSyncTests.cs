using System;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SolutionsPG.QuickSilver.Core.Async;
using SolutionsPG.QuickSilver.Core.System;
using SolutionsPG.QuickSilver.Test.Core;

namespace SolutionsPG.QuickSilver.Core.Tests.Async
{
    [TestClass()]
    public class AwaitSyncTests
    {
        #region | void AwaitSync(this Func<Task> action) |

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
        
        #region | void AwaitSync<T>(this Func<Task<T>> action) |

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncGeneric_ActionNull_ThrowArgumentNullException()
        {
            //Arrange


            //Act
            var exception = Act.GetException<ArgumentNullException>(() => ((Func<Task<int>>)null).AwaitSync());

            //Assert
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncGeneric_ActionWithoutAwait_ReturnDelegateRunWithoutError()
        {
            //Arrange
            bool hasRun = false;
            Task<int> task = null;
            const int ExpectedValue = 4;
            Func<Task<int>> func = () =>
            {
                hasRun = true;
                return (task = Task.FromResult(ExpectedValue));
            };

            //Act
            int result = func.AwaitSync();

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(task);
            Assert.IsTrue(task.IsCompleted);
            Assert.IsFalse(task.IsFaulted);
            Assert.IsFalse(task.IsCanceled);
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncGeneric_ActionThrowExceptionWithoutAwait_ReturnException()
        {
            //Arrange
            bool hasRun = false;
            Task<int> task = null;
            const int ExpectedValue = 4;
            Func<Task<int>> func = () =>
            {
                hasRun = true;
                task = Task.FromResult(ExpectedValue);
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
        public void AsyncEx_AwaitSyncGeneric_ActionWithAwait_ReturnWithoutError()
        {
            //Arrange
            bool hasRun = false;
            Task<int> task = null;
            const int ExpectedValue = 4;
            Func<Task<int>> func = async () =>
            {
                task = Task.FromResult(ExpectedValue);
                hasRun = true;
                return await task;
            };

            //Act
            int result = func.AwaitSync();

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(task);
            Assert.IsTrue(task.IsCompleted);
            Assert.IsFalse(task.IsFaulted);
            Assert.IsFalse(task.IsCanceled);
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncGeneric_ActionThrowExceptionWithAwait_ReturnException()
        {
            //Arrange
            bool hasRun = false;
            Task<int> task = null;
            const int ExpectedValue = 4;
            Func<Task<int>> func = async () =>
            {
                hasRun = true;
                task = Task.FromResult(ExpectedValue);
                Throw<NotImplementedException>();
                return await task;
            };

            //Act
            var exception = Act.GetException<NotImplementedException>(() => func.AwaitSync());

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(exception);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncGeneric_ActionWithTwoAwaitDeep_ReturnWithoutError()
        {
            //Arrange
            bool hasRun = false;
            Task<int> task = null;
            const int ExpectedValue = 4;
            Func<Task<int>> func = async () =>
            {
                hasRun = true;
                return await (task = Task.Run(async () =>
                {
                    await Task.Yield();
                    return ExpectedValue;
                }));
            };

            //Act
            int result = func.AwaitSync();

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(task);
            Assert.IsTrue(task.IsCompleted);
            Assert.IsFalse(task.IsFaulted);
            Assert.IsFalse(task.IsCanceled);
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncGeneric_ActionThrowExceptionWithTwoAwaitDeep_ReturnException()
        {
            //Arrange
            bool hasRun = false;
            Task<int> task = null;
            const int ExpectedValue = 4;
            Func<Task<int>> func = async () =>
            {
                hasRun = true;
                return await (task = Task.Run(async () =>
                {
                    await Task.Yield();
                    Throw<NotImplementedException>();
                    return ExpectedValue;
                }));
            };

            //Act
            var exception = Act.GetException<NotImplementedException>(() => func.AwaitSync());

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(exception);
        }

        #endregion //void AwaitSync<T>(this Func<Task<T>> action)

        #region | void AwaitSync(this Func<Task> action, Action configureThreadStatic) |

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncThreadStatic_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            void ConfigureThreadStatic() { }

            ;

            //Act
            var exception = Act.GetException<ArgumentNullException>(() => ((Func<Task>)null).AwaitSync(ConfigureThreadStatic));

            //Assert
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncThreadStatic_ConfigureThreadStaticNull_ThrowArgumentNullException()
        {
            //Arrange
            Func<Task> func = () => Task.CompletedTask;

            //Act
            var exception = Act.GetException<ArgumentNullException>(() => func.AwaitSync((Action)null));

            //Assert
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncThreadStatic_ActionWithoutAwait_ReturnDelegateRunWithoutError()
        {
            //Arrange
            bool hasRun = false;
            Task task = null;
            Func<Task> func = () =>
            {
                hasRun = true;
                return (task = Task.CompletedTask);
            };
            bool hasConfigRun = false;
            void ConfigureThreadStatic() => hasConfigRun = true;

            //Act
            func.AwaitSync(ConfigureThreadStatic);

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(task);
            Assert.IsTrue(task.IsCompleted);
            Assert.IsFalse(task.IsFaulted);
            Assert.IsFalse(task.IsCanceled);
            Assert.IsTrue(hasConfigRun);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncThreadStatic_ActionThrowExceptionWithoutAwait_ReturnException()
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
            bool hasConfigRun = false;
            void ConfigureThreadStatic() => hasConfigRun = true;

            //Act
            var exception = Act.GetException<NotImplementedException>(() => func.AwaitSync(ConfigureThreadStatic));

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(exception);
            Assert.IsTrue(hasConfigRun);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncThreadStatic_ActionWithAwait_ReturnWithoutError()
        {
            //Arrange
            bool hasRun = false;
            Task task = null;
            Func<Task> func = async () =>
            {
                hasRun = true;
                await (task = Task.CompletedTask);
            };
            bool hasConfigRun = false;
            void ConfigureThreadStatic() => hasConfigRun = true;

            //Act
            func.AwaitSync(ConfigureThreadStatic);

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(task);
            Assert.IsTrue(task.IsCompleted);
            Assert.IsFalse(task.IsFaulted);
            Assert.IsFalse(task.IsCanceled);
            Assert.IsTrue(hasConfigRun);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncThreadStatic_ActionThrowExceptionWithAwait_ReturnException()
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
            bool hasConfigRun = false;
            void ConfigureThreadStatic() => hasConfigRun = true;

            //Act
            var exception = Act.GetException<NotImplementedException>(() => func.AwaitSync(ConfigureThreadStatic));

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(exception);
            Assert.IsTrue(hasConfigRun);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncThreadStatic_ActionWithTwoAwaitDeep_ReturnWithoutError()
        {
            //Arrange
            bool hasRun = false;
            Task task = null;
            Func<Task> func = async () =>
            {
                hasRun = true;
                await (task = Task.Run(async () => await Task.Yield()));
            };
            bool hasConfigRun = false;
            void ConfigureThreadStatic() => hasConfigRun = true;

            //Act
            func.AwaitSync(ConfigureThreadStatic);

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(task);
            Assert.IsTrue(task.IsCompleted);
            Assert.IsFalse(task.IsFaulted);
            Assert.IsFalse(task.IsCanceled);
            Assert.IsTrue(hasConfigRun);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncThreadStatic_ActionThrowExceptionWithTwoAwaitDeep_ReturnException()
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
            bool hasConfigRun = false;
            void ConfigureThreadStatic() => hasConfigRun = true;

            //Act
            var exception = Act.GetException<NotImplementedException>(() => func.AwaitSync(ConfigureThreadStatic));

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(exception);
            Assert.IsTrue(hasConfigRun);
        }

        #endregion //void AwaitSync(this Func<Task> action, Action configureThreadStatic)

        #region | void AwaitSync<T>(this Func<Task<T>> action, Action configureThreadStatic) |

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncThreadStaticGeneric_ActionNull_ThrowArgumentNullException()
        {
            //Arrange
            void ConfigureThreadStatic() { }

            ;

            //Act
            var exception = Act.GetException<ArgumentNullException>(() => ((Func<Task<int>>)null).AwaitSync(ConfigureThreadStatic));

            //Assert
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncThreadStaticGeneric_ConfigureThreadStaticNull_ThrowArgumentNullException()
        {
            //Arrange
            Func<Task<int>> func = () => Task.FromResult(4);

            //Act
            var exception = Act.GetException<ArgumentNullException>(() => func.AwaitSync((Action)null));

            //Assert
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncThreadStaticGeneric_ActionWithoutAwait_ReturnDelegateRunWithoutError()
        {
            //Arrange
            bool hasRun = false;
            Task<int> task = null;
            const int ExpectedValue = 4;
            Func<Task<int>> func = () =>
            {
                hasRun = true;
                return (task = Task.FromResult(ExpectedValue));
            };
            bool hasConfigRun = false;
            void ConfigureThreadStatic() => hasConfigRun = true;

            //Act
            int result = func.AwaitSync(ConfigureThreadStatic);

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(task);
            Assert.IsTrue(task.IsCompleted);
            Assert.IsFalse(task.IsFaulted);
            Assert.IsFalse(task.IsCanceled);
            Assert.IsTrue(hasConfigRun);
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncThreadStaticGeneric_ActionThrowExceptionWithoutAwait_ReturnException()
        {
            //Arrange
            bool hasRun = false;
            Task<int> task = null;
            const int ExpectedValue = 4;
            Func<Task<int>> func = () =>
            {
                hasRun = true;
                task = Task.FromResult(ExpectedValue);
                Throw<NotImplementedException>();
                return task;
            };
            bool hasConfigRun = false;
            void ConfigureThreadStatic() => hasConfigRun = true;

            //Act
            var exception = Act.GetException<NotImplementedException>(() => func.AwaitSync(ConfigureThreadStatic));

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(exception);
            Assert.IsTrue(hasConfigRun);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncThreadStaticGeneric_ActionWithAwait_ReturnWithoutError()
        {
            //Arrange
            bool hasRun = false;
            Task<int> task = null;
            const int ExpectedValue = 4;
            Func<Task<int>> func = async () =>
            {
                hasRun = true;
                return await (task = Task.FromResult(ExpectedValue));
            };
            bool hasConfigRun = false;
            void ConfigureThreadStatic() => hasConfigRun = true;

            //Act
            int result = func.AwaitSync(ConfigureThreadStatic);

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(task);
            Assert.IsTrue(task.IsCompleted);
            Assert.IsFalse(task.IsFaulted);
            Assert.IsFalse(task.IsCanceled);
            Assert.IsTrue(hasConfigRun);
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncThreadStaticGeneric_ActionThrowExceptionWithAwait_ReturnException()
        {
            //Arrange
            bool hasRun = false;
            Task<int> task = null;
            const int ExpectedValue = 4;
            Func<Task<int>> func = async () =>
            {
                hasRun = true;
                task = Task.FromResult(ExpectedValue);
                Throw<NotImplementedException>();
                return await task;
            };
            bool hasConfigRun = false;
            void ConfigureThreadStatic() => hasConfigRun = true;

            //Act
            var exception = Act.GetException<NotImplementedException>(() => func.AwaitSync(ConfigureThreadStatic));

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(exception);
            Assert.IsTrue(hasConfigRun);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncThreadStaticGeneric_ActionWithTwoAwaitDeep_ReturnWithoutError()
        {
            //Arrange
            bool hasRun = false;
            Task<int> task = null;
            const int ExpectedValue = 4;
            Func<Task<int>> func = async () =>
            {
                hasRun = true;
                return await (task = Task.Run(async () =>
                {
                    await Task.Yield();
                    return ExpectedValue;
                }));
            };
            bool hasConfigRun = false;
            void ConfigureThreadStatic() => hasConfigRun = true;

            //Act
            int result = func.AwaitSync(ConfigureThreadStatic);

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(task);
            Assert.IsTrue(task.IsCompleted);
            Assert.IsFalse(task.IsFaulted);
            Assert.IsFalse(task.IsCanceled);
            Assert.IsTrue(hasConfigRun);
            Assert.AreEqual(ExpectedValue, result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.Async"), TestCategory("Core.Async.AwaitSync")]
        public void AsyncEx_AwaitSyncThreadStaticGeneric_ActionThrowExceptionWithTwoAwaitDeep_ReturnException()
        {
            //Arrange
            bool hasRun = false;
            Task<int> task = null;
            const int ExpectedValue = 4;
            Func<Task<int>> func = async () =>
            {
                hasRun = true;
                return await(task = Task.Run(async () =>
                {
                    await Task.Yield();
                    Throw<NotImplementedException>();
                    return ExpectedValue;
                }));
            };
            bool hasConfigRun = false;
            void ConfigureThreadStatic() => hasConfigRun = true;

            //Act
            var exception = Act.GetException<NotImplementedException>(() => func.AwaitSync(ConfigureThreadStatic));

            //Assert
            Assert.IsTrue(hasRun);
            Assert.IsNotNull(exception);
            Assert.IsTrue(hasConfigRun);
        }

        #endregion //void AwaitSync<T>(this Func<Task<T>> action, Action configureThreadStatic)

        #region | Private methods |

        private static void Throw<TException>() where TException : Exception, new()
        {
            throw FastActivator<TException>.CreateInstance();
        }

        #endregion //Private methods
    }
}