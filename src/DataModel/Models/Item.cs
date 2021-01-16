using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModel.Models
{
	public class Item
	{
		public int ItemId { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
		public string Description { get; set; }
		public DateTime InsertionDate { get; set; }
		public byte[] RowVertion { get; set; }

		public ICollection<Coupon> Coupons { get; } = new List<Coupon>();
		public ICollection<Provider> Providers { get; } = new List<Provider>();
		public ICollection<Order> Orders { get; } = new List<Order>();
	}
}
