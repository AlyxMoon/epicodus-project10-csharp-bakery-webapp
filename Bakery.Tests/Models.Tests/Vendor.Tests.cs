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
      Order.ResetIdCount();
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
      Order order = vendor.AddOrder(new Order(
        "Test Order", 
        "description here"
      ));

      Assert.AreEqual("Test Order", order.Title);
      Assert.AreEqual("description here", order.Description);

      CollectionAssert.AreEqual(
        new List<Order> { order },
        vendor.Orders
      );
    }

    [TestMethod]
    public void GetOrder_FindsAndReturnsOrderById_ReturnsCorrectOrder ()
    {
      Vendor vendor = new();
      vendor.AddOrder(new Order(
        "Test Order", 
        "description here"
      ));
      Order order2 = vendor.AddOrder(new Order(
        "Test Order 2", 
        "description here"
      ));
      vendor.AddOrder(new Order(
        "Test Order 3", 
        "description here"
      ));

      Console.WriteLine(vendor.GetOrder(2).Id);
      Console.WriteLine(vendor.GetOrder(2).Title);
      Console.WriteLine(vendor.GetOrder(2).Description);

      Assert.AreSame(
        order2,
        vendor.GetOrder(order2.Id)
      );
    }

    [TestMethod]
    public void GetOrder_FindsAndReturnsOrderById_ReturnsNullIfNotFound ()
    {
      Vendor vendor = new();
      vendor.AddOrder(new Order(
        "Test Order", 
        "description here"
      ));

      Assert.IsNull(vendor.GetOrder(100));
    }

    [TestMethod]
    public void DeleteOrder_FindsAndDeletesOrderById_RemovesOrder ()
    {
      Vendor vendor = new();
      Order order1 = vendor.AddOrder(new Order(
        "Test Order", 
        "description here"
      ));
      Order order2 = vendor.AddOrder(new Order(
        "Test Order 2", 
        "description here"
      ));
      Order order3 = vendor.AddOrder(new Order(
        "Test Order 3", 
        "description here"
      ));

      CollectionAssert.AreEqual(
        new List<Order> { order1, order2, order3 },
        vendor.Orders
      );

      Order deleted1 = vendor.DeleteOrder(order2.Id);
      
      Assert.AreSame(order2, deleted1);
      CollectionAssert.AreEqual(
        new List<Order> { order1, order3 },
        vendor.Orders
      );

      Order deleted2 = vendor.DeleteOrder(order3.Id);

      Assert.AreSame(order3, deleted2);
      CollectionAssert.AreEqual(
        new List<Order> { order1 },
        vendor.Orders
      );
    }

    [TestMethod]
    public void DeleteOrder_FindsAndDeletesOrderById_DoesNothingIfNotFound ()
    {
      Vendor vendor = new();
      Order order1 = vendor.AddOrder(new Order(
        "Test Order 1", 
        "description here"
      ));

      CollectionAssert.AreEqual(
        new List<Order> { order1 },
        vendor.Orders
      );

      Order deleted = vendor.DeleteOrder(410321);

      Assert.IsNull(deleted);
      CollectionAssert.AreEqual(
        new List<Order> { order1, },
        vendor.Orders
      );
    }
  }
}