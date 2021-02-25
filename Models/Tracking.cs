using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_webapp.Models
{
    public class Tracking
    {
        public int Id { get; set; }
        [Required]
        public DateTime Expected_date_of_delivery { get; set; }

        public int ParcelId { get; set; }
        public Parcel Parcel { get; set; }
    }
}
