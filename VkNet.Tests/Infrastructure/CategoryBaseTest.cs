namespace VkNet.Tests.Infrastructure
{
	public abstract class CategoryBaseTest : BaseTest
	{
		protected abstract string Folder { get; }

		protected void ReadCategoryJsonPath(string path)
		{
			ReadJsonFile(Folder, path);
		}
	}
}