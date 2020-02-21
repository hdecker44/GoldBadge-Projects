using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public class ClaimsRepository
    {
        Queue<Claim> _claims = new Queue<Claim>();

        public Queue<Claim> GetContents()
        {
            return _claims;
        }
        public bool Enqueue(Claim content)
        {
            int directoryLength = _claims.Count();
            _claims.Enqueue(content);
            bool wasAdded = directoryLength + 1 == _claims.Count();
            return wasAdded;
        }
        public void AddNewClaim()
        {
            Claim content = new Claim();

            Console.WriteLine("Input Claim ID: ");
            string claimIDString = Console.ReadLine();
            content.ID = Convert.ToInt32(claimIDString);

            Console.WriteLine("Input Claim Type: \n" +
                "1) Car \n" +
                "2) Home \n" +
                "3) Theft");
            string claimType = Console.ReadLine();
 
            switch (claimType)
            {
                case "1":
                    content.ClaimType = Types.Car;
                    break;
                case "2":
                    content.ClaimType = Types.Home;
                    break;
                case "3":
                    content.ClaimType = Types.Theft;
                    break;
            }
            Console.WriteLine("Input Description: ");
            content.Description = Console.ReadLine();

            Console.WriteLine("Input Claim Amount: ");
            string claimAmount = Console.ReadLine();
            content.ClaimAmount = Convert.ToDecimal(claimAmount);

            Console.WriteLine("Input Date of Incident (dd/MM/yyyy): ");
            content.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Input Date of Claim (dd/MM/yyyy): ");
            content.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            _claims.Enqueue(content);

            if (content.IsValid)
            {
                Console.WriteLine("This claim is valid!");
            }
            else
            {
                Console.WriteLine($"This claim is not valid.");
            }
            Console.WriteLine($"Claim {content.ID} successfully added!\n" +
                $"\n" +
                $"\n" +
                $"Press any key to continue");
            Console.ReadLine();
        }
        public void NextClaim()
        {
            while (_claims.Count > 0)
            {
                var val = _claims.Dequeue();

                if (_claims.Count > 0)
                {
                    var next = _claims.Peek();
                    Console.WriteLine("Here are the details for the next claim to be handled: ");
                    Console.WriteLine($"ClaimID: {next.ID}\n" +
                        $"Type: {next.ClaimType}\n" +
                        $"Description: {next.Description}\n" +
                        $"Amount: {next.ClaimAmount}\n" +
                        $"Date Of Accident: {next.DateOfIncident}\n" +
                        $"Date Of Claim: {next.DateOfClaim}\n" +
                        $"Is Valid? {next.IsValid}\n" +
                        $"\n" +
                        $"Do you want to deal with this claim now(y/n)? ");
                    string claimResponse = Console.ReadLine();
                    switch (claimResponse)
                    {
                        case "y":
                            break;
                        case "n":
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public void ShowAllClaims()
        {
            foreach(Claim claim in _claims)
            {
                Console.WriteLine($"Claim ID: {claim.ID}   Description: {claim.Description}   Type: {claim.ClaimType}   Amount: {claim.ClaimAmount}   Date of Accident: {claim.DateOfIncident}   Date of Claim: {claim.DateOfClaim}   Is Valid? {claim.IsValid}");
            }
            Console.ReadLine();
        }
    }
}
