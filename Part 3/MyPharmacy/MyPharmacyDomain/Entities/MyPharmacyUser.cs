using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPharmacyDomain.Entities
{
    public class MyPharmacyUser: IdentityUser
    {


        public string? Name { get; set; }
        public string? Role { get; set; }
        public DateTime? lastEntryDate { get; set; }
        public int? lastLocationId { get; set; }
        [ForeignKey("LastLocationId")]
        public Location? lastLocation { get; set; }
        public long? lastPharmacyId { get; set; }
        [ForeignKey("LastPharmacyId")]
        public Pharmacy? lastPharmacy { get; set; }

    }
}
