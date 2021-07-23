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
  }
}