using ChallengeThree.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeThree.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private static BadgeRepository _badgeTest = new BadgeRepository();
        [TestMethod]
        public void TestCreateNewBadge()
        {
            // Arrange
            Badge badge = new Badge(1, new List<string> { "a1", "a3"}, "Gavin");
            bool expected = true;
            // Act
            bool actual = _badgeTest.CreateNewBadge(badge);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestSeeAllBadges()
        {
            // Arrange
            Badge badge = new Badge(1, new List<string> { "a1", "a3" }, "Gavin");
            _badgeTest.CreateNewBadge(badge);
            // Act
            var actual = _badgeTest.SeeAllBadges();
            // Assert
            Assert.IsNotNull(actual);
        }
        [TestMethod]
        public void TestGetBadgeById()
        {
            Badge badge = new Badge(1, new List<string> { "a1", "a3" }, "Gavin");
            _badgeTest.CreateNewBadge(badge);
            var expected = badge;
            Badge actual = _badgeTest.GetBadgeById(1);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestUpdateDoorsOnBadge()
        {
            // Arrange
            Badge badge = new Badge(1, new List<string> { "a1", "a3" }, "Gavin");
            _badgeTest.CreateNewBadge(badge);
            // Act
            bool updatedResult = _badgeTest.UpdateDoorsOnBadge(badge);
            // Assert
            Assert.IsTrue(updatedResult);
            
        }
    }
}
