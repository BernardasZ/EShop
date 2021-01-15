using System.Collections.Generic;

namespace DataModel.Models
{
	public class Item
	{
		public int ItemId { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }

		public ICollection<Coupon> Coupons { get; } = new List<Coupon>();
		public ICollection<Provider> Providers { get; } = new List<Provider>();

	}
}
