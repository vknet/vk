using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions.Category;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="ILeadFormsCategory" />
public partial class LeadFormsCategory
{
	/// <inheritdoc/>
	public Task<LeadFormCreateResult> CreateAsync(LeadFormsCreateParams createParams,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Create(createParams), token);

	/// <inheritdoc/>
	public Task<LeadFormCreateResult> DeleteAsync(long groupId,
												long formId,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Delete(groupId, formId), token);

	/// <inheritdoc/>
	public Task<LeadFormCreateResult> GetAsync(long groupId,
												long formId,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(groupId, formId), token);

	/// <inheritdoc/>
	public Task<ReadOnlyCollection<LeadFormsGetLeadResult>>
		GetLeadsAsync(long groupId,
					long formId,
					string nextPageToken,
					ulong? limit = null,
					CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetLeads(groupId, formId, nextPageToken, limit), token);

	/// <inheritdoc/>
	public Task<Uri> GetUploadURLAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(GetUploadURL, token);


	/// <inheritdoc/>
	public Task<ReadOnlyCollection<LeadFormCreateResult>> ListAsync(long groupId,
																	CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			List(groupId), token);

	/// <inheritdoc/>
	public Task<LeadFormCreateResult> UpdateAsync(LeadFormsUpdateParams updateParams,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Update(updateParams), token);
}