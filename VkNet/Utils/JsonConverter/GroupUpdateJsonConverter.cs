using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Infrastructure;
using VkNet.Model;

namespace VkNet.Utils.JsonConverter;

/// <summary>
/// Attachment JsonConverter
/// </summary>
/// <seealso cref="Newtonsoft.Json.JsonConverter" />
public class GroupUpdateJsonConverter : Newtonsoft.Json.JsonConverter
{
	/// <inheritdoc />
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();


	/// <inheritdoc />
	/// <exception cref="T:System.TypeAccessException"> </exception>
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		if (reader.TokenType == JsonToken.Null)
		{
			return null;
		}

		var obj = JObject.Load(reader: reader);

		var resObj = obj["object"]?.ToString();
		var resObj1 = resObj?.Contains("client_info");
		var type = obj["type"].ToString();

		var groupUpdate = JsonConvert.DeserializeObject<GroupUpdate>(obj.ToString(), JsonConfigure.JsonSerializerSettings);

		groupUpdate.Instance = type switch
		{
			"message_new" or "message_edit" or "message_reply" => resObj1!.Value
				? JsonConvert.DeserializeObject<MessageNew>(resObj)
				: JsonConvert.DeserializeObject<Message>(resObj),
			"message_allow" => JsonConvert.DeserializeObject<MessageAllow>(resObj),
			"message_typing_state" => JsonConvert.DeserializeObject<MessageTypingState>(resObj),
			"vkpay_transaction" => JsonConvert.DeserializeObject<VkPayTransaction>(resObj),
			"like_add" => JsonConvert.DeserializeObject<LikeAdd>(resObj),
			"like_remove" => JsonConvert.DeserializeObject<LikeRemove>(resObj),
			"group_change_settings" => JsonConvert.DeserializeObject<GroupChangeSettings>(resObj),
			"message_deny" => JsonConvert.DeserializeObject<MessageDeny>(resObj),
			"photo_new" => JsonConvert.DeserializeObject<Photo>(resObj),
			"photo_comment_new" or "photo_comment_edit" or "photo_comment_restore" => JsonConvert.DeserializeObject<PhotoComment>(resObj),
			"photo_comment_delete" => JsonConvert.DeserializeObject<PhotoCommentDelete>(resObj),
			"audio_new" => JsonConvert.DeserializeObject<Audio>(resObj),
			"video_new" => JsonConvert.DeserializeObject<Video>(resObj),
			"video_comment_new" or "video_comment_edit" or "video_comment_restore" => JsonConvert.DeserializeObject<VideoComment>(resObj),
			"video_comment_delete" => JsonConvert.DeserializeObject<VideoCommentDelete>(resObj),
			"wall_post_new" or "wall_repost" => JsonConvert.DeserializeObject<WallPost>(resObj),
			"market_comment_new" or "market_comment_edit" or "market_comment_restore" =>
				JsonConvert.DeserializeObject<MarketCommentGroupUpdate>(resObj),
			"wall_reply_new" or "wall_reply_edit" or "wall_reply_restore" =>
				JsonConvert.DeserializeObject<WallReplyGroupUpdate>(resObj),
			"wall_reply_delete" => JsonConvert.DeserializeObject<WallReplyDelete>(resObj),
			"board_post_new" or "board_post_edit" or "board_post_restore" => JsonConvert.DeserializeObject<BoardPost>(resObj),
			"board_post_delete" => JsonConvert.DeserializeObject<BoardPostDelete>(resObj),
			"market_comment_delete" => JsonConvert.DeserializeObject<MarketCommentDelete>(resObj),
			"group_leave" => JsonConvert.DeserializeObject<GroupLeave>(resObj),
			"group_join" => JsonConvert.DeserializeObject<GroupJoin>(resObj),
			"user_block" => JsonConvert.DeserializeObject<UserBlock>(resObj),
			"user_unblock" => JsonConvert.DeserializeObject<UserUnblock>(resObj),
			"poll_vote_new" => JsonConvert.DeserializeObject<PollVoteNew>(resObj),
			"group_change_photo" => JsonConvert.DeserializeObject<GroupChangePhoto>(resObj),
			"group_officers_edit" => JsonConvert.DeserializeObject<GroupOfficersEdit>(resObj),
			"message_event" => JsonConvert.DeserializeObject<MessageEvent>(resObj),
			"donut_subscription_create" or "donut_subscription_prolonged" => JsonConvert.DeserializeObject<DonutNew>(resObj),
			"donut_subscription_cancelled" or "donut_subscription_expired" => JsonConvert.DeserializeObject<DonutEnd>(resObj),
			"donut_subscription_price_changed" => JsonConvert.DeserializeObject<DonutChanged>(resObj),
			"donut_money_withdraw" or "donut_money_withdraw_error" => JsonConvert.DeserializeObject<DonutWithdraw>(resObj),
			"market_order_new" => JsonConvert.DeserializeObject<MarketOrder>(resObj),
			"market_order_edit" => JsonConvert.DeserializeObject<MarketOrder>(resObj),
			"app_payload" => JsonConvert.DeserializeObject<AppPayload>(resObj),
			_ => null
		};
		groupUpdate.Raw = JsonConvert.DeserializeObject<VkResponse>(obj.ToString());

		return groupUpdate;
	}

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => typeof(GroupUpdate).IsAssignableFrom(c: objectType);
}