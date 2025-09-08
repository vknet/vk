using AwesomeAssertions;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Models;

public class CommentsModel
{
	[Fact(DisplayName = "Should have field groups can post")]
	public void ShouldHaveField_GroupsCanPost()
	{
		var comments = new Comments();

		comments.GroupsCanPost.Should()
			.BeFalse();
	}
}