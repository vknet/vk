namespace VkNet.Categories
{
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using JetBrains.Annotations;
	using Newtonsoft.Json.Linq;
	using Enums;
	using Utils;
	using Model.Attachments;
	using Model;

	/// <summary>
	/// Методы для работы с документами (получение списка, загрузка, удаление и т.д.)
	/// </summary>
	public partial class DocsCategory
	{
		/// <summary>
		/// API
		/// </summary>
		private readonly VkApi _vk;

		/// <summary>
		/// Методы для работы с документами (получение списка, загрузка, удаление и т.д.).
		/// </summary>
		/// <param name="vk">API.</param>
		public DocsCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <summary>
		/// Возвращает расширенную информацию о документах пользователя или сообщества.
		/// </summary>
		/// <param name="count">Количество документов, информацию о которых нужно вернуть. По умолчанию — все документы.</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества документов. Положительное число.</param>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежат документы. Целое число, по умолчанию идентификатор текущего пользователя.</param>
		/// <param name="filter">Фильтр по типу документа.</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов документов.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/docs.get" />.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public VkCollection<Document> Get(int? count = null, int? offset = null, long? ownerId = null, DocFilter? filter = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => count);
			VkErrors.ThrowIfNumberIsNegative(() => offset);

			var parameters = new VkParameters
			{
				{ "count", count },
				{ "offset", offset },
				{ "owner_id", ownerId },
				{ "type", filter }
			};

			return _vk.Call("docs.get", parameters).ToVkCollectionOf<Document>(r => r);
		}

		/// <summary>
		/// Возвращает информацию о документах по их идентификаторам.
		/// </summary>
		/// <param name="docs">Идентификаторы документов, информацию о которых нужно вернуть.</param>
		/// <returns>После успешного выполнения возвращает список объектов документов.</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/docs.getById"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public ReadOnlyCollection<Document> GetById(IEnumerable<Document> docs)
		{
			foreach (var doc in docs)
			{
				VkErrors.ThrowIfNumberIsNegative(() => doc.Id);
				VkErrors.ThrowIfNumberIsNegative(() => doc.OwnerId);
			}

			var parameters = new VkParameters
			{
				{ "docs", string.Concat(docs.Select(it => it.OwnerId + "_" + it.Id + ",")) }
			};

			var response = _vk.Call("docs.getById", parameters);
			return response.ToReadOnlyCollectionOf<Document>(r => r);
		}

		/// <summary>
		/// Возвращает адрес сервера для загрузки документов.
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества (если необходимо загрузить документ в список документов сообщества). Если документ нужно загрузить в список пользователя, метод вызывается без дополнительных параметров. Положительное число</param>
		/// <returns>После успешного выполнения возвращает объект <see cref="UploadServerInfo"/></returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/docs.getUploadServer"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public UploadServerInfo GetUploadServer(long? groupId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);

			var parameters = new VkParameters
			{
				{ "group_id", groupId }
			};

			return _vk.Call("docs.getUploadServer", parameters);
		}

		/// <summary>
		/// Возвращает адрес сервера для загрузки документов в папку Отправленные, для последующей отправки документа на стену или личным сообщением.
		/// </summary>
		/// <param name="groupId">Идентификатор сообщества, в которое нужно загрузить документ. Положительное число.</param>
		/// <returns>После успешного выполнения возвращает объект <see cref="UploadServerInfo"/></returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/docs.getWallUploadServer"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public UploadServerInfo GetWallUploadServer(long? groupId = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => groupId);

			var parameters = new VkParameters { { "group_id", groupId } };

			return _vk.Call("docs.getWallUploadServer", parameters);
		}

		/// <summary>
		/// Сохраняет документ после его успешной загрузки на сервер.
		/// </summary>
		/// <param name="file">Параметр, возвращаемый в результате загрузки файла на сервер. Обязательный параметр.</param>
		/// <param name="title">Название документа.</param>
		/// <param name="tags">Метки для поиска.</param>
		/// <param name="captchaSid">Id капчи (только если для вызова метода необходимо ввести капчу)</param>
		/// <param name="captchaKey">Текст капчи (только если для вызова метода необходимо ввести капчу)</param>
		/// <returns>Возвращает массив с загруженными объектами. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/docs.save"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public ReadOnlyCollection<Document> Save(string file, string title, string tags = null, long? captchaSid = null, string captchaKey = null)
		{
			VkErrors.ThrowIfNullOrEmpty(() => file);
			VkErrors.ThrowIfNullOrEmpty(() => title);
			var responseJson = JObject.Parse(file);
			file = responseJson["file"].ToString();
			var parameters = new VkParameters
			{
				{ "file", file },
				{ "title", title },
				{ "tags", tags },
				{ "captcha_sid", captchaSid },
				{ "captcha_key", captchaKey }
			};

			var response = _vk.Call("docs.save", parameters);
			return response.ToReadOnlyCollectionOf<Document>(r => r);
		}

		/// <summary>
		/// Удаляет документ пользователя или группы.
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит документ. Целое число, обязательный параметр</param>
		/// <param name="docId">Идентификатор документа. Положительное число, обязательный параметр</param>
		/// <returns>После успешного выполнения возвращает 1. </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/docs.delete"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public bool Delete(long ownerId, long docId)
		{
			VkErrors.ThrowIfNumberIsNegative(() => ownerId);
			VkErrors.ThrowIfNumberIsNegative(() => docId);

			var parameters = new VkParameters
			{
				{ "owner_id", ownerId },
				{ "doc_id", docId }
			};
			return _vk.Call("docs.delete", parameters);
		}

		/// <summary>
		/// Копирует документ в документы текущего пользователя.
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит документ. Целое число, обязательный параметр</param>
		/// <param name="docId">Идентификатор документа. Положительное число, обязательный параметр</param>
		/// <param name="accessKey">Ключ доступа документа. Этот параметр следует передать, если вместе с остальными данными о документе было возвращено поле access_key.</param>
		/// <returns>После успешного выполнения возвращает идентификатор созданного документа (did).</returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/docs.add"/>.
		/// </remarks>
		[Pure]
		[ApiVersion("5.44")]
		public long Add(long ownerId, long docId, string accessKey = null)
		{
			VkErrors.ThrowIfNumberIsNegative(() => ownerId);
			VkErrors.ThrowIfNumberIsNegative(() => docId);

			var parameters = new VkParameters { { "owner_id", ownerId }, { "doc_id", docId }, { "access_key", accessKey } };

			return _vk.Call("docs.add", parameters);
		}

		/// <summary>
		/// Возвращает доступные типы документы для пользователя.
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежат документы. целое число, по умолчанию идентификатор текущего пользователя, обязательный параметр (Целое число, по умолчанию идентификатор текущего пользователя, обязательный параметр).</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов type.
		/// Объект type — тип документов.
		/// id идентификатор типа.
		/// положительное число name название типа.
		/// строка count число документов;
		/// int (числовое значение).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/docs.getTypes" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public VkCollection<DocumentType> GetTypes(long ownerId)
		{
			var parameters = new VkParameters {
				{ "owner_id", ownerId }
			};

			return _vk.Call("docs.getTypes", parameters).ToVkCollectionOf<DocumentType>(x => x);
		}

		/// <summary>
		/// Возвращает результаты поиска по документам.
		/// </summary>
		/// <param name="query">Строка поискового запроса. Например, зеленые тапочки. строка, обязательный параметр, максимальная длина 512 (Строка, обязательный параметр, максимальная длина 512).</param>
		/// <param name="count">Количество документов, информацию о которых нужно вернуть. положительное число (Положительное число).</param>
		/// <param name="offset">Смещение, необходимое для выборки определенного подмножества документов. положительное число (Положительное число).</param>
		/// <returns>
		/// После успешного выполнения возвращает список объектов документов.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/docs.search" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public VkCollection<Document> Search(string query, long? count = null, long? offset = null)
		{
			var parameters = new VkParameters {
				{ "q", query },
				{ "count", count },
				{ "offset", offset }
			};

			return _vk.Call("docs.search", parameters).ToVkCollectionOf<Document>(x => x);
		}

		/// <summary>
		/// Редактирует документ пользователя или группы.
		/// </summary>
		/// <param name="ownerId">Идентификатор пользователя или сообщества, которому принадлежит документ.
		/// Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя, обязательный параметр (Целое число, по умолчанию идентификатор текущего пользователя, обязательный параметр).</param>
		/// <param name="docId">Идентификатор документа. положительное число, обязательный параметр (Положительное число, обязательный параметр).</param>
		/// <param name="title">Название документа. строка, максимальная длина 128 (Строка, максимальная длина 128).</param>
		/// <param name="tags">Метки для поиска. список слов, разделенных через запятую (Список слов, разделенных через запятую).</param>
		/// <returns>
		/// После успешного выполнения возвращает <c>true</c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте <see href="http://vk.com/dev/docs.edit" />.
		/// </remarks>
		[ApiVersion("5.44")]
		public bool Edit(long ownerId, long docId, string title, IEnumerable<string> tags)
		{
			var parameters = new VkParameters {
				{ "owner_id", ownerId },
				{ "doc_id", docId },
				{ "title", title },
				{ "tags", tags }
			};

			return _vk.Call("docs.edit", parameters);
		}
	}
}