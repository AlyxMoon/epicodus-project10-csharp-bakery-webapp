using System.Collections.Generic;

namespace Bakery.Models
{
  public class Vendor
  {
    private static int NextId = 1;
    public int Id { get; private set; }
    public string Name { get; set; }
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
  }
}