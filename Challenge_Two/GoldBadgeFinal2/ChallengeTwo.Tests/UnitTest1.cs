using ChallengeTwo.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChallengeTwo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private static ClaimRepository _claimRepo = new ClaimRepository();
        [TestMethod]
        public void TestEnterANewClaim()
        {
            // Arrange
            Claim claim = new Claim(1, ClaimType.Home, "home destroyed", 275000, new DateTime(2021/12/06), new DateTime(2021/12/15), true);
            bool expected = true;
            // Act
            bool actual = _claimRepo.EnterNewClaim(claim);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSeeAllClaims()
        {

        }

        [TestMethod]
        public void TestNextInQueue()
        {

        }

        [TestMethod]
        public void TestAddClaimToQueue()
        {

        }

        [TestMethod]
        public void ClaimIsValid() 
        {

        }
    }
}
