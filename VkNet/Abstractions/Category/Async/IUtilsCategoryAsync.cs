using System;
using System.Threading.Tasks;
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
	public interface IUtilsCategoryAsync
	{
		/// <summary>
		/// Возвращает информацию о том, является ли внешняя ссылка заблокированной на
		/// сайте ВКонтакте.
		/// </summary>
		/// <param name="url"> Внешняя ссылка, которую необходимо проверить. </param>
		/// <returns> Статус ссылки </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/utils.checkLink
		/// </remarks>
		Task<LinkAccessType> CheckLinkAsync([NotNull]
											string url);

		/// <summary>
		/// Возвращает информацию о том, является ли внешняя ссылка заблокированной на
		/// сайте ВКонтакте.
		/// </summary>
		/// <param name="url"> Внешняя ссылка, которую необходимо проверить. </param>
		/// <returns> Статус ссылки </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/utils.checkLink
		/// </remarks>
		Task<LinkAccessType> CheckLinkAsync([NotNull]
											Uri url);

		/// <summary>
		/// Определяет тип объекта (пользователь, сообщество, приложение) и его
		/// идентификатор по короткому имени ScreenName.
		/// </summary>
		/// <param name="screenName"> Короткое имя </param>
		/// <returns> Тип объекта </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/utils.resolveScreenName
		/// </remarks>
		Task<VkObject> ResolveScreenNameAsync([NotNull]
											string screenName);

		/// <summary>
		/// Возвращает текущее время на сервере ВКонтакте в unixtime.
		/// </summary>
		/// <returns> Время на сервере ВКонтакте в unixtime </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/utils.getServerTime
		/// </remarks>
		Task<DateTime> GetServerTimeAsync();

		/// <summary>
		/// Позволяет получить URL, сокращенный с помощью vk.cc.
		/// </summary>
		/// <returns> URL, сокращенный с помощью vk.cc </returns>
		Task<ShortLink> GetShortLinkAsync(Uri url, bool isPrivate);

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
		Task<bool> DeleteFromLastShortenedAsync(string key);

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
		Task<VkCollection<ShortLink>> GetLastShortenedLinksAsync(ulong count = 10, ulong offset = 0);

		/// <summary>
		/// Возвращает статистику переходов по сокращенной ссылке.
		/// </summary>
		/// <param name="params"> Параметры запроса </param>
		/// <returns> </returns>
		Task<LinkStatsResult> GetLinkStatsAsync(LinkStatsParams @params);
	}
}