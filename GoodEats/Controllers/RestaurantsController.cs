using System;
using System.Collections.Generic;
using GoodEats.Models;
using GoodEats.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoodEats.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RestaurantsController : ControllerBase
  {
    private readonly RestaurantsService _restaurantsService;
    private readonly ReviewsService _reviewsService;

    public RestaurantsController(RestaurantsService restaurantsService, ReviewsService reviewsService)
    {
      _restaurantsService = restaurantsService;
      _reviewsService = reviewsService;
    }

    [HttpGet]

    public ActionResult<List<Restaurant>> GetAll()
    {
      try
      {
        return Ok(_restaurantsService.GetAll());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]

    public ActionResult<Restaurant> GetById(int id)
    {
      try
      {
        return Ok(_restaurantsService.GetById(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/reviews")]

    public ActionResult<List<Review>> GetReviewsByRestaurantId(int id)
    {
      try
      {
        List<Review> reviews = _reviewsService.GetByRestaurantId(id);
        return Ok(reviews);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}