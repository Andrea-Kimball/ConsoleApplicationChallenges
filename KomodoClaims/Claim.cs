using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    public enum ClaimType { Car=1, Home=2, Theft=3};
    public class Claim
    {
        
        static void Main(string[] args) { }
        
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim{ get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }


        public Claim() { }
        public Claim(int claimID, ClaimType typeOfClaim, string description, double claimamount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimamount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }
    }
}
