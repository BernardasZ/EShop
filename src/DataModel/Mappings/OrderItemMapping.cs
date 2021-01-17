using DataModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Mappings
{
	internal class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> builder)
		{
			builder.ToTable("order_item");
			builder.HasKey(x => new { x.OrderId, x.ItemId });
			builder.Property(x => x.ItemId).HasColumnName("item_id").IsRequired(true);
			builder.Property(x => x.OrderId).HasColumnName("order_id").IsRequired(true);
			builder.Property(x => x.Quantity).HasColumnName("quantity").HasColumnType("int").IsRequired(true);
			builder.Property(x => x.Price).HasColumnName("item_price").HasColumnType("decimal(19,4)").IsRequired(true);
			builder.Property(x => x.Discount).HasColumnName("item_discount").HasColumnType("decimal(19,4)").IsRequired(true);
		}
	}
}
