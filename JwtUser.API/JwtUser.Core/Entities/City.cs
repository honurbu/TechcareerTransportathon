using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtUser.Core.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Town> Towns { get; set; }

    }
}
