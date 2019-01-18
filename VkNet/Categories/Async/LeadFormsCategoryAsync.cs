using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.LeadForms;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
	public partial class LeadFormsCategory
	{
		/// <inheritdoc/>
		public Task<LeadFormCreateResult> CreateAsync(LeadFormsCreateParams createParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Create(createParams));
		}

		/// <inheritdoc/>
		public Task<long> DeleteAsync(long groupId, long formId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Delete(groupId, formId));
		}

		/// <inheritdoc/>
		public Task<Uri> GetAsync(long groupId, long formId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Get(groupId, formId));
		}

		/// <inheritdoc/>
		public Task<IEnumerable<object>> GetLeadsAsync(long groupId, long formId, string nextPageToken, ulong? limit = null)
		{
			return TypeHelper.TryInvokeMethodAsync(() => GetLeads(groupId, formId, nextPageToken, limit));
		}

		/// <inheritdoc/>
		public Task<Uri> GetUploadURLAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(GetUploadURL);
		}

		/// <inheritdoc/>
		public Task<IEnumerable<object>> ListAsync(long groupId)
		{
			return TypeHelper.TryInvokeMethodAsync(() => List(groupId));
		}

		/// <inheritdoc/>
		public Task<Uri> UpdateAsync(LeadFormsUpdateParams updateParams)
		{
			return TypeHelper.TryInvokeMethodAsync(() => Update(updateParams));
		}
	}
}