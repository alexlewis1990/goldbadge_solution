using KomodoBadge_Poco;
using KomodoBadge_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgeInsurance
{
    public class KomodoBadge_UI
    {
        private readonly Badge_Repo _badgeRepo = new Badge_Repo();

        public void Run()
        {
            Seed();
            RunApplication();

        }

        private void Seed()
        {
            List<string> A2 = new List<string> { "2A" };
            List<string> A3 = new List<string> { "3C" };
            Badge badge = new Badge(A2);
            Badge badge2 = new Badge(A3);
            _badgeRepo.CreateBadge(badge);
            _badgeRepo.CreateBadge(badge2);
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {

                Console.WriteLine("Welcome to the Komodo Badge App!\n" +
                                  "1.Add a Badge.\n" +
                                  "2.Edit a Badge.\n" +
                                  "3.List all Badges.\n" +
                                  "10.Close Application.\n");
                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditABadge();
                        break;
                    case "3":
                        ViewAllBadges();
                        break;
                    case "10":
                        isRunning = false;
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Input Invalid.");
                        break;
                }
                Console.Clear();
            }
        }

        private void ViewAllBadges()
        {
            Console.Clear();
            var badgesInDatabase = _badgeRepo.GetAllBadges();

            foreach (var badge in badgesInDatabase.Values)
            {
                Data(badge);
            }

            Console.ReadKey();
        }
        private void Data(Badge badge)
        {
            Console.WriteLine($"{badge.ID}\n");
            foreach (var door in badge.DoorNames)
            {
                Console.WriteLine(door);
            }
        }
        private void EditABadge()
        {
            Console.Clear();
            Console.WriteLine("Edit Badge Menu\n" +
                              "1.Add door to badge\n" +
                              "2.Remove door from badge\n" +
                              "3.Return to main menu.\n");
            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddDoorToBadge();
                    break;
                case "2":
                    RemoveDoorFromBadge();
                    break;
                case "3":
                    RunApplication();
                    break;
                default:
                    Console.WriteLine("invalid Input");
                    break;
            }
            Console.ReadKey();
        }

        private void RemoveDoorFromBadge()
        {
            Console.Clear();
            Console.WriteLine("Please Input Badge ID.");
            var userInput = int.Parse(Console.ReadLine());
            var badge = _badgeRepo.GetBadgeByKey(userInput);
            if (badge == null)
            {
                Console.WriteLine("Badge does not exist");
            }
            else
            {
                Console.WriteLine("Please Input a door Name.");
                var userInputDoorName = Console.ReadLine();
                var Success = _badgeRepo.RemoveDoor(badge, userInputDoorName);
                if (Success)
                {
                    Console.WriteLine("SUCCESS");
                }
                else
                {
                    Console.WriteLine("FAILURE");
                }
            }
            Console.ReadKey();
        }

        private void AddDoorToBadge()
        {
            Console.Clear();
            Console.WriteLine("Please Input Badge ID.");
            var userInput = int.Parse(Console.ReadLine());
            var badge = _badgeRepo.GetBadgeByKey(userInput);
            if (badge == null)
            {
                Console.WriteLine("Badge does not exist");
            }
            else
            {
                Console.WriteLine("Please Input a door Name.");
                var userInputDoorName = Console.ReadLine();
                var Success = _badgeRepo.AddDoor(badge, userInputDoorName);
                if (Success)
                {
                    Console.WriteLine("SUCCESS");
                }
                else
                {
                    Console.WriteLine("FAILURE");
                }
            }
            Console.ReadKey();
        }

        private void AddABadge()
        {
            Console.Clear();
            //Need a list that will hold all doors created
            List<string> userDoorInputs = new List<string>();

            //need a bool to initialize a while loop
            bool hasenlistedalldoors = false;

            while (hasenlistedalldoors == false)
            {
                hasenlistedalldoors = AddDoorsToList(userDoorInputs);
            }

            Badge badge = new Badge(userDoorInputs);
            bool Success = _badgeRepo.CreateBadge(badge);
            if (Success)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("failure");
            }
            Console.ReadKey();
        }
        private bool AddDoorsToList(List<string> doors)
        {

            Console.WriteLine("Are there any other doors to add? y or n");
            string userInputYorN = Console.ReadLine();
            if (userInputYorN == "Y".ToLower())
            {
                Console.WriteLine("List a door that this Badge needs access to");
                string userInputDoor = Console.ReadLine();
                doors.Add(userInputDoor);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
