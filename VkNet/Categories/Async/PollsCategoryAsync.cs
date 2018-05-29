using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class PollsCategory
	{
		/// <inheritdoc />
		public async Task<Poll> GetByIdAsync(PollsGetByIdParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.PollsCategory.GetById(@params: @params));
		}

		/// <inheritdoc />
		public async Task<bool> EditAsync(PollsEditParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.PollsCategory.Edit(@params: @params));
		}

		/// <inheritdoc />
		public async Task<bool> AddVoteAsync(PollsAddVoteParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.PollsCategory.AddVote(@params: @params));
		}

		/// <inheritdoc />
		public async Task<bool> DeleteVoteAsync(PollsDeleteVoteParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.PollsCategory.DeleteVote(@params: @params));
		}

		/// <inheritdoc />
		public async Task<VkCollection<PollAnswerVoters>> GetVotersAsync(PollsGetVotersParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.PollsCategory.GetVoters(@params: @params));
		}

		/// <inheritdoc />
		public async Task<Poll> CreateAsync(PollsCreateParams @params)
		{
			return await TypeHelper.TryInvokeMethodAsync(func: () => _vk.PollsCategory.Create(@params: @params));
		}
	}
}