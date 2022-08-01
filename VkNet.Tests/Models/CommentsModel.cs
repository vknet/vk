using FluentAssertions;
using VkNet.Model;
using Xunit;

namespace VkNet.Tests.Models;

public class CommentsModel
{
	[Fact]
	public void ShouldHaveField_GroupsCanPost()
	{
		var comments = new Comments();

		comments.GroupsCanPost.Should()
			.BeFalse();
	}
}