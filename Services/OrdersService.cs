using System;
using System.Collections.Generic;
using BurgerShack.Models;
using BurgerShack.Repositories;

namespace BurgerShack.Services
{
  public class OrdersService
  {
    private readonly OrdersRepository _repo;
    public OrdersService(OrdersRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Order> Get()
    {
      return _repo.Get();
    }
    public Order Get(string id)
    {
      Order exists = _repo.Get(id);
      if (exists == null) { throw new Exception("bad ID bruh"); }
      return exists;
    }
    public Order Create(Order newOrder)
    {
      int id = _repo.Create(newOrder);
      newOrder.Id = id;
      return newOrder;
    }
    public Order Edit(Order editOrderData)
    {
      Order order = _repo.Get(editOrderData.Id);
      if (order == null) { throw new Exception("bad ID bruh"); }
      order.CustomerName = editOrderData.CustomerName;
      _repo.Edit(order);
      return editOrderData;
    }
    public string Delete(string id)
    {
      Order order = _repo.Get(id);
      if (order == null) { throw new Exception("bad ID bruh"); }
      _repo.Remove(id);
      return "deleted!";
    }
  }
}