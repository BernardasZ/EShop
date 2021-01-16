using DataModel.Enums;
using System;
using System.Collections.Generic;

namespace DataModel.Models
{
	public class Coupon
	{
		public int CouponId { get; set; }
		public string Barcode { get; set; }
		public CouponTypeEnum Type { get; set; }
		public string Description { get; set; }
		public decimal Value { get; set; }
		public DateTime? ActiveFromDate { get; set; }
		public DateTime? ActiveToDate { get; set; }
		public DateTime InsertionDate { get; set; }

		public ICollection<Item> Items { get; } = new List<Item>();
	}
}
