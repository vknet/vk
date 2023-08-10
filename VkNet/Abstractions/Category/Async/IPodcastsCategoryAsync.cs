using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы с подкастами.
/// </summary>
public interface IPodcastsCategoryAsync
{
	/// <summary>
	/// Метод очищает последние запросы.
	/// </summary>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>
	/// Признак успешной очистки
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/podcasts.clearRecentSearches
	/// </remarks>
	[Obsolete("This method is deprecated. Use SearchPodcast method for work with podcast")]
	Task<bool> ClearRecentSearchesAsync(CancellationToken token = default);

	/// <summary>
	/// Метод удаляет карточку карусели.
	/// </summary>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>
	/// Список популярных подкастов
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/podcasts.getPopular
	/// </remarks>
	[Obsolete("This method is deprecated. Use SearchPodcast method for work with podcast")]
	Task<ReadOnlyCollection<PodcastsGetPopularResult>> GetPopularAsync(CancellationToken token = default);

	/// <summary>
	/// Метод редактирует карточку карусели.
	/// </summary>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>
	/// Список подкастов
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/podcasts.getRecentSearchRequests
	/// </remarks>
	[Obsolete("This method is deprecated. Use SearchPodcast method for work with podcast")]
	Task<ReadOnlyCollection<string>> GetRecentSearchRequestsAsync(CancellationToken token = default);

	/// <summary>
	/// Метод возвращает неиспользованные карточки владельца.
	/// </summary>
	/// <param name="params"> Параметры запроса </param>
	/// <param name="token">Токен отмены операции</param>
	/// <returns>
	/// Результат поиска
	/// </returns>
	/// <remarks>
	/// Страница документации ВКонтакте https://vk.com/dev/podcasts.search
	/// </remarks>
	Task<PodcastsSearchResult> SearchAsync(PodcastsSearchParams @params,
											CancellationToken token = default);
}