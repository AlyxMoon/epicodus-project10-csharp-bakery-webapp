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
    public ActionResult ShowVendors ()
    {
      return View("Index", BakeryStore);
    }

    [HttpGet("vendors/new")]
    public ActionResult ShowCreateVendor (int vendorId)
    {
      return View();
    }

    [HttpGet("vendors/{vendorId}")]
    public ActionResult ShowVendor (int vendorId)
    {
      return View("Index", BakeryStore);
    }

    [HttpPost("vendors")]
    public ActionResult CreateVendor (Vendor vendor)
    {
      return View("Index", BakeryStore);
    }

    [HttpPost("vendors/{vendorId}/delete")]
    public ActionResult DeleteVendor (int vendorId)
    {
      return View("Index", BakeryStore);
    }

    [HttpGet("orders")]
    [HttpGet("vendors/{vendorId}/orders")]
    public ActionResult ShowOrders (int vendorId)
    {
      return View("Index", BakeryStore);
    }

    [HttpGet("vendors/{vendorId}/orders/new")]
    public ActionResult ShowCreateOrder (int vendorId)
    {
      return View("Index", BakeryStore);
    }

    [HttpGet("orders/{orderId}")]
    [HttpGet("vendors/{vendorId}/orders/{orderId}")]
    public ActionResult ShowOrder (int orderId)
    {
      return View("Index", BakeryStore);
    }

    [HttpPost("vendors/{vendorId}/orders")]
    public ActionResult CreateOrder (Order order)
    {
      return View("Index", BakeryStore);
    }

    [HttpPost("orders/{orderId}/delete")]
    [HttpPost("vendors/{vendorId}/orders/{orderId}/delete")]
    public ActionResult DeleteOrder (int orderId)
    {
      return View("Index", BakeryStore);
    }
  }
}