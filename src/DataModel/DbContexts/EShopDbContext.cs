using Microsoft.EntityFrameworkCore;

namespace DataModel.DbContexts
{
	public class EShopDbContext : DbContext
	{
		public EShopDbContext(DbContextOptions<EShopDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
