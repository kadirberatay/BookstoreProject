using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using System.Reflection.Emit;

namespace DataAccess.Configuration
{
	public class BookConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.ToTable("Book");

			builder.HasKey(t => t.Id);

			builder.Property(t => t.Id)
					.ValueGeneratedOnAdd()
					.UseIdentityAlwaysColumn();

			builder.Property(t => t.Author)
					.IsRequired()
			.HasMaxLength(150);

			builder.Property(b => b.Title)
					.IsRequired()
					.HasMaxLength(200);

			builder.Property(b => b.ISBN)
					.IsRequired()
					.HasMaxLength(13);

			builder.HasOne(o => o.Category)
				   .WithMany(b => b.Books)
				   .HasForeignKey(o => o.CategoryId)
				   .OnDelete(DeleteBehavior.Cascade);
		}
	}
}
