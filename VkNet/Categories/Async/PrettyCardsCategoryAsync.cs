using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class PrettyCardsCategory
{
	/// <inheritdoc />
	public Task<PrettyCardsCreateResult> CreateAsync(PrettyCardsCreateParams @params,
													CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Create(@params));

	/// <inheritdoc />
	public Task<PrettyCardsDeleteResult> DeleteAsync(PrettyCardsDeleteParams @params,
													CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Delete(@params));

	/// <inheritdoc />
	public Task<PrettyCardsEditResult> EditAsync(PrettyCardsEditParams @params,
												CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Edit(@params));

	/// <inheritdoc />
	public Task<VkCollection<PrettyCardsGetByIdResult>> GetAsync(PrettyCardsGetParams @params,
																CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(@params));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<PrettyCardsGetByIdResult>> GetByIdAsync(PrettyCardsGetByIdParams @params,
																			CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetById(@params));

	/// <inheritdoc />
	public Task<Uri> GetUploadUrlAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(GetUploadUrl);
}