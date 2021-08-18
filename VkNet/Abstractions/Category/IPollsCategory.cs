using System.Collections.ObjectModel;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;
using VkNet.Model.RequestParams.Polls;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IPollsCategoryAsync"/>
	public interface IPollsCategory : IPollsCategoryAsync
	{
		/// <inheritdoc cref="IPollsCategoryAsync.GetByIdAsync"/>
		Poll GetById(PollsGetByIdParams @params);

		/// <inheritdoc cref="IPollsCategoryAsync.EditAsync"/>
		bool Edit(PollsEditParams @params);

		/// <inheritdoc cref="IPollsCategoryAsync.AddVoteAsync"/>
		bool AddVote(PollsAddVoteParams @params);

		/// <inheritdoc cref="IPollsCategoryAsync.DeleteVoteAsync"/>
		bool DeleteVote(PollsDeleteVoteParams @params);

		/// <inheritdoc cref="IPollsCategoryAsync.GetVotersAsync"/>
		VkCollection<PollAnswerVoters> GetVoters(PollsGetVotersParams @params);

		/// <inheritdoc cref="IPollsCategoryAsync.CreateAsync"/>
		Poll Create(PollsCreateParams @params);

		/// <inheritdoc cref="IPollsCategoryAsync.GetBackgroundsAsync"/>
		ReadOnlyCollection<GetBackgroundsResult> GetBackgrounds();

		/// <inheritdoc cref="IPollsCategoryAsync.GetPhotoUploadServerAsync"/>
		PhotoUploadServer GetPhotoUploadServer(long ownerId);

		/// <inheritdoc cref="IPollsCategoryAsync.SavePhotoAsync"/>
		SavePhotoResult SavePhoto(SavePhotoParams @params);
	}
}