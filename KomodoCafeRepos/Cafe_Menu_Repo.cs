using Komodo_Cafe_Pocos;
using System;
using System.Collections.Generic;
using System.Text;


namespace Komodo_Cafe_Repo
{
    public class Cafe_Menu_Repo
    {
        private readonly List<Cafe_Menu> _CafeMenuList = new List<Cafe_Menu>();

        private int _count = 0;

        public bool AddToCafeMenu(Cafe_Menu cafe_menu)
        {
            if (cafe_menu != null)
            {
                _count++;
                cafe_menu.ID = _count;
                _CafeMenuList.Add(cafe_menu);
                return true;
            }
            return false;
        }
        public IEnumerable<Cafe_Menu> GetCafe_Menus()
        {
            return _CafeMenuList;
        }

        public Cafe_Menu GetCafe_MenuByID(int id)
        {
            foreach (Cafe_Menu cafe_menu in _CafeMenuList)
                {
                if (cafe_menu.ID==id)
                {
                    return cafe_menu;
                }
            }
            return null;
        }
        public bool DeleteCafe_Menu(int id)
        {
            Cafe_Menu cafe_menu = GetCafe_MenuByID(id);
            if (cafe_menu!=null)
            {
                _CafeMenuList.Remove(cafe_menu);
                return true;
            }
            return false;
        }
    }
}
