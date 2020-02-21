using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class CafeRepository
    {
        protected readonly List<Menu> _menu = new List<Menu>();

        public bool Add(Menu content)
        {
            int directoryLength = _menu.Count();
            _menu.Add(content);
            bool wasAdded = directoryLength + 1 == _menu.Count();
            return wasAdded;
        }
        public Menu RandomMenuItem()
        {
            int listLength = _menu.Count();

            Random random = new Random();
            int randomIndex = random.Next(0, listLength);
            Menu menuItem = _menu[randomIndex];

            return menuItem;
        }
        public void AddItemToMenu()
        {
            Menu content = new Menu();

            Console.WriteLine("Input Item Number: ");
            string numberInput = Console.ReadLine();
            content.Number = Convert.ToInt32(numberInput);

            Console.WriteLine("Input Item Name: ");
            content.Name = Console.ReadLine();

            Console.WriteLine("Input Item Description: ");
            content.Description = Console.ReadLine();

            // new List<string>() { };
            string ingredientInput = "";

            while (ingredientInput != "n")
            {
                Console.WriteLine("Input an item Ingredient (if no more ingredients, input 'n'): ");
                ingredientInput = Console.ReadLine();
                content.Attachments.Add(ingredientInput);
            }

            Console.WriteLine("Input Item Price: ");
            string priceInput = Console.ReadLine();
            content.Price = Convert.ToDecimal(priceInput);

            _menu.Add(content);

            Console.WriteLine($"Menu item {content.Name} added to menu");
        }
        public void DeleteItem()
        {
            Console.WriteLine("Input ItemID of the menu item you would like to delete: ");
            string deleteInput = Console.ReadLine();
            int delete = Convert.ToInt32(deleteInput);
            foreach (Menu item in _menu)
            {
                if (delete == item.Number)
                {
                    _menu.Remove(item);

                    Console.WriteLine($"Item '{item.Name}' removed successfully");
                }
                else
                {
                    Console.WriteLine("Item ID not found");
                }
            }
        }
        public void ShowAllItems()
        {
            foreach (Menu item in _menu)
            {
                Console.WriteLine(item.Name);
            }
        }
        public List<Menu> GetContents()
        {
            return _menu;
        }
    }
}
