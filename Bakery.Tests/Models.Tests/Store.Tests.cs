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
    
    [TestMethod]
    public void CreateOrder_CreatesNewOrderWithProperties ()
    {
      Store store = new();
      Vendor vendor = store.CreateVendor("vendor 1", "description");
      Order order = store.CreateOrder(vendor.Id, "order 1", "order description");

      Assert.AreEqual("order 1", order.Title);
      Assert.AreEqual("order description", order.Description);
      CollectionAssert.AreEqual(
        new List<Order> { order },
        store.Orders
      );
    }

    [TestMethod]
    public void CreateOrder_CreatesNewOrderWithProperties_OnlyAddsToCorrectVendor ()
    {
      Store store = new();
      Vendor vendor1 = store.CreateVendor("vendor 1", "description");
      Vendor vendor2 = store.CreateVendor("vendor 2", "description");
      Order order = store.CreateOrder(vendor2.Id, "order 1", "order description");

      CollectionAssert.AreEqual(
        new List<Order> { order },
        store.Orders
      );
      CollectionAssert.AreEqual(
        new List<Order> {},
        store.GetVendor(vendor1.Id).Orders
      );
      CollectionAssert.AreEqual(
        new List<Order> { order },
        store.GetVendor(vendor2.Id).Orders
      );
    }

    [TestMethod]
    public void GetOrder_FindAndReturnsOrderById_ReturnsCorrectOrder ()
    {
      Store store = new();
      Vendor vendor1 = store.CreateVendor("vendor 1", "Description of Vendor");
      Order order1 = store.CreateOrder(vendor1.Id, "order 1", "order description");
      Order order2 = store.CreateOrder(vendor1.Id, "order 2", "order description");
      Order order3 = store.CreateOrder(vendor1.Id, "order 2", "order description");

      Assert.AreSame(order2, store.GetOrder(order2.Id));
    }

    [TestMethod]
    public void GetOrder_FindAndReturnsOrderById_ReturnsNullIfNotFound ()
    {
      Store store = new();
      Vendor vendor1 = store.CreateVendor("vendor 1", "Description of Vendor");
      store.CreateOrder(vendor1.Id, "order 1", "order description");

      Assert.IsNull(store.GetVendor(1123));
    }

    [TestMethod]
    public void DeleteOrder_FindsAndDeletesOrderById_RemovesOrder ()
    {
      Store store = new();
      Vendor vendor1 = store.CreateVendor("vendor 1", "Description of Vendor");
      Order order1 = store.CreateOrder(vendor1.Id, "order 1", "description here");
      Order order2 = store.CreateOrder(vendor1.Id, "order 2", "other description");

      CollectionAssert.AreEqual(
        new List<Order> { order1, order2 },
        store.Orders
      );

      Order deleted1 = store.DeleteOrder(order2.Id);
      
      Assert.AreSame(order2, deleted1);
      CollectionAssert.AreEqual(
        new List<Order> { order1 },
        store.Orders
      );

      Order deleted2 = store.DeleteOrder(order1.Id);

      Assert.AreSame(order1, deleted2);
      CollectionAssert.AreEqual(
        new List<Order> {},
        store.Orders
      );
    }

    [TestMethod]
    public void DeleteOrder_FindsAndDeletesOrderById_AlsoRemovesFromVendorOrders ()
    {
      Store store = new();
      Vendor vendor1 = store.CreateVendor("vendor 1", "Description of Vendor");
      Order order1 = store.CreateOrder(vendor1.Id, "order 1", "description here");
      Order order2 = store.CreateOrder(vendor1.Id, "order 2", "other description");


      Order deleted = store.DeleteOrder(order2.Id);
      
      CollectionAssert.AreEqual(
        new List<Order> { order1 },
        store.GetVendor(vendor1.Id).Orders
      );
    }

    [TestMethod]
    public void DeleteOrder_FindsAndDeletesOrderById_DoesNothingIfNotFound ()
    {
      Store store = new();
      Vendor vendor1 = store.CreateVendor("vendor 1", "description here");
      Order order1 = store.CreateOrder(vendor1.Id, "order 1", "description here");

      Assert.IsNull(store.DeleteVendor(410321));
      CollectionAssert.AreEqual(
        new List<Order> { order1, },
        store.Orders
      );
    }
  }
}