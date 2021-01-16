using DataModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Mappings
{
	internal class ItemMapping : IEntityTypeConfiguration<Item>
	{
		public void Configure(EntityTypeBuilder<Item> builder)
		{
			builder.ToTable("item");
			builder.HasKey(x => x.ItemId);
			builder.Property(x => x.ItemId).HasColumnName("item_id").IsRequired(true);
			builder.Property(x => x.Code).HasColumnName("item_code").HasColumnType("varchar(20)").IsRequired(true);
			builder.Property(x => x.Name).HasColumnName("item_name").HasMaxLength(250).IsRequired(true);
			builder.Property(x => x.Quantity).HasColumnName("quantity").HasColumnType("int").IsRequired(true);
			builder.Property(x => x.Description).HasColumnName("description").HasMaxLength(4000);
			builder.Property(x => x.InsertionDate).HasColumnName("ins_dt").HasColumnType("datetime").HasDefaultValueSql("GETDATE()").IsRequired(true);
			builder.Property(x => x.RowVertion).HasColumnName("row_version").HasColumnType("timestamp");
		}
	}
}
