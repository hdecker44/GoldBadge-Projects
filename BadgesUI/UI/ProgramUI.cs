using Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesUI.UI
{
    class ProgramUI
    {
        private readonly BadgesRepository _badgesRepository = new BadgesRepository();
        public void Run()
        {
            BadgesSeed();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Select an option number:\n" +
                    "1. Create New Badge\n" +
                    "2. Update Current Badge\n" +
                    "3. List All Badges\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                switch (userInput)
                {
                    case "1":
                        _badgesRepository.CreateNewBadge();
                        break;
                    case "2":
                        _badgesRepository.UpdateBadge();
                        break;
                    case "3":
                        ShowAllContent();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                }
            }
        }
        public void BadgesSeed()
        {
            string a1 = "A1";
            string a2 = "A2";
            string a3 = "A3";
            string a4 = "A4";
            string a5 = "A5";
            string b1 = "B1";
            string b2 = "B2";
            string b3 = "B3";
            string b4 = "B4";
            string b5 = "B5";
            string c1 = "C1";
            string c2 = "C2";
            string c3 = "C3";
            string c4 = "C4";
            string c5 = "C5";
            string d1 = "D1";
            string d2 = "D2";
            string d3 = "D3";
            string d4 = "D4";
            string d5 = "D5";
            string e1 = "E1";
            string e2 = "E2";
            string e3 = "E3";
            string e4 = "E4";
            string e5 = "E5";

            Badge badge1 = new Badge("12345", new List<string>() { a1, e2, c3, d1, d4 });
            _badgesRepository.AddSeed(badge1.BadgeID, badge1.DoorName);
            Badge badge2 = new Badge("12346", new List<string>() { a1, b1, c1, d1, e1 });
            _badgesRepository.AddSeed(badge2.BadgeID, badge2.DoorName);
            Badge badge3 = new Badge("12347", new List<string>() { a1, b1 });
            _badgesRepository.AddSeed(badge3.BadgeID, badge3.DoorName);
            Badge badge4 = new Badge("12348", new List<string>() { a1, d2, e5, a2 });
            _badgesRepository.AddSeed(badge4.BadgeID, badge4.DoorName);
        }
        private void ShowAllContent()
        {
            Console.Clear();
            Dictionary<string, List<string>> dictionary = _badgesRepository.GetContents();

            foreach (KeyValuePair<string, List<string>> kvp in dictionary)
            {
                string values = "";
                foreach(string item in kvp.Value)
                {
                    values += item + ", ";
                }
                Console.WriteLine($"Key: {kvp.Key}, Value(s): {values}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
