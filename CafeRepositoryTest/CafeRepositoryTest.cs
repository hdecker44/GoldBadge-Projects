using System;
using Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeRepositoryTest
{
    [TestClass]
    public class CafeRepositoryTest
    {
        [TestMethod]
        public void TestShowAll()
        {
            CafeRepository cafeRepository = new CafeRepository();
            cafeRepository.AddMenuItem();
            cafeRepository.ShowAllItems();
        }
    }
}
