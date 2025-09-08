using AwesomeAssertions;
using Newtonsoft.Json.Linq;
using VkNet.Abstractions.Utils;
using VkNet.Enums.StringEnums;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Utils;

public class LeadFormsQuestionBuilderTests : BaseTest
{
	[Fact(DisplayName = "Add text area")]
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

	[Fact(DisplayName = "Default")]
	public void Default()
	{
		var json = ReadJson("Utils", nameof(LeadFormsQuestionBuilder), nameof(Default));

		ILeadFormsQuestionBuilder builder = new LeadFormsQuestionBuilder();

		var questions = builder.AddStandard(StandardQuestion.FirstName)
			.AddInput("Кличка кота")
			.AddSelect("favorite_color",
				"Любимый цвет",
				[
					new()
					{
						Key = "red",
						Label = "Красный"
					},
					new()
					{
						Key = "green",
						Label = "Зелёный"
					}
				])
			.AddRadio("Я ношу часы...",
			[
				new()
				{
					Key = "left",
					Label = "на левой руке"
				},
				new()
				{
					Key = "right",
					Label = "на правой руке"
				}
			])
			.AddCheckbox("visited_cities",
				"Города, в которых я был",
				[
					new()
					{
						Label = "Екатеринбург"
					},
					new()
					{
						Label = "Волгоград"
					},
					new()
					{
						Label = "Санкт-Петербург"
					}
				])
			.Build();

		var expected = JToken.Parse(json);
		var actual = JToken.Parse(questions);

		JToken.DeepEquals(expected, actual)
			.Should()
			.BeTrue();
	}
}