using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo.Lib
{
    public enum ClaimType { Car = 1, Home, Theft }
    public class Claim
    {
        public int ClaimId { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
        public ClaimType ClaimType { get; set; }
        public Claim()
        {
        }
        public Claim(string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid, ClaimType claimType)
        {
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
            ClaimType = claimType;
        }
    }
}
