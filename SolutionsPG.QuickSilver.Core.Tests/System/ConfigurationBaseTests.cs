using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionsPG.QuickSilver.Core.System;
using NSubstitute;
using SolutionsPG.QuickSilver.Test.Core;
using SolutionsPG.QuickSilver.Core.Exceptions;
using SolutionsPG.QuickSilver.Core.System.ServiceLocation;


namespace SolutionsPG.QuickSilver.Core.Tests.System
{
    [TestClass()]
    public class ConfigurationBaseTests
    {
        #region | Initialization |

        private ConfigurationStub _configuration;
        private IServiceLocator _serviceLocator;

        [TestInitialize]
        public void TestInitialize()
        {
            _configuration = new ConfigurationStub(false);
            _serviceLocator = Substitute.For<IServiceLocator>();
        }

        #endregion //Initialization
        
        #region | Configure |

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.ConfigurationBase")]
        public void System_ConfigurationBase_Configure_NewConfiguration_ResultImplCalled()
        {
            //Arrange

            //Act
            _configuration.Configure(_serviceLocator);

            //Assert
            Assert.IsTrue(_configuration.ImplCalled);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.ConfigurationBase")]
        public void System_ConfigurationBase_Configure_Ignored_ResultImplNotCalled()
        {
            //Arrange
            bool ignore = true;
            _configuration = new ConfigurationStub(ignore);

            //Act
            _configuration.Configure(_serviceLocator);

            //Assert
            Assert.IsFalse(_configuration.ImplCalled);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.ConfigurationBase")]
        public void System_ConfigurationBase_Configure_NewConfiguration_ResultIsConfigured()
        {
            //Arrange

            //Act
            _configuration.Configure(_serviceLocator);

            //Assert
            Assert.IsTrue(_configuration.Configured);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.ConfigurationBase")]
        public void System_ConfigurationBase_Configure_ConfigurationAlreadyConfigured_ResultNoException()
        {
            //Arrange
            _configuration.Configure(_serviceLocator);

            //Act
            Exception exception = Act.GetException<Exception>(() => _configuration.Configure(_serviceLocator));

            //Assert
            Assert.IsNull(exception);
        }

        #endregion //Configure

        #region | Private |

        private class ConfigurationStub : ConfigurationBase
        {
            public bool ImplCalled { get; private set; } = false;

            public ConfigurationStub(bool ignore) : base(ignore)
            {

            }

            protected override void ConfigureImpl(IServiceLocator container)
            {
                ImplCalled = true;
            }
        }

        #endregion //Private
    }
}