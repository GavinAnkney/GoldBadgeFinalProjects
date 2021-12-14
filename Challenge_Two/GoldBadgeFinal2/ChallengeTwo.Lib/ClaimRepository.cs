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
        // Update

        //Delete

        
        public bool TakeNextClaim(int id)
        {

        }
    }
}
