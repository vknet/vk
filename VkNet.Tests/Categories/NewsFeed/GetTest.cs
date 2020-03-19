﻿using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.NewsFeed
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class GetTest : CategoryBaseTest
	{
		protected override string Folder => "NewsFeed";

		[Test]
		public void Get()
		{
			Url = "https://api.vk.com/method/newsfeed.get";
			ReadCategoryJsonPath(nameof(Get));

			var result = Api.NewsFeed.Get(new NewsFeedGetParams
			{
				Filters = NewsTypes.Post | NewsTypes.Photo | NewsTypes.WallPhoto | NewsTypes.Friend,
				SourceIds = new []{"-106879986", "-30022666"},
				Count = 100
			});

			Assert.NotNull(result);
			Assert.IsNotEmpty(result.NextFrom);
		}

		[Test]
		public void Get2()
		{
			Url = "https://api.vk.com/method/newsfeed.get";
			ReadCategoryJsonPath(nameof(Get2));

			var result = Api.NewsFeed.Get(new NewsFeedGetParams
			{
				Filters = NewsTypes.Post | NewsTypes.Photo | NewsTypes.WallPhoto | NewsTypes.Friend,
				SourceIds = new []{"361347484"},
				Count = 100
			});

			Assert.NotNull(result);
			Assert.IsNotEmpty(result.NextFrom);
		}
	}
}