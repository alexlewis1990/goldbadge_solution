using System;
using System.Collections.Generic;
using System.Text;

namespace Komodo_Cafe_Pocos
{
    public class Cafe_Menu
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string MealDiscription { get; set; }

        public decimal MealPrice { get; set; }

        public List<string> Ingrediants { get; set; }

        public Cafe_Menu()
        {

        }

        public Cafe_Menu(string name,string mealdisctription,decimal mealprice,List<string> ingrediants )
        {
            Name = name;
            MealDiscription = mealdisctription;
            MealPrice = mealprice;
            Ingrediants = ingrediants;
        }
    }
}
