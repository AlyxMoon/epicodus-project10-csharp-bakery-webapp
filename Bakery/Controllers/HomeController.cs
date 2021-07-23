using Microsoft.AspNetCore.Mvc;
using Bakery.Models;

namespace Bakery.Controllers
{
  public class HomeController : Controller
  {
    private static Store BakeryStore = new();
 
    [HttpGet("/")]
    public ActionResult Index ()
    {
      BakeryStore.Orders.Add(new Order());

      System.Console.WriteLine(BakeryStore.Orders.Count);

      return View();
    }
  }
}