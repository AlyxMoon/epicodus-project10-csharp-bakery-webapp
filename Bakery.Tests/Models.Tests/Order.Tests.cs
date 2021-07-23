using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery.Models;

namespace Bakery.Tests
{
  [TestClass]
  public class OrderTests
  {
    [TestMethod]
    public void Constructor_InitializesWithCorrectValues ()
    {
      Order order = new();

      Assert.AreEqual("", order.Title);
      Assert.AreEqual("", order.Description);
      // give a little leeway for date check
      Assert.IsTrue(order.Date >= DateTime.Now.AddSeconds(-5));
      Assert.IsTrue(order.Date <= DateTime.Now.AddSeconds(5));
    }

    [TestMethod]
    public void Constructor_InitializesWithCorrectValues_SetsToValuesProvided ()
    {
      Order order = new("Test Order", "Test Description");

      Assert.AreEqual("Test Order", order.Title);
      Assert.AreEqual("Test Description", order.Description);
    }
  }
}