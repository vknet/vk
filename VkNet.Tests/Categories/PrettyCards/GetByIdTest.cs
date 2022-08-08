using System;
using System.Collections.Generic;
using FluentAssertions;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.PrettyCards;

public class GetByIdTest : CategoryBaseTest
{
	protected override string Folder => "PrettyCards";

	[Fact]
	public void GetById()
	{
		Url = "https://api.vk.com/method/prettyCards.getById";

		ReadCategoryJsonPath(nameof(Api.PrettyCards.GetById));

		var list = new List<string>
		{
			"1488",
			"1337"
		};

		var result = Api.PrettyCards.GetById(new()
		{
			OwnerId = -126102803,
			CardIds = list
		});

		result.Should()
			.NotBeNull();

		result[0]
			.CardId.Should()
			.Be("7037403");

		result[2]
			.Images[0]
			.Url.Should()
			.Be(new Uri("https://vk.com/8Jseb63OJSE.jpg"));
	}
}