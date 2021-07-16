using Komodo_Cafe_Pocos;
using Komodo_Cafe_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Komodo_Cafe
{
    public class KomodoCafe_UI
    {
        private readonly Cafe_Menu_Repo _cafeMenuList = new Cafe_Menu_Repo();

        public void Run()
        {

        seed();
        RunApplication();
        }

    private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to the Komodo Cafe Application!\n" +
                                  "1.Add a meal Item\n" +
                                  "2.View all meal Items\n" +
                                  "3.Delete a meal Item\n" +
                                  "4.Close Application.");

                string userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "1":
                        AddToCafeMenu();
                        break;
                    case "2":
                        ViewCafeMenu();
                        break;
                    case "3":
                        DeleteFromCafeMenu();
                        break;
                    case "4":
                        Console.Clear();
                        isRunning = false;
                        Console.WriteLine("Thank you for using our Application!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Invalid Input.");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }
        private void AddToCafeMenu()
        {
            Console.Clear();

            Console.WriteLine("Please Input Meal Name.");
            string userInputMealName = Console.ReadLine();

            Console.WriteLine("Please Input Meal Discription.");
            string userInputMealDiscription = Console.ReadLine();

            Console.WriteLine("Please Input Ingrediants.");
            List<string> userInputMealIngrediants = null;

            Console.WriteLine("Please Input Price.");
            decimal userInputMealPrice = decimal.Parse(Console.ReadLine());


            Cafe_Menu cafe_menu = new Cafe_Menu(userInputMealName, userInputMealDiscription, userInputMealPrice , userInputMealIngrediants );
            bool isSuccessful = _cafeMenuList.AddToCafeMenu(cafe_menu);
            if (isSuccessful)
            {
                Console.WriteLine($"{cafe_menu.Name} was added to your repository.");                  
            }
            else
            {
                Console.WriteLine($"{cafe_menu.Name} was not added to your repository.");
            }
        }
        private void ViewCafeMenu()
        {
            Console.Clear();
            List<Cafe_Menu> cafe_Menus = _cafeMenuList.GetCafe_Menus().ToList();
            foreach (Cafe_Menu cafe_Menu in cafe_Menus)
            {
                DisplayCafeMenuDetails(cafe_Menu);
            }
            Console.ReadLine();
        }
        private void DisplayCafeMenuDetails(Cafe_Menu cafe_Menu)
        {
            Console.WriteLine($"{cafe_Menu.ID}\n" +
                              $"{cafe_Menu.Name}\n" +
                              $"{cafe_Menu.MealDiscription}\n" +
                              $"{cafe_Menu.Ingrediants}\n" +
                              $"{cafe_Menu.MealPrice}\n");
            Console.WriteLine("*********************************");
        }
        private void DeleteFromCafeMenu()
        {
            Console.Clear();
            Console.WriteLine("Please Input Meal ID");
            int userInputID = int.Parse(Console.ReadLine());

            bool isSuccessful = _cafeMenuList.DeleteCafe_Menu(userInputID);
            if (isSuccessful)
            {
                Console.WriteLine("Meal Deleted");
            }    
            else
            {
                Console.WriteLine("Meal not Deleted");
            }    
        }
        private void seed()
        {


            Cafe_Menu cafe_menuA = new Cafe_Menu("Pancakes", "pancakes with syrup and a side of bacon", 9.30m, null);
            Cafe_Menu cafe_menuB = new Cafe_Menu("Pancakes", "pancakes with syrup and a side of bacon", 9.30m, null);
            Cafe_Menu cafe_menuC = new Cafe_Menu("Pancakes", "pancakes with syrup and a side of bacon", 9.30m, null);
            Cafe_Menu cafe_menuD = new Cafe_Menu("Pancakes", "pancakes with syrup and a side of bacon", 9.30m, null);

            _cafeMenuList.AddToCafeMenu(cafe_menuA);
            _cafeMenuList.AddToCafeMenu(cafe_menuB);
            _cafeMenuList.AddToCafeMenu(cafe_menuC);
            _cafeMenuList.AddToCafeMenu(cafe_menuD);
        }
    }
}
