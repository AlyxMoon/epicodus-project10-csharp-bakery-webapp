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

    [TestMethod]
    public void CreateVendor_CreatesNewVendorWithProperties ()
    {
      Store store = new();
      Vendor vendor = store.CreateVendor("Test Vendor", "Description of Vendor");

      Assert.AreEqual("Test Vendor", vendor.Name);
      Assert.AreEqual("Description of Vendor", vendor.Description);
      CollectionAssert.AreEqual(
        new List<Vendor> { vendor },
        store.Vendors
      );
    }

    [TestMethod]
    public void GetVendor_FindAndReturnsVendorById_ReturnsCorrectVendor ()
    {
      Store store = new();
      store.CreateVendor("Test Vendor 1", "Description of Vendor");
      store.CreateVendor("Test Vendor 2", "Description of Vendor");
      Vendor vendor3 = store.CreateVendor("Test Vendor 3", "Description of Vendor");

      Assert.AreSame(vendor3, store.GetVendor(vendor3.Id));
    }

    [TestMethod]
    public void GetVendor_FindAndReturnsVendorById_ReturnsNullIfNotFound ()
    {
      Store store = new();
      store.CreateVendor("Test Vendor 1", "Description of Vendor");

      Assert.IsNull(store.GetVendor(748192));
    }

    [TestMethod]
    public void DeleteVendor_FindsAndDeletesVendorById_RemovesVendor ()
    {
      Store store = new();
      Vendor vendor1 = store.CreateVendor("Test Vendor 1", "description here");
      Vendor vendor2 = store.CreateVendor("Test Vendor 2", "other description");
      Vendor vendor3 = store.CreateVendor("Test Vendor 3", "some other description");

      CollectionAssert.AreEqual(
        new List<Vendor> { vendor1, vendor2, vendor3 },
        store.Vendors
      );

      Vendor deleted1 = store.DeleteVendor(vendor2.Id);
      
      Assert.AreSame(vendor2, deleted1);
      CollectionAssert.AreEqual(
        new List<Vendor> { vendor1, vendor3 },
        store.Vendors
      );

      Vendor deleted2 = store.DeleteVendor(vendor3.Id);

      Assert.AreSame(vendor3, deleted2);
      CollectionAssert.AreEqual(
        new List<Vendor> { vendor1 },
        store.Vendors
      );
    }

    [TestMethod]
    public void DeleteVendor_FindsAndDeletesVendorById_DoesNothingIfNotFound ()
    {
      Store store = new();
      Vendor vendor1 = store.CreateVendor("Test Vendor 1", "description here");

      CollectionAssert.AreEqual(
        new List<Vendor> { vendor1 },
        store.Vendors
      );

      Assert.IsNull(store.DeleteVendor(410321));
      CollectionAssert.AreEqual(
        new List<Vendor> { vendor1, },
        store.Vendors
      );
    }
  }
}