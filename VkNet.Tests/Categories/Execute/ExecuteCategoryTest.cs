using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
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
			Assert.That(result.RawJson, Is.EqualTo(Json));
		}

		[Test]
		public void ExecuteTopicsFeedTest()
		{
			Url = "https://api.vk.com/method/execute";

			ReadCategoryJsonPath(nameof(ExecuteTopicsFeedTest));
			var code = ReadScript(nameof(ExecuteTopicsFeedTest));

			var result = Api.Execute.Execute<TopicsFeed>(code);
			Assert.That(result, Is.Not.Null);
		}

		[Test]
		public void ExecuteGetUniversitiesTest()
		{
			Url = "https://api.vk.com/method/execute";
			ReadCategoryJsonPath(nameof(ExecuteGetUniversitiesTest));

			var code = ReadScript(nameof(ExecuteGetUniversitiesTest));

			var result = Api.Execute.Execute<VkCollection<University>>(code);
			Assert.That(result, Is.Not.Null);
			Assert.That(result.TotalCount, Is.EqualTo(93));
			Assert.That(result, Is.Not.Empty);
		}

		[Test]
		public void ExecuteErrorTest()
		{
			Url = "https://api.vk.com/method/execute";
			ReadErrorsJsonFile(12);

			var code = ReadScript(nameof(ExecuteErrorTest));

			Assert.That(() => Api.Execute.Execute(code), Throws.InstanceOf<VkApiException>());
		}

		[Test]
		public void ExecuteErrors()
		{
			Url = "https://api.vk.com/method/execute";
			ReadCategoryJsonPath(nameof(ExecuteErrors));

			var code = ReadScript(nameof(ExecuteErrorTest));

			var exception = Assert.Throws<ExecuteException>(() => Api.Execute.Execute(code));

			Assert.IsInstanceOf<ExecuteException>(exception);
			Assert.AreEqual(3, exception.InnerExceptions.Count);
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