namespace DataModel.Models
{
	public class User
	{
		public int UserId { get; set; }		
		public string LoginName { get; set; }
		public string PassValue { get; set; }

		public int UserRoleId { get; set; }
		public UserRole UserRole { get; set; }
	}
}
