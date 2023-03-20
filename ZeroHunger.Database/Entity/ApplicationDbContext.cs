using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ZeroHunger.Model;

namespace ZeroHunger.Database.Entity
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
		{
			
		}
		public DbSet<Restaurant> Restaurants { get; set; }
		public DbSet<Request> Requests { get; set; }
        public DbSet<Admin> Admins  { get; set; }

        public DbSet<Employee> Employees { get; set; }

    }
}
