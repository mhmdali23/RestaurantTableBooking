using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class RestaurantBranch
{
    public int Id { get; set; }

    public int RestaurantId { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<DinningTable> DinningTables { get; set; } = new List<DinningTable>();

    public virtual Restaurant Restaurant { get; set; } = null!;
}
