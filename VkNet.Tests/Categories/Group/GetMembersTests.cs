using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Group
{
	[ExcludeFromCodeCoverage]
	public class GetMembersTests : CategoryBaseTest
	{
		/// <inheritdoc />
		protected override string Folder => "Groups";

		[Test]
		public void GetMembers()
		{
			Url = "https://api.vk.com/method/groups.getMembers";

			ReadCategoryJsonPath(nameof(GetMembers));

			var result = Api.Groups.GetMembers(new GroupsGetMembersParams
			{
				Filter = GroupsMemberFilters.Managers,
				GroupId = "187905748"
			});

			Assert.NotNull(result);
		}
	}
}