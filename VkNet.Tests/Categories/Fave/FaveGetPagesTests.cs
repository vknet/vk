using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Enums.SafetyEnums;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Fave
{
	public class FaveGetPagesTests : CategoryBaseTest
	{
		/// <inheritdoc />
		protected override string Folder => "Fave";

		[Test]
		public void GetPages()
		{
			Url = "https://api.vk.com/method/fave.getPages";
			ReadCategoryJsonPath(nameof(GetPages));

			var pages = Api.Fave.GetPages(FavePageType.Users);
			var page = pages.FirstOrDefault();

			pages.Should().NotBeEmpty();
			page.Should().NotBeNull();
		}
	}
}