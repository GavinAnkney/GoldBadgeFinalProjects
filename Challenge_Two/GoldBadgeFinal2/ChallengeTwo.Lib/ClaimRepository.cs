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
        //private int _count = 0;
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
        // Update

        //Delete

        /*public bool TakeNextClaim(int id)
        {
            foreach (var claimId in _claims)
            {
                if ()
                {
       
                }
            }
        }*/
        public void AddClaimToQueue(Claim claim)
        {
            _claims.Enqueue(claim);
        }
    }
}
