using ChallengeTwo.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo.UI
{
    public class ProgramUI
    {
        private static ClaimRepository _claimRepo = new ClaimRepository();
        public void Run()
        {
            Seed();
            RunApplication();
        }
        public void RunMenu()
        {
            Console.WriteLine("Welcome to your insurance claims app! \n" +
                "1. See all claims \n" +
                "2. Take care of next claim \n" +
                "3. Enter a new claim \n" +
                "4. Exit app");
        }
        private void RunApplication()
        {
            bool isRunnning = true;
            while (isRunnning)
            {
                Console.Clear();
                RunMenu();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ListOfAllClaims();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "2":
                        NextClaimInQueue();
                        Console.ReadKey();
                        break;
                    case "3":
                        Claim newClaim = CreateANewClaim();
                        _claimRepo.EnterNewClaim(newClaim);
                        Console.WriteLine("You have entered a new claim! Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "4":
                        isRunnning = false;
                        break;
                    default:

                        break;
                }
            }
        }
        private Claim CreateANewClaim()
        {
            Claim newClaim = new Claim();
            Console.WriteLine("Please enter the claim Id: ");
            newClaim.ClaimId = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the claim type \n" +
                "1. Car \n" +
                "2. Home \n" +
                "3. Theft \n");
            newClaim.ClaimType = (ClaimType)int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a decription of the claim: ");
            newClaim.Description = Console.ReadLine();
            Console.WriteLine("Please enter the damage amount in United States dollars: ");
            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the date of the accident (year/month/date): ");
            newClaim.DateOfAccident = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the date the accident was claimed on (year/month/date): ");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());
            if (_claimRepo.ClaimIsValid(newClaim))
            {
                Console.WriteLine("The claim is valid.");
            }
            else
            {
                Console.WriteLine("The claim is not valid.");
            }
            return newClaim;
        }
        private void ListOfAllClaims()
        {
            Console.Clear();
            int tableWidth = 120;
            Console.WriteLine(String.Format("|{0, 0}|{1, -10}|{2, -20}|{3, -20}|{4, -20}|{5, -20}|{6, -10}|",
                "Claim Id", "Claim Type", "Claim Description", "Claim Amount", "Date of Accident", "Date of Claim", "Is it Valid?"));
            PrintLine(tableWidth);
            int counter = 1;
            foreach (var claim in _claimRepo.SeeAllClaims())
            {
                Console.WriteLine($"{claim.ClaimId, -5}\t{claim.ClaimType, -10}\t{claim.Description, -10}\t${claim.ClaimAmount, -10}\t{claim.DateOfAccident, -10}\t{claim.DateOfClaim, -10}\t{claim.IsValid}");
                counter++;
            }
        }
        private void NextClaimInQueue()
        {
            Console.WriteLine($"Here are ther details for the next claim to be handled: \n" +
            "Claim Id: \tType\tDescription\tAmount\tDateOfAccident\tDateOfClaim\tIsValid");
            var claim = _claimRepo.PullUpNextInQueue();
            Console.WriteLine($"{claim.ClaimId,-5}\t{claim.ClaimType,-10}\t{claim.Description,-10}\t${claim.ClaimAmount,-10}\t{claim.DateOfAccident,-10}\t{claim.DateOfClaim,-10}\t{claim.IsValid}");
            Console.WriteLine("Do you want to deal with this claim now? (y/n) ");
            string dealWithClaimNow = Console.ReadLine().ToLower();
            if(dealWithClaimNow == "y")
            {
                _claimRepo.NextInQueue();
                Console.WriteLine("The claim was successfully dequeued! Press any key to continue...");
            }
            else
            {
                Console.WriteLine("The claim was not dequeued! Press any key to return to the main menu");
            }
        }
        private void Seed()
        {
            Claim claim1 = new Claim(1, ClaimType.Home, "Home caught on fire.", 275000.00m, new DateTime(2021, 12, 08), new DateTime(2021, 12, 14), true);
            Claim claim2 = new Claim(2, ClaimType.Theft, "My laptop was stolen.", 2500.00m, new DateTime(2021,12,10), new DateTime(2021,12,12), true);
            Claim claim3 = new Claim(3, ClaimType.Car, "My car was stolen.", 14000.00m, new DateTime(2021,02,14), new DateTime(2021,12,10), false);
            _claimRepo.AddClaimToQueue(claim1);
            _claimRepo.AddClaimToQueue(claim2);
            _claimRepo.AddClaimToQueue(claim3);
        }
        private void PrintLine(int tableWidth)
        {
            Console.WriteLine(new string('_', tableWidth));
        }
    }
} 
