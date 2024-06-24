using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_Net8.Models;


namespace MVC_Net8.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options){ }

        public DbSet<Lenguajes> lenguajes {get;set;}
    }
}