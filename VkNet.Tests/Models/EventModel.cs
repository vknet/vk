using FluentAssertions;
using VkNet.Model.Attachments;
using Xunit;

namespace VkNet.Tests.Models
{


	public class EventModel : BaseTest
	{
		[Fact]
		public void EventModel_ImplicitEvent()
		{
			ReadJsonFile("Models", nameof(EventModel_ImplicitEvent));

			var response = GetResponse();

			var attachment = Attachment.FromJson(response);

			attachment.Instance.Should().BeOfType<Event>();
		}
	}
}