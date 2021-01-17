using DataModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataModel.Models
{
	public class Order
	{
		public int OrderId { get; set; }
		public int CustomerFormId { get; set; }
		public OrderStatusEnum Status { get; set; }
		public DateTime OrderDate { get; set; } = DateTime.Now;
		public string Comment { get; set; }


		public CustomerForm CustomerForm { get; set; }
		public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
	}
}
