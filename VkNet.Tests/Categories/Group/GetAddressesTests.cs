using NUnit.Framework;
using VkNet.Model.RequestParams.Groups;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Group
{
	[TestFixture]

	public class GetAddressesTests : CategoryBaseTest
	{
		protected override string Folder => "Groups";

		[Test]
		public void GetAddresses()
		{
			Url = "https://api.vk.com/method/groups.getAddresses";

			ReadCategoryJsonPath(nameof(GetAddresses));

			var result = Api.Groups.GetAddresses(new GetAddressesParams
			{
				GroupId = 165669449,
				AddressIds = new ulong[]{ 58227}
			});

			Assert.AreEqual(3, result.TotalCount);
		}
	}
}