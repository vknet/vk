using AwesomeAssertions;
using VkNet.Model;

namespace VkNet.Tests.Models;

public class CommentsModel
{
	[Test]
	[DisplayName("Should have field groups can post")]
	public void ShouldHaveField_GroupsCanPost()
	{
		var comments = new Comments();

		comments.GroupsCanPost.Should()
			.BeFalse();
	}
}