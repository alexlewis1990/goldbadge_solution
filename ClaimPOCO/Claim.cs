using ClaimPOCO.ENUMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimPOCO
{
    public class Claim
    {
        public int ID { get; set; }

        public ClaimType ClaimType { get; set; }

        public string Description { get; set; }

        public decimal ClaimAmount { get; set; }

        public DateTime DateOfIncedent { get; set; }

        public DateTime DateOfClaim { get; set; }

        public bool IsValid { get; set; }


        public Claim()
        {

        }

        public Claim(ClaimType claimtype, string description, decimal claimamount, DateTime dateofincedent, DateTime dateofclaim, bool isvalid)
        {
            ClaimType = claimtype;
            Description = description;
            ClaimAmount = claimamount;
            DateOfIncedent = dateofincedent;
            DateOfClaim = dateofclaim;
            IsValid = isvalid;
        }
    }
}
