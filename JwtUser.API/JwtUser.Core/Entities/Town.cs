using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtUser.Core.Entities
{
    public class Town : BaseEntity
    {
        public string Name { get; set; }


        public int CityId { get; set; }
        public City City { get; set; }
        public ICollection<Street> Streets { get; set; }
    }
}
