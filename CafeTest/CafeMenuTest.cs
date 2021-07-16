using Komodo_Cafe_Pocos;
using Komodo_Cafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CafeTest
{
    [TestClass]
    public class CafeMenuTest
    {
        [TestMethod]
        public void CreateMenuItemReturnTrue()
        {
            Cafe_Menu cafe_Menu = new Cafe_Menu("omlette","omlette with cheese and rice",7.98m, null);
            Cafe_Menu_Repo cafe_Menu_Repo = new Cafe_Menu_Repo();
           bool testResult = cafe_Menu_Repo.AddToCafeMenu(cafe_Menu);

            Assert.IsTrue(testResult);
            
        }
        public void CreateMenuItemReturnFalse()
        {
            Cafe_Menu cafe_Menu = null;
            Cafe_Menu_Repo cafe_Menu_Repo = new Cafe_Menu_Repo();
            bool testResult = cafe_Menu_Repo.AddToCafeMenu(cafe_Menu);
            Assert.IsFalse(testResult);
        }
    }
}
