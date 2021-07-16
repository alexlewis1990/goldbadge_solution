using KomodoBadge_Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge_Repo
{
    public class Badge_Repo
    {
        public readonly Dictionary<int,Badge> _KomodoBadgeRepo = new Dictionary<int,Badge>();
        private int _Count;

        public bool CreateBadge(Badge badge)
        {
            if (badge == null)
            {
                return false;
            }
            _Count++;
            badge.ID = _Count;
            _KomodoBadgeRepo.Add(badge.ID, badge);
            return true;
        }


        public Dictionary<int,Badge> GetAllBadges()
        {
            return _KomodoBadgeRepo;
        }
        public Badge GetBadgeByKey(int key)
        {
            foreach (var badge in _KomodoBadgeRepo)
            {
                if (badge.Key==key)
                {
                    return badge.Value;
                }
            }
            return null;
        }
        public bool AddDoor(Badge badge,string DoorName)
        {
            var badgeData = GetBadgeByKey(badge.ID);
            if (badgeData == null)
            {
                return false;
            }
            badgeData.DoorNames.Add(DoorName);
            return true;
        }
        public bool RemoveDoor(Badge badge, string DoorName)
        {
            var badgeData = GetBadgeByKey(badge.ID);
            if (badgeData == null)
            {
                return false;
            }
            foreach (var door in badgeData.DoorNames)
            {
                if (door==DoorName)
                {
                    badgeData.DoorNames.Remove(door);
                    return true;
                }
            }
            return false;
        }
    }
}
