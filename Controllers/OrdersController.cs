using System;
using System.Collections.Generic;
using BurgerShack.Models;
using BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class OrdersController : ControllerBase
  {
    private readonly OrdersService _os;
    public OrdersController(OrdersService os)
    {
      _os = os;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Order>> Get()
    {
      try
      {
        return Ok(_os.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }
    [HttpGet("{id}")]
    public ActionResult<Order> GetAction(string id)
    {
      try
      {
        return Ok(_os.Get(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPost]
    public ActionResult<Item> Post([FromBody] Order newOrder)
    {
      try
      {
        return Ok(_os.Create(newOrder));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Order> Edit(int id, [FromBody] Order editOrderData)
    {
      try
      {
        editOrderData.Id = id;
        return Ok(_os.Edit(editOrderData));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(string id)
    {
      try
      {
        return Ok(_os.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}