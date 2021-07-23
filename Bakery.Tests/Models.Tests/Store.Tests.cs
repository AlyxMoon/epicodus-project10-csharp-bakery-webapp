using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery.Models;

namespace Bakery.Tests
{
  [TestClass]
  public class StoreTests : IDisposable
  {
    public void Dispose ()
    {
      Order.ResetIdCount();
      Vendor.ResetIdCount();
    }

    [TestMethod]
    public void Constructor_InitializesWithCorrectValues ()
    {
      Store store = new();

      Assert.AreEqual(0, store.Inventory.Keys.Count);
      CollectionAssert.AreEquivalent(new List<Order>(), store.Orders);
      CollectionAssert.AreEquivalent(new List<Vendor>(), store.Vendors);
    }
  }
}