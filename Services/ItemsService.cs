using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Db;
using BurgerShack.Models;
using BurgerShack.Repositories;

namespace BurgerShack.Services
{
  public class ItemsService
  {
    private readonly ItemRepository _repo;
    public ItemsService(ItemRepository repo)
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
      if (exists == null) { throw new Exception("Bad ID"); }
      return exists;
    }

    public Item Create(Item newItem)
    {
      Item exists = _repo.Exists("name", newItem.Name);
      if (exists != null) { throw new Exception("We already have that on the menu!"); }
      newItem.Id = Guid.NewGuid().ToString();
      _repo.Create(newItem);
      return newItem;
    }

    public Item Edit(Item editItemData)
    {
      Item item = _repo.Get(editItemData.Id);
      if (item == null) { throw new Exception("Invalid Id"); }
      item.Name = editItemData.Name;
      item.Description = editItemData.Description;
      item.Price = editItemData.Price;
      _repo.Edit(editItemData);
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