using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionsPG.QuickSilver.Core.System;
using NSubstitute;
using SolutionsPG.QuickSilver.Test.Core;
using SolutionsPG.QuickSilver.Core.Exceptions;


namespace SolutionsPG.QuickSilver.Core.Tests.System
{
    [TestClass()]
    public class ServiceLocatorTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            ServiceLocator.SetProvider(null);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.ServiceLocator")]
        public void System_ServiceLocator_SetProvider_ValidProvider_ProviderDefined()
        {
            //Arrange
            var serviceLocator = Substitute.For<IServiceLocator>();
            Func<IServiceLocator> serviceLocatorProvider = () => serviceLocator;

            //Act
            ServiceLocator.SetProvider(serviceLocatorProvider);

            //Assert
            Assert.AreEqual(serviceLocator, ServiceLocator.Instance);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.ServiceLocator")]
        public void System_ServiceLocator_SetProvider_ProviderExist_ProviderAlreadySetException()
        {
            //Arrange
            var serviceLocator1 = Substitute.For<IServiceLocator>();
            var serviceLocator2 = Substitute.For<IServiceLocator>();
            ServiceLocator.SetProvider(() => serviceLocator1);

            //Act
            ServiceLocator.SetProvider(() => serviceLocator2);

            //Assert
            Assert.AreEqual(serviceLocator2, ServiceLocator.Instance);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.ServiceLocator")]
        public void System_ServiceLocator_Instance_ProviderDefined_ReturnProvider()
        {
            //Arrange
            var serviceLocator = Substitute.For<IServiceLocator>();
            ServiceLocator.SetProvider(() => serviceLocator);

            //Act
            IServiceLocator result = ServiceLocator.Instance;

            //Assert
            Assert.AreEqual(serviceLocator, result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.ServiceLocator")]
        public void System_ServiceLocator_Instance_ProviderNotDefined_ReturnException()
        {
            //Arrange

            //Act
            var exception = Act.GetException<InvalidOperationException>(() =>
            {
                var result = ServiceLocator.Instance;
            });

            //Assert
            Assert.IsNotNull(exception);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.ServiceLocator")]
        public void System_ServiceLocator_IsProviderDefined_ProviderDefined_ReturnTrue()
        {
            //Arrange
            var serviceLocator = Substitute.For<IServiceLocator>();
            Func<IServiceLocator> serviceLocatorProvider = () => serviceLocator;
            ServiceLocator.SetProvider(serviceLocatorProvider);

            //Act
            var resultReturned = ServiceLocator.IsProviderDefined;

            //Assert
            Assert.IsTrue(resultReturned);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.ServiceLocator")]
        public void System_ServiceLocator_IsProviderDefined_ProviderDefinedThenNull_ReturnFalse()
        {
            //Arrange
            var serviceLocator = Substitute.For<IServiceLocator>();
            ServiceLocator.SetProvider(() => serviceLocator);
            ServiceLocator.SetProvider(null);

            //Act
            var resultReturned = ServiceLocator.IsProviderDefined;

            //Assert
            Assert.IsFalse(resultReturned);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.ServiceLocator")]
        public void System_ServiceLocator_IsProviderDefined_ProviderReDefined_ReturnTrue()
        {
            //Arrange
            var serviceLocator1 = Substitute.For<IServiceLocator>();
            var serviceLocator2 = Substitute.For<IServiceLocator>();
            ServiceLocator.SetProvider(() => serviceLocator1);
            ServiceLocator.SetProvider(() => serviceLocator2);

            //Act
            var resultReturned = ServiceLocator.IsProviderDefined;

            //Assert
            Assert.IsTrue(resultReturned);
        }
    }
}