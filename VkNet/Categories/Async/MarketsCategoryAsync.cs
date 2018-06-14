using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	public partial class MarketsCategory
	{
		/// <summary>
		/// Метод возвращает список товаров в сообществе.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор владельца товаров. Обратите внимание, идентификатор сообщества в
		/// параметре owner_id
		/// необходимо указывать со знаком "-" — например, owner_id=-1 соответствует
		/// идентификатору сообщества ВКонтакте API
		/// (club1)  целое число, обязательный параметр (целое число, обязательный
		/// параметр).
		/// </param>
		/// <param name="albumId">
		/// Идентификатор подборки, товары из которой нужно вернуть. положительное число
		/// (положительное
		/// число).
		/// </param>
		/// <param name="count">
		/// Количество возвращаемых товаров. положительное число, максимальное значение
		/// 200, по умолчанию 100
		/// (положительное число, максимальное значение 200, по умолчанию 100).
		/// </param>
		/// <param name="offset">
		/// Смещение относительно первого найденного товара для выборки определенного
		/// подмножества.
		/// положительное число (положительное число).
		/// </param>
		/// <param name="extended">
		/// 1 — будут возвращены дополнительные поля likes, can_comment, can_repost,
		/// ''photos'''. По
		/// умолчанию эти поля не возвращается. флаг, может принимать значения 1 или 0
		/// (флаг, может принимать значения 1 или
		/// 0).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов item с дополнительным
		/// полем comments, содержащим число
		/// комментариев у товара.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.get
		/// </remarks>
		public async Task<VkCollection<Market>> GetAsync(long ownerId
														, long? albumId = null
														, int? count = null
														, int? offset = null
														, bool extended = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Markets.Get(ownerId: ownerId, albumId: albumId, count: count, offset: offset, extended: extended));
		}

		/// <summary>
		/// Возвращает информацию о товарах по идентификаторам.
		/// </summary>
		/// <param name="itemIds">
		/// Перечисленные через запятую идентификаторы — идущие через знак подчеркивания id
		/// владельцев
		/// товаров и id самих товаров. Если товар принадлежит сообществу, то в качестве
		/// первого параметра используется -id
		/// сообщества. Пример значения item_ids: -4363_136089719,13245770_137352259 список
		/// строк, разделенных через запятую,
		/// обязательный параметр, количество элементов должно составлять не более 100
		/// (список строк, разделенных через
		/// запятую, обязательный параметр, количество элементов должно составлять не более
		/// 100).
		/// </param>
		/// <param name="extended">
		/// 1 — будут возвращены дополнительные поля likes, can_comment, can_repost,
		/// photos. По умолчанию
		/// эти поля не возвращается. флаг, может принимать значения 1 или 0 (флаг, может
		/// принимать значения 1 или 0).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов item с дополнительным
		/// полем comments, содержащим число
		/// комментариев у товара.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.getById
		/// </remarks>
		public async Task<VkCollection<Market>> GetByIdAsync(IEnumerable<string> itemIds, bool extended = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Markets.GetById(itemIds: itemIds, extended: extended));
		}

		/// <summary>
		/// Поиск товаров в каталоге сообщества.
		/// </summary>
		/// <param name="params"> Входные параметры запроса. </param>
		/// <returns>
		/// Возвращает список объектов item.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.search
		/// </remarks>
		public async Task<VkCollection<Market>> SearchAsync(MarketSearchParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Markets.Search(@params: @params));
		}

		/// <summary>
		/// Возвращает список подборок с товарами.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор владельца товаров. Обратите внимание, идентификатор сообщества в
		/// параметре owner_id
		/// необходимо указывать со знаком "-" — например, owner_id=-1 соответствует
		/// идентификатору сообщества ВКонтакте API
		/// (club1)  целое число, обязательный параметр (целое число, обязательный
		/// параметр).
		/// </param>
		/// <param name="offset">
		/// Смещение относительно первой найденной подборки для выборки определенного
		/// подмножества.
		/// положительное число (положительное число).
		/// </param>
		/// <param name="count">
		/// Количество возвращаемых подборок. положительное число, по умолчанию 50,
		/// максимальное значение 100
		/// (положительное число, по умолчанию 50, максимальное значение 100).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов album.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.getAlbums
		/// </remarks>
		public async Task<VkCollection<MarketAlbum>> GetAlbumsAsync(long ownerId, int? offset, int? count)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Markets.GetAlbums(ownerId: ownerId, offset: offset, count: count));
		}

		/// <summary>
		/// Метод возвращает данные подборки с товарами.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор владельца подборки. Обратите внимание, идентификатор сообщества в
		/// параметре
		/// owner_id необходимо указывать со знаком "-" — например, owner_id=-1
		/// соответствует идентификатору сообщества
		/// ВКонтакте API (club1)  целое число, обязательный параметр (целое число,
		/// обязательный параметр).
		/// </param>
		/// <param name="albumIds">
		/// Идентификаторы подборок, данные о которых нужно получить. список положительных
		/// чисел,
		/// разделенных запятыми, обязательный параметр (список положительных чисел,
		/// разделенных запятыми, обязательный
		/// параметр).
		/// </param>
		/// <returns>
		/// Возвращает список объектов album.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.getAlbumById
		/// </remarks>
		public async Task<VkCollection<MarketAlbum>> GetAlbumByIdAsync(long ownerId, IEnumerable<long> albumIds)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Markets.GetAlbumById(ownerId: ownerId, albumIds: albumIds));
		}

		/// <summary>
		/// Создает новый комментарий к товару.
		/// </summary>
		/// <param name="params"> Входные параметры запроса. </param>
		/// <returns>
		/// После успешного выполнения возвращает идентификатор созданного комментария.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.createComment
		/// </remarks>
		public async Task<long> CreateCommentAsync(MarketCreateCommentParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Markets.CreateComment(@params: @params));
		}

		/// <summary>
		/// Возвращает список комментариев к товару.
		/// </summary>
		/// <param name="params"> Входные параметры запроса. </param>
		/// <returns>
		/// Возвращает список объектов комментариев.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.getComments
		/// </remarks>
		public async Task<VkCollection<MarketComment>> GetCommentsAsync(MarketGetCommentsParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Markets.GetComments(@params: @params));
		}

		/// <summary>
		/// Удаляет комментарий к товару.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в
		/// параметре owner_id
		/// необходимо указывать со знаком "-" — например, owner_id=-1 соответствует
		/// идентификатору сообщества ВКонтакте API
		/// (club1)  целое число, обязательный параметр (целое число, обязательный
		/// параметр).
		/// </param>
		/// <param name="commentId">
		/// Идентификатор комментария. положительное число, обязательный параметр
		/// (положительное число,
		/// обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1 (0, если комментарий не найден).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.deleteComment
		/// </remarks>
		public async Task<bool> DeleteCommentAsync(long ownerId, long commentId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Markets.DeleteComment(ownerId: ownerId, commentId: commentId));
		}

		/// <summary>
		/// Восстанавливает удаленный комментарий к товару.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в
		/// параметре owner_id
		/// необходимо указывать со знаком "-" — например, owner_id=-1 соответствует
		/// идентификатору сообщества ВКонтакте API
		/// (club1)  целое число, обязательный параметр (целое число, обязательный
		/// параметр).
		/// </param>
		/// <param name="commentId">
		/// Идентификатор удаленного комментария. положительное число, обязательный
		/// параметр (положительное
		/// число, обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1 (0, если комментарий с таким
		/// идентификатором не является удаленным).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.restoreComment
		/// </remarks>
		public async Task<bool> RestoreCommentAsync(long ownerId, long commentId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Markets.RestoreComment(ownerId: ownerId, commentId: commentId));
		}

		/// <summary>
		/// Изменяет текст комментария к товару.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в
		/// параметре owner_id
		/// необходимо указывать со знаком "-" — например, owner_id=-1 соответствует
		/// идентификатору сообщества ВКонтакте API
		/// (club1)  целое число, обязательный параметр (целое число, обязательный
		/// параметр).
		/// </param>
		/// <param name="commentId">
		/// Идентификатор комментария. положительное число, обязательный параметр
		/// (положительное число,
		/// обязательный параметр).
		/// </param>
		/// <param name="message">
		/// Новый текст комментария (является обязательным, если не задан параметр
		/// attachments). Максимальное
		/// количество символов: 2048. строка (строка).
		/// </param>
		/// <param name="attachments">
		/// Новый список объектов, приложенных к комментарию и разделённых символом ",".
		/// (список строк,
		/// разделенных через запятую).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.editComment
		/// </remarks>
		public async Task<bool> EditCommentAsync(long ownerId
												, long commentId
												, string message
												, IEnumerable<MediaAttachment> attachments = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Markets.EditComment(ownerId: ownerId, commentId: commentId, message: message, attachments: attachments));
		}

		/// <summary>
		/// Позволяет оставить жалобу на комментарий к товару.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в
		/// параметре owner_id
		/// необходимо указывать со знаком "-" — например, owner_id=-1 соответствует
		/// идентификатору сообщества ВКонтакте API
		/// (club1)  целое число, обязательный параметр (целое число, обязательный
		/// параметр).
		/// </param>
		/// <param name="commentId">
		/// Идентификатор комментария. положительное число, обязательный параметр
		/// (положительное число,
		/// обязательный параметр).
		/// </param>
		/// <param name="reason">
		/// Причина жалобы (положительное число, обязательный
		/// параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.reportComment
		/// </remarks>
		public async Task<bool> ReportCommentAsync(long ownerId, long commentId, ReportReason reason)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Markets.ReportComment(ownerId: ownerId, commentId: commentId, reason: reason));
		}

		/// <summary>
		/// Позволяет отправить жалобу на товар.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор владельца товаров. Обратите внимание, идентификатор сообщества в
		/// параметре owner_id
		/// необходимо указывать со знаком "-" — например, owner_id=-1 соответствует
		/// идентификатору сообщества ВКонтакте API
		/// (club1)  целое число, обязательный параметр (целое число, обязательный
		/// параметр).
		/// </param>
		/// <param name="itemId">
		/// Идентификатор товара положительное число, обязательный параметр (положительное
		/// число, обязательный
		/// параметр).
		/// </param>
		/// <param name="reason">
		/// Причина жалобы (положительное число, обязательный
		/// параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.report
		/// </remarks>
		public async Task<bool> ReportAsync(long ownerId, long itemId, ReportReason reason)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Markets.Report(ownerId: ownerId, itemId: itemId, reason: reason));
		}

		/// <summary>
		/// Добавляет новый товар.
		/// </summary>
		/// <param name="params"> Входные параметры запроса. </param>
		/// <returns>
		/// После успешного выполнения возвращает идентификатор добавленного товара.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.add
		/// </remarks>
		public async Task<long> AddAsync(MarketProductParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Markets.Add(@params: @params));
		}

		/// <summary>
		/// Редактирует товар.
		/// </summary>
		/// <param name="params"> Входные параметры запроса. </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.edit
		/// </remarks>
		public async Task<bool> EditAsync(MarketProductParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Markets.Edit(@params: @params));
		}

		/// <summary>
		/// Удаляет товар.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в
		/// параметре owner_id
		/// необходимо указывать со знаком "-" — например, owner_id=-1 соответствует
		/// идентификатору сообщества ВКонтакте API
		/// (club1)  целое число, обязательный параметр (целое число, обязательный
		/// параметр).
		/// </param>
		/// <param name="itemId">
		/// Идентификатор товара. положительное число, обязательный параметр (положительное
		/// число,
		/// обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.delete
		/// </remarks>
		public async Task<bool> DeleteAsync(long ownerId, long itemId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Markets.Delete(ownerId: ownerId, itemId: itemId));
		}

		/// <summary>
		/// Восстанавливает удаленный товар.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в
		/// параметре owner_id
		/// необходимо указывать со знаком "-" — например, owner_id=-1 соответствует
		/// идентификатору сообщества ВКонтакте API
		/// (club1)  целое число, обязательный параметр (целое число, обязательный
		/// параметр).
		/// </param>
		/// <param name="itemId">
		/// Идентификатор товара. положительное число, обязательный параметр (положительное
		/// число,
		/// обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1 (0, если товар не найден среди
		/// удаленных).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.restore
		/// </remarks>
		public async Task<bool> RestoreAsync(long ownerId, long itemId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Markets.Restore(ownerId: ownerId, itemId: itemId));
		}

		/// <summary>
		/// Изменяет положение товара в подборке.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в
		/// параметре owner_id
		/// необходимо указывать со знаком "-" — например, owner_id=-1 соответствует
		/// идентификатору сообщества ВКонтакте API
		/// (club1)  целое число, обязательный параметр (целое число, обязательный
		/// параметр).
		/// </param>
		/// <param name="albumId">
		/// Идентификатор подборки, в которой находится товар. целое число, обязательный
		/// параметр (целое
		/// число, обязательный параметр).
		/// </param>
		/// <param name="itemId">
		/// Идентификатор товара. положительное число, обязательный параметр (положительное
		/// число,
		/// обязательный параметр).
		/// </param>
		/// <param name="before">
		/// Идентификатор товара, перед которым следует поместить текущий. положительное
		/// число (положительное
		/// число).
		/// </param>
		/// <param name="after">
		/// Идентификатор товара, после которого следует поместить текущий. положительное
		/// число (положительное
		/// число).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.reorderItems
		/// </remarks>
		public async Task<bool> ReorderItemsAsync(long ownerId, long albumId, long itemId, long? before, long? after)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Markets.ReorderItems(ownerId: ownerId, albumId: albumId, itemId: itemId, before: before, after: after));
		}

		/// <summary>
		/// Изменяет положение подборки с товарами в списке.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор владельца альбома. Обратите внимание, идентификатор сообщества в
		/// параметре owner_id
		/// необходимо указывать со знаком "-" — например, owner_id=-1 соответствует
		/// идентификатору сообщества ВКонтакте API
		/// (club1)  целое число, обязательный параметр (целое число, обязательный
		/// параметр).
		/// </param>
		/// <param name="albumId">
		/// Идентификатор подборки. целое число, обязательный параметр (целое число,
		/// обязательный параметр).
		/// </param>
		/// <param name="before">
		/// Идентификатор подборки, перед которой следует поместить текущую. положительное
		/// число
		/// (положительное число).
		/// </param>
		/// <param name="after">
		/// Идентификатор подборки, после которой следует поместить текущую. положительное
		/// число (положительное
		/// число).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.reorderAlbums
		/// </remarks>
		public async Task<bool> ReorderAlbumsAsync(long ownerId, long albumId, long? before = null, long? after = null)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Markets.ReorderAlbums(ownerId: ownerId, albumId: albumId, before: before, after: after));
		}

		/// <summary>
		/// Добавляет новую подборку с товарами.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор владельца подборки. Обратите внимание, идентификатор сообщества в
		/// параметре
		/// owner_id необходимо указывать со знаком "-" — например, owner_id=-1
		/// соответствует идентификатору сообщества
		/// ВКонтакте API (club1)  целое число, обязательный параметр (целое число,
		/// обязательный параметр).
		/// </param>
		/// <param name="title">
		/// Название подборки. строка, обязательный параметр, максимальная длина 128
		/// (строка, обязательный
		/// параметр, максимальная длина 128).
		/// </param>
		/// <param name="photoId">
		/// Идентификатор фотографии-обложки подборки. положительное число (положительное
		/// число).
		/// </param>
		/// <param name="mainAlbum">
		/// Назначить подборку основной (1 — назначить, 0 — нет). флаг, может принимать
		/// значения 1 или 0
		/// (флаг, может принимать значения 1 или 0).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает идентификатор созданной подборки.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.addAlbum
		/// </remarks>
		public async Task<long> AddAlbumAsync(long ownerId, string title, long? photoId = null, bool mainAlbum = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Markets.AddAlbum(ownerId: ownerId, title: title, photoId: photoId, mainAlbum: mainAlbum));
		}

		/// <summary>
		/// Редактирует подборку с товарами.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор владельца подборки. Обратите внимание, идентификатор сообщества в
		/// параметре
		/// owner_id необходимо указывать со знаком "-" — например, owner_id=-1
		/// соответствует идентификатору сообщества
		/// ВКонтакте API (club1)  целое число, обязательный параметр (целое число,
		/// обязательный параметр).
		/// </param>
		/// <param name="albumId">
		/// Идентификатор подборки. положительное число, обязательный параметр
		/// (положительное число,
		/// обязательный параметр).
		/// </param>
		/// <param name="title">
		/// Название подборки. строка, обязательный параметр, максимальная длина 128
		/// (строка, обязательный
		/// параметр, максимальная длина 128).
		/// </param>
		/// <param name="photoId">
		/// Идентификатор фотографии-обложки подборки. положительное число (положительное
		/// число).
		/// </param>
		/// <param name="mainAlbum"> Назначить подборку основной (1 — назначить, 0 — нет). </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.editAlbum
		/// </remarks>
		public async Task<bool> EditAlbumAsync(long ownerId, long albumId, string title, long? photoId = null, bool mainAlbum = false)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Markets.EditAlbum(ownerId: ownerId, albumId: albumId, title: title, photoId: photoId, mainAlbum: mainAlbum));
		}

		/// <summary>
		/// Удаляет подборку с товарами.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор владельца подборки. Обратите внимание, идентификатор сообщества в
		/// параметре
		/// owner_id необходимо указывать со знаком "-" — например, owner_id=-1
		/// соответствует идентификатору сообщества
		/// ВКонтакте API (club1)  целое число, обязательный параметр (целое число,
		/// обязательный параметр).
		/// </param>
		/// <param name="albumId">
		/// Идентификатор подборки. положительное число, обязательный параметр
		/// (положительное число,
		/// обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.deleteAlbum
		/// </remarks>
		public async Task<bool> DeleteAlbumAsync(long ownerId, long albumId)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Markets.DeleteAlbum(ownerId: ownerId, albumId: albumId));
		}

		/// <summary>
		/// Удаляет товар из одной или нескольких выбранных подборок.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в
		/// параметре owner_id
		/// необходимо указывать со знаком "-" — например, owner_id=-1 соответствует
		/// идентификатору сообщества ВКонтакте API
		/// (club1)  целое число, обязательный параметр (целое число, обязательный
		/// параметр).
		/// </param>
		/// <param name="itemId">
		/// Идентификатор товара. положительное число, обязательный параметр (положительное
		/// число,
		/// обязательный параметр).
		/// </param>
		/// <param name="albumIds">
		/// Идентификаторы подборок, из которых нужно удалить товар. список положительных
		/// чисел, разделенных
		/// запятыми, обязательный параметр (список положительных чисел, разделенных
		/// запятыми, обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.removeFromAlbum
		/// </remarks>
		public async Task<bool> RemoveFromAlbumAsync(long ownerId, long itemId, IEnumerable<long> albumIds)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Markets.RemoveFromAlbum(ownerId: ownerId, itemId: itemId, albumIds: albumIds));
		}

		/// <summary>
		/// Добавляет товар в одну или несколько выбранных подборок.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор владельца товара. Обратите внимание, идентификатор сообщества в
		/// параметре owner_id
		/// необходимо указывать со знаком "-" — например, owner_id=-1 соответствует
		/// идентификатору сообщества ВКонтакте API
		/// (club1)  целое число, обязательный параметр (целое число, обязательный
		/// параметр).
		/// </param>
		/// <param name="itemId">
		/// Идентификатор товара. положительное число, обязательный параметр (положительное
		/// число,
		/// обязательный параметр).
		/// </param>
		/// <param name="albumIds">
		/// Идентификаторы подборок, в которые нужно добавить товар. список положительных
		/// чисел, разделенных
		/// запятыми, обязательный параметр (список положительных чисел, разделенных
		/// запятыми, обязательный параметр).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает 1.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.addToAlbum
		/// </remarks>
		public async Task<bool> AddToAlbumAsync(long ownerId, long itemId, IEnumerable<long> albumIds)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () =>
					_vk.Markets.AddToAlbum(ownerId: ownerId, itemId: itemId, albumIds: albumIds));
		}

		/// <summary>
		/// Возвращает список категорий для товаров..
		/// </summary>
		/// <param name="count">
		/// Количество категорий, информацию о которых необходимо вернуть. положительное
		/// число, максимальное
		/// значение 1000, по умолчанию 10 (Положительное число, максимальное значение
		/// 1000, по умолчанию 10).
		/// </param>
		/// <param name="offset">
		/// Смещение, необходимое для выборки определенного подмножества категорий.
		/// положительное число
		/// (Положительное число).
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов category.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/market.getCategories
		/// </remarks>
		public async Task<VkCollection<MarketCategory>> GetCategoriesAsync(long? count, long? offset)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.Markets.GetCategories(count: count, offset: offset));
		}
	}
}