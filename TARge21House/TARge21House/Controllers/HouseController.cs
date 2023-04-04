using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TARge21House.Core.Domain;
using TARge21House.Core.ServiceInterface;
using TARge21House.Data;
using TARge21House.Models.House;

namespace TARge21House.Controllers
{
	public class HouseController : Controller
	{
		private readonly TARge21HouseContext _context;
		private readonly IHousesServices _housesServices;

		public HouseController
			(
				TARge21HouseContext context,
				IHousesServices housesServices
			)
		{
			_context = context;
			_housesServices = housesServices;
		}

		//index
		public IActionResult Index()
		{
			var result = _context.Houses
				.OrderByDescending(y => y.CreatedAt)
				.Select(x => new HouseIndexViewModel
				{
					Id = x.Id,
					Bedrooms = x.Bedrooms,
					Bathrooms = x.Bathrooms,
					RentPrice = x.RentPrice,
					BuiltDate = x.BuiltDate
				});
			return View(result);
		}

		//get create
		//post create
		//get update
		//post update
		//get details
		//get delete
		//post/confirm delete

	}
}
