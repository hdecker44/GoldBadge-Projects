using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class BadgesRepository
    {
        List<Badge> _badges = new List<Badge>();

        private Dictionary<string, List<string>> internalDictionary = new Dictionary<string, List<string>>();

        public void AddSeed(string key, List<string> list)
        {
            if (this.internalDictionary.ContainsKey(key))
            {

            }
            else
            {
                this.internalDictionary.Add(key, list);
            }
        }

        public void Add(string key, string value)
        {
            if (this.internalDictionary.ContainsKey(key))
            {
                List<string> list = this.internalDictionary[key];
                if (list.Contains(value) == false)
                {
                    list.Add(value);
                }
            }
            else
            {
                List<string> list = new List<string>();
                list.Add(value);
                this.internalDictionary.Add(key, list);
            }
        }
        public void Remove(string key, string value)
        {
            if (this.internalDictionary.ContainsKey(key))
            {
                List<string> list = this.internalDictionary[key];
                if (list.Contains(value) == true)
                {
                    list.Remove(value);
                }
            }
        }
        public Dictionary<string, List<string>> GetContents()
        {
            return internalDictionary;
        }
        public void CreateNewBadge()
        {
            Badge content = new Badge();

            Console.WriteLine("Input BadgeID: ");
            string badgeInput = Console.ReadLine();

            if (this.internalDictionary.ContainsKey(badgeInput))
            {
                Console.WriteLine("This Badge already exists.");
            }
            else
            {
                string input = "";
                bool keepRunning = true;

                Console.WriteLine("What doors can this Badge access?");
                input = Console.ReadLine();

                List<string> list = new List<string>();
                list.Add(input);
                this.internalDictionary.Add(badgeInput, list);

                while (keepRunning)
                {
                    Console.WriteLine("Input another Door or press 'n' if no more doors");
                    input = Console.ReadLine();

                    if (input != "n")
                    {
                        if (list.Contains(input) == false)
                        {
                            list.Add(input);
                        }
                        else
                        {
                            Console.WriteLine($"Already contains {input}");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        keepRunning = false;
                    }
                }
            }
        }
        public void UpdateBadge()
        {
            Console.WriteLine("Input BadgeID you would like to update: ");
            string update = Console.ReadLine();

            if (this.internalDictionary.ContainsKey(update))
            {
                List<string> key = this.internalDictionary[update];
                Console.WriteLine($"{update} has access to doors {key}");
                Console.WriteLine($"What would you like to do?\n" +
                    $"1) Remove a door\n" +
                    $"2) Add a door\n" +
                    $"3) Quit");
                string updateResponse = Console.ReadLine();
                switch (updateResponse)
                {
                    case "1":
                        Console.WriteLine("Which door would you like to remove?");
                        string doorRemove = Console.ReadLine();
                        if (key.Contains(doorRemove))
                        {
                            key.Remove(doorRemove);
                            Console.WriteLine("Door removed.");
                            Console.WriteLine($"{update} has access to doors {key}");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine($"Badge does not have access to {doorRemove}");
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        Console.WriteLine("Which door would you like to add?");
                        string doorAdd = Console.ReadLine();
                        if (key.Contains(doorAdd))
                        {
                            Console.WriteLine($"This badge already has access to {doorAdd}");
                            Console.ReadKey();
                        }
                        else
                        {
                            key.Add(doorAdd);
                            Console.WriteLine("Door added.");
                            Console.WriteLine($"{update} has access to doors {key}");
                            Console.ReadKey();
                        }
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Must input 1, 2, or 3.");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Badge does not exist.");
                Console.ReadLine();

            }
        }
    }
}
