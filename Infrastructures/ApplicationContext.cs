using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiladHosSignalR.Domain.Entities;

namespace MiladHosSignalR.Infrastructures
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<VWSurgeryReception> VWSurgeryReception { get; set; }
      
    }
}
