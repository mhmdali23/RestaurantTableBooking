using System;
using System.Collections.Generic;

namespace Core.Entities;

public  class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;

    public byte[]? ProfileImage { get; set; }=null;

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
