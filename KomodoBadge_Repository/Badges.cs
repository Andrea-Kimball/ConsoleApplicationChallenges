using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge_Repository
{
    public class Badges
    {
        public double BadgeID { get; set; }
        public List<string> DoorName { get; set; }

        public Badges() { }

        public Badges(double badgeID, List<string> doorName)
        {
            BadgeID = badgeID;
            DoorName = doorName;
        }
    }
}
