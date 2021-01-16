using DataModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Mappings
{
	class CustomerFormMapping : IEntityTypeConfiguration<CustomerForm>
	{
		public void Configure(EntityTypeBuilder<CustomerForm> builder)
		{
			builder.ToTable("customer_form");
			builder.HasKey(x => x.CustomerFormId);
			builder.Property(x => x.CustomerFormId).HasColumnName("customer_form_id").IsRequired(true);
			builder.Property(x => x.UserId).HasColumnName("user_id").IsRequired(false);
			builder.Property(x => x.Name).HasColumnName("customer_name").HasMaxLength(250).IsRequired(true);
			builder.Property(x => x.Surname).HasColumnName("customer_surname").HasMaxLength(250).IsRequired(true);
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
