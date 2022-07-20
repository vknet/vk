using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.LeadForms;

namespace VkNet.Abstractions.Category.Async
{
	/// <summary>
	/// Формы сбора заявок  Подойдут для записи клиентов, предварительной регистрации, подписки на рассылки, запросов информации, подключения услуг, оформления заказов и многого другого.
	/// Вы создаете формы с заявками, а пользователи оставляют свою контактную информацию. Вам остается завершить оформление заявки, связавшись с ними удобным способом.
	/// </summary>
	public interface ILeadFormsCategoryAsync
	{
		/// <summary>
		/// Создаёт форму сбора заявок.
		/// </summary>
		/// <param name = "createParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// Возвращается структура с информацией о созданной форме:
		/// form_id — идентификатор формы;
		/// url — ссылка на форму.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/leadForms.create
		/// </remarks>
		Task<LeadFormCreateResult> CreateAsync(LeadFormsCreateParams createParams);

		/// <summary>
		/// Удаляет форму сбора заявок.
		/// </summary>
		/// <param name = "groupId">
		/// Идентификатор группы, из которой надо удалить форму. обязательный параметр, целое число
		/// </param>
		/// <param name = "formId">
		/// Идентификатор удаляемой формы. обязательный параметр, целое число
		/// </param>
		/// <returns>
		/// Возвращает идентификатор удалённой формы
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/leadForms.delete
		/// </remarks>
		Task<LeadFormCreateResult> DeleteAsync(long groupId, long formId);

		/// <summary>
		/// Возвращает информацию о форме сбора заявок.
		/// </summary>
		/// <param name = "groupId">
		/// Идентификатор группы, в которой находится форма. обязательный параметр, целое число
		/// </param>
		/// <param name = "formId">
		/// Идентификатор формы. обязательный параметр, целое число
		/// </param>
		/// <returns>
		/// Возвращает структуру с информацией о форме. Значения полей см. в методе leadForms.create.
		/// Дополнительно возвращает следующие поля:
		/// form_id — идентификатор формы;
		/// leads_count — количество заявок;
		/// url — ссылка на форму.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/leadForms.get
		/// </remarks>
		Task<LeadFormCreateResult> GetAsync(long groupId, long formId);

		/// <summary>
		/// Возвращает заявки формы.
		/// </summary>
		/// <param name = "groupId">
		/// Идентификатор сообщества, в котором находится форма. обязательный параметр, целое число
		/// </param>
		/// <param name = "formId">
		/// Идентификатор формы. обязательный параметр, целое число
		/// </param>
		/// <param name = "nextPageToken">
		/// Строка, полученная из предыдущего запроса для получения следующей порции результатов. строка
		/// </param>
		/// <param name = "limit">
		/// Количество возвращаемых заявок за один запрос. положительное число, по умолчанию 10, максимальное значение 1000, минимальное значение 1
		/// </param>
		/// <returns>
		/// Возвращает массив структур со следующими полями:
		/// lead_id — идентификатор заявки;
		/// user_id — идентификатор пользователя, оставившего заявку;
		/// date — дата и время оставления заявки в формате unix timestamp;
		/// answers — информация об ответах на вопросы — массив структур со следующими полями:
		/// key — ключ вопроса. Совпадает с типом стандартного вопроса (его полем type), или с ключом нестандартного вопроса (поле key). Для нестандартных вопросов, для которых не был задан ключ, будет использовано значение вида custom_0, где «0» — порядковый номер нестандартного вопроса, считая с 0.
		/// answer — ответ на вопрос. Структура (для всех вопросов, кроме типа checkbox) или массив структур (для типа checkbox) со следующими полями:
		/// key — ключ ответа (в случае, если был задан при создании формы);
		/// value — текст ответа;
		/// ad_id — идентификатор рекламного объявления, с которого пришла заявка (поле отсутствует в случае, если заявка пришла не из рекламного объявления).
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/leadForms.getLeads
		/// </remarks>
		Task<ReadOnlyCollection<LeadFormsGetLeadResult>> GetLeadsAsync(long groupId, long formId, string nextPageToken, ulong? limit = null);

		/// <summary>
		/// Возвращает URL для загрузки обложки для формы.
		/// </summary>
		/// <returns>
		/// Возвращает URL для загрузки обложки для формы.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/leadForms.getUploadURl
		/// </remarks>
		Task<Uri> GetUploadURLAsync();

		/// <summary>
		/// Возвращает список форм сообщества.
		/// </summary>
		/// <param name = "groupId">
		/// Идентификатор сообщества. обязательный параметр, целое число
		/// </param>
		/// <returns>
		/// Возвращает массив структур с описанием форм. Подробнее о структуре описания формы см. метод leadForms.get.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/leadForms.list
		/// </remarks>
		Task<ReadOnlyCollection<LeadFormCreateResult>> ListAsync(long groupId);

		/// <summary>
		/// Обновляет форму сбора заявок.
		/// </summary>
		/// <param name = "updateParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// Возвращается структура с информацией об обновлённой форме:
		/// form_id — идентификатор формы;
		/// url — ссылка на форму.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/leadForms.update
		/// </remarks>
		Task<LeadFormCreateResult> UpdateAsync(LeadFormsUpdateParams updateParams);
	}
}