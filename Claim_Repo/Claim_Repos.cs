using ClaimPOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim_Repo
{
    public class Claim_Repos
    {
        private readonly Queue<Claim> _ClaimsRepo = new Queue<Claim>();

        private int _Count = 0;

        public bool AddClaim(Claim claim)
        {
            if (claim != null)
            {
                _Count++;
                claim.ID = _Count;
                _ClaimsRepo.Enqueue(claim);
                return true;
            }
            return false;
        }
        public Queue<Claim> GetClaims()
        {
            return _ClaimsRepo;
        }
        public Claim TakeCareOfClaim()
        {
            return _ClaimsRepo.Dequeue(); 
            
        }
        public Claim ViewNextClaim()
        {
           return _ClaimsRepo.Peek();
        }
    }
}