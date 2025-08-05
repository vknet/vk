using JetBrains.Annotations;
using VkNet.Abstractions.Core;
using VkNet.Exception;

namespace VkNet.Infrastructure;

/// <inheritdoc cref="IVkApiVersionManager" />
[UsedImplicitly]
public class VkApiVersionManager : IVkApiVersionManager
{
	private const int CurrentMajorVersion = 5;

	private const int CurrentMinorVersion = 131;

	private const int MinimalMinorVersion = 81;

	private int Major { get; set; } = CurrentMajorVersion;

	private int Minor { get; set; } = CurrentMinorVersion;

	/// <inheritdoc />
	public string Version => $"{Major}.{Minor}";

	/// <inheritdoc />
	public void SetVersion(int major, int minor)
	{
		switch (major)
		{
			case < CurrentMajorVersion:
				throw new VkApiException("С 27 мая 2019 года версии API ниже 5.0 больше не поддерживаются.")
				{
					HelpLink = "https://vk.com/dev/version_update_2.0"
				};

			case CurrentMajorVersion when minor < MinimalMinorVersion:
				throw new VkApiException("С 2 сентября 2021 года прекратилась поддержка версий ниже 5.81.")
				{
					HelpLink = "https://vk.com/dev/constant_version_updates"
				};

			default:
				Major = major;
				Minor = minor;

				break;
		}
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