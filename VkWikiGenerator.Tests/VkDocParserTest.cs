namespace VkWikiGenerator.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;
    using FluentNUnit;

    using DocGen;

    [TestFixture]
    public class VkDocParserTest
    {
        [Test]
        public void Parse_EmptyContent_ReturnEmptyList()
        {
            var parser = new VkDocParser();

            IList<VkDocType> types = parser.Parse("");

            types.Count.ShouldEqual(0);
        }

        [Test]
        public void Parser_TwoTypes()
        {
            const string xml = @"<?xml version=""1.0""?>
<doc>
    <assembly>
        <name>VkNet</name>
    </assembly>
    <members>
        <member name=""T:VkNet.Categories.AudioCategory"">
            <summary>
            Методы для работы с аудиозаписями.
            </summary>
        </member>
        <member name=""M:VkNet.Categories.AudioCategory.GetCount(System.Int64)"">
            <summary>
            Возвращает количество аудиозаписей пользователя или группы.
            </summary>
        </member>
         <member name=""T:VkNet.Categories.DatabaseCategory"">
            <summary>
            Методы для получения справочной информации (страны, города, школы, учебные заведения и т.п.).
            </summary>
        </member>
    </members>
</doc>";

            var parser = new VkDocParser();
            var types = parser.Parse(xml);

            types.Count.ShouldEqual(2);
            types[0].FullName.ShouldEqual("VkNet.Categories.AudioCategory");
            types[0].ShortName.ShouldEqual("AudioCategory");
            types[0].Summary.ShouldEqual("Методы для работы с аудиозаписями.");
            types[0].Methods.Count.ShouldEqual(1);

            types[1].FullName.ShouldEqual("VkNet.Categories.DatabaseCategory");
            types[1].ShortName.ShouldEqual("DatabaseCategory");
            types[1].Summary.ShouldEqual("Методы для получения справочной информации (страны, города, школы, учебные заведения и т.п.).");
            types[1].Methods.Count.ShouldEqual(0);

            VkDocMethod method = types[0].Methods[0];
            method.FullName.ShouldEqual("VkNet.Categories.AudioCategory.GetCount(System.Int64)");
            method.Type.ShouldEqual(types[0]);
            method.Summary.ShouldEqual("Возвращает количество аудиозаписей пользователя или группы.");
        }

        [Test]
        public void GetShortName_MethodName()
        {
            const string fullName = @"VkNet.Categories.AudioCategory.GetFromGroup(System.Int64,System.Nullable{System.Int64},System.Collections.Generic.IEnumerable{System.Int64},System.Nullable{System.Int32},System.Nullable{System.Int32})";

            string name = VkDocParser.GetShortName(fullName);

            name.ShouldEqual("GetFromGroup");
        }

        [Test]
        public void GetShortName_NormalCase()
        {
            const string fullName = @"VkNet.Model.Post.Id";

            string name = VkDocParser.GetShortName(fullName);

            name.ShouldEqual("Id");
        }

        [Test]
        public void Parse_PropertiesForType()
        {
            const string xml = @"<?xml version=""1.0""?>
<doc>
    <assembly>
        <name>VkNet</name>
    </assembly>
    <members>
         <member name=""T:VkNet.Model.Post"">
            <summary>
            Запись со стены пользователя или сообщества.
            См. описание <see cref=""!:http://vk.com/dev/post""/>.
            </summary>
        </member>
        <member name=""P:VkNet.Model.Post.Id"">
            <summary>
            Идентификатор записи на стене.
            </summary>
        </member>
        <member name=""P:VkNet.Model.Post.ToId"">
            <summary>
            Идентификатор владельца стены, на которой размещена запись.
            </summary>
        </member>
        <member name=""P:VkNet.Model.Post.FromId"">
            <summary>
            Идентификатор автора записи.
            </summary>
        </member>
    </members>
</doc>";
            var parser = new VkDocParser();
            var types = parser.Parse(xml);

            types.Count.ShouldEqual(1);
            types[0].FullName.ShouldEqual("VkNet.Model.Post");
            types[0].ShortName.ShouldEqual("Post");
            types[0].Summary.ShouldEqual(@"Запись со стены пользователя или сообщества.
            См. описание <see cref=""!:http://vk.com/dev/post"" />.");
            types[0].Methods.Count.ShouldEqual(0);
            types[0].Properties.Count.ShouldEqual(3);

            var props = types[0].Properties;
            props[0].ShortName.ShouldEqual("Id");
            props[0].FullName.ShouldEqual("VkNet.Model.Post.Id");
            props[0].Summary.ShouldEqual("Идентификатор записи на стене.");
            props[0].Type.ShouldEqual(types[0]);

            props[1].ShortName.ShouldEqual("ToId");
            props[1].FullName.ShouldEqual("VkNet.Model.Post.ToId");
            props[1].Summary.ShouldEqual("Идентификатор владельца стены, на которой размещена запись.");
            props[1].Type.ShouldEqual(types[0]);

            props[2].ShortName.ShouldEqual("FromId");
            props[2].FullName.ShouldEqual("VkNet.Model.Post.FromId");
            props[2].Summary.ShouldEqual("Идентификатор автора записи.");
            props[2].Type.ShouldEqual(types[0]);
        }

        [Test]
        public void Parse_AllMethodMembers()
        {
            const string xml = @"<?xml version=""1.0""?>
<doc>
    <assembly>
        <name>VkNet</name>
    </assembly>
    <members>
        <member name=""T:VkNet.Categories.AudioCategory"">
            <summary>
            Методы для работы с аудиозаписями.
            </summary>
        </member>
         <member name=""M:VkNet.Categories.AudioCategory.GetFromGroup(System.Int64,System.Nullable{System.Int64},System.Collections.Generic.IEnumerable{System.Int64},System.Nullable{System.Int32},System.Nullable{System.Int32})"">
            <summary>
            Возвращает список аудиозаписей группы.
            </summary>
            <param name=""gid"">Идентификатор группы, у которой необходимо получить аудиозаписи.</param>
            <param name=""albumId"">Идентификатор альбома, аудиозаписи которого необходимо вернуть (по умолчанию возвращаются аудиозаписи из всех альбомов).</param>
            <param name=""aids"">
            Список идентификаторов аудиозаписей группы, по которым необходимо получить информацию.
            Если список не указан (null), то ограничение на идентификаторы аудиозаписей на накладываются.
            </param>            
            <param name=""count"">Требуемое количество аудиозаписей.</param>
            <param name=""offset"">Смещение относительно первой найденной аудиозаписи (для выборки определенного подмножества аудиозаписей).</param>
            <returns>
            В случае успеха возвращает затребованный список аудиозаписей группы.
            </returns>
            <remarks>
            Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref=""F:VkNet.Enums.Settings.Audio""/>.
            Страница документации ВКонтакте <see cref=""!:http://vk.com/dev/audio.get""/>.
            </remarks>       
        </member>
         <member name=""M:VkNet.Categories.AudioCategory.Get(System.Int64,VkNet.Model.User@,System.Nullable{System.Int64},System.Collections.Generic.IEnumerable{System.Int64},System.Nullable{System.Int32},System.Nullable{System.Int32})"">
            <summary>
            Возвращает список аудиозаписей пользователя и краткую информацию о нем.
            </summary>
            <param name=""uid"">Идентификатор пользователя, у которого необходимо получить аудиозаписи.</param>
            <param name=""user"">Базовая информация о владельце аудиозаписей - пользователе с идентификатором <paramref name=""uid""/> (идентификатор, имя, фотография).</param>
            <param name=""albumId"">Идентификатор альбома пользователя, аудиозаписи которого необходимо получить (по умолчанию возвращаются аудиозаписи из всех альбомов).</param>            
            <returns>
            В случае успеха возвращает затребованный список аудиозаписей пользователя.
            </returns>
            <remarks>
            Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref=""F:VkNet.Enums.Settings.Audio""/>.
            Страница документации ВКонтакте <see cref=""!:http://vk.com/dev/audio.get""/>.
            </remarks>
            <example>
                <code>
                [LocalizationRequiredAttribute(true)]
                public class Foo
                {
                  private string str = ""my string""; // Warning: Localizable string
                }
                </code>
            </example>
        </member>
    </members>
</doc>";
            var parser = new VkDocParser();
            var types = parser.Parse(xml);

            types.Count.ShouldEqual(1);
            types[0].FullName.ShouldEqual("VkNet.Categories.AudioCategory");
            types[0].ShortName.ShouldEqual("AudioCategory");
            types[0].Summary.ShouldEqual("Методы для работы с аудиозаписями.");
            types[0].Methods.Count.ShouldEqual(2);

            VkDocMethod first = types[0].Methods[0];
            first.FullName.ShouldEqual("VkNet.Categories.AudioCategory.GetFromGroup(System.Int64,System.Nullable{System.Int64},System.Collections.Generic.IEnumerable{System.Int64},System.Nullable{System.Int32},System.Nullable{System.Int32})");

            first.ShortName.ShouldEqual("GetFromGroup");
            first.Signature.ShouldEqual("GetFromGroup(long gid, long? albumId = null, IEnumerable<long> aids, int? count = null, int? offset = null)");

            first.Remarks.ShouldEqual(@"Для вызова этого метода Ваше приложение должно иметь права с битовой маской, содержащей <see cref=""F:VkNet.Enums.Settings.Audio"" />.
            Страница документации ВКонтакте <see cref=""!:http://vk.com/dev/audio.get"" />.");
            first.Returns.ShouldEqual("В случае успеха возвращает затребованный список аудиозаписей группы.");
            first.Summary.ShouldEqual("Возвращает список аудиозаписей группы.");
            first.Params.Count.ShouldEqual(5);
            first.Params[0].Name.ShouldEqual("gid");
            first.Params[0].Description.ShouldEqual("Идентификатор группы, у которой необходимо получить аудиозаписи.");
            first.Params[1].Name.ShouldEqual("albumId");
            first.Params[1].Description.ShouldEqual("Идентификатор альбома, аудиозаписи которого необходимо вернуть (по умолчанию возвращаются аудиозаписи из всех альбомов).");
            first.Params[2].Name.ShouldEqual("aids");
            first.Params[2].Description.ShouldEqual(@"Список идентификаторов аудиозаписей группы, по которым необходимо получить информацию.
            Если список не указан (null), то ограничение на идентификаторы аудиозаписей на накладываются.");
            first.Params[3].Name.ShouldEqual("count");
            first.Params[3].Description.ShouldEqual("Требуемое количество аудиозаписей.");
            first.Params[4].Name.ShouldEqual("offset");
            first.Params[4].Description.ShouldEqual("Смещение относительно первой найденной аудиозаписи (для выборки определенного подмножества аудиозаписей).");

            // add tests for name and shortname

            VkDocMethod second = types[0].Methods[1];

            second.Examples.First().ShouldEqual(@"<code>
                [LocalizationRequiredAttribute(true)]
                public class Foo
                {
                  private string str = ""my string""; // Warning: Localizable string
                }
                </code>");
        }

        [Test]
        public void Parse_EnumItems()
        {
            const string xml = @"<?xml version=""1.0""?>
<doc>
    <assembly>
        <name>VkNet</name>
    </assembly>
    <members>
         <member name=""T:VkNet.Enums.ReportType"">
            <summary>
            Тип жалобы
            </summary>
        </member>
        <member name=""F:VkNet.Enums.ReportType.Porn"">
            <summary>
            Порнография
            </summary>
        </member>
        <member name=""F:VkNet.Enums.ReportType.Spam"">
            <summary>
            Рассылка спама
            </summary>
        </member>
        <member name=""F:VkNet.Enums.ReportType.Insult"">
            <summary>
            Оскорбительное поведение
            </summary>
        </member>
    </members>
</doc>";

            var parser = new VkDocParser();
            var types = parser.Parse(xml);

            types.Count.ShouldEqual(1);
            types[0].IsEnum.ShouldBeTrue();

            var enums = types[0].EnumItems;
            enums.Count.ShouldEqual(3);

            enums[0].FullName.ShouldEqual("VkNet.Enums.ReportType.Porn");
            enums[0].ShortName.ShouldEqual("Porn");
            enums[0].Summary.ShouldEqual("Порнография");

            enums[1].FullName.ShouldEqual("VkNet.Enums.ReportType.Spam");
            enums[1].ShortName.ShouldEqual("Spam");
            enums[1].Summary.ShouldEqual("Рассылка спама");

            enums[2].FullName.ShouldEqual("VkNet.Enums.ReportType.Insult");
            enums[2].ShortName.ShouldEqual("Insult");
            enums[2].Summary.ShouldEqual("Оскорбительное поведение");
        }
    }
}