using DataModel.Enums;
using System.Collections.Generic;

namespace DataModel.Models
{
	public class UserRole
	{
		public int UserRoleId { get; set; }
		public RoleEnum Role { get; set; }

		public ICollection<User> Users { get; } = new List<User>();
}
}
