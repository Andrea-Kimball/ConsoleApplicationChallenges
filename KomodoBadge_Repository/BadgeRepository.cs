using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge_Repository
{

    public class BadgeRepository
    {

        private Dictionary<double, List<string>> _badgeValue = new Dictionary<double, List<string>>();

        //Create 
        public void AddBadge(Badges badge)
        {
            _badgeValue.Add(badge.BadgeID, badge.DoorName);
        }

        //Read
        public Dictionary<double, List<string>> GetBadgeList()
        {
            return _badgeValue;
        }
        //Update
        public List<string> EditBadge(double badgeID)
            //find the badgeID               
        {
            _badgeValue.Contains(badgeID, out var rooms);
        }
        //update the badge

        //Delete


        public List<string> GetRoomAccess(double badgeID)
        {
            _badgeValue.TryGetValue(badgeID, out var rooms);
            return rooms;

         // _badgeValue.Remove()

        }
    }
}


