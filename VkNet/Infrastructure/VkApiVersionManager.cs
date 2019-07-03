using JetBrains.Annotations;
using VkNet.Abstractions.Core;

namespace VkNet.Infrastructure
{
	/// <inheritdoc />
	[UsedImplicitly]
	public class VkApiVersionManager : IVkApiVersionManager
	{
		private int Major { get; set; } = 5;

		private int Minor { get; set; } = 101;

		/// <inheritdoc />
		public string Version => $"{Major}.{Minor}";

		/// <inheritdoc />
		public void SetVersion(int major, int minor)
		{
			Major = major;
			Minor = minor;
		}

		/// <inheritdoc />
		public bool IsGreaterThanOrEqual(int major, int minor)
		{
			if (Major == major && Minor >= minor)
			{
				return true;
			}

			return Major > major;
		}

		/// <inheritdoc />
		public bool IsLessThanOrEqual(int major, int minor)
		{
			if (Major == major && Minor <= minor)
			{
				return true;
			}

			return Major < major;
		}
	}
}