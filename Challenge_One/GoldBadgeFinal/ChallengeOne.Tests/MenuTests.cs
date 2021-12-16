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
            Menu item = new Menu("name", "desc", "ingred", 50);
            _menuRepo.AddMenuItem(item);
            bool expected = true;
            // Act
            bool actual = _menuRepo.RemoveMenuItem("name");
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSeeAllMenuItems()
        {
            // Arrange 
            Menu item = new Menu("name", "desc", "ingred", 50);
            _menuRepo.AddMenuItem(item);

            // Act
            var actual = _menuRepo.SeeAllMenuItems();
            // Assert
            Assert.IsNotNull(actual);
            CollectionAssert.Contains(actual, item);
        }

        [TestMethod]
        public void TestGetItemByName()
        {
            // Arrange
            Menu item = new Menu("name", "desc", "ingred", 50);
            _menuRepo.AddMenuItem(item);
            var expected = item;
            // Act
            Menu actual = _menuRepo.GetItemByName("name"); 
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
