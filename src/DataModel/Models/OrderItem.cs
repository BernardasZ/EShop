namespace DataModel.Models
{
	public class OrderItem
	{
		public int OrderId { get; set; }
		public int ItemId { get; set; }
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
		public int Quantity { get; set; }


		public Order Order { get; set; }
		public Item Item { get; set; }
	}
}
