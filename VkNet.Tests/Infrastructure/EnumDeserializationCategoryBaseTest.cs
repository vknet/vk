namespace VkNet.Tests.Infrastructure;

public abstract class EnumDeserializationCategoryBaseTest : EnumDeserializationErrorTest
{
	protected abstract string Folder { get; }

	protected virtual void ReadJsonPath(string path) => ReadJsonFile(JsonTestFolderConstants.RootFolder.Common, Folder, path);
}