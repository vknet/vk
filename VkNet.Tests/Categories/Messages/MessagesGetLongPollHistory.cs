﻿using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Messages
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class MessagesGetLongPollHistory : CategoryBaseTest
	{
		protected override string Folder => "Messages";

		[Test]
		public void GetLongPollHistory_ThrowArgumentException()
		{
			Assert.That(() => Api.Messages.GetLongPollHistory(new MessagesGetLongPollHistoryParams()),
				Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void GroupsField()
		{
			Url = "https://api.vk.com/method/messages.getLongPollHistory";

			ReadCategoryJsonPath(nameof(Api.Messages.GetLongPollHistory));

			var result = Api.Messages.GetLongPollHistory(new MessagesGetLongPollHistoryParams
			{
				Ts = 1874397841,
				PreviewLength = 0,
				EventsLimit = 1000,
				MsgsLimit = 200,
				MaxMsgId = 0,
				Onlines = true
			});

			Assert.IsNotEmpty(result.Groups);
		}
	}
}