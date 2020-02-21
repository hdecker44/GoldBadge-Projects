using Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_UI.UI
{
    class ProgramUI
    {
        private readonly ClaimsRepository _claimsRepository = new ClaimsRepository();
        public void Run()
        {
            CreateClaims();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Select an option number:\n" +
                    "1. Add New Claim\n" +
                    "2. Next Claim\n" +
                    "3. Show All Claims\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                switch (userInput)
                {
                    case "1":
                        _claimsRepository.AddNewClaim();
                        break;
                    case "2":
                        _claimsRepository.NextClaim();
                        break;
                    case "3":
                        ShowAllClaims();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                }
            }
        }
        private void ShowAllClaims()
        {
            Console.Clear();
            // Get all of our content
            Queue<Claim> directory = _claimsRepository.GetContents();

            // Go through each item and display its properties
            foreach (Claim content in directory)
            {
                Console.WriteLine($"Claim ID: {content.ID}\n" +
                    $"Type: {content.ClaimType}\n" +
                    $"Description: {content.Description}\n" +
                    $"Amoung: {content.ClaimAmount}\n" +
                    $"Date of Incident: {content.DateOfIncident}\n" +
                    $"Date of Claim: {content.DateOfClaim}\n" +
                    $"Valid?: {content.IsValid}\n");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public void CreateClaims()
        {

            Claim claim1 = new Claim(1, Types.Car, "Fender Bender", 300.00m, new DateTime(01 / 15 / 2020), new DateTime(01 / 30 / 2020));
            _claimsRepository.Enqueue(claim1);

            Claim claim2 = new Claim(2, Types.Home, "Flooding", 1000.00m, new DateTime(01 / 01 / 2020), new DateTime(02 / 02 / 2020));
            _claimsRepository.Enqueue(claim2);

            Claim claim3 = new Claim(3, Types.Theft, "Robbed", 543.21m, new DateTime(01 / 01 / 2020), new DateTime(01 / 30 / 2020));
            _claimsRepository.Enqueue(claim3);
        }
    }
}
