using DataModel.Mappings;
using DataModel.Models;
using Microsoft.EntityFrameworkCore;

namespace DataModel.DbContexts
{
	public class EShopDbContext : DbContext
	{
		public EShopDbContext(DbContextOptions<EShopDbContext> options) : base(options)
		{
		}

		public DbSet<Coupon> Coupons { get; set; }
		public DbSet<CustomerForm> CustomerForms { get; set; }
		public DbSet<Item> Items { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Provider> Providers { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserMapping());
			modelBuilder.ApplyConfiguration(new CouponMapping());
			modelBuilder.ApplyConfiguration(new UserRoleMapping());
			modelBuilder.ApplyConfiguration(new ItemMapping());
			modelBuilder.ApplyConfiguration(new OrderMapping());
			modelBuilder.ApplyConfiguration(new ProviderMapping());
			modelBuilder.ApplyConfiguration(new CustomerFormMapping());

			base.OnModelCreating(modelBuilder);
		}
	}
}
