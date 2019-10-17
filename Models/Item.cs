using BurgerShack.Interfaces;

namespace BurgerShack.Models
{
  public class Item : IItem
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

  }
}