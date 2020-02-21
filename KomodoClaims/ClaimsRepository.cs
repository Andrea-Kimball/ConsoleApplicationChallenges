using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Write a take care of next claim method using the dequeue function


namespace KomodoClaims
{
    public class ClaimRepository
    {
        private Queue<Claim> _claimInfo = new Queue<Claim>();

        //See all claims in the queue
        public Queue<Claim> GetClaim()
        {
            return _claimInfo;
        }
           
        //View next claim
        public Claim ViewNextClaim()
        {

        return  _claimInfo.Peek();

        }

        //Take care of next claim
        public Claim RemoveClaimFromQueue()
        {

           return  _claimInfo.Dequeue();

        }


        //Dont need this
        //Update- Take care of next claim
        //public bool UpdateExistingClaim(int originalClaim, Claims newClaim)
        //{
        //    //find the claim
        //    Claims oldClaim = GetClaimByID(originalClaim);

        //    //update the menu item
        //    if (oldClaim != null)
        //    {
        //        oldClaim.ClaimID = newClaim.ClaimID;
        //        oldClaim.TypeOfClaim = newClaim.TypeOfClaim;
        //        oldClaim.Description = newClaim.Description;
        //        oldClaim.ClaimAmount = newClaim.ClaimAmount;
        //        oldClaim.DateOfIncident = newClaim.DateOfIncident;
        //        oldClaim.DateOfClaim = newClaim.DateOfClaim;
        //        oldClaim.IsValid = newClaim.IsValid;

        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //Create a new claim       
        public void AddClaimToQueue(Claim claim)
        {
            _claimInfo.Enqueue(claim);

        }

    }
}
