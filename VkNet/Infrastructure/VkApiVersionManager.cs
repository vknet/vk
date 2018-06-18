using JetBrains.Annotations;
using VkNet.Abstractions;

namespace VkNet.Infrastructure
{
	/// <inheritdoc />
	[UsedImplicitly]
	public class VkApiVersionManager: IVkApiVersionManager
	{
		/// <inheritdoc />
		public string Version { get; private set; } = "5.80";

		/// <inheritdoc />
		public void SetVersion(string version)
		{
			Version = version;
		}
	}
}