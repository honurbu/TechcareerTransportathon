using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JwtUser.Core.Entities
{
    public class Transport : BaseEntity
    {
        public int CategoryId { get; set; }

        public string Directions { get; set; }      //adres tarifi


        public int StreetId { get; set; }

        [JsonIgnore]
        public Street Street { get; set; }


        public int HowCarryId { get; set; }

        [JsonIgnore]
         public HowCarry HowCarries { get; set; }    
        
        public int PackageHelperId { get; set; }

        [JsonIgnore]
        public PackageHelper PackageHelpers { get; set; }

        public int InsuranceId { get; set; }


        [JsonIgnore]
        public Insurance Insurances { get; set; }


    }
}
