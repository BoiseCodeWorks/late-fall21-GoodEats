using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using GoodEats.Models;
using GoodEats.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoodEats.Controllers
{
  [ApiController]
  // TO LOCK DOWN ENTIRE CONTROLLER WITH AUTH ADD HERE
  [Authorize]
  [Route("api/[controller]")]
  public class ReviewsController : ControllerBase
  {
    private readonly ReviewsService _rs;

    public ReviewsController(ReviewsService rs)
    {
      _rs = rs;
    }


    [HttpPost]
    public async Task<ActionResult<Review>> Create([FromBody] Review newReview)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        newReview.CreatorId = userInfo.Id;
        Review review = _rs.Create(newReview);
        // PRO TIP- Consider what the client will do whith the data you return
        review.Creator = userInfo;
        return Ok(review);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Review>> Edit([FromBody] Review update, int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        update.CreatorId = userInfo.Id;
        update.Id = id;
        Review updated = _rs.Edit(update);
        return Ok(updated);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<String>> Delete(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _rs.Delete(id, userInfo.Id);
        return Ok("Successfully Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }

    }
  }
}