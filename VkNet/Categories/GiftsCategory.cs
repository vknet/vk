using System.Collections.ObjectModel;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы с подарками.
	/// </summary>
	public class GiftsCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly VkApi _vk;

		/// <summary>
		/// Методы для работы с подарками.
		/// </summary>
		/// <param name="vk">API.</param>
		internal GiftsCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Возвращает список полученных подарков пользователя.
		/// </summary>
		/// <param name="totalCount">Количество полученных подарков.</param>
		/// <param name="userId">Идентификатор пользователя, для которого необходимо получить список подарков.</param>
		/// <param name="count">Количество подарков, которое нужно вернуть.</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества подарков.</param>
		/// <returns>
		/// В случае успешного вступления в группу метод вернёт <c>true</c>, иначе <c>false</c>.
		/// Возвращает список объектов gift_item, каждый из которых содержит следующие поля:
		/// id — идентификатор полученного подарка;
		/// from_id — идентификатор пользователя, который отправил подарок, или 0, если отправитель скрыт;
		/// message — текст сообщения, приложенного к подарку;
		/// date — время отправки подарка в формате unixtime;
		/// gift — объект подарка в следующем формате:
		/// id — номер подарка;
		/// thumb_256 — url изображения подарка размером 256x256px;
		/// thumb_96 — url изображения подарка размером 96x96px;
		/// thumb_48 — url изображения подарка размером 48x48px;
		/// privacy — значение приватности подарка(только для текущего пользователя; возможные значения: 0 — имя отправителя и сообщение видно всем; 1 — имя отправителя видно всем, сообщение видно только получателю; 2 — имя отправителя скрыто, сообщение видно только получателю).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/gifts.get" />.
		/// </remarks>
		[ApiVersion("5.37")]
		public ReadOnlyCollection<GiftItem> Get(out int totalCount, ulong userId, ulong? count = null, ulong? offset = null)
		{
			var parameters = new VkParameters
			{
				{ "user_id", userId },
				{ "count", count },
				{ "offset", offset }
			};
			var response = _vk.Call("gifts.get", parameters);
			totalCount = response["count"];
			return response["items"].ToReadOnlyCollectionOf<GiftItem>(x => x);
		}
	}
}
