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
		public Task<object> DeleteAsync(object @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Delete(@params: @params));
		}

		/// <inheritdoc />
		public Task<object> EditAsync(object @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Edit(@params: @params));
		}

		/// <inheritdoc />
		public Task<object> GetAsync(object @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Get(@params: @params));
		}

		/// <inheritdoc />
		public Task<object> GetByIdAsync(object @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetById(@params: @params));
		}

		/// <inheritdoc />
		public Task<object> GetUploadUrlAsync(object @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetUploadUrl(@params: @params));
		}
	}
}