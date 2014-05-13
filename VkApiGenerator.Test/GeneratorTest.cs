using NUnit.Framework;
using VkApiGenerator.Model;

namespace VkApiGenerator.Test
{
    [TestFixture]
    public class GeneratorTest
    {
        [Test]
        public void GenerateMethod_Fave_GetUsers()
        {
            var method = new VkMethodInfo();
            method.Name = "fave.getUsers";

            method.ReturnType = ReturnType.Collection;

            method.Params.Add(new VkMethodParam
            {
                Name = "count",
                Description = "Количество пользователей, информацию о которых необходимо вернуть"
            });
            method.Params.Add(new VkMethodParam
            {
                Name = "offset",
                Description = "Смещение"
               
            });

            var gen = new VkApiGenerator();
            string result = gen.GenerateMethod(method);

            Assert.Fail("undone");
        }
    }
}