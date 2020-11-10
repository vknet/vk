using JetBrains.Annotations;
using VkNet.Abstractions.Core;
using VkNet.Exception;

namespace VkNet.Infrastructure
{
	/// <inheritdoc />
	[UsedImplicitly]
	public class VkApiVersionManager : IVkApiVersionManager
	{
		private const int CurrentMajorVersion = 5;

		private const int CurrentMinorVersion = 126;

		private const int MinimalMinorVersion = 81;

		private int Major { get; set; } = CurrentMajorVersion;

		private int Minor { get; set; } = CurrentMinorVersion;

		/// <inheritdoc />
		public string Version => $"{Major}.{Minor}";

		/// <inheritdoc />
		public void SetVersion(int major, int minor)
		{
			if (major < CurrentMajorVersion)
			{
				throw new VkApiException("С 27 мая 2019 года версии API ниже 5.0 больше не поддерживаются.")
				{
					HelpLink = "https://vk.com/dev/version_update_2.0"
				};
			}

			if (major == CurrentMajorVersion && minor < MinimalMinorVersion)
			{
				throw new VkApiException("С 14 октября 2020 года прекратится поддержка версий ниже 5.81.")
				{
					HelpLink = "https://vk.com/dev/constant_version_updates"
				};
			}

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