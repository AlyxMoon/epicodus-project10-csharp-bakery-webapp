using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bakery.Models
{
  public class Vendor
  {
    private static int NextId = 1;

    public int Id { get; private set; }

    [Required()]
    [DisplayName("Vendor Name")]
    public string Name { get; set; }

    [DataType(DataType.MultilineText)]
    [DisplayName("Description")]
    public string Description { get; set; }

    public List<Order> Orders { get; set; }

    public static void ResetIdCount ()
    {
      NextId = 1;
    }

    public Vendor (string name = "", string description = "")
    {
      Name = name;
      Description = description;
      Orders = new();
      Id = NextId++;
    }

    public Order AddOrder (Order order)
    {
      Orders.Add(order);
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
      return order;
    }
  }
}