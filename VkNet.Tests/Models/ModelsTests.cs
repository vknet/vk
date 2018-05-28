using System;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace VkNet.Tests.Models
{
    [TestFixture]
    public class ModelsTests
    {
        [Test]
        public void ModelsDateTimeFieldsShouldHaveJsonConverterAttribute()
        {
            var models = typeof(VkApi).Assembly
                .GetTypes()
                .Where(t =>
                    t.Namespace != null
                    && t.Namespace.StartsWith("VkNet.Model")
                    && t.GetProperties().Any(p =>
                        (
                            p.PropertyType == typeof(DateTime)
                            || p.PropertyType == typeof(DateTime?)
                        ) && p.GetCustomAttributes(typeof(JsonConverterAttribute), false).Length < 1
                    )
                );
            
            var enumerable = models.ToList();

            if (enumerable.Any())
            {
                Assert.Fail(string.Join(Environment.NewLine, enumerable.Select(x => x.Name)));
            }
            
            Assert.IsEmpty(enumerable);
        }
    }
}