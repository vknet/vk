using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using NUnit.Framework;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Tests.Utils
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class UtilitiesTests
	{
		[Test]
		public void JsonConvert()
		{
			var result = Utilities.SerializeToJson(new User
			{
				FirstName = "Maxim",
				LastName = "Inyutin"
			});

			Assert.AreNotEqual(result, "{}");
			var attribute = Attribute.GetCustomAttribute(typeof(User), typeof(DataContractAttribute));
			Assert.That(attribute, Is.Null);
		}

		[Test]
		public void JsonConvertWrite()
		{
			var vkCollection = new VkCollection<User>(10,
				new List<User>
				{
					new User
					{
						Id = 12,
						FirstName = "Andrew",
						LastName = "Teleshev"
					},
					new User
					{
						Id = 13,
						FirstName = "Даниил",
						LastName = "Рыльцов"
					}
				});

			var result = Utilities.SerializeToJson(vkCollection);
			Assert.AreNotEqual(result, "{}");
			var attribute = Attribute.GetCustomAttribute(typeof(VkCollection<>), typeof(DataContractAttribute));
			Assert.That(attribute, Is.Null);
		}
	}
}