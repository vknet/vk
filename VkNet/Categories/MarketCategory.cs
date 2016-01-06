using System.Collections.Generic;
using System.Collections.ObjectModel;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы с товарами.
	/// </summary>
	public class MarketCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly VkApi _vk;

		/// <summary>
		/// Методы для работы с приложениями.
		/// </summary>
		/// <param name="vk">API.</param>
		internal MarketCategory(VkApi vk)
		{
			_vk = vk;
		}


		/// <summary>
		/// Метод возвращает список товаров в сообществе.
		/// </summary>
		/// <param name="ownerId">Идентификатор владельца товаров. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр (целое число, обязательный параметр).</param>
		/// <param name="albumId">Идентификатор подборки, товары из которой нужно вернуть. положительное число (положительное число).</param>
		/// <param name="count">Количество возвращаемых товаров. положительное число, максимальное значение 200, по умолчанию 100 (положительное число, максимальное значение 200, по умолчанию 100).</param>
		/// <param name="offset">Смещение относительно первого найденного товара для выборки определенного подмножества. положительное число (положительное число).</param>
		/// <param name="extended">1 — будут возвращены дополнительные поля likes, can_comment, can_repost, ''photos'''. По умолчанию эти поля не возвращается. флаг, может принимать значения 1 или 0 (флаг, может принимать значения 1 или 0).</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов item с дополнительным полем comments, содержащим число комментариев у товара.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/market.get" />.
		/// </remarks>
		[ApiVersion("5.42")]
		public ReadOnlyCollection<Product> Get(long ownerId, long? albumId = null, int? count = null, int? offset = null, bool extended = false)
		{
			var parameters = new VkParameters {
				{ "owner_id", ownerId },
				{ "album_id", albumId },
				{ "count", count },
				{ "offset", offset },
				{ "extended", extended }
			};

			return _vk.Call("market.get", parameters).ToReadOnlyCollectionOf<Product>(x => x);
		}

		/// <summary>
		/// Возвращает информацию о товарах по идентификаторам.
		/// </summary>
		/// <param name="itemIds">Перечисленные через запятую идентификаторы — идущие через знак подчеркивания id владельцев товаров и id самих товаров. Если товар принадлежит сообществу, то в качестве первого параметра используется -id сообщества. Пример значения item_ids: -4363_136089719,13245770_137352259 список строк, разделенных через запятую, обязательный параметр, количество элементов должно составлять не более 100 (список строк, разделенных через запятую, обязательный параметр, количество элементов должно составлять не более 100).</param>
		/// <param name="extended">1 — будут возвращены дополнительные поля likes, can_comment, can_repost, photos. По умолчанию эти поля не возвращается. флаг, может принимать значения 1 или 0 (флаг, может принимать значения 1 или 0).</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов item с дополнительным полем comments, содержащим число комментариев у товара.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/market.getById" />.
		/// </remarks>
		[ApiVersion("5.42")]
		public ReadOnlyCollection<Product> GetById(IEnumerable<string> itemIds, bool extended = false)
		{
			var parameters = new VkParameters {
				{ "item_ids", itemIds },
				{ "extended", extended }
			};

			return _vk.Call("market.getById", parameters).ToReadOnlyCollectionOf<Product>(x => x);
		}


		/// <summary>
		/// Поиск товаров в каталоге сообщества.
		/// </summary>
		/// <param name="params">Входные параметры запроса.</param>
		/// <returns>
		/// Возвращает список объектов item.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/market.search" />.
		/// </remarks>
		[ApiVersion("5.42")]
		public ReadOnlyCollection<Product> Search(MarketSearchParams @params)
		{
			return _vk.Call("market.search", @params).ToReadOnlyCollectionOf<Product>(x => x);
		}


		/// <summary>
		/// Возвращает список подборок с товарами.
		/// </summary>
		/// <param name="ownerId">Идентификатор владельца товаров. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр (целое число, обязательный параметр).</param>
		/// <param name="offset">Смещение относительно первой найденной подборки для выборки определенного подмножества. положительное число (положительное число).</param>
		/// <param name="count">Количество возвращаемых подборок. положительное число, по умолчанию 50, максимальное значение 100 (положительное число, по умолчанию 50, максимальное значение 100).</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов album.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/market.getAlbums" />.
		/// </remarks>
		[ApiVersion("5.42")]
		public ReadOnlyCollection<ProductAlbum> GetAlbums(long ownerId, int? offset = null, int? count = null)
		{
			var parameters = new VkParameters {
				{ "owner_id", ownerId },
				{ "offset", offset },
				{ "count", count }
			};

			return _vk.Call("market.getAlbums", parameters).ToReadOnlyCollectionOf<ProductAlbum>(x => x);
		}


		/// <summary>
		/// Метод возвращает данные подборки с товарами.
		/// </summary>
		/// <param name="ownerId">Идентификатор владельца подборки. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр (целое число, обязательный параметр).</param>
		/// <param name="albumIds">Идентификаторы подборок, данные о которых нужно получить. список положительных чисел, разделенных запятыми, обязательный параметр (список положительных чисел, разделенных запятыми, обязательный параметр).</param>
		/// <returns>
		/// Возвращает список объектов album. 
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/market.getAlbumById" />.
		/// </remarks>
		[ApiVersion("5.42")]
		public ReadOnlyCollection<ProductAlbum> GetAlbumById(long ownerId, IEnumerable<long> albumIds)
		{
			var parameters = new VkParameters {
				{ "owner_id", ownerId },
				{ "album_ids", albumIds }
			};

			return _vk.Call("market.getAlbumById", parameters).ToReadOnlyCollectionOf<ProductAlbum>(x => x);
		}




		/// <summary>
		/// Создает новый комментарий к товару.
		/// </summary>
		/// <param name="params">Входные параметры запроса.</param>
		/// <returns>
		/// После успешного выполнения возвращает идентификатор созданного комментария.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/market.createComment" />.
		/// </remarks>
		[ApiVersion("5.42")]
		public long CreateComment(MarketCreateCommentParams @params)
		{
			return _vk.Call("market.createComment", @params);
		}



		/// <summary>
		/// Возвращает список комментариев к товару.
		/// </summary>
		/// <param name="params">Входные параметры запроса.</param>
		/// <returns>
		/// Возвращает список объектов комментариев. 
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/market.getComments" />.
		/// </remarks>
		[ApiVersion("5.42")]
		public ProductComment GetComments(MarketGetCommentsParams @params)
		{
			return _vk.Call("market.getComments", @params);
		}


		/// <summary>
		/// Удаляет комментарий к товару.
		/// </summary>
		/// <param name="ownerId">Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр (целое число, обязательный параметр).</param>
		/// <param name="commentId">Идентификатор комментария. положительное число, обязательный параметр (положительное число, обязательный параметр).</param>
		/// <returns>
		/// После успешного выполнения возвращает 1 (0, если комментарий не найден).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/market.deleteComment" />.
		/// </remarks>
		[ApiVersion("5.42")]
		public bool DeleteComment(long ownerId, long commentId)
		{
			var parameters = new VkParameters {
				{ "owner_id", ownerId },
				{ "comment_id", commentId },
			};

			return _vk.Call("market.deleteComment", parameters);
		}


		/// <summary>
		/// Восстанавливает удаленный комментарий к товару.
		/// </summary>
		/// <param name="ownerId">Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр (целое число, обязательный параметр).</param>
		/// <param name="commentId">Идентификатор удаленного комментария. положительное число, обязательный параметр (положительное число, обязательный параметр).</param>
		/// <returns>
		/// После успешного выполнения возвращает 1 (0, если комментарий с таким идентификатором не является удаленным).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/market.restoreComment" />.
		/// </remarks>
		[ApiVersion("5.42")]
		public bool RestoreComment(long ownerId, long commentId)
		{
			var parameters = new VkParameters {
				{ "owner_id", ownerId },
				{ "comment_id", commentId },
			};

			return _vk.Call("market.restoreComment", parameters);
		}


		///// <summary>
		///// Изменяет текст комментария к товару.
		///// </summary>
		///// <param name="owner_id">Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр (целое число, обязательный параметр).</param>
		///// <param name="comment_id">Идентификатор комментария. положительное число, обязательный параметр (положительное число, обязательный параметр).</param>
		///// <param name="message">Новый текст комментария (является обязательным, если не задан параметр attachments). Максимальное количество символов: 2048. строка (строка).</param>
		///// <param name="attachments">Новый список объектов, приложенных к комментарию и разделённых символом &quot;,&quot;. (список строк, разделенных через запятую).</param>
		///// <returns>
		///// После успешного выполнения возвращает 1.
		///// </returns>
		///// <remarks>
		///// Страница документации ВКонтакте <see href="http://vk.com/dev/market.editComment" />.
		///// </remarks>
		//public bool EditComment(string owner_id, string comment_id, string message, string attachments)
		//{
		//	var parameters = new VkParameters {
		//		{ "owner_id", owner_id },
		//		{ "comment_id", comment_id },
		//		{ "message", message },
		//		{ "attachments", attachments },
		//	};

		//	return _vk.Call("market.editComment", parameters);
		//}


		///// <summary>
		///// Позволяет оставить жалобу на комментарий к товару.
		///// </summary>
		///// <param name="owner_id">Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр (целое число, обязательный параметр).</param>
		///// <param name="comment_id">Идентификатор комментария. положительное число, обязательный параметр (положительное число, обязательный параметр).</param>
		///// <param name="reason">Причина жалобы (положительное число, обязательный параметр).</param>
		///// <returns>
		///// После успешного выполнения возвращает 1.
		///// </returns>
		///// <remarks>
		///// Страница документации ВКонтакте <see href="http://vk.com/dev/market.reportComment" />.
		///// </remarks>
		//public bool ReportComment(string owner_id, string comment_id, string reason)
		//{
		//	var parameters = new VkParameters {
		//		{ "owner_id", owner_id },
		//		{ "comment_id", comment_id },
		//		{ "reason", reason },
		//	};

		//	return _vk.Call("market.reportComment", parameters);
		//}


		///// <summary>
		///// Позволяет отправить жалобу на товар.
		///// </summary>
		///// <param name="owner_id">Идентификатор владельца товаров. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр (целое число, обязательный параметр).</param>
		///// <param name="item_id">Идентификатор товара положительное число, обязательный параметр (положительное число, обязательный параметр).</param>
		///// <param name="reason">Причина жалобы (положительное число, обязательный параметр).</param>
		///// <returns>
		///// После успешного выполнения возвращает 1.
		///// </returns>
		///// <remarks>
		///// Страница документации ВКонтакте <see href="http://vk.com/dev/market.report" />.
		///// </remarks>
		//public bool Report(string owner_id, string item_id, string reason)
		//{
		//	var parameters = new VkParameters {
		//		{ "owner_id", owner_id },
		//		{ "item_id", item_id },
		//		{ "reason", reason },
		//	};

		//	return _vk.Call("market.report", parameters);
		//}


		///// <summary>
		///// Добавляет новый товар.
		///// </summary>
		///// <param name="owner_id">Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр (целое число, обязательный параметр).</param>
		///// <param name="name">Название товара. строка, минимальная длина 4, максимальная длина 100, обязательный параметр (строка, минимальная длина 4, максимальная длина 100, обязательный параметр).</param>
		///// <param name="description">Описание товара. строка, минимальная длина 10, обязательный параметр (строка, минимальная длина 10, обязательный параметр).</param>
		///// <param name="category_id">Идентификатор категории товара. положительное число, обязательный параметр (положительное число, обязательный параметр).</param>
		///// <param name="price">Цена товара. дробное число, обязательный параметр, минимальное значение 0.01 (дробное число, обязательный параметр, минимальное значение 0.01).</param>
		///// <param name="deleted">Статус товара (1 — товар удален, 0 — товар не удален). флаг, может принимать значения 1 или 0 (флаг, может принимать значения 1 или 0).</param>
		///// <param name="main_photo_id">Идентификатор фотографии обложки товара. положительное число, обязательный параметр (положительное число, обязательный параметр).</param>
		///// <param name="photo_ids">Идентификаторы дополнительных фотографий товара. список положительных чисел, разделенных запятыми, количество элементов должно составлять не более 4 (список положительных чисел, разделенных запятыми, количество элементов должно составлять не более 4).</param>
		///// <returns>
		///// После успешного выполнения возвращает идентификатор добавленного товара.
		///// </returns>
		///// <remarks>
		///// Страница документации ВКонтакте <see href="http://vk.com/dev/market.add" />.
		///// </remarks>
		//public bool Add(string owner_id, string name, string description, string category_id, string price, string deleted, string main_photo_id, string photo_ids)
		//{
		//	var parameters = new VkParameters {
		//		{ "owner_id", owner_id },
		//		{ "name", name },
		//		{ "description", description },
		//		{ "category_id", category_id },
		//		{ "price", price },
		//		{ "deleted", deleted },
		//		{ "main_photo_id", main_photo_id },
		//		{ "photo_ids", photo_ids },
		//	};

		//	return _vk.Call("market.add", parameters);
		//}


		///// <summary>
		///// Редактирует товар.
		///// </summary>
		///// <param name="owner_id">Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр (целое число, обязательный параметр).</param>
		///// <param name="item_id">Идентификатор товара. положительное число, обязательный параметр (положительное число, обязательный параметр).</param>
		///// <param name="name">Новое название товара. строка, минимальная длина 4, максимальная длина 100, обязательный параметр (строка, минимальная длина 4, максимальная длина 100, обязательный параметр).</param>
		///// <param name="description">Новое описание товара. строка, минимальная длина 10, обязательный параметр (строка, минимальная длина 10, обязательный параметр).</param>
		///// <param name="category_id">Идентификатор категории товара. положительное число, обязательный параметр (положительное число, обязательный параметр).</param>
		///// <param name="price">Цена товара. дробное число, обязательный параметр, минимальное значение 0.01 (дробное число, обязательный параметр, минимальное значение 0.01).</param>
		///// <param name="deleted">Статус товара (1 — товар удален, 0 — товар не удален). флаг, может принимать значения 1 или 0 (флаг, может принимать значения 1 или 0).</param>
		///// <param name="main_photo_id">Идентификатор фотографии для обложки товара. положительное число, обязательный параметр (положительное число, обязательный параметр).</param>
		///// <param name="photo_ids">Идентификаторы дополнительных фотографией товара. список положительных чисел, разделенных запятыми, количество элементов должно составлять не более 4 (список положительных чисел, разделенных запятыми, количество элементов должно составлять не более 4).</param>
		///// <returns>
		///// После успешного выполнения возвращает 1.
		///// </returns>
		///// <remarks>
		///// Страница документации ВКонтакте <see href="http://vk.com/dev/market.edit" />.
		///// </remarks>
		//public bool Edit(string owner_id, string item_id, string name, string description, string category_id, string price, string deleted, string main_photo_id, string photo_ids)
		//{
		//	var parameters = new VkParameters {
		//		{ "owner_id", owner_id },
		//		{ "item_id", item_id },
		//		{ "name", name },
		//		{ "description", description },
		//		{ "category_id", category_id },
		//		{ "price", price },
		//		{ "deleted", deleted },
		//		{ "main_photo_id", main_photo_id },
		//		{ "photo_ids", photo_ids },
		//	};

		//	return _vk.Call("market.edit", parameters);
		//}


		///// <summary>
		///// Удаляет товар.
		///// </summary>
		///// <param name="owner_id">Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр (целое число, обязательный параметр).</param>
		///// <param name="item_id">Идентификатор товара. положительное число, обязательный параметр (положительное число, обязательный параметр).</param>
		///// <returns>
		///// После успешного выполнения возвращает 1.
		///// </returns>
		///// <remarks>
		///// Страница документации ВКонтакте <see href="http://vk.com/dev/market.delete" />.
		///// </remarks>
		//public bool Delete(string owner_id, string item_id)
		//{
		//	var parameters = new VkParameters {
		//		{ "owner_id", owner_id },
		//		{ "item_id", item_id },
		//	};

		//	return _vk.Call("market.delete", parameters);
		//}


		///// <summary>
		///// Восстанавливает удаленный товар.
		///// </summary>
		///// <param name="owner_id">Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр (целое число, обязательный параметр).</param>
		///// <param name="item_id">Идентификатор товара. положительное число, обязательный параметр (положительное число, обязательный параметр).</param>
		///// <returns>
		///// После успешного выполнения возвращает 1 (0, если товар не найден среди удаленных).
		///// </returns>
		///// <remarks>
		///// Страница документации ВКонтакте <see href="http://vk.com/dev/market.restore" />.
		///// </remarks>
		//public bool Restore(string owner_id, string item_id)
		//{
		//	var parameters = new VkParameters {
		//		{ "owner_id", owner_id },
		//		{ "item_id", item_id },
		//	};

		//	return _vk.Call("market.restore", parameters);
		//}


		///// <summary>
		///// Изменяет положение товара в подборке.
		///// </summary>
		///// <param name="owner_id">Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр (целое число, обязательный параметр).</param>
		///// <param name="album_id">Идентификатор подборки, в которой находится товар. целое число, обязательный параметр (целое число, обязательный параметр).</param>
		///// <param name="item_id">Идентификатор товара. положительное число, обязательный параметр (положительное число, обязательный параметр).</param>
		///// <param name="before">Идентификатор товара, перед которым следует поместить текущий. положительное число (положительное число).</param>
		///// <param name="after">Идентификатор товара, после которого следует поместить текущий. положительное число (положительное число).</param>
		///// <returns>
		///// После успешного выполнения возвращает 1.
		///// </returns>
		///// <remarks>
		///// Страница документации ВКонтакте <see href="http://vk.com/dev/market.reorderItems" />.
		///// </remarks>
		//public bool ReorderItems(string owner_id, string album_id, string item_id, string before, string after)
		//{
		//	var parameters = new VkParameters {
		//		{ "owner_id", owner_id },
		//		{ "album_id", album_id },
		//		{ "item_id", item_id },
		//		{ "before", before },
		//		{ "after", after },
		//	};

		//	return _vk.Call("market.reorderItems", parameters);
		//}


		///// <summary>
		///// Изменяет положение подборки с товарами в списке.
		///// </summary>
		///// <param name="owner_id">Идентификатор владельца альбома. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр (целое число, обязательный параметр).</param>
		///// <param name="album_id">Идентификатор подборки. целое число, обязательный параметр (целое число, обязательный параметр).</param>
		///// <param name="before">Идентификатор подборки, перед которой следует поместить текущую. положительное число (положительное число).</param>
		///// <param name="after">Идентификатор подборки, после которой следует поместить текущую. положительное число (положительное число).</param>
		///// <returns>
		///// После успешного выполнения возвращает 1.
		///// </returns>
		///// <remarks>
		///// Страница документации ВКонтакте <see href="http://vk.com/dev/market.reorderAlbums" />.
		///// </remarks>
		//public bool ReorderAlbums(string owner_id, string album_id, string before, string after)
		//{
		//	var parameters = new VkParameters {
		//		{ "owner_id", owner_id },
		//		{ "album_id", album_id },
		//		{ "before", before },
		//		{ "after", after },
		//	};

		//	return _vk.Call("market.reorderAlbums", parameters);
		//}


		///// <summary>
		///// Добавляет новую подборку с товарами.
		///// </summary>
		///// <param name="owner_id">Идентификатор владельца подборки. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр (целое число, обязательный параметр).</param>
		///// <param name="title">Название подборки. строка, обязательный параметр, максимальная длина 128 (строка, обязательный параметр, максимальная длина 128).</param>
		///// <param name="photo_id">Идентификатор фотографии-обложки подборки. положительное число (положительное число).</param>
		///// <param name="main_album">Назначить подборку основной (1 — назначить, 0 — нет). флаг, может принимать значения 1 или 0 (флаг, может принимать значения 1 или 0).</param>
		///// <returns>
		///// После успешного выполнения возвращает идентификатор созданной подборки.
		///// </returns>
		///// <remarks>
		///// Страница документации ВКонтакте <see href="http://vk.com/dev/market.addAlbum" />.
		///// </remarks>
		//public bool AddAlbum(string owner_id, string title, string photo_id, string main_album)
		//{
		//	var parameters = new VkParameters {
		//		{ "owner_id", owner_id },
		//		{ "title", title },
		//		{ "photo_id", photo_id },
		//		{ "main_album", main_album },
		//	};

		//	return _vk.Call("market.addAlbum", parameters);
		//}


		///// <summary>
		///// Редактирует подборку с товарами.
		///// </summary>
		///// <param name="owner_id">Идентификатор владельца подборки. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр (целое число, обязательный параметр).</param>
		///// <param name="album_id">Идентификатор подборки. положительное число, обязательный параметр (положительное число, обязательный параметр).</param>
		///// <param name="title">Название подборки. строка, обязательный параметр, максимальная длина 128 (строка, обязательный параметр, максимальная длина 128).</param>
		///// <param name="photo_id">Идентификатор фотографии-обложки подборки. положительное число (положительное число).</param>
		///// <returns>
		///// После успешного выполнения возвращает 1.
		///// </returns>
		///// <remarks>
		///// Страница документации ВКонтакте <see href="http://vk.com/dev/market.editAlbum" />.
		///// </remarks>
		//public bool EditAlbum(string owner_id, string album_id, string title, string photo_id)
		//{
		//	var parameters = new VkParameters {
		//		{ "owner_id", owner_id },
		//		{ "album_id", album_id },
		//		{ "title", title },
		//		{ "photo_id", photo_id },
		//	};

		//	return _vk.Call("market.editAlbum", parameters);
		//}


		///// <summary>
		///// Удаляет подборку с товарами.
		///// </summary>
		///// <param name="owner_id">Идентификатор владельца подборки. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр (целое число, обязательный параметр).</param>
		///// <param name="album_id">Идентификатор подборки. положительное число, обязательный параметр (положительное число, обязательный параметр).</param>
		///// <returns>
		///// После успешного выполнения возвращает 1.
		///// </returns>
		///// <remarks>
		///// Страница документации ВКонтакте <see href="http://vk.com/dev/market.deleteAlbum" />.
		///// </remarks>
		//public bool DeleteAlbum(string owner_id, string album_id)
		//{
		//	var parameters = new VkParameters {
		//		{ "owner_id", owner_id },
		//		{ "album_id", album_id },
		//	};

		//	return _vk.Call("market.deleteAlbum", parameters);
		//}


		///// <summary>
		///// Удаляет товар из одной или нескольких выбранных подборок.
		///// </summary>
		///// <param name="owner_id">Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр (целое число, обязательный параметр).</param>
		///// <param name="item_id">Идентификатор товара. положительное число, обязательный параметр (положительное число, обязательный параметр).</param>
		///// <param name="album_ids">Идентификаторы подборок, из которых нужно удалить товар. список положительных чисел, разделенных запятыми, обязательный параметр (список положительных чисел, разделенных запятыми, обязательный параметр).</param>
		///// <returns>
		///// После успешного выполнения возвращает 1.
		///// </returns>
		///// <remarks>
		///// Страница документации ВКонтакте <see href="http://vk.com/dev/market.removeFromAlbum" />.
		///// </remarks>
		//public bool RemoveFromAlbum(string owner_id, string item_id, string album_ids)
		//{
		//	var parameters = new VkParameters {
		//		{ "owner_id", owner_id },
		//		{ "item_id", item_id },
		//		{ "album_ids", album_ids },
		//	};

		//	return _vk.Call("market.removeFromAlbum", parameters);
		//}


		///// <summary>
		///// Добавляет товар в одну или несколько выбранных подборок.
		///// </summary>
		///// <param name="owner_id">Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком &quot;-&quot; — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр (целое число, обязательный параметр).</param>
		///// <param name="item_id">Идентификатор товара. положительное число, обязательный параметр (положительное число, обязательный параметр).</param>
		///// <param name="album_ids">Идентификаторы подборок, в которые нужно добавить товар. список положительных чисел, разделенных запятыми, обязательный параметр (список положительных чисел, разделенных запятыми, обязательный параметр).</param>
		///// <returns>
		///// После успешного выполнения возвращает 1.
		///// </returns>
		///// <remarks>
		///// Страница документации ВКонтакте <see href="http://vk.com/dev/market.addToAlbum" />.
		///// </remarks>
		//public bool AddToAlbum(string owner_id, string item_id, string album_ids)
		//{
		//	var parameters = new VkParameters {
		//		{ "owner_id", owner_id },
		//		{ "item_id", item_id },
		//		{ "album_ids", album_ids },
		//	};

		//	return _vk.Call("market.addToAlbum", parameters);
		//}

	}
}