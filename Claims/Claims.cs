using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public enum Types { Car, Home, Theft}
    public class Claim
    {
        public int ID { get; set; }
        public Types ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                TimeSpan daysSince = DateOfClaim - DateOfIncident;
                double daysDouble = daysSince.Days;
                int days = Convert.ToInt32(Math.Floor(daysDouble));
                
                if (days <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Claim() { }
        public Claim(int id, Types claimType, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ID = id;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
