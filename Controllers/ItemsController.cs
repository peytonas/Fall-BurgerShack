using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurgerShack.Db;
using BurgerShack.Models;
using BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BurgerShack.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ItemsController : ControllerBase
  {
    private readonly ItemsService _iss;
    public ItemsController(ItemsService iss)
    {
      _iss = iss;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Item>> Get()
    {
      try
      {
        return Ok(_iss.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }

    [HttpGet("{id}")]
    public ActionResult<Item> Get(string id)
    {
      try
      {
        return Ok(_iss.Get(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Item> Post([FromBody] Item newItem)
    {
      try
      {
        return Ok(_iss.Create(newItem));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Item> Edit(string id, [FromBody] Item editItemData)
    {
      try
      {
        editItemData.Id = id;
        return Ok(_iss.Edit(editItemData));
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
        return Ok(_iss.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
