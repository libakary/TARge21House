using TARge21House.Core.Domain;
using TARge21House.Core.Dto;
using TARge21House.Core.ServiceInterface;

namespace TARge21House.HouseTest
{
	public class HouseTest : TestBase
	{
		//4 different xUnit tests
		[Fact]
		public async  Task Should_CreateHouse_WhenCreateHouse()
		{
			// arrange / initializes objects and gives a value
			string guid = Guid.NewGuid().ToString();

			HouseDto house = new HouseDto();

			house.MainColor = "Red";
			house.RoofColor = "Red";
			house.Stories = 2;
			house.Bedrooms = 4;
			house.Bathrooms = 2;
			house.RentPrice = 10000;
			house.PurchasePrice = 100000;
			house.BuiltDate = DateTime.Now;

			house.CreatedAt = DateTime.Now;
			house.ModifiedAt = DateTime.Now;
			// act / invokes the method tested with the given parameters 

			var result = await Svc<IHousesServices>().Create(house);

			// assert / verifies if the thing works
			Assert.NotNull(result);
		}

		[Fact]
		public async Task Should_UpdateHouse_WhenUpdateData()
		{
			// arrange / initializes objects and gives a value
			var guid = new Guid("2d3d37d1-9ba4-4fd3-94d8-cb249420a069");

			House house = new House();

			HouseDto dto = MockHouseData();

			house.Id = Guid.Parse("2d3d37d1-9ba4-4fd3-94d8-cb249420a069");
			house.MainColor = "Red";
			house.RoofColor = "Red";
			house.Stories = 2;
			house.Bedrooms = 4;
			house.Bathrooms = 2;
			house.RentPrice = 10000;
			house.PurchasePrice = 100000;
			house.BuiltDate = DateTime.Parse("2023-03-23");

			house.CreatedAt = DateTime.Parse("2023-03-23");
			house.ModifiedAt = DateTime.Parse("2023-03-23");

			// act / invokes the method tested with the given parameters 
			await Svc<IHousesServices>().Update(dto);

			// assert / verifies if the thing works
			Assert.Equal(house.Id, guid);
			Assert.DoesNotMatch(house.CreatedAt.ToString(), dto.CreatedAt.ToString());
		}

		[Fact]
		public async Task ShouldNot_UpdateHouse_WhenNotUpdateData()
		{
			// arrange / initializes objects and gives a value
			HouseDto dto = MockHouseData();
			var createSpaceship = await Svc<IHousesServices>().Create(dto);
			HouseDto nullUpdate = MockNullHouse();

			// act / invokes the method tested with the given parameters 
			var result = await Svc<IHousesServices>().Update(nullUpdate);

			var nullId = nullUpdate.Id;

			// assert / verifies if the thing works
			Assert.False(result.Id == nullId);
		}

		[Fact]
		public async Task Should_DeleteByIdHouse_WhenDeleteHouse()
		{
			// arrange / initializes objects and gives a value
			HouseDto house = MockHouseData();

			// act / invokes the method tested with the given parameters 
			var addHouse = await Svc<IHousesServices>().Create(house);
			var result = await Svc<IHousesServices>().Delete((Guid)addHouse.Id);

			// assert / verifies if the thing works
			Assert.Equal(result, addHouse);
		}


		private HouseDto MockHouseData()
		{
			HouseDto house = new()
			{
				MainColor = "Red",
				RoofColor = "Red",
				Stories = 2,
				Bedrooms = 4,
				Bathrooms = 2,
				RentPrice = 10000,
				PurchasePrice = 100000,
				BuiltDate = DateTime.Now,

				CreatedAt = DateTime.Now,
				ModifiedAt = DateTime.Now,
			};

			return house;
		}

		private HouseDto MockNullHouse()
		{
			HouseDto nullDto = new()
			{
				Id = null,
				MainColor = "Red",
				RoofColor = "Red",
				Stories = 2,
				Bedrooms = 4,
				Bathrooms = 2,
				RentPrice = 10000,
				PurchasePrice = 100000,
				BuiltDate = DateTime.Now,

				CreatedAt = DateTime.Now,
				ModifiedAt = DateTime.Now,
			};
			return nullDto;
		}
	}
}