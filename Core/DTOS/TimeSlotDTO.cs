﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOS
{
   public record TimeSlotDTO(int Id,int DinningTableId,DateTime ReservationDay, string MealType, string TableStatus);

}
