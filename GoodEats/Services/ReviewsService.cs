using System;
using System.Collections.Generic;
using GoodEats.Models;
using GoodEats.Repositories;

namespace GoodEats.Services
{
  public class ReviewsService
  {
    private readonly ReviewsRepository _repo;
    private readonly RestaurantsService _rs;

    public ReviewsService(ReviewsRepository repo, RestaurantsService rs)
    {
      _repo = repo;
      _rs = rs;
    }

    private Review FindReviewByRestaurantAndUser(int restaurantId, string userId)
    {
      Review review = _repo.FindReviewByRestaurantAndUser(restaurantId, userId);
      return review;
    }

    internal List<Review> GetByCreatorId(string id)
    {
      return _repo.GetByCreatorId(id);
    }

    private Review FindById(int id)
    {
      Review review = _repo.FindById(id);
      if (review == null)
      {
        throw new Exception("Invalid Review Id");
      }
      return review;
    }

    internal Review Create(Review newReview)
    {
      Review existing = FindReviewByRestaurantAndUser(newReview.RestaurantId, newReview.CreatorId);
      if (existing != null)
      {
        // If you wanted to allow a 'create' to edit an existing incase they already have one
        // return Edit(newReview);
        throw new Exception("You have already reviewed this location");
      }
      return _repo.Create(newReview);
    }

    internal Review Edit(Review update)
    {
      Review original = FindById(update.Id);
      original.Body = update.Body != null && update.Body.Trim().Length > 0 ? update.Body : original.Body;
      original.Rating = update.Rating;
      original.UpdatedAt = DateTime.Now;
      _repo.Edit(original);
      return original;
    }

    internal List<Review> GetByRestaurantId(int id)
    {
      _rs.GetById(id);
      return _repo.GetByRestaurantId(id);
    }

    internal void Delete(int id, string userId)
    {
      Review toDelete = FindById(id);
      if (toDelete.CreatorId != userId)
      {
        throw new Exception("You cannot delete another users review (without paying for it)");
      }
      _repo.Delete(id);
    }
  }
}