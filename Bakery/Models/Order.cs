using System;

namespace Bakery.Models
{
  public class Order
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; }

    public Order (string title = "", string description = "")
    {
      Title = title;
      Description = description;
      Date = DateTime.Now;
    }
  }
}