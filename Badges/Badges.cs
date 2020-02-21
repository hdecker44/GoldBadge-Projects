using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class Badge
    {
        public string BadgeID { get; set; }
        public List<string> DoorName { get; set; }

        public Badge() { }
        public Badge(string badgeID, List<string> doorName)
        {
            BadgeID = badgeID;
            DoorName = doorName;
        }
    }
}
