using DataModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Mappings
{
	internal class ProviderMapping : IEntityTypeConfiguration<Provider>
	{
		public void Configure(EntityTypeBuilder<Provider> builder)
		{
			builder.ToTable("provider");
			builder.HasKey(x => x.ProviderId);
			builder.Property(x => x.ProviderId).HasColumnName("provider_id").IsRequired(true);
			builder.Property(x => x.CompanyName).HasColumnName("company_name").HasMaxLength(250).IsRequired(true);
			builder.Property(x => x.VATCode).HasColumnName("vat_code").HasColumnType("varchar(20)").IsRequired(true);
			builder.Property(x => x.Email).HasColumnName("email").HasColumnType("varchar(250)").IsRequired(true);
			builder.Property(x => x.Mobile).HasColumnName("mobile").HasColumnType("varchar(12)").IsRequired(true);
			builder.Property(x => x.Country).HasColumnName("country").HasMaxLength(100).IsRequired(true);
			builder.Property(x => x.City).HasColumnName("city").HasMaxLength(100).IsRequired(true);
			builder.Property(x => x.AddressLine).HasColumnName("address").HasMaxLength(250).IsRequired(true);
			builder.Property(x => x.ZipCode).HasColumnName("zip_code").HasColumnType("varchar(5)").HasMaxLength(100).IsRequired(true);
			builder.Property(x => x.InsertionDate).HasColumnName("ins_dt").HasColumnType("datetime").HasDefaultValueSql("GETDATE()").IsRequired(true);
		}
	}
}
