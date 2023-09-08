using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtUser.Core.Entities
{
    public class PackageHelper : BaseEntity
    {
        public string Name { get; set; }


        public ICollection<Transport> Transports { get; set; }
    }
}
