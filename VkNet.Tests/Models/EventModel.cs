using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.Attachments;

namespace VkNet.Tests.Models
{
	[TestFixture]

	public class EventModel : BaseTest
	{
		[Test]
		public void EventModel_ImplicitEvent()
		{
			ReadJsonFile("Models", nameof(EventModel_ImplicitEvent));

			var response = GetResponse();

			var attachment = Attachment.FromJson(response);

			attachment.Instance.Should().BeOfType<Event>();
		}
	}
}