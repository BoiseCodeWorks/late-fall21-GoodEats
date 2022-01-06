using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using GoodEats.Models;

namespace GoodEats.Repositories
{
  public class RestaurantsRepository
  {
    private readonly IDbConnection _db;

    public RestaurantsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Restaurant Create(Restaurant newData)
    {
      throw new System.NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }

    public Restaurant Edit(Restaurant newData)
    {
      throw new System.NotImplementedException();
    }

    public List<Restaurant> GetAll()
    {
      string sql = "SELECT * FROM restaurants";
      return _db.Query<Restaurant>(sql).ToList();
    }

    public Restaurant GetById(int id)
    {
      string sql = @"
      SELECT 
        rs.*,
        AVG(rv.rating) AS AverageRating
      FROM restaurants rs
      JOIN reviews rv ON rv.restaurantId = rs.id
      WHERE rs.id = @id;";
      return _db.QueryFirstOrDefault<Restaurant>(sql, new { id });
    }
  }
}