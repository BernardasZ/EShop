using DataModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Mappings
{
	internal class UserMapping : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("user");
			builder.HasKey(x => x.UserId);
			builder.Property(x => x.UserId).HasColumnName("user_id").IsRequired(true);
			builder.Property(x => x.UserRoleId).HasColumnName("user_role_id").IsRequired(true);
			builder.Property(x => x.LoginName).HasColumnName("login").HasColumnType("varchar(250)").IsRequired(true);
			builder.Property(x => x.PassValue).HasColumnName("pass").HasColumnType("varchar(250)").IsRequired(true);
			builder.Property(x => x.RegistrationDate).HasColumnName("reg_dt").HasColumnType("datetime").IsRequired(true);
		}
	}
}
