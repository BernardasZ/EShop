using System;
using System.ComponentModel.DataAnnotations;

namespace DataModel.Models
{
	public class User
	{
		public int UserId { get; set; }
		public int UserRoleId { get; set; }
		public string LoginName { get; set; }
		public string PassValue { get; set; }
		public DateTime RegistrationDate { get; set; } = DateTime.Now;

		
		public UserRole UserRole { get; set; }
		public CustomerForm CustomerForm { get; set; }
	}
}
