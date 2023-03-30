using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Threading;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Model.RequestParams.Polls;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class PollsCategory
{
	/// <inheritdoc />
	public Task<Poll> GetByIdAsync(PollsGetByIdParams @params,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetById(@params));

	/// <inheritdoc />
	public Task<bool> EditAsync(PollsEditParams @params,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Edit(@params));

	/// <inheritdoc />
	public Task<bool> AddVoteAsync(PollsAddVoteParams @params,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			AddVote(@params));

	/// <inheritdoc />
	public Task<bool> DeleteVoteAsync(PollsDeleteVoteParams @params,
									CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			DeleteVote(@params));

	/// <inheritdoc />
	public Task<VkCollection<PollAnswerVoters>> GetVotersAsync(PollsGetVotersParams @params,
																CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetVoters(@params));

	/// <inheritdoc />
	public Task<Poll> CreateAsync(PollsCreateParams @params,
								CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Create(@params));

	/// <inheritdoc />
	public Task<ReadOnlyCollection<GetBackgroundsResult>> GetBackgroundsAsync(CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(GetBackgrounds);

	/// <inheritdoc />
	public Task<UploadServer> GetPhotoUploadServerAsync(long ownerId,
														CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			GetPhotoUploadServer(ownerId));

	/// <inheritdoc />
	public Task<SavePhotoResult> SavePhotoAsync(SavePhotoParams @params,
												CancellationToken token) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			SavePhoto(@params));
}