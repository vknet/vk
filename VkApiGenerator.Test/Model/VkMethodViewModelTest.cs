using NUnit.Framework;
using VkApiGenerator.Model;
using VkNet.Utils.Tests;

namespace VkApiGenerator.Test.Model
{
    [TestFixture]
    public class VkMethodViewModelTest
    {
        [Test]
        public void GetInvokeBlock_CollectionWithParameters()
        {
            var vm = new VkMethodViewModel(new VkMethodInfo());
            string result = vm.GetInvokeBlock(ReturnType.Collection, "fave.getUsers", 2);

            result.ShouldEqual(@"VkResponseArray response = _vk.Call(""fave.getUsers"", parameters);");
        }

        [Test]
        public void GetInvokeBlock_BoolWithParameters()
        {
            var vm = new VkMethodViewModel(new VkMethodInfo());
            string result = vm.GetInvokeBlock(ReturnType.Bool, "fave.getUsers", 2);

            result.ShouldEqual(@"VkResponse response = _vk.Call(""fave.getUsers"", parameters);");
        }

        [Test]
        public void GetInvokeBlock_BoolWithoutParameters()
        {
            var vm = new VkMethodViewModel(new VkMethodInfo());
            string result = vm.GetInvokeBlock(ReturnType.Bool, "fave.getUsers", 0);

            result.ShouldEqual(@"VkResponse response = _vk.Call(""fave.getUsers"", VkParameters.Empty);");
        }

        [Test]
        public void GetReturnBlock_Collection()
        {
            var vm = new VkMethodViewModel(new VkMethodInfo());
            string result = vm.GetReturnBlock(ReturnType.Collection);
            result.ShouldEqual("return response.ToReadOnlyCollectionOf<>(x => x);");
        }

        [Test]
        public void GetReturnBlock_SimpleType()
        {
            var vm = new VkMethodViewModel(new VkMethodInfo());
            string result = vm.GetReturnBlock(ReturnType.Bool);
            result.ShouldEqual("return response;");
        }

        [Test]
        public void GetXmlDoc_NormalCase()
        {
            var vm = new VkMethodViewModel(new VkMethodInfo());

            var parameters = new VkMethodParamsCollection
            {
                new VkMethodParam
                {
                    Name = "count",
                    Description = "Количество пользователей, информацию о которых необходимо вернуть",
                    Restrictions = VkParamRestrictions.PositiveDigit
                },
                new VkMethodParam
                {
                    Name = "offset",
                    Description = "Смещение",
                    Restrictions = VkParamRestrictions.PositiveDigit
                }
            };

            string comment = vm.GetXmlDoc("fave.getUsers", "Возвращает список пользователей", "После успешного выполнения возвращает список объектов пользователей.", parameters);

            comment.ShouldEqual(@"/// <summary>
/// Возвращает список пользователей
/// </summary>
/// <param name=""count"">Количество пользователей, информацию о которых необходимо вернуть</param>
/// <param name=""offset"">Смещение</param>
/// <returns>После успешного выполнения возвращает список объектов пользователей.</returns>
/// <remarks>
/// Страница документации ВКонтакте <see href=""http://vk.com/dev/fave.getUsers""/>.
/// </remarks>");
        }
    }
}