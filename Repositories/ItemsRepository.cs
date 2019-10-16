using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class ItemsRepository
  {
    private readonly IDbConnection _db;
    public ItemsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Item> Get()
    {
      string sql = "SELECT * FROM items";
      return _db.Query<Item>(sql);
    }
    internal Item Get(string id)
    {
      string sql = "SELECT * FROM items WHERE id = @id";
      return _db.QueryFirstOrDefault<Item>(sql, new { id });
    }
    internal Item Exists(string property, string value)
    {
      string sql = "SELECT * FROM items WHERE @property = @value";
      return _db.QueryFirstOrDefault<Item>(sql, new { property, value });
    }
    internal void Create(Item itemData)
    {
      string sql = @"
        INSERT INTO items
        (id, name, description, price)
        VALUES
        (@Id, @Name, @Description, @Price)
        ";
      _db.Execute(sql, itemData);
    }
    internal void Edit(Item itemData)
    {
      string sql = @"
        UPDATE items
        SET 
        name = @Name,
        description = @Description,
        price = @Price
        WHERE id = @id;
        ";
      _db.Execute(sql, itemData);
    }
    internal void Remove(string id)
    {
      string sql = "DELETE FROM items WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}