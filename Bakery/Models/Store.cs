using System.Collections.Generic;

namespace Bakery.Models
{
  public class Store
  {
    public Dictionary<string, int> Inventory { get; private set; }
    public List<Order> Orders { get; private set; }
    public List<Vendor> Vendors { get; private set; }

    public Store ()
    {
      Inventory = new();
      Orders = new();
      Vendors = new();
    }
  }
}