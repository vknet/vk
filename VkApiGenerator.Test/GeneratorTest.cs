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
            var method = new VkMethodInfo
            {
                Name = "fave.getUsers",
                Description = "Возвращает список пользователей",
                ReturnType = ReturnType.Collection,
                ReturnText = "После успешного выполнения возвращает список объектов пользователей."
            };

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

            result.ShouldEqual(@"/// <summary>
/// Возвращает список пользователей
/// </summary>
/// <param name=""count"">Количество пользователей, информацию о которых необходимо вернуть</param>
/// <param name=""offset"">Смещение</param>
/// <returns>После успешного выполнения возвращает список объектов пользователей.</returns>
/// <remarks>
/// Страница документации ВКонтакте <see href=""http://vk.com/dev/fave.getUsers""/>.
/// </remarks>
public ReadOnlyCollection<> GetUsers(int? count = null, int? offset = null)
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

        [Test]
        public void GenerateUnitTest_NormalCase()
        {
            var gen = new VkApiGenerator();
            gen.GenerateUnitTest("Photos");


        }
    }
}