using System;

namespace DataModel.Enums
{
	[Flags]
	public enum RoleEnum: Int16
	{
		Admin = 0,
		Customer = 1
	}
}
