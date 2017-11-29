using System;
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
            var result = Utilities.SerializeToJson(new User
            {
                FirstName = "Maxim",
                LastName = "Inyutin"
            });
            Assert.AreNotEqual(result, "{}");
            var attribute = Attribute.GetCustomAttribute(typeof(User), typeof(DataContractAttribute));
            Assert.That(attribute, Is.Null);
        }
    }
}