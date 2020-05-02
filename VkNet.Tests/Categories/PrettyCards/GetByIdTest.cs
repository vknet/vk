﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.PrettyCards
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class GetByIdTest : CategoryBaseTest
	{
		protected override string Folder => "PrettyCards";

		[Test]
		public void GetById()
		{
			Url = "https://api.vk.com/method/prettyCards.getById";

			ReadCategoryJsonPath(nameof(Api.PrettyCards.GetById));

			var list = new List<string>
			{
				"1488",
				"1337"
			};

			var result = Api.PrettyCards.GetById(new PrettyCardsGetByIdParams
			{
				OwnerId = -126102803,
				CardIds = list,
			});

			Assert.NotNull(result);
			Assert.AreEqual(result[0].CardId, "7037403");
			Assert.AreEqual(result[2].Images[0].Url, new Uri("https://vk.com/8Jseb63OJSE.jpg"));
		}
	}
}