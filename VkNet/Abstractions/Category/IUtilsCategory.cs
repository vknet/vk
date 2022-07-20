using System;
using JetBrains.Annotations;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IUtilsCategoryAsync"/>
	public interface IUtilsCategory : IUtilsCategoryAsync
	{
		/// <inheritdoc cref="IUtilsCategoryAsync.CheckLinkAsync(string)"/>
		LinkAccessType CheckLink([NotNull] string url);

		/// <inheritdoc cref="IUtilsCategoryAsync.CheckLinkAsync(Uri)"/>
		LinkAccessType CheckLink([NotNull] Uri url);

		/// <inheritdoc cref="IUtilsCategoryAsync.ResolveScreenNameAsync"/>
		VkObject ResolveScreenName([NotNull] string screenName);

		/// <inheritdoc cref="IUtilsCategoryAsync.GetServerTimeAsync"/>
		DateTime GetServerTime();

		/// <inheritdoc cref="IUtilsCategoryAsync.GetShortLinkAsync"/>
		ShortLink GetShortLink(Uri url, bool isPrivate);

		/// <inheritdoc cref="IUtilsCategoryAsync.DeleteFromLastShortenedAsync"/>ии ВКонтакте http://vk.com/dev/utils.deleteFromLastShortened
		bool DeleteFromLastShortened(string key);

		/// <inheritdoc cref="IUtilsCategoryAsync.GetLastShortenedLinksAsync"/>
		VkCollection<ShortLink> GetLastShortenedLinks(ulong count = 10, ulong offset = 0);

		/// <inheritdoc cref="IUtilsCategoryAsync.GetLinkStatsAsync"/>
		LinkStatsResult GetLinkStats(LinkStatsParams @params);
	}
}