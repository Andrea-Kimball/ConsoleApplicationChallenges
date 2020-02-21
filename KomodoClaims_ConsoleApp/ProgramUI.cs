using KomodoClaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_ConsoleApp
{
    class ProgramUI
    {
        private ClaimRepository _claimsListRepo = new ClaimRepository();

        public void Run()
        {
            SeedClaims();
            ViewMenu();
        }
        private void ViewMenu()

        {
            bool keeprunning = true;
            while (keeprunning)
            {
                Console.WriteLine("Select an option by number:\n" +
                   "1. See all claims \n" +
                   "2. Take care of next claim\n" +
                   "3. Enter a new claim \n" +
                   "4. Exit ");
                //prompt the user 
                string input = Console.ReadLine();

                //evaluate users input and act accordingly
                switch (input)
                {
                    case "1":
                        //See all claims
                        SeeAllClaims();
                        break;
                    case "2":
                        //Take care of next claim
                         ViewNextClaim();
                        break;
                    case "3":
                        //Enter a new claim
                        EnterNewClaim();
                        break;
                    case "4":
                        //exit
                        Console.WriteLine("Goodbye");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;

                }
                Console.WriteLine("please press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
           

        }

        //Enter a new claim
        private void EnterNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            //claim ID
            Console.WriteLine("Enter the Claim ID:");
            string ItemasString = Console.ReadLine();
            newClaim.ClaimID = int.Parse(ItemasString);

            //type
            Console.WriteLine("Enter the claim Type");
            string TypeString = Console.ReadLine();
            int ClaimType = int.Parse(TypeString);


            //Description
            Console.WriteLine("Enter the description of the claim:");
            newClaim.Description = Console.ReadLine();

            //amount
            Console.WriteLine("Enter the amount of this claim: $");
            string AmountAsString = Console.ReadLine();
            newClaim.ClaimAmount = double.Parse(AmountAsString);

            //Date of accident
            Console.WriteLine("Enter the Date of the accident:");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());


            //Date of claim
            Console.WriteLine("Enter the Date of the accident:");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());


            //Valid
            Console.WriteLine("is this claim valid?:");
            newClaim.IsValid = bool.Parse(Console.ReadLine());


            _claimsListRepo.AddClaimToQueue(newClaim);

        }
        private void SeeAllClaims()
        {
            Queue<Claim> claimQueue = _claimsListRepo.GetClaim();
            foreach (Claim claim in claimQueue)
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID} \n" +
                    $"Claim Type: {claim.TypeOfClaim} \n" +
                    $"Description: {claim.Description} \n" +
                    $"Amount: {claim.ClaimAmount} \n" +
                    $"Date Of Incident: {claim.DateOfIncident} \n" +
                    $"Date of Claim: {claim.DateOfClaim} \n" +
                    $"Is Valid: {claim.IsValid}");

                
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

        }

        private void ViewNextClaim()
        {
            Claim claimQueue = _claimsListRepo.RemoveClaimFromQueue();
            Console.WriteLine("Do you want to address this claim now? (y/n):");
            String UserInput = Console.ReadLine();

            if (UserInput == "y")
            {
               
            }

            else
            {
                Console.Clear();
            }

        }


        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SeedClaims()
        {
            Claim auto = new Claim(1, ClaimType.Car, "car accident on 465", 400, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);


            Claim home = new Claim(2, ClaimType.Home, "House fire in kitchen", 4000, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12), true);

            Claim theft = new Claim(3, ClaimType.Theft, "stolen pancakes", 4, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1), false);

            _claimsListRepo.AddClaimToQueue(auto);
            _claimsListRepo.AddClaimToQueue(home);
            _claimsListRepo.AddClaimToQueue(theft);

        }
    }

}




