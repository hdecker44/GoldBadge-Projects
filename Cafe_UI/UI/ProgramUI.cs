using Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_UI.UI
{
    class ProgramUI
    {
        private readonly CafeRepository _cafeRepository = new CafeRepository();
        public void Run()
        {
            AddMenuItem();
            RunMenu();
            
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Select an option number:\n" +
                    "1. Add Menu Item\n" +
                    "2. Delete Menu Item\n" +
                    "3. Show All Menu Items\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                switch (userInput)
                {
                    case "1":
                        AddItemToMenu();
                        break;
                    case "2":
                        DeleteItem();
                        break;
                    case "3":
                        ShowAllItems();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                }
            }
        }
        public void ShowAllItems()
        {
            Console.Clear();
            List<Menu> directory = _cafeRepository.GetContents();
            foreach (Menu item in directory)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public void AddItemToMenu()
        {
            Console.Clear();
            List<Menu> directory = _cafeRepository.GetContents();

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
                if (ingredientInput != "n")
                {
                    content.Attachments.Add(ingredientInput);
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Input Item Price: ");
            string priceInput = Console.ReadLine();
            content.Price = Convert.ToDecimal(priceInput);

            directory.Add(content);

            Console.WriteLine($"Menu item {content.Name} added to menu");
        }
        public void DeleteItem()
        {
            Console.WriteLine("Input ItemID of the menu item you would like to delete: ");
            string deleteInput = Console.ReadLine();
            int delete = Convert.ToInt32(deleteInput);
            Console.Clear();
            List<Menu> directory = _cafeRepository.GetContents();
            foreach (Menu item in directory)
            {
                if (delete == item.Number)
                {
                    directory.Remove(item);

                    Console.WriteLine($"Item '{item.Name}' removed successfully");
                    break;
                } 
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();             
        }
        public void AddMenuItem()
        {
            string burgerBun = "Burger Bun";
            string hotDogBun = "Hot Dog Bun";
            string beefPatty = "Beef Patty";
            string chickenPatty = "Chicken Patty";
            string individualChickenNuggets = "Chicken Nuggets";
            string individualHotDog = "Hot Dog";
            string fries = "French Fries";
            string americanCheese = "American Cheese";
            string nachoCheese = "Nacho Cheese";
            string baconBits = "Bacon Bits";
            string ranch = "Ranch";
            string bbqSauce = "BBQ Sauce";
            string jalepenos = "Jalepenos";
            string tomato = "Tomato";
            string lettuce = "Lettuce";
            string onion = "Onion";
            string pickle = "Pickle";
            string iceCream = "Ice Cream";
            string chocolate = "Chocolate";
            string vanilla = "Vanilla";
            string milk = "Milk";

            Menu burger = new Menu(1, "Burger", "Single patty beef burger", new List<string>() { burgerBun, beefPatty }, 4.99m);
            _cafeRepository.Add(burger);

            Menu burgerDeluxe = new Menu(2, "Deluxe Burger", "Single patty beef burger with toppings", new List<string>() { burgerBun, beefPatty, lettuce, tomato, pickle, onion }, 5.49m);
            _cafeRepository.Add(burgerDeluxe);

            Menu cheeseBurger = new Menu(3, "Cheeseburger", "Single patty beef burger with American cheese", new List<string>() { burgerBun, beefPatty, americanCheese }, 5.99m);
            _cafeRepository.Add(cheeseBurger);

            Menu cheeseBurgerDeluxe = new Menu(4, "Deluxe Cheeseburger", "Single patty beef burger with American cheese and toppings", new List<string>() { burgerBun, beefPatty, americanCheese, lettuce, tomato, pickle, onion }, 6.49m);
            _cafeRepository.Add(cheeseBurgerDeluxe);

            Menu chickenSandwich = new Menu(5, "Chicken Sandwich", "Fresh chicken sandwich", new List<string>() { burgerBun, chickenPatty, pickle }, 4.99m);
            _cafeRepository.Add(chickenSandwich);

            Menu chickenSandwichDeluxe = new Menu(6, "Deluxe Chicken Sandwich", "Fresh chicken sandwich with toppings", new List<string>() { burgerBun, chickenPatty, pickle, lettuce, tomato }, 5.49m);
            _cafeRepository.Add(chickenSandwichDeluxe);

            Menu hotDog = new Menu(7, "Hot Dog", "All beef hot dog", new List<string>() { hotDogBun, individualHotDog }, 2.49m);
            _cafeRepository.Add(hotDog);

            Menu loadedHotDog = new Menu(8, "Loaded Hot Dog", "All beef hot dog LOADED with toppings", new List<string>() { hotDogBun, individualHotDog, nachoCheese, baconBits, jalepenos }, 3.49m);
            _cafeRepository.Add(loadedHotDog);

            Menu frenchFries = new Menu(9, "French Fries", "Freshly salted crisp french fries", new List<string>() { fries }, 1.99m);
            _cafeRepository.Add(frenchFries);

            Menu loadedFries = new Menu(10, "Loaded French Fries", "Freshly salted crisp french fries", new List<string>() { fries, nachoCheese, jalepenos, bbqSauce, ranch, baconBits }, 2.99m);
            _cafeRepository.Add(loadedFries);

            Menu chickenNuggets = new Menu(11, "Chicken Nuggets", "Five chicken nuggets", new List<string>() { individualChickenNuggets }, 1.99m);
            _cafeRepository.Add(chickenNuggets);

            Menu chocolateShake = new Menu(12, "Chocolate Shake", "Thicc Chocolate Shake", new List<string>() { chocolate, milk, iceCream }, 2.99m);
            _cafeRepository.Add(chocolateShake);

            Menu vanillaShake = new Menu(13, "Vanilla Shake", "Thicc Vanilla Shake", new List<string>() { vanilla, milk, iceCream }, 2.99m);
            _cafeRepository.Add(vanillaShake);
        }
    }
}
