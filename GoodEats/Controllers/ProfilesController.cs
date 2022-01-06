using System;
using System.Collections.Generic;
using GoodEats.Models;
using GoodEats.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoodEats.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ReviewsService _rs;

    public ProfilesController(ReviewsService rs)
    {
      _rs = rs;
    }

    [HttpGet("{id}/reviews")]
    public ActionResult<List<Review>> Get(string id)
    {
      try
      {
        List<Review> reviews = _rs.GetByCreatorId(id);
        return Ok(reviews);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}