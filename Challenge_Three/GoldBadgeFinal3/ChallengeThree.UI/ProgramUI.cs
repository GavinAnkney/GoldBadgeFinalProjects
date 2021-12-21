using System;
using ChallengeThree.Lib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree.UI
{
    public class ProgramUI
    {
        private static BadgeRepository _badgeRepo = new BadgeRepository();
        public void Run()
        {
            //Seed();
            RunApplication();
        }
        public void RunMenu()
        {
            Console.WriteLine("Hello Security Admin, What would you like to do? \n" +
                "1. Add a badge \n" +
                "2. Edit a badge \n" +
                "3. List of all badges \n" +
                "4. Exit");
        }
        public void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                RunMenu();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddBadgeToDictionary();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "2":
                        EditBadgeInDictionary();
                        break;
                    case "3":
                        ListOfAllBadges();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private void AddBadgeToDictionary()
        {
            Badge newBadge = new Badge();
            List<string> doorName = new List<string>();
            Console.WriteLine("What is the number on the badge?");
            newBadge.BadgeId = int.Parse(Console.ReadLine());
            Console.WriteLine("List a door it needs access to (A1-A4 or B1-B4): ");
            var doors = Console.ReadLine();
            doorName.Add(doors);
            Console.WriteLine("Any other doors (y/n)?");
            string addMoreDoors = Console.ReadLine().ToLower();
            while (addMoreDoors == "y")
            {
                Console.WriteLine("List a door it needs access to (A1-A4 or B1-B4): ");
                var door = Console.ReadLine();
                doorName.Add(door);
                Console.WriteLine("Any other doors (y/n)?");
                addMoreDoors = Console.ReadLine().ToLower();
            }
            newBadge.DoorNames = doorName;
            Console.WriteLine("Please enter the name of the badge user: ");
            newBadge.BadgeName = Console.ReadLine();
            Console.WriteLine("Badge succesfully added!");
            _badgeRepo.CreateNewBadge(newBadge);

        }
        private void EditBadgeInDictionary()
        {
            throw new NotImplementedException();
        }
        private void ListOfAllBadges()
        {
            throw new NotImplementedException();
        }
        /*private void Seed()
        {
            Badge badge1 = new Badge(1, , "Gavin");
            Badge badge2 = new Badge(1, , "Garrett");
            Badge badge3 = new Badge(1, , "Grant");
        }*/

    }
}
