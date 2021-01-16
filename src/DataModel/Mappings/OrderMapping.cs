using DataModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Mappings
{
	internal class OrderMapping : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable("order");
			builder.HasKey(x => x.OrderId);
			builder.Property(x => x.OrderId).HasColumnName("order_id").IsRequired(true);
			builder.Property(x => x.CustomerFormId).HasColumnName("customer_form_id").IsRequired(true);
			builder.Property(x => x.Status).HasColumnName("order_status").HasColumnType("tinyint").IsRequired(true);
			builder.Property(x => x.OrderDate).HasColumnName("order_dt").HasColumnType("datetime").IsRequired(true);
			builder.Property(x => x.Comment).HasColumnName("comment").HasMaxLength(1000);
		}
	}
}
