using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prac_demo_enitity_framework.Models
{
    public class ApplicationDatabaseContext:DbContext
    {
     
        public ApplicationDatabaseContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Admin> Admins { get; set; }
    }

}


