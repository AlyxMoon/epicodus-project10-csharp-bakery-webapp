using System.Collections.Generic;

namespace Bakery.Models
{
  public class Store
  {
    public Inventory BakeryInventory { get; set; } = new();
    public List<Order> Orders { get; set; } = new();
    public List<Vendor> Vendors { get; set; } = new();
  }
}