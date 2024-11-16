using System;
using System.Collections.Generic;

namespace Core.Entities;

public  class RestaurantBranch
{
    public int Id { get; set; }

    public int RestaurantId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<DiningTable> DinningTables { get; set; } = new List<DiningTable>();

    public virtual Restaurant Restaurant { get; set; } = null!;
}
