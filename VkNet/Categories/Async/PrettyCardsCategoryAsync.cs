using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class PrettyCardsCategory
{
	/// <inheritdoc />
	public Task<PrettyCardsCreateResult> CreateAsync(PrettyCardsCreateParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Create(@params: @params));

	/// <inheritdoc />
	public Task<PrettyCardsDeleteResult> DeleteAsync(PrettyCardsDeleteParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Delete(@params: @params));

	/// <inheritdoc />
	public Task<PrettyCardsEditResult> EditAsync(PrettyCardsEditParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Edit(@params: @params));

	/// <inheritdoc />
	public Task<VkCollection<PrettyCardsGetByIdResult>> GetAsync(PrettyCardsGetParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => Get(@params: @params));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<PrettyCardsGetByIdResult>> GetByIdAsync(PrettyCardsGetByIdParams @params) =>
		TypeHelper.TryInvokeMethodAsync(func: () => GetById(@params: @params));

	/// <inheritdoc />
	public Task<Uri> GetUploadUrlAsync() => TypeHelper.TryInvokeMethodAsync(func: GetUploadUrl);
}