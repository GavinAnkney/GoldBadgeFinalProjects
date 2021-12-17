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
            // Arrange - what data do we need to be able to use to test.
            Claim claim = new Claim(1, ClaimType.Home, "home destroyed", 275000, new DateTime(2021 / 12 / 06), new DateTime(2021 / 12 / 15), true);
            _claimRepo.EnterNewClaim(claim);
            // Act - Using our methods to complete the test
            var actual = _claimRepo.SeeAllClaims();
            //Assert - seeing if the method worked how we expected
            Assert.IsNotNull(actual);
            CollectionAssert.Contains(actual, claim);
        }

        [TestMethod]
        public void TestDequeueNextInQueue()
        {
            // Arrange
            Claim claim = new Claim(1, ClaimType.Home, "home destroyed", 275000, new DateTime(2021 / 12 / 06), new DateTime(2021 / 12 / 15), true);
            _claimRepo.EnterNewClaim(claim);


            var expected = true;
            // Act
            var actual = _claimRepo.DequeueNextInQueue();
            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestDequeueFail_ShouldReturnFalse()
        {
            //Arrange
            //needs queue to be null
            int expectedCount = 0;
            //Act
            var result = _claimRepo.DequeueNextInQueue();
            int actualCount = _claimRepo.SeeAllClaims().Count;
            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void TestClaimIsValid() 
        {
            // Arrange
            Claim claim = new Claim(1, ClaimType.Home, "home destroyed", 275000, new DateTime(2021 / 12 / 06), new DateTime(2021 / 12 / 15), true);
            _claimRepo.EnterNewClaim(claim);
            // Act
            bool actual = _claimRepo.ClaimIsValid(claim);
            // Assert
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void TestClaimIsValid_ShouldReturnFalse()
        {
            // Arrange
            Claim claim = new Claim(1, ClaimType.Home, "home destroyed", 275000, new DateTime(2021 / 10 / 06), new DateTime(2021 / 12 / 15), true);
            _claimRepo.EnterNewClaim(claim);
            // Act
            bool actual = _claimRepo.ClaimIsValid(claim);
            //Assert
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void TestPullUpNextInQueue()
        {
            // Arrange
            Claim claim = new Claim(1, ClaimType.Home, "home destroyed", 275000, new DateTime(2021 / 10 / 06), new DateTime(2021 / 12 / 15), true);
            _claimRepo.EnterNewClaim(claim);
            var expected = claim;
            //Act
            Claim actual = _claimRepo.PullUpNextInQueue();
            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
