namespace TARge21House.Models.House
{
	public class HouseIndexViewModel
	{
		public Guid? Id { get; set; }
		public int Bedrooms { get; set; }
		public int Bathrooms { get; set; }
		public int RentPrice { get; set; }
		public DateTime BuiltDate { get; set; }
	}
}
