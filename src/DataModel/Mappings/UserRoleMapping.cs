using DataModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Mappings
{
	internal class UserRoleMapping : IEntityTypeConfiguration<UserRole>
	{
		public void Configure(EntityTypeBuilder<UserRole> builder)
		{
			builder.ToTable("user_role");
			builder.HasKey(x => x.UserRoleId);
			builder.Property(x => x.UserRoleId).HasColumnName("user_role_id").IsRequired(true);
			builder.Property(x => x.Role).HasColumnName("role_type").HasColumnType("int").IsRequired(true);
		}
	}
}
