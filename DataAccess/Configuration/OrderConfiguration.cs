using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace DataAccess.Configuration
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable("Order");

			builder.HasKey(o => o.Id);
			builder.Property(o => o.Id)
				   .ValueGeneratedOnAdd()
				   .UseIdentityAlwaysColumn();

			builder.Property(o => o.Status)
			.HasConversion<string>()
			.IsRequired();

			builder.HasOne(o => o.Book)
				   .WithMany(b => b.Orders)
				   .HasForeignKey(o => o.BookId)
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
