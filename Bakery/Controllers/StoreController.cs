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
    public ActionResult OrdersShowAll (int vendorId)
    {
      if (vendorId == 0) return View(BakeryStore.Orders);

      return View(BakeryStore.GetVendor(vendorId).Orders);
    }

    [HttpGet("vendors/{vendorId}/orders/new")]
    public ActionResult OrdersAddNew (int vendorId)
    {
      ViewBag.VendorId = vendorId;
      return View();
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