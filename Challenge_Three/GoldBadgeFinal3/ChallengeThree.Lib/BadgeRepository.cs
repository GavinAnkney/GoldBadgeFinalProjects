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

        public Badge GetBadgeById(int badgeId)
        {
            if (_badge.TryGetValue(badgeId, out Badge badge))
            {
                return badge;
            }
            return null;
        }


        // Update
        public bool UpdateDoorsOnBadge(Badge newBadge)
        {
            Badge oldBadge = _badge[newBadge.BadgeId];
            oldBadge.DoorNames = newBadge.DoorNames;
            if (_badge[oldBadge.BadgeId] != newBadge)
            {
                return false;
            }
            else return true;
        }
    }
}
