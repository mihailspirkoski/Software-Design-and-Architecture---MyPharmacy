using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPharmacyDomain.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public double distance { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
    }
}
