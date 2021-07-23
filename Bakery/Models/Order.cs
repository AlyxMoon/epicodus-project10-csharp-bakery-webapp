using System;

namespace Bakery.Models
{
  public class Order
  {
    private static int NextId = 1;
    public int Id { get; private set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; }

    public static void ResetIdCount ()
    {
      NextId = 1;
    }

    public Order (string title = "", string description = "")
    {
      Title = title;
      Description = description;
      Date = DateTime.Now;
      Id = NextId++;
    }
  }
}