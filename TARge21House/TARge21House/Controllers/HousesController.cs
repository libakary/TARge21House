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
		[HttpGet]
		public async Task<IActionResult> Update(Guid id)
		{
			var house = await _housesServices.GetAsync(id);

			if (house == null )
			{
				return NotFound();
			}

			var vm = new HouseCreateUpdateViewModel();

			vm.Id = house.Id;

			vm.MainColor = house.MainColor;
			vm.RoofColor = house.RoofColor;
			vm.Stories = house.Stories;
			vm.Bedrooms = house.Bedrooms;
			vm.Bathrooms = house.Bathrooms;
			vm.RentPrice = house.RentPrice;
			vm.PurchasePrice = house.PurchasePrice;
			vm.BuiltDate = house.BuiltDate;

			vm.CreatedAt = house.CreatedAt;
			vm.ModifiedAt = house.ModifiedAt;

			return View("CreateUpdate", vm);

		}
		//post update
		[HttpPost]
		public async Task<IActionResult> Update(HouseCreateUpdateViewModel vm)
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

			var result = await _housesServices.Update(dto);

			if (result == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index), vm);
		}
		//get details
		[HttpGet]
		public async Task<IActionResult> Details(Guid id)
		{
			var house = await _housesServices.GetAsync(id);

			if (house == null)
			{
				return NotFound();
			}

			var vm = new HouseDetailsViewModel();
			vm.Id = house.Id;

			vm.MainColor = house.MainColor;
			vm.RoofColor = house.RoofColor;
			vm.Stories = house.Stories;
			vm.Bedrooms = house.Bedrooms;
			vm.Bathrooms = house.Bathrooms;
			vm.RentPrice = house.RentPrice;
			vm.PurchasePrice = house.PurchasePrice;
			vm.BuiltDate = house.BuiltDate;

			vm.CreatedAt = house.CreatedAt;
			vm.ModifiedAt = house.ModifiedAt;

			return View(vm);
		}
		//get delete
		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			var house = await _housesServices.GetAsync(id);

			if (house == null)
			{
				return NotFound();
			}

			var vm = new HouseDeleteViewModel();
			vm.Id = house.Id;

			vm.MainColor = house.MainColor;
			vm.RoofColor = house.RoofColor;
			vm.Stories = house.Stories;
			vm.Bedrooms = house.Bedrooms;
			vm.Bathrooms = house.Bathrooms;
			vm.RentPrice = house.RentPrice;
			vm.PurchasePrice = house.PurchasePrice;
			vm.BuiltDate = house.BuiltDate;

			vm.CreatedAt = house.CreatedAt;
			vm.ModifiedAt = house.ModifiedAt;

			return View(vm);
		}
		//post/confirm delete
		//miks siin httpdelete ei kasutata?
		[HttpPost]
		public async Task<IActionResult> DeleteConfirm(Guid id)
		{
			var houseId = await _housesServices.Delete(id);

			if (houseId == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index));
		}
	}
}
