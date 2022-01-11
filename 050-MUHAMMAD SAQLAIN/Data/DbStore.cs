using _050_MUHAMMAD_SAQLAIN.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _050_MUHAMMAD_SAQLAIN.Data
{
    public class DbStore : DbContext
    {
        public DbStore(DbContextOptions<DbStore> options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }

    }
}
