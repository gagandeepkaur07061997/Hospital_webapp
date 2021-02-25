using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hospital_webapp.Models;

namespace Hospital_webapp.Data
{
    public class Hospital_webappDatabase : DbContext
    {
        public Hospital_webappDatabase (DbContextOptions<Hospital_webappDatabase> options)
            : base(options)
        {
        }

        public DbSet<Hospital_webapp.Models.Companydetails> Companydetails { get; set; }

        public DbSet<Hospital_webapp.Models.Recieverdetails> Recieverdetails { get; set; }

        public DbSet<Hospital_webapp.Models.Senderdetails> Senderdetails { get; set; }

        public DbSet<Hospital_webapp.Models.Tracking> Tracking { get; set; }

        public DbSet<Hospital_webapp.Models.Parcel> Parcel { get; set; }
    }
}
