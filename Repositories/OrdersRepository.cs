using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class OrdersRepository
  {
    private readonly IDbConnection _db;
    public OrdersRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Order> Get()
    {
      string sql = "SELECT * FROM items";
      return _db.Query<Order>(sql);
    }
    internal Order Get(string id)
    {
      string sql = "SELECT * FROM orders WHERE id = @id";
      return _db.QueryFirstOrDefault<Order>(sql, new { id });
    }
    internal Order Exists(string property, string value)
    {
      string sql = "SELECT * FROM orders WHERE @property = @value";
      return _db.QueryFirstOrDefault<Order>(sql, new { property, value });
    }
    internal void Create(Order orderData)
    {
      string sql = @"
        INSERT INTO orders
        (id, customerName)
        VALUES
        (@Id, @CustomerName)
        ";
      _db.Execute(sql, orderData);
    }
    internal void Edit(Order orderData)
    {
      string sql = @"
        UPDATE orders
        SET 
        name = @Name,
        description = @Description,
        price = @Price,
        WHERE id = @id;
        ";
      _db.Execute(sql, orderData);
    }
    internal void Remove(string id)
    {
      string sql = "DELETE FROM orders WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}