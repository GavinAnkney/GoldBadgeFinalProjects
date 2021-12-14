using System;
using ChallengeOne.Lib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne.UI
{
    public class ProgramUI
    {
        private readonly MenuRepository _menuRepo = new MenuRepository();
        public void Run()
        {
            RunApplication();
        }
        public void RunMenu()
        {
            Console.WriteLine("Welcome to your menu app! \n" +
                "1. Add item to the menu \n" +
                "2. Remove Item from the menu \n" +
                "3. List of items on the menu \n" +
                "4. Exit");
        }
        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                RunMenu();
                int userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        AddItemToMenu();
                        break;
                    case 2:
                        RemoveMenuItem();
                        break;
                    case 3:
                        ViewAllMenuItems();
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void AddItemToMenu()
        {
            Console.Clear();
            Console.WriteLine("Please enter the name of the menu item: ");
            string userInputName = Console.ReadLine();
            Console.WriteLine("Please enter the description for the menu item: ");
            string userInputDescription = Console.ReadLine();
            Console.WriteLine("Please enter the ingredients in the menu item: ");
            string userInputIngredients = Console.ReadLine();
            Console.WriteLine("Please enter the price of the menu item: ");
            decimal userInputPrice = decimal.Parse(Console.ReadLine());
            Menu itemToBeAddedToDataBase = new Menu(userInputName, userInputDescription, userInputIngredients, userInputPrice);
            bool isSuccessful = _menuRepo.AddMenuItem(itemToBeAddedToDataBase);
            if (isSuccessful)
            {
                Console.WriteLine("Item successfully added to the database!");
            }
            else
            {
                Console.WriteLine("Item was NOT added to the database!");
            }
        }
        private void RemoveMenuItem()
        {
            ViewAllMenuItems();

            Console.WriteLine("Please enter the name of the menu item you would like to remove: ");

            string input = Console.ReadLine();

            bool wasRemoved = _menuRepo.RemoveMenuItem(input);
            if (wasRemoved)
            {
                Console.WriteLine("The item was successfully removed.");
            }
            else
            {
                Console.WriteLine("The item could not be removed from the menu");
            }
        }
        private void ViewAllMenuItems()
        {
            Console.Clear();
            List<Menu> listOfMenuItems = _menuRepo.SeeAllMenuItems();
            foreach (var menuItem in listOfMenuItems)
            {
                DisplayMenuItemInfo(menuItem);
            }
        }
        private void DisplayMenuItemInfo(Menu menuItem)
        {
            Console.WriteLine($"ID: {menuItem.MenuId} \n" +
                $"Name: {menuItem.Name} \n" +
                $"Desc: {menuItem.Description} \n" +
                $"Ingredients: {menuItem.Ingredients} \n" +
                $"Price: ${menuItem.Price} \n");
            Console.WriteLine("**********************************");
        }
    }
}
