using System;
using GoodEats.Interfaces;

namespace GoodEats.Models
{
  public class Profile : IRepoItem<string>
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Picture { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }

  // ANYTHING IN HERE IS FOR THE USER ONLY
  public class Account : Profile
  {
    public string Email { get; set; }
  }
}