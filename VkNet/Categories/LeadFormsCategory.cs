using System;
using System.Collections.ObjectModel;
using VkNet.Abstractions;
using VkNet.Abstractions.Category;
using VkNet.Model;
using VkNet.Model.LeadForms;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc/>
	public partial class LeadFormsCategory : ILeadFormsCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// api vk.com
		/// </summary>
		/// <param name = "vk">
		/// Api vk.com
		/// </param>
		public LeadFormsCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc/>
		public LeadFormCreateResult Create(LeadFormsCreateParams createParams)
		{
			return _vk.Call<LeadFormCreateResult>("leadForms.create",
				new VkParameters
				{
					{ "group_id", createParams.GroupId },
					{ "name", createParams.Name },
					{ "title", createParams.Title },
					{ "description", createParams.Description },
					{ "questions", createParams.Questions },
					{ "policy_link_url", createParams.PolicyLinkUrl },
					{ "photo", createParams.Photo },
					{ "confirmation", createParams.Confirmation },
					{ "site_link_url", createParams.SiteLinkUrl },
					{ "pixel_code", createParams.PixelCode },
					{ "notify_emails", createParams.NotifyEmails },
					{ "active", createParams.Active },
					{ "once_per_user", createParams.OncePerUser },
					{ "notify_admins", createParams.NotifyAdmins }
				});
		}

		/// <inheritdoc/>
		public LeadFormCreateResult Delete(long groupId, long formId)
		{
			return _vk.Call<LeadFormCreateResult>("leadForms.delete",
				new VkParameters
				{
					{ "group_id", groupId },
					{ "form_id", formId }
				});
		}

		/// <inheritdoc/>
		public LeadFormCreateResult Get(long groupId, long formId)
		{
			return _vk.Call<LeadFormCreateResult>("leadForms.get",
				new VkParameters
				{
					{ "group_id", groupId },
					{ "form_id", formId }
				});
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<LeadFormsGetLeadResult> GetLeads(long groupId, long formId, string nextPageToken, ulong? limit = null)
		{
			return _vk.Call<ReadOnlyCollection<LeadFormsGetLeadResult>>("leadForms.getLeads",
				new VkParameters
				{
					{ "group_id", groupId },
					{ "form_id", formId },
					{ "next_page_token", nextPageToken },
					{ "limit", limit }
				});
		}

		/// <inheritdoc/>
		public Uri GetUploadURL()
		{
			return _vk.Call<Uri>("leadForms.getUploadURL", VkParameters.Empty);
		}

		/// <inheritdoc/>
		public ReadOnlyCollection<LeadFormCreateResult> List(long groupId)
		{
			return _vk.Call<ReadOnlyCollection<LeadFormCreateResult>>("leadForms.list",
				new VkParameters
				{
					{ "group_id", groupId }
				});
		}

		/// <inheritdoc/>
		public LeadFormCreateResult Update(LeadFormsUpdateParams updateParams)
		{
			return _vk.Call<LeadFormCreateResult>("leadForms.update",
				new VkParameters
				{
					{ "group_id", updateParams.GroupId },
					{ "form_id", updateParams.FormId },
					{ "name", updateParams.Name },
					{ "title", updateParams.Title },
					{ "description", updateParams.Description },
					{ "questions", updateParams.Questions },
					{ "policy_link_url", updateParams.PolicyLinkUrl },
					{ "photo", updateParams.Photo },
					{ "confirmation", updateParams.Confirmation },
					{ "site_link_url", updateParams.SiteLinkUrl },
					{ "pixel_code", updateParams.PixelCode },
					{ "notify_emails", updateParams.NotifyEmails },
					{ "active", updateParams.Active },
					{ "once_per_user", updateParams.OncePerUser },
					{ "notify_admins", updateParams.NotifyAdmins }
				});
		}
	}
}