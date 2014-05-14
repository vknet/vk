using NUnit.Framework;
using VkApiGenerator.Model;
using VkNet.Utils.Tests;

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
                Description = "Количество пользователей, информацию о которых необходимо вернуть",
                Restrictions = VkParamRestrictions.PositiveDigit
            });
            method.Params.Add(new VkMethodParam
            {
                Name = "offset",
                Description = "Смещение",
                Restrictions = VkParamRestrictions.PositiveDigit
            });

            var gen = new VkApiGenerator();
            string result = gen.GenerateMethod(method);

            result.ShouldEqual(@"public ReadOnlyCollection<> GetUsers(int? count = null, int? offset = null)
{
    VkErrors.ThrowIfNumberIsNegative(() => count);
    VkErrors.ThrowIfNumberIsNegative(() => offset);

    var parameters = new VkParameters
        {
            {""count"", count},
            {""offset"", offset}
        };

    VkResponseArray response = _vk.Call(""fave.getUsers"", parameters);

    return response.ToReadOnlyCollectionOf<>(x => x);
}");
        }
    }
}