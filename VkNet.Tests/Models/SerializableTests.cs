using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace VkNet.Tests.Models
{
    [TestFixture]
    public class SerializableTests
    {
        [Test]
        public void ModelsShouldHaveSerializableAtribute()
        {
            var models = typeof(VkApi).Assembly
                .GetTypes()
                .Where(x =>
                    x.Namespace != null
                    && x.Namespace.StartsWith("VkNet.Model")
                    && !x.Attributes.HasFlag(TypeAttributes.Serializable)
                    && !x.IsInterface
                )
                .Where(x => !x.Name.StartsWith("<>c__DisplayClass56_0"));

            Assert.IsEmpty(models);
        }
    }
}