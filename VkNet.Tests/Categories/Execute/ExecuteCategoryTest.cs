using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Tests.Infrastructure;
using VkNet.Utils;

namespace VkNet.Tests.Categories.Execute
{
	public class ExecuteCategoryTest : CategoryBaseTest
	{
		protected override string Folder => "Execute";

		[Test]
		public void ExecuteTest()
		{
			Url = "https://api.vk.com/method/execute";

			ReadCategoryJsonPath(nameof(ExecuteTest));

			var code = ReadScript(nameof(ExecuteTest));

			var result = Api.Execute.Execute(code);
			result.RawJson.Should().Be(Json);
		}

		[Test]
		public void ExecuteTopicsFeedTest()
		{
			Url = "https://api.vk.com/method/execute";

			ReadCategoryJsonPath(nameof(ExecuteTopicsFeedTest));
			var code = ReadScript(nameof(ExecuteTopicsFeedTest));

			var result = Api.Execute.Execute<TopicsFeed>(code);
			result.Should().NotBeNull();
		}

		[Test]
		public void ExecuteGetUniversitiesTest()
		{
			Url = "https://api.vk.com/method/execute";
			ReadCategoryJsonPath(nameof(ExecuteGetUniversitiesTest));

			var code = ReadScript(nameof(ExecuteGetUniversitiesTest));

			var result = Api.Execute.Execute<VkCollection<University>>(code);
			result.Should().NotBeNull();
			result.TotalCount.Should().Be(93);
			result.Should().NotBeEmpty();
		}

		[Test]
		public void ExecuteErrorTest()
		{
			Url = "https://api.vk.com/method/execute";
			ReadErrorsJsonFile(12);

			var code = ReadScript(nameof(ExecuteErrorTest));

			FluentActions.Invoking(() => Api.Execute.Execute(code)).Should().ThrowExactly<VkApiException>();
		}

		[Test]
		public void ExecuteErrors()
		{
			Url = "https://api.vk.com/method/execute";
			ReadCategoryJsonPath(nameof(ExecuteErrors));

			var code = ReadScript(nameof(ExecuteErrorTest));

			FluentActions.Invoking(() => Api.Execute.Execute(code))
				.Should()
				.ThrowExactly<ExecuteException>()
				.And.InnerExceptions.Should()
				.HaveCount(3);
		}

		private string ReadScript(string scriptPath)
		{
			var folders = new List<string>
			{
				AppContext.BaseDirectory,
				"TestData"
			};

			folders.AddRange(new[]
			{
				"Categories",
				Folder,
				scriptPath
			});

			var path = Path.Combine(folders.ToArray()) + ".vkscript";

			if (!File.Exists(path))
			{
				throw new FileNotFoundException(path);
			}

			return File.ReadAllText(path);
		}
	}
}