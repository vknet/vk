namespace VkWikiGenerator.Tests
{
    using NUnit.Framework;
    using FluentNUnit;

    using DocGen;

    [TestFixture]
    public class VkDocMethodTest
    {
        [Test]
        public void Signature_OneItem()
        {
            var param = new VkDocMethodParam
                {
                    Name = "uid",
                    Description = "Идентификатор пользователя"
                };

            var method = new VkDocMethod { FullName = "VkNet.Categories.AudioCategory.GetFromGroup(System.Int64)" };
            method.Params.Add(param);

            method.Signature.ShouldEqual("GetFromGroup(long uid)");
        }

        [Test]
        public void Signature_WithoutParams()
        {
            var method = new VkDocMethod { FullName = "M:VkNet.Categories.UtilsCategory.GetServerTime" };

            method.Signature.ShouldEqual("GetServerTime()");
        }

        [Test]
        public void Signature_TwoNullableParams()
        {
            var first = new VkDocMethodParam{Name = "uid"};
            var second = new VkDocMethodParam {Name = "count"};

            var method = new VkDocMethod
                {
                    FullName =
                        "VkNet.Categories.VideoCategory.Get(System.Nullable{System.Int64},System.Nullable{System.Int64})"
                };
            method.Params.Add(first);
            method.Params.Add(second);

            method.Signature.ShouldEqual("Get(long? uid = null, long? count = null)");
        }

        [Test]
        public void Signature_CustomType()
        {
            var first = new VkDocMethodParam {Name = "isEnabled"};
            var second = new VkDocMethodParam {Name = "filter"};
            var third = new VkDocMethodParam {Name = "fields"};
            

            var method = new VkDocMethod { FullName = "VkNet.Categories.GroupsCategory.Get(System.Boolean,VkNet.Enums.GroupsFilters,VkNet.Enums.GroupsFields)" };
            method.Params.Add(first);
            method.Params.Add(second);
            method.Params.Add(third);

            method.Signature.ShouldEqual("Get(bool isEnabled, GroupsFilters filter, GroupsFields fields)");
        }
    }
}