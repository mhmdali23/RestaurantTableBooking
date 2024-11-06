using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOS
{
    public record DinningTableDTO(int Id,int BranchId,string TableName,int Capacity);
}
