using System;
using Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsRepositoryTest
{
    [TestClass]
    public class ClaimsRepositoryTest
    {
        [TestMethod]
        public void ClaimsTest()
        {
            ClaimsRepository claimsRepository = new ClaimsRepository();
            claimsRepository.CreateClaims();
            claimsRepository.ShowAllClaims();

            claimsRepository.AddNewClaim();
        }
    }
}
