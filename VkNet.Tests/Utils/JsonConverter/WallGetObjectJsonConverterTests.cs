using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Utils.JsonConverter;

namespace VkNet.Tests.Utils.JsonConverter
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class WallGetObjectJsonConverterTests : BaseTest
	{
		[Test]
		public void Deserialize()
		{
			ReadJsonFile(nameof(JsonConverter), nameof(WallGetObjectJsonConverter), nameof(WallGetObject));

			DeserializeAndAssert();
		}

		[Test]
		public void Deserialize_Array()
		{
			ReadJsonFile(nameof(JsonConverter), nameof(WallGetObjectJsonConverter), "WallGetObjectAsArray");

			DeserializeAndAssert();
		}

		[Test]
		public void Serialize()
		{
			ReadJsonFile(nameof(JsonConverter), nameof(WallGetObjectJsonConverter), nameof(WallGetObject));

			var wallGetObject = new WallGetObject
			{
				TotalCount = 1,
				WallPosts = new ReadOnlyCollection<Post>(new[]
				{
					new Post()
					{
						Id = 1,
						OwnerId = 2
					}
				}),
				Profiles = new ReadOnlyCollection<User>(ImmutableList<User>.Empty),
				Groups = new ReadOnlyCollection<Group>(ImmutableList<Group>.Empty)
			};

			var json = JsonConvert.SerializeObject(wallGetObject,
				new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore,
					DefaultValueHandling = DefaultValueHandling.Ignore,
					Formatting = Formatting.Indented,
					ContractResolver = new DefaultContractResolver
					{
						NamingStrategy = new SnakeCaseNamingStrategy()
					},
				});

			Assert.AreEqual(Json, json);
		}

		private void DeserializeAndAssert()
		{
			var result = JsonConvert.DeserializeObject<WallGetObject>(Json);

			var post = result.WallPosts.FirstOrDefault();

			Assert.NotNull(result);
			Assert.NotNull(post);
			Assert.AreEqual(1, post.Id);
			Assert.AreEqual(2, post.OwnerId);
		}
	}
}