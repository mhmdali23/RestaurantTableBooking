using System;
using System.Collections.Generic;

namespace Core.Entities;

public  class DiningTable
{
    public int Id { get; set; }
    public int BranchId { get; set; }
    public int Capacity { get; set; }
    public virtual RestaurantBranch Branch { get; set; } = null!;
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
