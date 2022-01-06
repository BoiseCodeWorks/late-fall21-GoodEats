using System;
using System.ComponentModel.DataAnnotations;
using GoodEats.Interfaces;

namespace GoodEats.Models
{
  public class Review : IRepoItem<int>
  {
    public int Id { get; set; }
    public string Body { get; set; }
    [Range(1, 5)]
    public int Rating { get; set; }
    public int RestaurantId { get; set; }
    public string CreatorId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    //VIRTUAL
    public Profile Creator { get; set; }
  }
}