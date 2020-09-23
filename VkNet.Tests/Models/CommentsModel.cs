﻿using NUnit.Framework;
using VkNet.Model;

namespace VkNet.Tests.Models
{
	[TestFixture]

	public class CommentsModel
	{
		[Test]
		public void ShouldHaveField_GroupsCanPost()
		{
			var comments = new Comments();
			Assert.That(comments, Has.Property("GroupsCanPost"));
		}
	}
}