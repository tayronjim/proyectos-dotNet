using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proyApiREST_Net8.Models;

namespace proyApiREST_Net8.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){ }

        public DbSet<Person> Persons {get;set;}
    }
}