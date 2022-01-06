using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using GoodEats.Models;

namespace GoodEats.Repositories
{
  public class ReviewsRepository
  {
    private readonly IDbConnection _db;

    public ReviewsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Review FindReviewByRestaurantAndUser(int restaurantId, string userId)
    {
      string sql = @"
        SELECT * FROM reviews
        WHERE restaurantId = @restaurantId AND creatorId = @userId;
      ";
      return _db.QueryFirstOrDefault<Review>(sql, new { restaurantId, userId });
    }

    internal Review FindById(int id)
    {
      string sql = @"
      SELECT
        r.*,
        a.*
      FROM reviews r
      JOIN accounts a ON r.creatorId = a.id
      WHERE r.id = @id";
      return _db.Query<Review, Profile, Review>(sql, (review, prof) =>
      {
        review.Creator = prof;
        return review;
      }, new { id }).FirstOrDefault();
    }

    internal List<Review> GetByCreatorId(string id)
    {
      string sql = @"
      SELECT
        r.*,
        a.*
      FROM reviews r
      JOIN accounts a ON r.creatorId = a.id
      WHERE r.creatorId = @id";
      return _db.Query<Review, Profile, Review>(sql, (review, prof) =>
      {
        review.Creator = prof;
        return review;
      }, new { id }).ToList();
    }

    internal Review Create(Review newReview)
    {
      string sql = @"
      INSERT INTO reviews
      (body, creatorId, restaurantId, rating)
      VALUES
      (@Body, @CreatorId, @RestaurantId, @Rating);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newReview);
      newReview.Id = id;
      return newReview;
    }



    internal void Edit(Review original)
    {
      string sql = @"
        UPDATE reviews
        SET
          body = @Body,
          rating = @Rating,
          updatedAt = @UpdatedAt
        WHERE id = @Id;";
      _db.Execute(sql, original);
    }

    internal List<Review> GetByRestaurantId(int id)
    {
      string sql = @"
      SELECT
        r.*,
        a.*
      FROM reviews r
      JOIN accounts a ON r.creatorId = a.id
      WHERE r.restaurantId = @id
      ";
      return _db.Query<Review, Profile, Review>(sql, (rev, prof) =>
      {
        rev.Creator = prof;
        return rev;
      }, new { id }).ToList();

    }

    internal void Delete(int id)
    {
      string sql = @"DELETE FROM reviews WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}