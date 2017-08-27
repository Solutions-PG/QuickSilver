using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionsPG.QuickSilver.Core.System;
using System.Text;


namespace SolutionsPG.QuickSilver.Core.Tests.System
{
    [TestClass()]
    public class FastActivatorTests
    {
        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.FastActivator")]
        public void System_FastActivator_CreateInstante_Class_ReturnValidConstructor()
        {
            //Arrange

            //Act
            StringBuilder result = FastActivator<StringBuilder>.CreateInstance();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.FastActivator")]
        public void System_FastActivator_CreateInstante_Class_1Arg_ReturnValidConstructor()
        {
            //Arrange
            int capacity = 256;

            //Act
            StringBuilder result = FastActivator<int, StringBuilder>.CreateInstance(capacity);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(capacity, result.Capacity);
        }
        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.FastActivator")]
        public void System_FastActivator_CreateInstante_Struct_ReturnValidConstructor()
        {
            //Arrange

            //Act
            TestStruct result = FastActivator<TestStruct>.CreateInstance();

            //Assert
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Core.System"), TestCategory("Core.System.FastActivator")]
        public void System_FastActivator_CreateInstante_Struct_1Arg_ReturnValidConstructor()
        {
            //Arrange
            int value = 4;

            //Act
            TestStruct2 result = FastActivator<int, TestStruct2>.CreateInstance(value);

            //Assert
            Assert.AreEqual(value, result.TestInt);
        }

        struct TestStruct { }

        struct TestStruct2
        {
            public int TestInt { get; }

            public TestStruct2(int testInt)
            {
                TestInt = testInt;
            }
        }
    }
}