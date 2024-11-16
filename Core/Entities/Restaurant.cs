using System;
using System.Collections.Generic;

namespace Core.Entities;

public  class Restaurant
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<RestaurantBranch> RestaurantBranches { get; set; } = new List<RestaurantBranch>();
}
