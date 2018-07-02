using System;
using JetBrains.Annotations;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Служебные методы.
	/// </summary>
	public interface IUtilsCategory : IUtilsCategoryAsync
	{
		/// <summary>
		/// Возвращает информацию о том, является ли внешняя ссылка заблокированной на
		/// сайте ВКонтакте.
		/// </summary>
		/// <param name="url"> Внешняя ссылка, которую необходимо проверить. </param>
		/// <param name="skipAuthorization"> Без авторизации </param>
		/// <returns> Статус ссылки </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/utils.checkLink
		/// </remarks>
		LinkAccessType CheckLink([NotNull]
								string url
								, bool skipAuthorization = true);

		/// <summary>
		/// Возвращает информацию о том, является ли внешняя ссылка заблокированной на
		/// сайте ВКонтакте.
		/// </summary>
		/// <param name="url"> Внешняя ссылка, которую необходимо проверить. </param>
		/// <param name="skipAuthorization"> Без авторизации </param>
		/// <returns> Статус ссылки </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/utils.checkLink
		/// </remarks>
		LinkAccessType CheckLink([NotNull]
								Uri url
								, bool skipAuthorization = true);

		/// <summary>
		/// Определяет тип объекта (пользователь, сообщество, приложение) и его
		/// идентификатор по короткому имени ScreenName.
		/// </summary>
		/// <param name="screenName"> Короткое имя </param>
		/// <returns> Тип объекта </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/utils.resolveScreenName
		/// </remarks>
		VkObject ResolveScreenName([NotNull]
									string screenName);

		/// <summary>
		/// Возвращает текущее время на сервере ВКонтакте в unixtime.
		/// </summary>
		/// <returns> Время на сервере ВКонтакте в unixtime </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/utils.getServerTime
		/// </remarks>
		DateTime GetServerTime();

		/// <summary>
		/// Позволяет получить URL, сокращенный с помощью vk.cc.
		/// </summary>
		/// <returns> URL, сокращенный с помощью vk.cc </returns>
		ShortLink GetShortLink(Uri url, bool isPrivate);

		/// <summary>
		/// Удаляет сокращенную ссылку из списка пользователя.
		/// </summary>
		/// <param name="key"> сокращенная ссылка (часть URL после "vk.cc/"). </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/utils.deleteFromLastShortened
		/// </remarks>
		bool DeleteFromLastShortened(string key);

		/// <summary>
		/// Получает список сокращенных ссылок для текущего пользователя.
		/// </summary>
		/// <param name="count"> количество ссылок, которые необходимо получить. </param>
		/// <param name="offset"> сдвиг для получения определенного подмножества ссылок. </param>
		/// <returns>
		/// Возвращает количество ссылок в поле count (integer) и массив объектов items,
		/// описывающих ссылки.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/utils.getLastShortenedLinks
		/// </remarks>
		VkCollection<ShortLink> GetLastShortenedLinks(ulong count = 10, ulong offset = 0);

		/// <summary>
		/// Возвращает статистику переходов по сокращенной ссылке.
		/// </summary>
		/// <param name="params"> Параметры запроса </param>
		/// <returns> </returns>
		LinkStatsResult GetLinkStats(LinkStatsParams @params);
	}
}