
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using N_Tier.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Data.DAL
{
    public class MyDataBaseDbContext: IdentityDbContext<IdentityUser>
    {
        public MyDataBaseDbContext(DbContextOptions<MyDataBaseDbContext> options):base(options)
        {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
    }
}
