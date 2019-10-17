using System;
using System.Collections.Generic;
using BurgerShack.Models;
using BurgerShack.Repositories;

namespace BurgerShack.Services
{
  public class ItemsService
  {
    private readonly ItemsRepository _repo;
    public ItemsService(ItemsRepository repo) //REVIEW Dependency Injection
    {
      _repo = repo;
    }
    public IEnumerable<Item> Get()
    {
      return _repo.Get();
    }

    public Item Get(string id)
    {
      Item exists = _repo.Get(id);
      if (exists == null) { throw new Exception("bad ID bruh"); }
      return exists;
    }

    public Item Create(Item newItem)
    {
      string id = _repo.Create(newItem);
      newItem.Id = id;
      return newItem;
    }

    public Item Edit(Item editItemData)
    {
      Item item = _repo.Get(editItemData.Id);
      if (item == null) { throw new Exception("Invalid Id"); }
      item.Name = editItemData.Name;
      item.Price = editItemData.Price;
      _repo.Edit(item);
      return editItemData;
    }

    public string Delete(string id)
    {
      Item item = _repo.Get(id);
      if (item == null) { throw new Exception("Bad ID"); }
      _repo.Remove(id);
      return "successfully deleted";
    }
  }
}