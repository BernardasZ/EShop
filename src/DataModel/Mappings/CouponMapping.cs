using DataModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Mappings
{
	internal class CouponMapping : IEntityTypeConfiguration<Coupon>
	{
		public void Configure(EntityTypeBuilder<Coupon> builder)
		{
			builder.ToTable("coupon");
			builder.HasKey(x => x.CouponId);
			builder.Property(x => x.CouponId).HasColumnName("coupon_id").IsRequired(true);
			builder.Property(x => x.Barcode).HasColumnName("barcode").HasColumnType("varchar(20)").IsRequired(true);
			builder.Property(x => x.Type).HasColumnName("coupon_type").HasColumnType("tinyint").IsRequired(true);
			builder.Property(x => x.Value).HasColumnName("coupon_value").HasColumnType("decimal(19,4)").IsRequired(true);
			builder.Property(x => x.Description).HasColumnName("description").HasMaxLength(4000);
			builder.Property(x => x.ActiveFromDate).HasColumnName("dt_from").HasColumnType("datetime").IsRequired(false);
			builder.Property(x => x.ActiveToDate).HasColumnName("dt_to").HasColumnType("datetime").IsRequired(false);
			builder.Property(x => x.InsertionDate).HasColumnName("ins_dt").HasColumnType("datetime").HasDefaultValueSql("GETDATE()").IsRequired(true);
		}
	}
}
