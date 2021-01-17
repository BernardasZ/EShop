using DataModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

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
		public DbSet<OrderItem> OrderItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            base.OnModelCreating(modelBuilder);

            var mappingInterface = typeof(IEntityTypeConfiguration<>);
            var mappingTypes = typeof(EShopDbContext).GetTypeInfo().Assembly.GetTypes()
                .Where(x => x.GetInterfaces()
				.Any(y => y.GetTypeInfo().IsGenericType && y.GetGenericTypeDefinition() == mappingInterface));

            var entityMethod = typeof(ModelBuilder)
				.GetMethods()
				.Single(x => x.Name == "Entity" && x.IsGenericMethod && x.ReturnType.Name == "EntityTypeBuilder`1");

            foreach (var mappingType in mappingTypes)
            {
                var genericTypeArg = mappingType.GetInterfaces().Single().GenericTypeArguments.Single();
                var genericEntityMethod = entityMethod.MakeGenericMethod(genericTypeArg);
                var entityBuilder = genericEntityMethod.Invoke(modelBuilder, null);
                var mapper = Activator.CreateInstance(mappingType);
                mapper.GetType().GetMethod("Configure").Invoke(mapper, new[] { entityBuilder });
            }
        }
	}
}
