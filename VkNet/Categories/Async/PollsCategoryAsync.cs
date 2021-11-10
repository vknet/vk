using System.Threading.Tasks;
using System.Collections.ObjectModel;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Model.RequestParams.Polls;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class PollsCategory
	{
		/// <inheritdoc />
		public Task<Poll> GetByIdAsync(PollsGetByIdParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetById(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> EditAsync(PollsEditParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Edit(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> AddVoteAsync(PollsAddVoteParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => AddVote(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> DeleteVoteAsync(PollsDeleteVoteParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => DeleteVote(@params: @params));
		}

		/// <inheritdoc />
		public Task<VkCollection<PollAnswerVoters>> GetVotersAsync(PollsGetVotersParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetVoters(@params: @params));
		}

		/// <inheritdoc />
		public Task<Poll> CreateAsync(PollsCreateParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => Create(@params: @params));
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<GetBackgroundsResult>> GetBackgroundsAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetBackgrounds());
		}

		/// <inheritdoc />
		public Task<PhotoUploadServer> GetPhotoUploadServerAsync(long ownerId)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetPhotoUploadServer(ownerId));
		}

		/// <inheritdoc />
		public Task<SavePhotoResult> SavePhotoAsync(SavePhotoParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => SavePhoto(@params: @params));
		}
	}
}