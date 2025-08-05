using FluentAssertions;
using VkNet.Model;
using VkNet.Tests.Infrastructure;
using Xunit;

namespace VkNet.Tests.Categories.Polls;

public class GetVotersTest : CategoryBaseTest
{
	protected override string Folder => "Polls";

	[Fact(DisplayName = "Баг 1609. Ошибка при получении голосований")]
	public void GetVoters()
	{
		Url = "https://api.vk.com/method/polls.getVoters";

		ReadCategoryJsonPath(nameof(GetVoters));

		var pollsGetVotersParams = new PollsGetVotersParams
		{
			OwnerId = -145005178,
			PollId = 928754744,
			AnswersIds =
			[
				2501159906,
				2501159907
			]
		};

		var pollAnswerVotersList = Api.PollsCategory.GetVoters(pollsGetVotersParams);

		pollAnswerVotersList.Should()
			.NotBeEmpty();
	}
}