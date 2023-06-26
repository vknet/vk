using FluentAssertions;
using Newtonsoft.Json.Linq;
using VkNet.Abstractions.Utils;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Utils;

public class LeadFormsQuestionBuilderTests : BaseTest
{
	[Fact]
	public void AddTextArea()
	{
		var json = ReadJson("Utils", nameof(LeadFormsQuestionBuilder), nameof(AddTextArea));

		ILeadFormsQuestionBuilder builder = new LeadFormsQuestionBuilder();

		var questions = builder.AddTextArea("Кличка кота")
			.Build();

		var expected = JToken.Parse(json);
		var actual = JToken.Parse(questions);

		JToken.DeepEquals(expected, actual)
			.Should()
			.BeTrue();
	}

	[Fact]
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

		JToken.DeepEquals(expected, actual)
			.Should()
			.BeTrue();
	}
}