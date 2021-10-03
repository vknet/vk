using FluentAssertions;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Fave
{
	public class FaveAddTagTests : CategoryBaseTest
	{
		/// <inheritdoc />
		protected override string Folder => "Fave";

		[Test]
		public void AddTag()
		{
			Url = "https://api.vk.com/method/fave.addTag";

			ReadCategoryJsonPath(nameof(AddTag));

			var tag = Api.Fave.AddTag("Важное", null);

			tag.Should().NotBeNull();
		}
	}
}