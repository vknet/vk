using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NUnit.Framework;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Tests.Utils
{
	[TestFixture]
	public class UtilitiesTests
	{
		[Test]
		public void JsonConvert()
		{
			var result = Utilities.SerializeToJson(@object: new User
			{
				FirstName = "Maxim",
				LastName = "Inyutin"
			});

			Assert.AreNotEqual(expected: result, actual: "{}");
			var attribute = Attribute.GetCustomAttribute(element: typeof(User), attributeType: typeof(DataContractAttribute));
			Assert.That(actual: attribute, expression: Is.Null);
		}

		[Test]
		public void JsonConvertWrite()
		{
			var vkCollection = new VkCollection<User>(totalCount: 10,
				list: new List<User>
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

			var result = Utilities.SerializeToJson(@object: vkCollection);
			Assert.AreNotEqual(expected: result, actual: "{}");
			var attribute = Attribute.GetCustomAttribute(element: typeof(VkCollection<>), attributeType: typeof(DataContractAttribute));
			Assert.That(actual: attribute, expression: Is.Null);
		}
	}
}