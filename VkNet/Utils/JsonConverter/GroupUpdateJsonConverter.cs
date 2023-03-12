using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;
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

			var fromJson = type switch
			{
				"message_new" or "message_edit" or "message_reply" => resObj1
					? CreateTyped(u => u.MessageNew, JsonConvert.DeserializeObject<MessageNew>(resObj))
					: CreateTyped(u => u.Message, JsonConvert.DeserializeObject<Message>(resObj)),
				"message_allow" => CreateTyped(u => u.MessageAllow, JsonConvert.DeserializeObject<MessageAllow>(resObj)),
				"message_typing_state" => CreateTyped(u => u.MessageTypingState,
					JsonConvert.DeserializeObject<MessageTypingState>(resObj)),
				"vkpay_transaction" => CreateTyped(u => u.VkPayTransaction, JsonConvert.DeserializeObject<VkPayTransaction>(resObj)),
				"like_add" => CreateTyped(u => u.LikeAdd, JsonConvert.DeserializeObject<LikeAdd>(resObj)),
				"like_remove" => CreateTyped(u => u.LikeRemove, JsonConvert.DeserializeObject<LikeRemove>(resObj)),
				"group_change_settings" => CreateTyped(u => u.GroupChangeSettings,
					JsonConvert.DeserializeObject<GroupChangeSettings>(resObj)),
				"message_deny" => CreateTyped(u => u.MessageDeny, JsonConvert.DeserializeObject<MessageDeny>(resObj)),
				"photo_new" => CreateTyped(u => u.Photo, JsonConvert.DeserializeObject<Photo>(resObj)),
				"photo_comment_new" or "photo_comment_edit" or "photo_comment_restore" => CreateTyped(u => u.PhotoComment,
					JsonConvert.DeserializeObject<PhotoComment>(resObj)),
				"photo_comment_delete" => CreateTyped(u => u.PhotoCommentDelete,
					JsonConvert.DeserializeObject<PhotoCommentDelete>(resObj)),
				"audio_new" => CreateTyped(u => u.Audio, JsonConvert.DeserializeObject<Audio>(resObj)),
				"video_new" => CreateTyped(u => u.Video, JsonConvert.DeserializeObject<Video>(resObj)),
				"video_comment_new" or "video_comment_edit" or "video_comment_restore" => CreateTyped(u => u.VideoComment,
					JsonConvert.DeserializeObject<VideoComment>(resObj)),
				"video_comment_delete" => CreateTyped(u => u.VideoCommentDelete,
					JsonConvert.DeserializeObject<VideoCommentDelete>(resObj)),
				"wall_post_new" or "wall_repost" => CreateTyped(u => u.WallPost, JsonConvert.DeserializeObject<WallPost>(resObj)),
				"market_comment_new" or "market_comment_edit" or "market_comment_restore" =>
					CreateTyped(u => u.MarketComment, JsonConvert.DeserializeObject<VkNet.Model.GroupUpdate.MarketComment>(resObj)),
				"wall_reply_new" or "wall_reply_edit" or "wall_reply_restore" =>
					CreateTyped(u => u.WallReply, JsonConvert.DeserializeObject<VkNet.Model.GroupUpdate.WallReply>(resObj)),
				"wall_reply_delete" => CreateTyped(u => u.WallReplyDelete, JsonConvert.DeserializeObject<WallReplyDelete>(resObj)),
				"board_post_new" or "board_post_edit" or "board_post_restore" => CreateTyped(u => u.BoardPost,
					JsonConvert.DeserializeObject<BoardPost>(resObj)),
				"board_post_delete" => CreateTyped(u => u.BoardPostDelete, JsonConvert.DeserializeObject<BoardPostDelete>(resObj)),
				"market_comment_delete" => CreateTyped(u => u.MarketCommentDelete, JsonConvert.DeserializeObject<MarketCommentDelete>(resObj)),
				"group_leave" => CreateTyped(u => u.GroupLeave, JsonConvert.DeserializeObject<GroupLeave>(resObj)),
				"group_join" => CreateTyped(u => u.GroupJoin, JsonConvert.DeserializeObject<GroupJoin>(resObj)),
				"user_block" => CreateTyped(u => u.UserBlock, JsonConvert.DeserializeObject<UserBlock>(resObj)),
				"user_unblock" => CreateTyped(u => u.UserUnblock, JsonConvert.DeserializeObject<UserUnblock>(resObj)),
				"poll_vote_new" => CreateTyped(u => u.PollVoteNew, JsonConvert.DeserializeObject<PollVoteNew>(resObj)),
				"group_change_photo" => CreateTyped(u => u.GroupChangePhoto, JsonConvert.DeserializeObject<GroupChangePhoto>(resObj)),
				"group_officers_edit" => CreateTyped(u => u.GroupOfficersEdit, JsonConvert.DeserializeObject<GroupOfficersEdit>(resObj)),
				"message_event" => CreateTyped(u => u.MessageEvent, JsonConvert.DeserializeObject<MessageEvent>(resObj)),
				"donut_subscription_create" or "donut_subscription_prolonged" => CreateTyped(u => u.DonutSubscriptionNew, JsonConvert.DeserializeObject<DonutNew>(resObj)),
				"donut_subscription_cancelled" or "donut_subscription_expired" => CreateTyped(u => u.DonutSubscriptionEnd,
					JsonConvert.DeserializeObject<DonutEnd>(resObj)),
				"donut_subscription_price_changed" => CreateTyped(u => u.DonutSubscriptionPriceChanged,
					JsonConvert.DeserializeObject<DonutChanged>(resObj)),
				"donut_money_withdraw" or "donut_money_withdraw_error" => CreateTyped(u => u.DonutMoneyWithdraw,
					JsonConvert.DeserializeObject<DonutWithdraw>(resObj)),
				_ => JsonConvert.DeserializeObject<GroupUpdate>(item.ToString(), JsonConfigure.JsonSerializerSettings)
			};

			fromJson!.Type = Utilities.Deserialize<GroupUpdateType>(type);
			fromJson.Raw = JsonConvert.DeserializeObject<VkResponse>(item.ToString());
			fromJson.GroupId = Convert.ToUInt64(item["group_id"]);

			list.Add(fromJson);
		}

		return list;
	}

	#region Приватные методы

	private static GroupUpdate CreateTyped<TGroupUpdate>(Expression<Func<GroupUpdate, TGroupUpdate>> propertySelector,
														TGroupUpdate instance)
		where TGroupUpdate : IGroupUpdate
	{
		var update = new GroupUpdate
		{
			Instance = instance
		};

		// для сохранения обратной совместимости с публичными свойствами.
		if (propertySelector.Body is MemberExpression
			{
				Member: PropertyInfo propertyInfo
			})
		{
			propertyInfo.SetValue(update, instance);
		}

		return update;
	}

	#endregion

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => typeof(ReadOnlyCollection<>).IsAssignableFrom(c: objectType);
}