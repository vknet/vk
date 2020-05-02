using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class PrettyCardsCategory
	{
		/// <inheritdoc />
		public Task<PrettyCardsCreateResult> CreateAsync(PrettyCardsCreateParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Create(@params: @params));
		}

		/// <inheritdoc />
		public Task<PrettyCardsDeleteResult> DeleteAsync(PrettyCardsDeleteParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Delete(@params: @params));
		}

		/// <inheritdoc />
		public Task<PrettyCardsEditResult> EditAsync(PrettyCardsEditParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Edit(@params: @params));
		}

		/// <inheritdoc />
		public Task<VkCollection<PrettyCardsGetByIdResult>> GetAsync(PrettyCardsGetParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Get(@params: @params));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<PrettyCardsGetByIdResult>> GetByIdAsync(PrettyCardsGetByIdParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetById(@params: @params));
		}

		/// <inheritdoc />
		public Task<Uri> GetUploadUrlAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(func: GetUploadUrl);
		}
	}
}