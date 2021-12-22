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
            Seed();
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
                        Console.ReadKey();
                        break;
                    case "3":
                        ListOfAllBadges();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
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
            Console.WriteLine("What is the badge Id? ");
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
            Console.WriteLine("Please enter the badge id you would like to edit: ");
            int badgeId = int.Parse(Console.ReadLine());
            Badge oldBadge = _badgeRepo.GetBadgeById(badgeId);
            List<string> doorNames = oldBadge.DoorNames;
            Console.WriteLine($"{badgeId} has access to doors: {string.Join(", ", oldBadge.DoorNames)}");
            Console.WriteLine("What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door\n" +
                "3. Remove all doors");
            int userInput = int.Parse(Console.ReadLine());
            while (userInput == 1)
            {
                Console.WriteLine("Which door would you like to remove?");
                string doorInput = Console.ReadLine();
                doorNames.Remove(doorInput);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            while (userInput == 2)
            {
                Console.WriteLine("Which door would you like to add?");
                string doorInput = Console.ReadLine();
                doorNames.Add(doorInput);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            while (userInput == 3)
            {
                Console.WriteLine("Would you like to remove all doors (y/n)?");
                string doorInput = Console.ReadLine().ToLower();
                if (doorInput == "y")
                {
                    Console.WriteLine("All doors have been removed!");
                    doorNames.Clear();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Press any key to return to the main menu...");
                    Console.ReadKey();
                    return;
                }
            }
        }
        private void ListOfAllBadges()
        {
            Console.Clear();
            Console.WriteLine(String.Format("|{0, -10}|{1, -10}|{2, -10}",
                "Badge Id: ", "Badge user name:", "Door Access: "));
             var badge = _badgeRepo.SeeAllBadges();
            foreach (var items in badge.Values)
            {
                Console.WriteLine(string.Join(" | ", items.BadgeId, items.BadgeName, string.Join(", ", items.DoorNames)));

            }
        }
        private void Seed()
        {
            Badge badge1 = new Badge(1, new List<string> { "a1", "a2" }, "Gavin");
            Badge badge2 = new Badge(2, new List<string> { "b3" }, "Craig");
            Badge badge3 = new Badge(3, new List<string> { "b3", "a3" }, "Grant");
            _badgeRepo.CreateNewBadge(badge1);
            _badgeRepo.CreateNewBadge(badge2);
            _badgeRepo.CreateNewBadge(badge3);
        }
    }
}
