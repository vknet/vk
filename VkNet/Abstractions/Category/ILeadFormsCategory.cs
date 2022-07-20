using System;
using System.Collections.ObjectModel;
using VkNet.Abstractions.Category.Async;
using VkNet.Model;
using VkNet.Model.LeadForms;

namespace VkNet.Abstractions.Category
{
	/// <inheritdoc cref="ILeadFormsCategoryAsync" />
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
}