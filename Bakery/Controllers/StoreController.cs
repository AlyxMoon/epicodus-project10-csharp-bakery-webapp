using Microsoft.AspNetCore.Mvc;
using Bakery.Models;

namespace Bakery.Controllers
{
  [Route("store")]
  public class StoreController : Controller
  {
    private static readonly Store BakeryStore = new();
 
    [HttpGet]
    public ActionResult Index ()
    {
      BakeryStore.CreateVendor("vendor 1", "test description");
      BakeryStore.CreateVendor("vendor 2", "test description");
      BakeryStore.CreateVendor("vendor 3", "test description");
      BakeryStore.CreateVendor("vendor 4", "test description");

      return View(BakeryStore);
    }

    [HttpGet("vendors")]
    public ActionResult VendorsShowAll ()
    {
      return View(BakeryStore.Vendors);
    }

    [HttpGet("vendors/new")]
    public ActionResult VendorsAddNew ()
    {
      return View();
    }

    [HttpGet("vendors/{vendorId}")]
    public ActionResult VendorsSingleDetails (int vendorId)
    {
      return View(BakeryStore.GetVendor(vendorId));
    }

    [HttpPost("vendors")]
    public ActionResult VendorsCreate (string name, string description)
    {
      BakeryStore.CreateVendor(name, description);
      return RedirectToAction("VendorsShowAll");
    }

    [HttpGet("vendors/{vendorId}/delete")]
    public ActionResult VendorsDelete (int vendorId)
    {
      BakeryStore.DeleteVendor(vendorId);
      return RedirectToAction("VendorsShowAll");
    }

    [HttpGet("orders")]
    [HttpGet("vendors/{vendorId}/orders")]
    public ActionResult OrdersShowAll ()
    {
      return View(BakeryStore);
    }

    [HttpGet("vendors/{vendorId}/orders/new")]
    public ActionResult OrderAddNew (int vendorId)
    {
      return View(BakeryStore.GetVendor(vendorId));
    }

    [HttpGet("orders/{orderId}")]
    [HttpGet("vendors/{vendorId}/orders/{orderId}")]
    public ActionResult OrdersSingleDetails (int orderId)
    {
      return View(BakeryStore.GetOrder(orderId));
    }

    [HttpPost("vendors/{vendorId}/orders")]
    public ActionResult OrdersCreate (int vendorId, string title, string description)
    {
      BakeryStore.CreateOrder(vendorId, title, description);
      return RedirectToAction("OrdersShowAll");
    }

    [HttpGet("orders/{orderId}/delete")]
    [HttpGet("vendors/{vendorId}/orders/{orderId}/delete")]
    public ActionResult OrdersDelete (int orderId)
    {
      BakeryStore.DeleteOrder(orderId);
      return RedirectToAction("OrdersShowAll");
    }
  }
}