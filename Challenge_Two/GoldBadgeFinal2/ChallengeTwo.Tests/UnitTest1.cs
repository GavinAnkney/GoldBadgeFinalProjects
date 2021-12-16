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
            // Arrange
            

            // Act

            //Assert

        }

        [TestMethod]
        public void TestDequeueNextInQueue()
        {
            // Arrange
            Claim claim = new Claim(1, ClaimType.Home, "home destroyed", 275000, new DateTime(2021 / 12 / 06), new DateTime(2021 / 12 / 15), true);
            if (claim != null)
            {
                _claimRepo.DequeueNextInQueue();
            }
            var expected = _claimRepo.DequeueNextInQueue();
            // Act
            var actual = _claimRepo.DequeueNextInQueue();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAddClaimToQueue()
        {
            // Arrange 
            Claim claim = new Claim(1, ClaimType.Home, "home destroyed", 275000, new DateTime(2021 / 12 / 06), new DateTime(2021 / 12 / 15), true);

            // Act
            
            // Assert

        }

        [TestMethod]
        public void TestClaimIsValid() 
        {
            // Arrange
            Claim claim = new Claim(1, ClaimType.Home, "home destroyed", 275000, new DateTime(2021 / 12 / 06), new DateTime(2021 / 12 / 15), true);
            if (claim.IsValid == true)
            {
                _claimRepo.ClaimIsValid(claim);
            }
            bool expected = true;
            // Act
            bool actual = _claimRepo.ClaimIsValid(claim);
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestPullUpNextInQueue()
        {
            // Arrange

            // Act

            // Assert

        }
    }
}
