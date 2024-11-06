using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class DinningTable
{
    public int Id { get; set; }

    public int BranchId { get; set; }

    public string? TableName { get; set; }

    public int Capacity { get; set; }

    public virtual RestaurantBranch Branch { get; set; } = null!;

    public virtual ICollection<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();
}
