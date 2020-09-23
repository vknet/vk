using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.BotsLongPoll
{

	public abstract class BotsLongPollBaseTest : CategoryBaseTest
	{
		protected override string Folder => "BotsLongPoll";

		protected BotsLongPollBaseTest()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

			Encoding = Encoding.GetEncoding("windows-1251");
		}

		protected override void ReadCategoryJsonPath(string path)
		{
			var json = ReadJson("Categories", Folder, path);
			var format = ReadFile("Categories", Folder, "FullLongPollFormat");
			Json = string.Format(format, json);
			Url = "https://vk.com";
		}

		private string ReadFile(params string[] jsonRelativePaths)
		{
			var folders = new List<string>
			{
				AppContext.BaseDirectory, "TestData"
			};

			folders.AddRange(jsonRelativePaths);

			var path = Path.Combine(folders.ToArray()) + ".txt";

			if (!File.Exists(path))
			{
				throw new FileNotFoundException(path);
			}

			return File.ReadAllText(path, Encoding);
		}
	}
}