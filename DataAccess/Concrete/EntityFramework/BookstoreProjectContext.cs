using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class BookstoreProjectContext : DbContext
	{
		public BookstoreProjectContext(DbContextOptions<BookstoreProjectContext> options) : base(options)
		{
		}

		public DbSet<Book> Books { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Order> Orders { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.EnableSensitiveDataLogging(false);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(
				Assembly.GetExecutingAssembly(),
				p => p.GetInterfaces().Any(
					c => c.IsGenericType && c.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
		}
	}
}
