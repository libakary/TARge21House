using TARge21House.Core.Domain;
using TARge21House.Core.Dto;
using TARge21House.Core.ServiceInterface;
using TARge21House.Data;

namespace TARge21House.ApplicationServices.Services
{
	public class HousesServices : IHousesServices
	{
		private readonly TARge21HouseContext _context;

		//declares context
		public HousesServices
			(
				TARge21HouseContext context
			)
		{
			_context = context;
		}

		//create
		public async Task<House> Create(HouseDto dto)
		{
			House house = new House();

			house.Id = Guid.NewGuid();
			house.MainColor = dto.MainColor;
			house.RoofColor = dto.RoofColor;
			house.Stories = dto.Stories;
			house.Bedrooms = dto.Bedrooms;
			house.Bathrooms = dto.Bathrooms;
			house.RentPrice = dto.RentPrice;
			house.PurchasePrice = dto.PurchasePrice;
			house.BuiltDate = dto.BuiltDate;

			house.CreatedAt = DateTime.Now;
			house.ModifiedAt = DateTime.Now;

			await _context.Houses.AddAsync(house);
			await _context.SaveChangesAsync();

			return house;
		}
		//update
		//delete
		//get async
	}
}
