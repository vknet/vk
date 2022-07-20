using FluentAssertions;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams.Groups;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Group
{


	public class AddAddressTests : CategoryBaseTest
	{
		protected override string Folder => "Groups";

		[Fact]
		public void AddAddress_AlwaysOpened()
		{
			Url = "https://api.vk.com/method/groups.addAddress";

			ReadCategoryJsonPath(nameof(AddAddress_AlwaysOpened));

			var result = Api.Groups.AddAddress(new AddAddressParams
			{
				GroupId = 165669449,
				Title = "Точка встречи parkrun",
				Address = "Сосновкий лесопарк",
				AdditionalAddress = "Парковая дорожка между футбольным полем и спортивной площадкой",
				CountryId = 1,
				CityId = 2,
				MetroId = 189,
				Latitude = 60.0179405118554,
				Longitude = 30.365817365050702,
				Phone = "89511111111",
				WorkInfoStatus = ScheduleWorkInfoStatus.AlwaysOpened,
				Timetable = new Timetable()
				{
					Monday = new TimetableItem
					{
						OpenTime = 1080,
						CloseTime = 1380
					},
					Tuesday = new TimetableItem
					{
						OpenTime = 1080,
						CloseTime = 1380
					},
					Wednesday = new TimetableItem
					{
						OpenTime = 1080,
						CloseTime = 1320
					},
					Thursday = new TimetableItem
					{
						OpenTime = 1080,
						CloseTime = 1320
					},
					Friday = new TimetableItem
					{
						OpenTime = 1080,
						CloseTime = 1320
					},
					Saturday = new TimetableItem
					{
						OpenTime = 1080,
						CloseTime = 1320,
						BreakOpenTime = 1200,
						BreakCloseTime = 1230
					},
				},
				IsMainAddress = true
			});

			result.Id.Should().Be(58227);
		}

		[Fact]
		public void AddAddress_Timetable()
		{
			Url = "https://api.vk.com/method/groups.addAddress";

			ReadCategoryJsonPath(nameof(AddAddress_Timetable));

			var result = Api.Groups.AddAddress(new AddAddressParams
			{
				GroupId = 165669449,
				Title = "Точка встречи parkrun",
				Address = "Сосновкий лесопарк",
				AdditionalAddress = "Парковая дорожка между футбольным полем и спортивной площадкой",
				CountryId = 1,
				CityId = 2,
				MetroId = 189,
				Latitude = 60.0179405118554,
				Longitude = 30.365817365050702,
				Phone = "89511111111",
				WorkInfoStatus = ScheduleWorkInfoStatus.Timetable,
				Timetable = new Timetable()
				{
					Monday = new TimetableItem
					{
						OpenTime = 1080,
						CloseTime = 1380
					},
					Tuesday = new TimetableItem
					{
						OpenTime = 1080,
						CloseTime = 1380
					},
					Wednesday = new TimetableItem
					{
						OpenTime = 1080,
						CloseTime = 1320
					},
					Thursday = new TimetableItem
					{
						OpenTime = 1080,
						CloseTime = 1320
					},
					Friday = new TimetableItem
					{
						OpenTime = 1080,
						CloseTime = 1320
					},
					Saturday = new TimetableItem
					{
						OpenTime = 1080,
						CloseTime = 1320,
						BreakOpenTime = 1200,
						BreakCloseTime = 1230
					},
				},
				IsMainAddress = true
			});

			result.Id.Should().Be(58230);
		}
	}
}