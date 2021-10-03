using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.RequestParams.Fave;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Fave
{
	public class FaveGetTests : CategoryBaseTest
	{
		/// <inheritdoc />
		protected override string Folder => "Fave";

		[Test]
		public void Get()
		{
			Url = "https://api.vk.com/method/fave.get";
			ReadCategoryJsonPath(nameof(Get));

			var faves = Api.Fave.Get(new FaveGetParams { Count = 1 });

			var fave = faves.FirstOrDefault();

			Assert.IsTrue(faves.Any());
			fave.Should().NotBeNull();
		}
	}
}