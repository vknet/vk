using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using FluentAssertions;
using VkNet.Model;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Utils;

public class UtilitiesTests
{
	[Fact]
	public void JsonConvert()
	{
		var result = Utilities.SerializeToJson(new User
		{
			FirstName = "Maxim",
			LastName = "Inyutin"
		});

		result.Should()
			.NotBe("{}");

		var attribute = Attribute.GetCustomAttribute(typeof(User), typeof(DataContractAttribute));

		attribute.Should()
			.BeNull();
	}

	[Fact]
	public void JsonConvertWrite()
	{
		var vkCollection = new VkCollection<User>(10,
			new List<User>
			{
				new()
				{
					Id = 12,
					FirstName = "Andrew",
					LastName = "Teleshev"
				},
				new()
				{
					Id = 13,
					FirstName = "Даниил",
					LastName = "Рыльцов"
				}
			});

		var result = Utilities.SerializeToJson(vkCollection);

		result.Should()
			.NotBe("{}");

		var attribute = Attribute.GetCustomAttribute(typeof(VkCollection<>), typeof(DataContractAttribute));

		attribute.Should()
			.BeNull();
	}

	[Fact]
	public void PrettyPrintJsonShouldNotThrowException()
	{
		const string invalidJson = "ERROR";

		FluentActions.Invoking(() => Utilities.PrettyPrintJson(invalidJson))
			.Should()
			.NotThrow();
	}
}