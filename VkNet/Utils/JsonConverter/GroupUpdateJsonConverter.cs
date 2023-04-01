using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Enums.SafetyEnums;
using VkNet.Infrastructure;
using VkNet.Model;
using VkNet.Model.Attachments;
using VkNet.Model.GroupUpdate;

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
		if (!objectType.IsGenericType)
		{
			throw new TypeAccessException();
		}

		if (reader.TokenType == JsonToken.Null)
		{
			return null;
		}

		if (reader.TokenType != JsonToken.StartArray)
		{
			return null;
		}

		var keyType = objectType.GetGenericArguments()[0];

		var constructedListType = typeof(List<>).MakeGenericType(keyType);

		var list = (IList) Activator.CreateInstance(type: constructedListType);

		var obj = JArray.Load(reader: reader);

		foreach (var item in obj)
		{
			var resObj = item["object"].ToString();
			var resObj1 = resObj.Contains("client_info");

			var type = item["type"]
				.ToString();

			var groupUpdate = type switch
			{
				"message_new" or "message_edit" or "message_reply" => resObj1
					? CreateTyped(JsonConvert.DeserializeObject<MessageNew>(resObj))
					: CreateTyped(JsonConvert.DeserializeObject<Message>(resObj)),
				"message_allow" => CreateTyped(JsonConvert.DeserializeObject<MessageAllow>(resObj)),
				"message_typing_state" => CreateTyped(JsonConvert.DeserializeObject<MessageTypingState>(resObj)),
				"vkpay_transaction" => CreateTyped(JsonConvert.DeserializeObject<VkPayTransaction>(resObj)),
				"like_add" => CreateTyped(JsonConvert.DeserializeObject<LikeAdd>(resObj)),
				"like_remove" => CreateTyped(JsonConvert.DeserializeObject<LikeRemove>(resObj)),
				"group_change_settings" => CreateTyped(JsonConvert.DeserializeObject<GroupChangeSettings>(resObj)),
				"message_deny" => CreateTyped(JsonConvert.DeserializeObject<MessageDeny>(resObj)),
				"photo_new" => CreateTyped(JsonConvert.DeserializeObject<Photo>(resObj)),
				"photo_comment_new" or "photo_comment_edit" or "photo_comment_restore" => CreateTyped(JsonConvert.DeserializeObject<PhotoComment>(resObj)),
				"photo_comment_delete" => CreateTyped(JsonConvert.DeserializeObject<PhotoCommentDelete>(resObj)),
				"audio_new" => CreateTyped(JsonConvert.DeserializeObject<Audio>(resObj)),
				"video_new" => CreateTyped(JsonConvert.DeserializeObject<Video>(resObj)),
				"video_comment_new" or "video_comment_edit" or "video_comment_restore" => CreateTyped(JsonConvert.DeserializeObject<VideoComment>(resObj)),
				"video_comment_delete" => CreateTyped(JsonConvert.DeserializeObject<VideoCommentDelete>(resObj)),
				"wall_post_new" or "wall_repost" => CreateTyped(JsonConvert.DeserializeObject<WallPost>(resObj)),
				"market_comment_new" or "market_comment_edit" or "market_comment_restore" =>
					CreateTyped(JsonConvert.DeserializeObject<VkNet.Model.GroupUpdate.MarketComment>(resObj)),
				"wall_reply_new" or "wall_reply_edit" or "wall_reply_restore" =>
					CreateTyped(JsonConvert.DeserializeObject<VkNet.Model.GroupUpdate.WallReply>(resObj)),
				"wall_reply_delete" => CreateTyped(JsonConvert.DeserializeObject<WallReplyDelete>(resObj)),
				"board_post_new" or "board_post_edit" or "board_post_restore" => CreateTyped(JsonConvert.DeserializeObject<BoardPost>(resObj)),
				"board_post_delete" => CreateTyped(JsonConvert.DeserializeObject<BoardPostDelete>(resObj)),
				"market_comment_delete" => CreateTyped(JsonConvert.DeserializeObject<MarketCommentDelete>(resObj)),
				"group_leave" => CreateTyped(JsonConvert.DeserializeObject<GroupLeave>(resObj)),
				"group_join" => CreateTyped(JsonConvert.DeserializeObject<GroupJoin>(resObj)),
				"user_block" => CreateTyped(JsonConvert.DeserializeObject<UserBlock>(resObj)),
				"user_unblock" => CreateTyped(JsonConvert.DeserializeObject<UserUnblock>(resObj)),
				"poll_vote_new" => CreateTyped(JsonConvert.DeserializeObject<PollVoteNew>(resObj)),
				"group_change_photo" => CreateTyped(JsonConvert.DeserializeObject<GroupChangePhoto>(resObj)),
				"group_officers_edit" => CreateTyped(JsonConvert.DeserializeObject<GroupOfficersEdit>(resObj)),
				"message_event" => CreateTyped(JsonConvert.DeserializeObject<MessageEvent>(resObj)),
				"donut_subscription_create" or "donut_subscription_prolonged" => CreateTyped(JsonConvert.DeserializeObject<DonutNew>(resObj)),
				"donut_subscription_cancelled" or "donut_subscription_expired" => CreateTyped(JsonConvert.DeserializeObject<DonutEnd>(resObj)),
				"donut_subscription_price_changed" => CreateTyped(JsonConvert.DeserializeObject<DonutChanged>(resObj)),
				"donut_money_withdraw" or "donut_money_withdraw_error" => CreateTyped(JsonConvert.DeserializeObject<DonutWithdraw>(resObj)),
				"market_order_new" => CreateTyped(JsonConvert.DeserializeObject<MarketOrder>(resObj)),
				"market_order_edit" => CreateTyped(JsonConvert.DeserializeObject<MarketOrder>(resObj)),
				"app_payload" => CreateTyped(JsonConvert.DeserializeObject<AppPayload>(resObj)),

				_ => JsonConvert.DeserializeObject<GroupUpdate>(item.ToString(), JsonConfigure.JsonSerializerSettings)
			};

			groupUpdate.Raw = JsonConvert.DeserializeObject<VkResponse>(item.ToString());
			groupUpdate.Type = new(Utilities.Deserialize<GroupUpdateType>(groupUpdate.Instance.ToString()).GetValueOrDefault());
			groupUpdate.GroupId =  new(Convert.ToUInt64(item["group_id"]));

			if (item["secret"] is not null)
			{
				groupUpdate.Secret = new(item["secret"]
					.ToString());
			}

			list.Add(groupUpdate);
		}

		return list;
	}

	#region Приватные методы

	private static GroupUpdate CreateTyped<TGroupUpdate>(TGroupUpdate instance)
		where TGroupUpdate : IGroupUpdate
	{
		var update = new GroupUpdate
		{
			Instance = instance
		};

		return update;
	}

	#endregion

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => typeof(ReadOnlyCollection<>).IsAssignableFrom(c: objectType);
}