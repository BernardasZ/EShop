using System;
using System.Collections.Generic;

namespace DataModel.Models
{
	public class Provider
	{
		public int ProviderId { get; set; }
		public string CompanyName { get; set; }
		public string VATCode { get; set; }
		public string Email { get; set; }
		public string Mobile { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string AddressLine { get; set; }
		public string ZipCode { get; set; }
		public DateTime InsertionDate { get; set; }

		public ICollection<Item> Items { get; } = new List<Item>();
	}
}
