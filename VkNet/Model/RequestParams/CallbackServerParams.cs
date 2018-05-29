using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры настройки уведомлений о событиях в Callback API.
	/// </summary>
	[Serializable]
	public class CallbackServerParams
	{
		/// <summary>
		/// идентификатор сообщества.
		/// </summary>
		[JsonProperty(propertyName: "group_id")]
		public ulong? GroupId { get; set; }

		/// <summary>
		/// идентификатор сервера.
		/// </summary>
		[JsonProperty(propertyName: "server_id")]
		public long? ServerId { get; set; }

		/// <summary>
		/// уведомления о новых сообщениях (0 — выключить, 1 — включить).
		/// </summary>
		[JsonProperty(propertyName: "callback_settings")]
		public CallbackSettings CallbackSettings { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(CallbackServerParams p)
		{
			return new VkParameters
			{
					{ "group_id", p.GroupId }
					, { "server_id", p.ServerId }
					, { "message_new", p.CallbackSettings.MessageNew }
					, { "message_reply", p.CallbackSettings.MessageReply }
					, { "message_edit", p.CallbackSettings.MessageEdit }
					, { "message_allow", p.CallbackSettings.MessageAllow }
					, { "message_deny", p.CallbackSettings.MessageDeny }
					, { "photo_new", p.CallbackSettings.PhotoNew }
					, { "audio_new", p.CallbackSettings.AudioNew }
					, { "video_new", p.CallbackSettings.VideoNew }
					, { "wall_reply_new", p.CallbackSettings.WallReplyNew }
					, { "wall_reply_edit", p.CallbackSettings.WallReplyEdit }
					, { "wall_reply_delete", p.CallbackSettings.WallReplyDelete }
					, { "wall_reply_restore", p.CallbackSettings.WallReplyRestore }
					, { "wall_post_new", p.CallbackSettings.WallPostNew }
					, { "wall_repost", p.CallbackSettings.WallRepost }
					, { "board_post_new", p.CallbackSettings.BoardPostNew }
					, { "board_post_edit", p.CallbackSettings.BoardPostEdit }
					, { "board_post_restore", p.CallbackSettings.BoardPostRestore }
					, { "board_post_delete", p.CallbackSettings.BoardPostDelete }
					, { "photo_comment_new", p.CallbackSettings.PhotoCommentNew }
					, { "photo_comment_edit", p.CallbackSettings.PhotoCommentEdit }
					, { "photo_comment_delete", p.CallbackSettings.PhotoCommentDelete }
					, { "photo_comment_restore", p.CallbackSettings.PhotoCommentRestore }
					, { "video_comment_new", p.CallbackSettings.VideoCommentNew }
					, { "video_comment_edit", p.CallbackSettings.VideoCommentEdit }
					, { "video_comment_delete", p.CallbackSettings.VideoCommentDelete }
					, { "video_comment_restore", p.CallbackSettings.VideoCommentRestore }
					, { "market_comment_new", p.CallbackSettings.MarketCommentNew }
					, { "market_comment_edit", p.CallbackSettings.MarketCommentEdit }
					, { "market_comment_delete", p.CallbackSettings.MarketCommentDelete }
					, { "market_comment_restore", p.CallbackSettings.MarketCommentRestore }
					, { "poll_vote_new", p.CallbackSettings.PollVoteNew }
					, { "group_join", p.CallbackSettings.GroupJoin }
					, { "group_leave", p.CallbackSettings.GroupLeave }
					, { "group_change_settings", p.CallbackSettings.GroupChangeSettings }
					, { "group_change_photo", p.CallbackSettings.GroupChangePhoto }
					, { "group_officers_edit", p.CallbackSettings.GroupOfficersEdit }
					, { "user_block", p.CallbackSettings.UserBlock }
					, { "user_unblock", p.CallbackSettings.UserUnblock }
			};
		}
	}
}