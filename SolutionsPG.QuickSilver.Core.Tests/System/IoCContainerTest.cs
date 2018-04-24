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
    public class IoCContainerTest
    {
        #region | Initialization |

        private IoCContainer _iocContainer;

        [TestInitialize]
        public void TestInitialize()
        {
            _iocContainer = new IoCContainer();
        }

        #endregion //Initialization

        #region | Default |

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Default_ReturnNotNull()
        {
            //Arrange

            //Act
            IServiceLocator result = IoCContainer.Default;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Default_CalledTwice_ReturnSameReference()
        {
            //Arrange
            IServiceLocator firstCallResult = IoCContainer.Default;

            //Act
            IServiceLocator secondCallResult = IoCContainer.Default;

            //Assert
            Assert.AreEqual(firstCallResult, secondCallResult);
        }

        #endregion //Default

        #region | Resolve |

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_UnregisteredConcreteType_ReturnInstance()
        {
            //Arrange

            //Act
            ConcreteClass result = _iocContainer.Resolve<ConcreteClass>();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_UnregisteredConcreteTypeAlreadyResolved_ReturnNewInstance()
        {
            //Arrange
            ConcreteClass firstInstance = _iocContainer.Resolve<ConcreteClass>();

            //Act
            ConcreteClass result = _iocContainer.Resolve<ConcreteClass>();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(firstInstance, result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_UnregisteredConcreteType_ReturnConcreteTypeRegistered()
        {
            //Arrange

            //Act
            _iocContainer.Resolve<ConcreteClass>();

            //Assert
            Assert.IsTrue(_iocContainer.IsRegistered<ConcreteClass>());
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_UnregisteredInterface_ReturnException()
        {
            //Arrange

            //Act
            var exception = Act.GetException<InvalidOperationException>(() => _iocContainer.Resolve<IBase>());

            //Assert
            Assert.IsNotNull(exception);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_UnregisteredAbstract_ReturnException()
        {
            //Arrange

            //Act
            var exception = Act.GetException<InvalidOperationException>(() => _iocContainer.Resolve<DerivedAbstractClass>());

            //Assert
            Assert.IsNotNull(exception);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_UnregisteredConcreteClassWithParameterUnregisteredConcrete_ReturnInstance()
        {
            //Arrange

            //Act
            ConcreteClassWithParameterConcrete result = _iocContainer.Resolve<ConcreteClassWithParameterConcrete>();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_UnregisteredConcreteClassWithParameterUnregisteredConcrete_ReturnTypeIsRegistered()
        {
            //Arrange

            //Act
            _iocContainer.Resolve<ConcreteClassWithParameterConcrete>();

            //Assert
            Assert.IsTrue(_iocContainer.IsRegistered<ConcreteClassWithParameterConcrete>());
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_UnregisteredConcreteClassWithParameterUnregisteredInterface_ReturnInstance()
        {
            //Arrange

            //Act
            var exception = Act.GetException<InvalidOperationException>(() => _iocContainer.Resolve<ConcreteClassWithParameterInterface>());

            //Assert
            Assert.IsNotNull(exception);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_UnregisteredConcreteClassWithParameterUnregisteredAbstract_ReturnInstance()
        {
            //Arrange

            //Act
            var exception = Act.GetException<InvalidOperationException>(() => _iocContainer.Resolve<ConcreteClassWithParameterAbstact>());

            //Assert
            Assert.IsNotNull(exception);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_UnregisteredConcreteClassWithParameterRegisteredConcrete_ReturnInstance()
        {
            //Arrange
            _iocContainer.Register<ConcreteClass, ConcreteClass>();

            //Act
            ConcreteClassWithParameterConcrete result = _iocContainer.Resolve<ConcreteClassWithParameterConcrete>();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_UnregisteredConcreteClassWithParameterRegisteredInterface_ReturnInstance()
        {
            //Arrange
            _iocContainer.Register<IBase, ConcreteClass>();

            //Act
            ConcreteClassWithParameterInterface result = _iocContainer.Resolve<ConcreteClassWithParameterInterface>();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_UnregisteredConcreteClassWithParameterRegisteredAbstract_ReturnInstance()
        {
            //Arrange
            _iocContainer.Register<DerivedAbstractClass, ConcreteClass>();

            //Act
            ConcreteClassWithParameterAbstact result = _iocContainer.Resolve<ConcreteClassWithParameterAbstact>();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_RegisteredConcreteType_ReturnInstance()
        {
            //Arrange
            _iocContainer.Register<ConcreteClass, ConcreteClass>();

            //Act
            ConcreteClass result = _iocContainer.Resolve<ConcreteClass>();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_RegisteredInterface_ReturnInstance()
        {
            //Arrange
            _iocContainer.Register<IBase, ConcreteClass>();

            //Act
            IBase result = _iocContainer.Resolve<IBase>();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ConcreteClass));
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_RegisteredAbstract_ReturnInstance()
        {
            //Arrange
            _iocContainer.Register<DerivedAbstractClass, ConcreteClass>();

            //Act
            DerivedAbstractClass result = _iocContainer.Resolve<DerivedAbstractClass>();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ConcreteClass));
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_RegisteredConcreteTypeWithProvider_ReturnInstance()
        {
            //Arrange
            ConcreteClass expectedInstance = new ConcreteClass();
            _iocContainer.Register<ConcreteClass, ConcreteClass>(() => expectedInstance);

            //Act
            ConcreteClass returnedInstance = _iocContainer.Resolve<ConcreteClass>();

            //Assert
            Assert.IsNotNull(returnedInstance);
            Assert.AreEqual(expectedInstance, returnedInstance);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_RegisteredInterfaceWithProvider_ReturnInstance()
        {
            //Arrange
            ConcreteClass expectedInstance = new ConcreteClass();
            _iocContainer.Register<IBase, ConcreteClass>(() => expectedInstance);

            //Act
            IBase returnedInstance = _iocContainer.Resolve<IBase>();

            //Assert
            Assert.IsNotNull(returnedInstance);
            Assert.IsInstanceOfType(returnedInstance, typeof(ConcreteClass));
            Assert.AreEqual(expectedInstance, returnedInstance);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_RegisteredAbstractWithProvider_ReturnInstance()
        {
            //Arrange
            ConcreteClass expectedInstance = new ConcreteClass();
            _iocContainer.Register<DerivedAbstractClass, ConcreteClass>(() => expectedInstance);

            //Act
            DerivedAbstractClass returnedInstance = _iocContainer.Resolve<DerivedAbstractClass>();

            //Assert
            Assert.IsNotNull(returnedInstance);
            Assert.IsInstanceOfType(returnedInstance, typeof(ConcreteClass));
            Assert.AreEqual(expectedInstance, returnedInstance);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_ConcreteClassWithTwoConstructorDifferentQuantityOfParameter_ResultConstructorWithMostParametersWin()
        {
            //Arrange

            //Act
            var returnedInstance = _iocContainer.Resolve<ConcreteClassWithTwoConstructorDifferentQuantityOfParameter>();

            //Assert
            Assert.IsNotNull(returnedInstance);
            Assert.IsNotNull(returnedInstance.Obj);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_ConcreteClassWithTwoConstructorSameQuantityOfParameter_ReturnInvalidOperationException()
        {
            //Arrange

            //Act
            var returnedException = Act.GetException<InvalidOperationException>(
                () =>_iocContainer.Resolve<ConcreteClassWithTwoConstructorSameQuantityOfParameter>());

            //Assert
            Assert.IsNotNull(returnedException);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Resolve_ConcreteClassWithoutPublicConstructor_ReturnInvalidOperationException()
        {
            //Arrange

            //Act
            var returnedException = Act.GetException<InvalidOperationException>(
                () => _iocContainer.Resolve<ConcreteClassWithoutPublicConstructor>());

            //Assert
            Assert.IsNotNull(returnedException);
        }

        #endregion //Resolve

        #region | IsRegistered |

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_IsRegistered_UnregisteredConcreteType_ReturnFalse()
        {
            //Arrange

            //Act
            bool result = _iocContainer.IsRegistered<ConcreteClass>();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_IsRegistered_UnregisteredInterface_ReturnFalse()
        {
            //Arrange

            //Act
            bool result = _iocContainer.IsRegistered<IBase>();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_IsRegistered_UnregisteredAbstractType_ReturnFalse()
        {
            //Arrange

            //Act
            bool result = _iocContainer.IsRegistered<DerivedAbstractClass>();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_IsRegistered_RegisteredInterface_ReturnTrue()
        {
            //Arrange
            _iocContainer.Register<IBase, ConcreteClass>();

            //Act
            bool result = _iocContainer.IsRegistered<IBase>();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_IsRegistered_RegisteredAbstractType_ReturnTrue()
        {
            //Arrange
            _iocContainer.Register<DerivedAbstractClass, ConcreteClass>();

            //Act
            bool result = _iocContainer.IsRegistered<DerivedAbstractClass>();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_IsRegistered_RegisteredConcreteType_ReturnTrue()
        {
            //Arrange
            _iocContainer.Register<ConcreteClass, ConcreteClass>();

            //Act
            bool result = _iocContainer.IsRegistered<ConcreteClass>();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_IsRegistered_RegisteredInterfaceWithProvider_ReturnTrue()
        {
            //Arrange
            ConcreteClass expectedInstance = new ConcreteClass();
            _iocContainer.Register<IBase, ConcreteClass>(() => expectedInstance);

            //Act
            bool result = _iocContainer.IsRegistered<IBase>();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_IsRegistered_RegisteredAbstractTypeWithProvider_ReturnTrue()
        {
            //Arrange
            ConcreteClass expectedInstance = new ConcreteClass();
            _iocContainer.Register<DerivedAbstractClass, ConcreteClass>(() => expectedInstance);

            //Act
            bool result = _iocContainer.IsRegistered<DerivedAbstractClass>();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_IsRegistered_RegisteredConcreteTypeWithProvider_ReturnTrue()
        {
            //Arrange
            ConcreteClass expectedInstance = new ConcreteClass();
            _iocContainer.Register<ConcreteClass, ConcreteClass>(() => expectedInstance);

            //Act
            bool result = _iocContainer.IsRegistered<ConcreteClass>();

            //Assert
            Assert.IsTrue(result);
        }

        #endregion //IsRegistered

        #region | Register<IBase, IConcrete>() |

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Register_UnregisteredInterface_ResultIsRegistered()
        {
            //Arrange

            //Act
            _iocContainer.Register<IBase, ConcreteClass>();

            //Assert
            Assert.IsTrue(_iocContainer.IsRegistered<IBase>());
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Register_UnregisteredAbstractClass_ResultIsRegistered()
        {
            //Arrange

            //Act
            _iocContainer.Register<DerivedAbstractClass, ConcreteClass>();

            //Assert
            Assert.IsTrue(_iocContainer.IsRegistered<DerivedAbstractClass>());
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Register_UnregisteredConcreteClass_ResultIsRegistered()
        {
            //Arrange

            //Act
            _iocContainer.Register<ConcreteClass, ConcreteClass>();

            //Assert
            Assert.IsTrue(_iocContainer.IsRegistered<ConcreteClass>());
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Register_UnregisteredConcreteClassWithParameterUnregisteredConcrete_ResultIsRegistered()
        {
            //Arrange

            //Act
            _iocContainer.Register<ConcreteClassWithParameterConcrete, ConcreteClassWithParameterConcrete>();

            //Assert
            Assert.IsTrue(_iocContainer.IsRegistered<ConcreteClassWithParameterConcrete>());
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Register_UnregisteredConcreteClassWithParameterUnregisteredInterface_ResultIsRegistered()
        {
            //Arrange

            //Act
            _iocContainer.Register<ConcreteClassWithParameterInterface, ConcreteClassWithParameterInterface>();

            //Assert
            Assert.IsTrue(_iocContainer.IsRegistered<ConcreteClassWithParameterInterface>());
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Register_UnregisteredConcreteClassWithParameterUnregisteredAbstact_ResultIsRegistered()
        {
            //Arrange

            //Act
            _iocContainer.Register<ConcreteClassWithParameterAbstact, ConcreteClassWithParameterAbstact>();

            //Assert
            Assert.IsTrue(_iocContainer.IsRegistered<ConcreteClassWithParameterAbstact>());
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Register_RegisteredInterface_ResultInvalidOperationException()
        {
            //Arrange
            _iocContainer.Register<IBase, ConcreteClass>();

            //Act
            var returnedException = Act.GetException<InvalidOperationException>(() => _iocContainer.Register<IBase, ConcreteClass>());

            //Assert
            Assert.IsNotNull(returnedException);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Register_RegisteredAbstractClass_ResultInvalidOperationException()
        {
            //Arrange
            _iocContainer.Register<DerivedAbstractClass, ConcreteClass>();

            //Act
            var returnedException = Act.GetException<InvalidOperationException>(() => _iocContainer.Register<DerivedAbstractClass, ConcreteClass>());

            //Assert
            Assert.IsNotNull(returnedException);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Register_RegisteredConcreteClass_ResultInvalidOperationException()
        {
            //Arrange
            _iocContainer.Register<ConcreteClass, ConcreteClass>();

            //Act
            var returnedException = Act.GetException<InvalidOperationException>(() => _iocContainer.Register<ConcreteClass, ConcreteClass>());

            //Assert
            Assert.IsNotNull(returnedException);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Register_InterfaceInsteadOfConcreteType_ResultInvalidOperationException()
        {
            //Arrange

            //Act
            var returnedException = Act.GetException<InvalidOperationException>(() => _iocContainer.Register<IBase, IBase>());

            //Assert
            Assert.IsNotNull(returnedException);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Register_AbstractTypeInsteadOfConcreteType_ResultInvalidOperationException()
        {
            //Arrange

            //Act
            var returnedException = Act.GetException<InvalidOperationException>(() => _iocContainer.Register<IBase, IBase>());

            //Assert
            Assert.IsNotNull(returnedException);
        }

        #endregion //Register<IBase, IConcrete>()

        #region | Register<TBase, TDerived>(Func<TDerived> provider) |

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_RegisterWithProvider_UnregisteredInterface_ResultIsRegistered()
        {
            //Arrange
            var expectedInstance = new ConcreteClass();

            //Act
            _iocContainer.Register<IBase, IBase>(() => expectedInstance);

            //Assert
            Assert.IsTrue(_iocContainer.IsRegistered<IBase>());
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_RegisterWithProvider_UnregisteredAbstractClass_ResultIsRegistered()
        {
            //Arrange
            var expectedInstance = new ConcreteClass();

            //Act
            _iocContainer.Register<DerivedAbstractClass, DerivedAbstractClass>(() => expectedInstance);

            //Assert
            Assert.IsTrue(_iocContainer.IsRegistered<DerivedAbstractClass>());
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_RegisterWithProvider_UnregisteredConcreteClass_ResultIsRegistered()
        {
            //Arrange
            var expectedInstance = new ConcreteClass();

            //Act
            _iocContainer.Register<ConcreteClass, ConcreteClass>(() => expectedInstance);

            //Assert
            Assert.IsTrue(_iocContainer.IsRegistered<ConcreteClass>());
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_RegisterWithProvider_RegisteredInterface_ResultInvalidOperationException()
        {
            //Arrange
            _iocContainer.Register<IBase, ConcreteClass>();
            var expectedInstance = new ConcreteClass();

            //Act
            var returnedException = Act.GetException<InvalidOperationException>(() => _iocContainer.Register<IBase, ConcreteClass>(() => expectedInstance));

            //Assert
            Assert.IsNotNull(returnedException);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_RegisterWithProvider_RegisteredAbstractClass_ResultInvalidOperationException()
        {
            //Arrange
            _iocContainer.Register<DerivedAbstractClass, ConcreteClass>();
            var expectedInstance = new ConcreteClass();

            //Act
            var returnedException = Act.GetException<InvalidOperationException>(() => _iocContainer.Register<DerivedAbstractClass, ConcreteClass>(() => expectedInstance));

            //Assert
            Assert.IsNotNull(returnedException);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_RegisterWithProvider_RegisteredConcreteClass_ResultInvalidOperationException()
        {
            //Arrange
            _iocContainer.Register<ConcreteClass, ConcreteClass>();
            var expectedInstance = new ConcreteClass();

            //Act
            var returnedException = Act.GetException<InvalidOperationException>(() => _iocContainer.Register<ConcreteClass, ConcreteClass>(() => expectedInstance));

            //Assert
            Assert.IsNotNull(returnedException);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_RegisterWithProvider_ProviderNull_ResultArgumentNullException()
        {
            //Arrange
            Func<ConcreteClass> provider = null;

            //Act
            var returnedException = Act.GetException<ArgumentNullException>(() => _iocContainer.Register<ConcreteClass, ConcreteClass>(provider));

            //Assert
            Assert.IsNotNull(returnedException);
        }

        #endregion //Register<TBase, TDerived>(Func<TDerived> provider)

        #region | Configure |

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Configure_NewConfiguration_ReturnCaller()
        {
            //Arrange

            //Act
            IoCContainer returnedContainer = _iocContainer.Configure<ConfigurationStub>();

            //Assert
            Assert.AreEqual(_iocContainer, returnedContainer);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Configure_NewConfiguration_ResultConfigureImplCalled()
        {
            //Arrange

            //Act
            _iocContainer.Configure<ConfigurationStub>();

            //Assert
            Assert.IsTrue(_iocContainer.IsRegistered<IBase>());
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_Configure_ConfigurationAlreadyConfigured_ResultNoException()
        {
            //Arrange
            _iocContainer.Configure<ConfigurationStub>();

            //Act
            Exception exception = Act.GetException<Exception>(() => _iocContainer.Configure<ConfigurationStub>());

            //Assert
            Assert.IsNull(exception);
        }

        #endregion //Configure

        #region | As IServiceLocator |

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_AsIServiceLocator_Register_InterfaceWithConcreteType_ReturnedInstanceTypeIsTheSameAsTheCaller()
        {
            //Arrange
            IServiceLocator serviceLocator = _iocContainer;

            //Act
            IServiceLocator returnedInstance = serviceLocator.Register<IBase, ConcreteClass>();

            //Assert
            Assert.IsNotNull(returnedInstance);
            Assert.AreEqual(serviceLocator, returnedInstance);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_AsIServiceLocator_RegisterWithProvider_InterfaceWithConcreteType_ReturnedInstanceTypeIsTheSameAsTheCaller()
        {
            //Arrange
            Func<ConcreteClass> provider = () => new ConcreteClass();
            IServiceLocator serviceLocator = _iocContainer;

            //Act
            IServiceLocator returnedInstance = serviceLocator.Register<IBase, ConcreteClass>(provider);

            //Assert
            Assert.IsNotNull(returnedInstance);
            Assert.AreEqual(serviceLocator, returnedInstance);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.IoCContainer")]
        public void System_IoCContainer_AsIServiceLocator_Configure_InterfaceWithConcreteType_ReturnedInstanceTypeIsTheSameAsTheCaller()
        {
            //Arrange
            IServiceLocator serviceLocator = _iocContainer;

            //Act
            IServiceLocator returnedInstance = serviceLocator.Configure<ConfigurationStub>();

            //Assert
            Assert.IsNotNull(returnedInstance);
            Assert.AreEqual(serviceLocator, returnedInstance);
        }

        #endregion //Default

        #region | Private |

        private interface IBase
        {

        }

        private abstract class DerivedAbstractClass : IBase
        {

        }

        private class ConcreteClass : DerivedAbstractClass
        {

        }

        private class ConcreteClassWithParameterConcrete
        {
            public ConcreteClass Obj { get; }

            public ConcreteClassWithParameterConcrete(ConcreteClass obj)
            {
                Obj = obj;
            }
        }

        private class ConcreteClassWithParameterInterface
        {
            public IBase Obj { get; }

            public ConcreteClassWithParameterInterface(IBase obj)
            {
                Obj = obj;
            }
        }

        private class ConcreteClassWithParameterAbstact
        {
            public DerivedAbstractClass Obj { get; }

            public ConcreteClassWithParameterAbstact(DerivedAbstractClass obj)
            {
                Obj = obj;
            }
        }

        private class ConcreteClassWithTwoConstructorDifferentQuantityOfParameter
        {
            public DerivedAbstractClass Obj { get; }

            public ConcreteClassWithTwoConstructorDifferentQuantityOfParameter() : this(null) { }

            public ConcreteClassWithTwoConstructorDifferentQuantityOfParameter(ConcreteClass obj)
            {
                Obj = obj;
            }
        }

        private class ConcreteClassWithTwoConstructorSameQuantityOfParameter
        {
            public ConcreteClassWithTwoConstructorSameQuantityOfParameter(ConcreteClass obj)
            {
            }

            public ConcreteClassWithTwoConstructorSameQuantityOfParameter(IBase obj)
            {
            }
        }

        private class ConcreteClassWithoutPublicConstructor
        {
            private ConcreteClassWithoutPublicConstructor() { }
        }

        private class ConfigurationStub : ConfigurationBase
        {
            public bool ConfigureImplCalled { get; private set; } = false;

            protected override void ConfigureImpl(IServiceLocator container)
            {
                container.Register<IBase, ConcreteClass>();
            }
        }

        #endregion //Private
    }
}