using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessments.Transformation.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Assessments.Transformation.PublishDynamicProperties;

namespace Assessments.Transformation.Tests
{
    [TestClass]
    public class DynamicPropertyObjectComparerTests
    {
        [TestMethod]
        public void GetHashCode_SameObject_ReturnsSameHashCode()
        {
            // Arrange
            var comparer = new DynamicPropertyObjectComparer();
            var dynamicProperty = new DynamicProperty { Id = "1", References = new string[0], Properties = new DynamicProperty.Property[0] };

            // Act
            int hashCode1 = comparer.GetHashCode(dynamicProperty);
            int hashCode2 = comparer.GetHashCode(dynamicProperty);

            // Assert
            Assert.AreEqual(hashCode1, hashCode2);
        }

        [TestMethod]
        public void GetHashCode_EqualObjects_ReturnsSameHashCode()
        {
            // Arrange
            var comparer = new DynamicPropertyObjectComparer();
            var dynamicProperty1 = new DynamicProperty { Id = "1", References = new string[1] { "Ref1" }, Properties = new DynamicProperty.Property[1] { new DynamicProperty.Property() { Name = "test1" } } };
            var dynamicProperty2 = new DynamicProperty { Id = "1", References = new string[1] { "Ref1" }, Properties = new DynamicProperty.Property[1] { new DynamicProperty.Property() { Name = "test1" } } };

            // Act
            int hashCode1 = comparer.GetHashCode(dynamicProperty1);
            int hashCode2 = comparer.GetHashCode(dynamicProperty2);

            // Assert
            Assert.AreEqual(hashCode1, hashCode2);
        }

        [TestMethod]
        public void GetHashCode_DifferentObjects_ReturnsDifferentHashCode()
        {
            // Arrange
            var comparer = new DynamicPropertyObjectComparer();
            var dynamicProperty1 = new DynamicProperty { Id = "1", References = new string[1] { "Ref1" }, Properties = new DynamicProperty.Property[1] { new DynamicProperty.Property() { Name = "test1" } } };
            var dynamicProperty2 = new DynamicProperty { Id = "2", References = new string[1] { "Ref2" }, Properties = new DynamicProperty.Property[1] { new DynamicProperty.Property() { Name = "test2" } } };

            // Act
            int hashCode1 = comparer.GetHashCode(dynamicProperty1);
            int hashCode2 = comparer.GetHashCode(dynamicProperty2);

            // Assert
            Assert.AreNotEqual(hashCode1, hashCode2);
        }
    }
}
