using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.Attachments;

namespace VkNet.Utils.JsonConverter;

/// <inheritdoc />
public class GroupJsonConverter : Newtonsoft.Json.JsonConverter
{
	/// <inheritdoc />
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

	/// <inheritdoc />
	/// <exception cref="T:System.TypeAccessException"> </exception>
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		if (objectType.IsGenericType)
		{
			throw new TypeAccessException();
		}

		var obj = JObject.Load(reader);
		var responseJToken = obj["response"] ?? obj;
		var response = new VkResponse(responseJToken);

		var group = new Group
		{
			Id = response["group_id"] ?? response["gid"] ?? response["id"],
			Name = response["name"],
			ScreenName = response["screen_name"],
			IsClosed = response["is_closed"],
			IsAdmin = response["is_admin"],
			AdminLevel = response["admin_level"],
			IsMember = response["is_member"],
			IsAdvertiser = response["is_advertiser"],
			Type = !response.ContainsKey("type")?GroupType.Undefined:Utilities.Deserialize<GroupType>(response["type"]),
			PhotoPreviews = JsonConvert.DeserializeObject<Previews>(response.ToString()),
			Deactivated = !response.ContainsKey("deactivated")?Deactivated.Activated:Utilities.Deserialize<Deactivated>(response["deactivated"]),
			HasPhoto = response["has_photo"],
			Photo50 = response["photo_50"],
			Photo100 = response["photo_100"],
			Photo200 = response["photo_200"],

			// опциональные поля
			City = !response.ContainsKey("city")?null:JsonConvert.DeserializeObject<City>(response["city"].ToString()),
			Country = !response.ContainsKey("country")?null:JsonConvert.DeserializeObject<Country>(response["country"].ToString()),
			Place = !response.ContainsKey("place")?null:JsonConvert.DeserializeObject<Place>(response["place"].ToString()),
			Description = response["description"],
			WikiPage = response["wiki_page"],
			MembersCount = response["members_count"],
			Counters = !response.ContainsKey("counters")?null:JsonConvert.DeserializeObject<Counters>(response["counters"].ToString()),
			StartDate = response["start_date"],
			EndDate = response["finish_date"] ?? response["end_date"],
			CanPost = response["can_post"],
			CanSeeAllPosts = response["can_see_all_posts"],
			CanUploadDocuments = response["can_upload_doc"],
			CanCreateTopic = response["can_create_topic"],
			Activity = response["activity"],
			Status = response["status"],
			StatusAudio = !response.ContainsKey("status_audio") ? null : JsonConvert.DeserializeObject<Audio>(response["status_audio"].ToString()),
			Contacts = !response.ContainsKey("contacts") ? null : JsonConvert.DeserializeObject<ReadOnlyCollection<Contact>>(response["contacts"].ToString()),
			Links = !response.ContainsKey("links") ? null : JsonConvert.DeserializeObject<ReadOnlyCollection<ExternalLink>>(response["links"].ToString()),
			FixedPost = response["fixed_post"],
			Verified = response["verified"],
			Site = response["site"],
			InvitedBy = response["invited_by"],
			IsFavorite = response["is_favorite"],
			BanInfo = !response.ContainsKey("ban_info") ? null : JsonConvert.DeserializeObject<BanInfo>(response["ban_info"].ToString()),
			CanUploadVideo = response["can_upload_video"],
			MainAlbumId = response["main_album_id"],
			IsHiddenFromFeed = response["is_hidden_from_feed"],
			MainSection = response["main_section"],
			IsMessagesAllowed = response["is_messages_allowed"],
			Trending = response["trending"],
			CanMessage = response["can_message"],
			Cover = !response.ContainsKey("cover") ? null : JsonConvert.DeserializeObject<GroupCover>(response["cover"].ToString()),
			Market = !response.ContainsKey("market") ? null : JsonConvert.DeserializeObject<GroupMarket>(response["market"].ToString()),
			AgeLimits = response["age_limits"],
			MemberStatus = response["member_status"],
			PublicDateLabel = response["public_date_label"],
			Wall = response["wall"]
		};

		return group;
	}

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => throw new NotImplementedException();
}