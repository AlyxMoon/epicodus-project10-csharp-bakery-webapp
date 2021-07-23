using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery.Models;

namespace Bakery.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {
    public void Dispose ()
    {
      Vendor.ResetIdCount();
    }

    [TestMethod]
    public void Constructor_InitializesWithCorrectValues ()
    {
      Vendor vendor = new();

      Assert.AreEqual("", vendor.Name);
      Assert.AreEqual("", vendor.Description);
      Assert.AreEqual(0, vendor.Orders.Count);
    }

    [TestMethod]
    public void Constructor_InitializesWithCorrectValues_SetsToValuesProvided ()
    {
      Vendor vendor = new("Test Order", "Test Description");

      Assert.AreEqual("Test Order", vendor.Name);
      Assert.AreEqual("Test Description", vendor.Description);
    }

    [TestMethod]
    public void Constructor_ShouldHaveAutoIncrementingId ()
    {
      Vendor vendor1 = new();
      Vendor vendor2 = new();
      Vendor vendor3 = new();

      Assert.AreEqual(1, vendor1.Id);
      Assert.AreEqual(2, vendor2.Id);
      Assert.AreEqual(3, vendor3.Id);
    }

    [TestMethod]
    public void AddOrder_CreatesOrderAndAddsItToTheList_ReturnsOrder ()
    {
      Vendor vendor = new();
      Order order = vendor.AddOrder("Test Order", "description here");

      Assert.AreEqual("Test Order", order.Title);
      Assert.AreEqual("description here", order.Description);

      CollectionAssert.AreEqual(
        new List<Order> { order },
        vendor.Orders
      );
    }
  }
}