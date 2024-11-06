using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOS
{
    public record RestaurantBranchDTO(int Id,int RestaurantId, string Name, string Address, string? Email, string? Phone, string? ImageUrl);

}
