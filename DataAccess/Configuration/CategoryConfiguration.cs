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
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("Category");

			builder.HasKey(t => t.Id);

			builder.Property(t => t.Id)
					.ValueGeneratedOnAdd()
					.UseIdentityAlwaysColumn();

			builder.Property(t => t.Name)
					.IsRequired()
					.HasMaxLength(100);
		}
	}
}
