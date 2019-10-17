namespace BurgerShack.Interfaces
{
  public interface IOrder
  {
    int Id { get; set; }
    string CustomerName { get; set; }
  }
}