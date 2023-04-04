using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TARge21House.Core.Domain;
using TARge21House.Core.Dto;
using TARge21House.Core.ServiceInterface;
using TARge21House.Data;
using TARge21House.Models.House;

namespace TARge21House.Controllers
{
	public class HousesController : Controller
	{
		private readonly TARge21HouseContext _context;
		private readonly IHousesServices _housesServices;

		public HousesController
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
		[HttpGet]
		public IActionResult Create()
		{
			HouseCreateUpdateViewModel house = new HouseCreateUpdateViewModel();

			return View("CreateUpdate", house);
		}
		//post create
		[HttpPost]
		public async Task<IActionResult> Create(HouseCreateUpdateViewModel vm)
		{
			var dto = new HouseDto()
			{
				Id = vm.Id,

				MainColor = vm.MainColor,
				RoofColor = vm.RoofColor,
				Stories = vm.Stories,
				Bedrooms = vm.Bedrooms,
				Bathrooms = vm.Bathrooms,
				RentPrice = vm.RentPrice,
				PurchasePrice = vm.PurchasePrice,
				BuiltDate = vm.BuiltDate,

				CreatedAt = vm.CreatedAt,
				ModifiedAt = vm.ModifiedAt
			};

			var result = await _housesServices.Create(dto);

			if ( result == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index), vm);
		}
		//get update
		//post update
		//get details
		//get delete
		//post/confirm delete

	}
}
