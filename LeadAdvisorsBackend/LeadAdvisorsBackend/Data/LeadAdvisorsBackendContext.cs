using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LeadAdvisorsBackend.Models;

namespace LeadAdvisorsBackend.Data
{
    public class LeadAdvisorsBackendContext : DbContext
    {
        public LeadAdvisorsBackendContext (DbContextOptions<LeadAdvisorsBackendContext> options)
            : base(options)
        {
        }

        public DbSet<LeadAdvisorsBackend.Models.Email> Email { get; set; }
    }
}
