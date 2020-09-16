using System.Diagnostics.CodeAnalysis;

namespace VkNet.Tests.Infrastructure
{

	public abstract class CategoryBaseTest : BaseTest
	{
		protected abstract string Folder { get; }

		protected virtual void ReadCategoryJsonPath(string path)
		{
			ReadJsonFile("Categories", Folder, path);
		}
	}
}