using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPharmacyDomain.Entities
{
    public class Pharmacy
    {
        [Key]
        public long id { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string name { get; set; }

    }
}
