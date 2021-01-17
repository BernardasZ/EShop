using System.Collections.Generic;

namespace EShopApi.Models
{
	public class CartModel
	{
		public ICollection<ItemModel> Items { get; set; }
	}
}
