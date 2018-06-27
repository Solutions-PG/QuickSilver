using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SolutionsPG.QuickSilver.Shims.Tests
{
    [TestClass]
    public class NameOfTest
    {
        #region | Tests management |

        [TestInitialize]
        public void Initialize()
        {
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        #endregion //Tests management

        #region | NameOf |

        [TestMethod, TestCategory("_Unit"), TestCategory("Polyfill.CS60"), TestCategory("Polyfill.CS60.NameOf")]
        public void CS60_NameOf_ValidExpressionWithVariable_ReturnVariableName()
        {
            //Arrange
            int value = 0;
            Expression<Func<int>> propertyExpression = () => value;
            string expectedName = ((MemberExpression)propertyExpression.Body).Member.Name;

            //Act
            string returnedName = Cs60.NameOf(propertyExpression);

            //Assert
            Assert.AreEqual(expectedName, returnedName, "Returned name should have been equals to expected name. Any recent changes in the implementation?");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Polyfill.CS60"), TestCategory("Polyfill.CS60.NameOf")]
        public void CS60_NameOf_ValidExpressionWithProperty_ReturnPropertyName()
        {
            //Arrange
            List<int> values = new List<int>();
            Expression<Func<int>> propertyExpression = () => values.Count;
            string expectedName = ((MemberExpression)propertyExpression.Body).Member.Name;

            //Act
            string returnedName = Cs60.NameOf(propertyExpression);

            //Assert
            Assert.AreEqual(expectedName, returnedName, "Returned name should have been equals to expected name. Any recent changes in the implementation?");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Polyfill.CS60"), TestCategory("Polyfill.CS60.NameOf")]
        public void CS60_NameOf_InvalidExpressionWithMethod_ThrowArgumentException()
        {
            //Arrange
            List<int> values = new List<int>();
            Expression<Func<int>> propertyExpression = () => values.Count();
            string expectedName = ((MethodCallExpression)propertyExpression.Body).Method.Name;

            //Act
            string returnedName = Cs60.NameOf(propertyExpression);

            //Assert
            Assert.AreEqual(expectedName, returnedName, "Returned name should have been equals to expected name. Any recent changes in the implementation?");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Polyfill.CS60"), TestCategory("Polyfill.CS60.NameOf")]
        public void CS60_NameOf_InvalidExpressionType_ThrowArgumentException()
        {
            //Arrange
            List<int> values = new List<int>();
            Expression<Func<bool>> propertyExpression = () => values.Count > 10;

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => Cs60.NameOf(propertyExpression),
                "Operation should have thrown an ArgumentException. Any recent changes in the implementation?");
        }

        [TestMethod, TestCategory("_Unit"), TestCategory("Polyfill.CS60"), TestCategory("Polyfill.CS60.NameOf")]
        public void CS60_NameOf_NullExpression_ThrowArgumentNullException()
        {
            //Arrange
            Expression<Func<bool>> propertyExpression = null;

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => Cs60.NameOf(propertyExpression),
                "Operation should have thrown an ArgumentNullException. Any recent changes in the implementation?");
        }

        #endregion //NameOf
    }
}
