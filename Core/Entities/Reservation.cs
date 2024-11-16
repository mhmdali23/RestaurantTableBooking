using System;
using System.Collections.Generic;

namespace Core.Entities;

public  class Reservation
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int DiningTableId { get; set; }
    public int TimeSlotId { get; set; }
    public DateTime ReservationDate { get; set; }
    public virtual DiningTable DiningTable { get; set; } = null!;
    public virtual TimeSlot TimeSlot { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}
