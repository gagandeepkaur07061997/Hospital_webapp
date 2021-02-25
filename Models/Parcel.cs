using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_webapp.Models
{
    public class Parcel
    {
        public int Id { get; set; }
        [Required]
        public string Delivery_address { get; set; }

        public string Parcel_weight { get; set; }
        [Required]
        public string Content_type { get; set; }
        public Decimal Shipping_cost { get; set; }

        public int SenderdetailsId { get; set; }
        public Senderdetails Senderdetails { get; set; }

        public int CompanydetailsId { get; set; }
        public Companydetails Companydetails { get; set; }

        public int RecieverdetailsId { get; set; }
        public Recieverdetails Recieverdetails { get; set; }
    }
}
