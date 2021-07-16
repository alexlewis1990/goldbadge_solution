using KomodoBadge_Poco;
using KomodoBadge_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoBadgeTest
{
    [TestClass]
    public class BadgeTest
    {
        private List<string> doornames;

        [TestMethod]
        public void AddNewBadge()
        {
            Badge badge = new Badge(doornames);
            Badge_Repo badge_Repo = new Badge_Repo();
            bool testResult = Badge_Repo.CreateBadge(badge);
        }
    }
}
