using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChallengeOne.Lib;
using System;

namespace ChallengeOne.Tests
{
    [TestClass]
    public class MenuTests
    {
        private static MenuRepository _menuRepo = new MenuRepository();
        [TestMethod]
        public void TestAddMenuItem()
        {
            // Arrange
            Menu item = new Menu("name", "desc", "ingred", 50);
            bool expected = true;
            // Act 
            bool actual = _menuRepo.AddMenuItem(item);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRemoveMenuItem()
        {
            // Arrange

            // Act

            // Assert

        }

        [TestMethod]
        public void TestViewAllMenu()
        {
            // Arrange 

            // Act

            // Assert

        }
    }
}
