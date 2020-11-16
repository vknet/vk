using Newtonsoft.Json;
using NUnit.Framework;
using VkNet.Model;

namespace VkNet.Tests.Models
{
	[TestFixture]

	public class TimetableTests : BaseTest
	{
		[Test]
		public void TimetableToJson()
		{
			ReadJsonFile("Models", nameof(TimetableToJson));

			var timetable = new Timetable()
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
			};

			Assert.AreEqual(Json.Replace("\r", "").Replace("\n", ""), JsonConvert.SerializeObject(timetable, Formatting.Indented).Replace("\r", "").Replace("\n", ""));
		}
	}
}
