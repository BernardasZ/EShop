using System;
using System.Collections.Generic;

namespace DataModel.Models
{
	public class CustomerForm
	{
		public int CustomerFormId { get; set; }
		public int? UserId { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Mobile { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string AddressLine { get; set; }
		public string ZipCode { get; set; }
		public DateTime InsertionDate { get; set; }


		public User User { get; set; }
		public ICollection<Order> Orders { get; } = new List<Order>();
	}
}
