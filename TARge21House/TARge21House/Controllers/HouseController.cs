using Microsoft.AspNetCore.Mvc;

namespace TARge21House.Controllers
{
	public class HouseController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
