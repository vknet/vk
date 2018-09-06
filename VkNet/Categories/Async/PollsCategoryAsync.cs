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
		public Task<Poll> GetByIdAsync(PollsGetByIdParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetById(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> EditAsync(PollsEditParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Edit(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> AddVoteAsync(PollsAddVoteParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>AddVote(@params: @params));
		}

		/// <inheritdoc />
		public Task<bool> DeleteVoteAsync(PollsDeleteVoteParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>DeleteVote(@params: @params));
		}

		/// <inheritdoc />
		public Task<VkCollection<PollAnswerVoters>> GetVotersAsync(PollsGetVotersParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>GetVoters(@params: @params));
		}

		/// <inheritdoc />
		public Task<Poll> CreateAsync(PollsCreateParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Create(@params: @params));
		}
	}
}