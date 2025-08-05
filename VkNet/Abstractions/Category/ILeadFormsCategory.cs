using System;
using System.Collections.ObjectModel;
using VkNet.Abstractions.Category.Async;
using VkNet.Model;

namespace VkNet.Abstractions.Category;

/// <summary>
/// Формы сбора заявок Подойдут для записи клиентов, предварительной регистрации, подписки на рассылки, запросов информации, подключения услуг, оформления заказов и многого другого. Вы создаете формы с заявками, а пользователи оставляют свою контактную информацию. Вам остается завершить оформление заявки, связавшись с ними удобным способом.
/// </summary>
public interface ILeadFormsCategory : ILeadFormsCategoryAsync
{
	/// <inheritdoc cref="ILeadFormsCategoryAsync.CreateAsync" />
	LeadFormCreateResult Create(LeadFormsCreateParams createParams);

	/// <inheritdoc cref="ILeadFormsCategoryAsync.DeleteAsync" />
	LeadFormCreateResult Delete(long groupId, long formId);

	/// <inheritdoc cref="ILeadFormsCategoryAsync.GetAsync" />
	LeadFormCreateResult Get(long groupId, long formId);

	/// <inheritdoc cref="ILeadFormsCategoryAsync.GetLeadsAsync" />
	ReadOnlyCollection<LeadFormsGetLeadResult> GetLeads(long groupId, long formId, string nextPageToken, ulong? limit = null);

	/// <inheritdoc cref="ILeadFormsCategoryAsync.GetUploadURLAsync" />
	Uri GetUploadURL();

	/// <inheritdoc cref="ILeadFormsCategoryAsync.ListAsync" />
	ReadOnlyCollection<LeadFormCreateResult> List(long groupId);

	/// <inheritdoc cref="ILeadFormsCategoryAsync.UpdateAsync" />
	LeadFormCreateResult Update(LeadFormsUpdateParams updateParams);
}