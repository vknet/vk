using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using VkNet.Abstractions.Utils;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Tests.Utils
{
	[TestFixture]

	public class LeadFormsQuestionBuilderTests : BaseTest
	{
		[Test]
		public void AddTextArea()
		{
			var json = ReadJson("Utils", nameof(LeadFormsQuestionBuilder), nameof(AddTextArea));

			ILeadFormsQuestionBuilder builder = new LeadFormsQuestionBuilder();

			var questions = builder.AddTextArea("Кличка кота")
				.Build();

			var expected = JToken.Parse(json);
			var actual = JToken.Parse(questions);

			Assert.IsTrue(JToken.DeepEquals(expected, actual));
		}

		[Test]
		public void Default()
		{
			var json = ReadJson("Utils", nameof(LeadFormsQuestionBuilder), nameof(Default));

			ILeadFormsQuestionBuilder builder = new LeadFormsQuestionBuilder();

			var questions = builder.AddStandard(StandardQuestion.FirstName)
				.AddInput("Кличка кота")
				.AddSelect("favorite_color",
					"Любимый цвет",
					new[]
					{
						new QuestionOption
						{
							Key = "red",
							Label = "Красный"
						},
						new QuestionOption
						{
							Key = "green",
							Label = "Зелёный"
						}
					})
				.AddRadio("Я ношу часы...",
					new[]
					{
						new QuestionOption
						{
							Key = "left",
							Label = "на левой руке"
						},
						new QuestionOption
						{
							Key = "right",
							Label = "на правой руке"
						}
					})
				.AddCheckbox("visited_cities",
					"Города, в которых я был",
					new[]
					{
						new QuestionOption
						{
							Label = "Екатеринбург"
						},
						new QuestionOption
						{
							Label = "Волгоград"
						},
						new QuestionOption
						{
							Label = "Санкт-Петербург"
						}
					})
				.Build();

			var expected = JToken.Parse(json);
			var actual = JToken.Parse(questions);

			Assert.IsTrue(JToken.DeepEquals(expected, actual));
		}
	}
}