using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IPrettyCardsCategory" />
public partial class PrettyCardsCategory
{
	/// <inheritdoc />
	public Task<PrettyCardsCreateResult> CreateAsync(PrettyCardsCreateParams @params,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Create(@params), token);

	/// <inheritdoc />
	public Task<PrettyCardsDeleteResult> DeleteAsync(PrettyCardsDeleteParams @params,
													CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Delete(@params), token);

	/// <inheritdoc />
	public Task<PrettyCardsEditResult> EditAsync(PrettyCardsEditParams @params,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Edit(@params), token);

	/// <inheritdoc />
	public Task<VkCollection<PrettyCardsGetByIdResult>> GetAsync(PrettyCardsGetParams @params,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Get(@params), token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<PrettyCardsGetByIdResult>> GetByIdAsync(PrettyCardsGetByIdParams @params,
																			CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetById(@params), token);

	/// <inheritdoc />
	public Task<Uri> GetUploadUrlAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(GetUploadUrl, token);
}