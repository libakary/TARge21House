namespace TARge21House.Models.House
{
	public class HouseDeleteViewModel
	{
		public Guid? Id { get; set; }

		public string MainColor { get; set; }
		public string RoofColor { get; set; }
		public int Stories { get; set; }
		public int Bedrooms { get; set; }
		public int Bathrooms { get; set; }
		public int RentPrice { get; set; }
		public int PurchasePrice { get; set; }
		public DateTime BuiltDate { get; set; }

		// only in database
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
	}
}
