using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree.Lib
{
    public class BadgeRepository
    {
        Dictionary<int, Badge> _badge = new Dictionary<int, Badge>();
        // Create
        public bool CreateNewBadge(Badge badge)
        {
            if (badge == null)
            {
                return false;
            }
            else
            {
                _badge.Add(badge.BadgeId, badge);
                return true;
            }
        }
        // Read
        public Dictionary<int, Badge> SeeAllBadges()
        {
            return _badge;
        }

        //Read
        public Badge GetBadgeById(int badgeId)
        {
            foreach (KeyValuePair<int, Badge> badge in _badge)
            {
                return badge.Value;
            }
            return null;
        }


        // Update
       /* public bool UpdateDoorsOnBadge()
        {

        }*/

        // Delete

        // Helper Methods

    }  
}
