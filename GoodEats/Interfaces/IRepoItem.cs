using System;

namespace GoodEats.Interfaces
{
  public interface IRepoItem<T>
  {
    T Id { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }


    // NOT FOR THIS APP BUT MAAAAYBE LATER....
    // string CreatorId { get; set; }
    // Profile Creator { get; set; }
  }
}