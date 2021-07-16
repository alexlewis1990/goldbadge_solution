using Claim_Repo;
using ClaimPOCO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClaimTest
{
    [TestClass]
    public class ClaimsTest
    {
        [TestMethod]
        public void AddClaimToQueue()
        {
            Claim claim = new Claim();
            Claim_Repos claim_repo = new Claim_Repos();
            bool testResult = claim_repo.AddClaim(claim);

            Assert.IsTrue(testResult);
        }
        public void DeleteClaimFromQueue()
        {
            Claim claim = new Claim();
            Claim_Repos claim_repo = new Claim_Repos();
            claim_repo.AddClaim(claim);
            var result = claim_repo.TakeCareOfClaim();

            Assert.AreEqual(claim, result);
        }
        public void ViewNextClaim()
        {
            Claim claim = new Claim();
            Claim_Repos claim_repo = new Claim_Repos();
            claim_repo.AddClaim(claim);
            var result = claim_repo.ViewNextClaim();

            Assert.AreEqual(claim, result);
        }
    }
}
