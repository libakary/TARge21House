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
		//update
		//delete
		//get async
	}
}
