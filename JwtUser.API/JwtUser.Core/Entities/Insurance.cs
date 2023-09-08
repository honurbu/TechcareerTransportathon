using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtUser.Core.Entities
{
    public class Insurance : BaseEntity
    {
        public int Price { get; set; }

        public ICollection<Transport> Transports { get; set; }

    }
}
