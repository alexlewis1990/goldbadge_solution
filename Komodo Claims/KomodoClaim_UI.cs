using Claim_Repo;
using ClaimPOCO;
using ClaimPOCO.ENUMS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Komodo_Claims
{
    public class KomodoClaim_UI
    {
        private readonly Claim_Repos _claimRepos = new Claim_Repos();

        public void Run()
        {
            Seed();
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to the Komodo Claims Application!\n" +
                                  "1.See all Claims\n" +
                                  "2.Take care of next Claim\n" +
                                  "3.Enter a new Claim\n" +
                                  "4.Close Application\n");

                string userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "1":
                        ViewAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        Console.Clear();
                        isRunning = false;
                        Console.WriteLine("Thank you for using our Application! Press any key to continue.");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Input is Invalid.");
                        break;
                }
                Console.Clear();
            }    
        }
        private void AddNewClaim()
        {
            Console.Clear();

            Console.WriteLine("Please input Claim Number:\n" +
                              "1.Car\n" +
                              "2.Home\n" +
                              "3.Theft\n");
            int userInputClaimType = int.Parse(Console.ReadLine());
            ClaimType claimtype = (ClaimType)userInputClaimType;

            Console.WriteLine("Please Input Claim Input");
            string userInputClaimDescription = Console.ReadLine();

            Console.WriteLine("Please Input Claim Amount");
            decimal userInputClaimAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Please Input Date Of Accident (e.g. 08/04/1978)");
            DateTime userInputDateOfAccident = DateTime.Parse(Console.ReadLine());
            
            Console.WriteLine("Please Input Date Of Report (e.g. 08/04/1998)");
            DateTime userInputDateOfReport = DateTime.Parse(Console.ReadLine());

            TimeSpan timeSpan = userInputDateOfAccident - userInputDateOfReport;
            bool isValid;
            Console.WriteLine(timeSpan.TotalDays);
            if(timeSpan.TotalDays<=30)
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }
            Claim claim = new Claim(claimtype, userInputClaimDescription, userInputClaimAmount, userInputDateOfAccident, userInputDateOfReport, isValid);
            _claimRepos.AddClaim(claim);
        }
        private void ViewAllClaims()
        {
            Console.Clear();
            Queue<Claim> claims = _claimRepos.GetClaims();
            foreach (Claim claim in claims) 
            {
                DisplayClaims(claim);
            }
            Console.ReadLine();
        }
        private void DisplayClaims(Claim claim)
        {
            Console.WriteLine($"{claim.ID}\n" +
                              $"{claim.ClaimType}\n" +
                              $"{claim.Description}\n" +
                              $"{claim.ClaimAmount}\n" +
                              $"{claim.DateOfIncedent}\n" +
                              $"{claim.DateOfClaim}\n" +
                              $"{claim.IsValid}\n");
        }
        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Console.WriteLine("Here are the details of the next Claim");
            DisplayClaims(_claimRepos.ViewNextClaim());
            Console.WriteLine("Do you want this claim now? y or n");
           var input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                _claimRepos.TakeCareOfClaim();
            }
            else
            {
                return;
            }

        }
        private void Seed()
        {
            Claim claimA = new Claim((ClaimType)1, "Car accident on 465", 464.32m, DateTime.Parse("06/04/1995"), DateTime.Parse("07/03/1995"), true);

            _claimRepos.AddClaim(claimA);
        }
    }   
}
