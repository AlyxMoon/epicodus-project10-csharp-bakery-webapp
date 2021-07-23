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

    public Vendor CreateVendor (string title, string description)
    {
      Vendor vendor = new(title, description);
      Vendors.Add(vendor);
      return vendor;
    }

    public Vendor GetVendor (int id)
    {
      foreach (Vendor vendor in Vendors)
      {
        if (vendor.Id == id) return vendor;
      }

      return null;
    }

    public Vendor DeleteVendor (int id)
    {
      Vendor vendor = GetVendor(id);
      Vendors.Remove(vendor);
      return vendor;
    }

    public Order CreateOrder (int vendorId, string title, string description)
    {
      Order order = new(title, description);

      Orders.Add(order);
      GetVendor(vendorId).Orders.Add(order);

      return order;
    }

    public Order GetOrder (int id)
    {
      foreach (Order order in Orders)
      {
        if (order.Id == id) return order;
      }

      return null;
    }

    public Order DeleteOrder (int id)
    {
      Order order = GetOrder(id);

      Orders.Remove(order);

      foreach (Vendor vendor in Vendors)
      {
        vendor.Orders.Remove(order);
      }

      return order;
    }
  }
}