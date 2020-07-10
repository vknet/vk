using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Audio
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class AudioGetByIdTest : CategoryBaseTest
	{
		protected override string Folder => "Audio";

		[Test]
		public void GetByIdTest()
		{
			Url = "https://api.vk.com/method/audio.getById";

			ReadCategoryJsonPath(nameof(Api.Audio.GetById));

			var result = Api.Audio.GetById(new List<string> { "465742902_456239281" }).ToList();
			var audio = result.FirstOrDefault();

			Assert.IsNotEmpty(result);
			Assert.NotNull(audio);
		}
	}
}