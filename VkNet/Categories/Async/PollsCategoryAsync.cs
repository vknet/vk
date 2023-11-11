using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IPollsCategory" />
public partial class PollsCategory
{
	/// <inheritdoc />
	public Task<Poll> GetByIdAsync(PollsGetByIdParams @params,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetById(@params), token);

	/// <inheritdoc />
	public Task<bool> EditAsync(PollsEditParams @params,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Edit(@params), token);

	/// <inheritdoc />
	public Task<bool> AddVoteAsync(PollsAddVoteParams @params,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddVote(@params), token);

	/// <inheritdoc />
	public Task<bool> DeleteVoteAsync(PollsDeleteVoteParams @params,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteVote(@params), token);

	/// <inheritdoc />
	public Task<VkCollection<PollAnswerVoters>> GetVotersAsync(PollsGetVotersParams @params,
																CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetVoters(@params), token);

	/// <inheritdoc />
	public Task<Poll> CreateAsync(PollsCreateParams @params,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Create(@params), token);

	/// <inheritdoc />
	public Task<ReadOnlyCollection<GetBackgroundsResult>> GetBackgroundsAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(GetBackgrounds, token);

	/// <inheritdoc />
	public Task<UploadServer> GetPhotoUploadServerAsync(long ownerId,
														CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetPhotoUploadServer(ownerId), token);

	/// <inheritdoc />
	public Task<SavePhotoResult> SavePhotoAsync(SavePhotoParams @params,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SavePhoto(@params), token);
}