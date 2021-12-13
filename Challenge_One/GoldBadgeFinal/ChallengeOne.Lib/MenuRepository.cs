using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne.Lib
{
    public class MenuRepository
    {
        private readonly List<Menu> _menuItems = new List<Menu>();
        private int _count = 0;

        // Create
        public bool AddMenuItem(Menu menuItem)
        {
            if (menuItem == null)
            {
                return false;
            }
            _count++;
            menuItem.MenuId = _count;
            _menuItems.Add(menuItem);
            return true;
        }
        // Read
        public List<Menu> SeeAllMenuItems()
        {
            return _menuItems;
        }

        // Delete
        public bool RemoveMenuItem(string name)
        {
            Menu itemToBeDeleted = GetItemByName(name);
            if (itemToBeDeleted == null)
            {
                return false;
            }
            int intialCount = _menuItems.Count;
            _menuItems.Remove(itemToBeDeleted);
            if (intialCount > _menuItems.Count)
            {
                return true;
            }
            else return false;
        }
        // Helper Method
        public Menu GetItemByName(string name)
        {
            foreach (Menu item in _menuItems)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;
        }
    }
}
