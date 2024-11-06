using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class TimeSlot
{
    public int Id { get; set; }

    public int DinningTableId { get; set; }

    public DateTime ReservationDay { get; set; }

    public string MealType { get; set; } = null!;

    public string TableStatus { get; set; } = null!;

    public virtual DinningTable DinningTable { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
