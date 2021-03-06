using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo.Lib
{
    public class ClaimRepository
    {
        public Queue<Claim> _claims = new Queue<Claim>();
        
        // Create
        public bool EnterNewClaim(Claim claim)
        {
            if (claim == null)
            {
                return false;
            }
            _claims.Enqueue(claim);
            return true;
        }
        // Read
        public Queue<Claim> SeeAllClaims()
        {
            return _claims;
        }
        

        // Delete
        public bool DequeueNextInQueue()
        {
            if (_claims.Count() <= 0)
            {
                return false;
            }
            _claims.Dequeue();
            return true;
        }                
            
        // Helper Method
        public bool ClaimIsValid(Claim claim)
        {
            DateTime dateOfAccident = claim.DateOfAccident;
            DateTime dateOfClaim = claim.DateOfClaim;
            TimeSpan diffBetweenDates = dateOfClaim - dateOfAccident;
            if (diffBetweenDates.Days <= 30)
            {
                return true;
            }
            else return false;
        }

        public Claim PullUpNextInQueue()
        {
           var claims = SeeAllClaims();
           return claims.Peek();
        } 
    }
}
