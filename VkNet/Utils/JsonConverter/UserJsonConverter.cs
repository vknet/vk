using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.Attachments;

namespace VkNet.Utils.JsonConverter;

/// <inheritdoc />
public class UserJsonConverter : Newtonsoft.Json.JsonConverter
{
	/// <inheritdoc />
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		var user = (User) value;

		var jObj = new JObject
		{
			{
				"first_name" , JToken.FromObject(user.FirstName)
			},
			{
				"last_name" , JToken.FromObject(user.LastName)
			}
		};

		jObj.WriteTo(writer);
	}

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

		var user = new User
		{
			Id = response["user_id"] ?? response["uid"] ?? response["id"] ?? 0,
			FirstName = response["first_name"],
			LastName = response["last_name"],
			Sex = response["sex"],
			BirthDate = response["bdate"],
			City = !response.ContainsKey("city")?null:JsonConvert.DeserializeObject<City>(response["city"].ToString()),
			Country = !response.ContainsKey("country")?null:JsonConvert.DeserializeObject<Country>(response["country"].ToString()),
			PhotoPreviews = JsonConvert.DeserializeObject<Previews>(response.ToString()),
			Online = response["online"],
			FriendLists = response["lists"]
				.ToReadOnlyCollectionOf<long>(x => x),
			Domain = response["domain"],
			HasMobile = response["has_mobile"],
			MobilePhone = response["mobile_phone"] ?? response["phone"],
			HomePhone = response["home_phone"],
			Twitter = response["twitter"],
			Facebook = response["facebook"],
			Skype = response["skype"],
			Site = response["site"],
			Education = !response.ContainsKey("university")?null:JsonConvert.DeserializeObject<Education>(response.ToString()),
			Universities = !response.ContainsKey("universities")?null:JsonConvert.DeserializeObject<ReadOnlyCollection<University>>(response["universities"].ToString()),
			Schools =  !response.ContainsKey("schools")?null:JsonConvert.DeserializeObject<ReadOnlyCollection<School>>(response["schools"].ToString()),
			CanPost = response["can_post"],
			CanSeeAllPosts = response["can_see_all_posts"],
			CanSeeAudio = response["can_see_audio"],
			CanWritePrivateMessage = response["can_write_private_message"],
			Status = response["status"],
			StatusAudio = !response.ContainsKey("status_audio") ? null : JsonConvert.DeserializeObject<Audio>(response["status_audio"].ToString()),
			LastSeen = !response.ContainsKey("last_seen")?null:JsonConvert.DeserializeObject<LastSeen>(response["last_seen"].ToString()),
			CommonCount = response["common_count"],
			Relation = response["relation"],
			Relatives = !response.ContainsKey("relatives")?null:JsonConvert.DeserializeObject<ReadOnlyCollection<Relative>>(response["relatives"].ToString()),
			Counters = !response.ContainsKey("counters")?null:JsonConvert.DeserializeObject<Counters>(response["counters"].ToString()),
			ScreenName = response["screen_name"],
			Nickname = response["nickname"],
			Timezone = response["timezone"],
			Language = response["language"],
			OnlineMobile = response["online_mobile"],
			OnlineApp = response["online_app"],
			RelationPartner = !response.ContainsKey("relation_partner")?null:JsonConvert.DeserializeObject<User>(response["relation_partner"].ToString()),
			StandInLife = !response.ContainsKey("personal")?null:JsonConvert.DeserializeObject<StandInLife>(response["personal"].ToString()),
			Interests = response["interests"],
			Music = response["music"],
			Activities = response["activities"],
			Movies = response["movies"],
			Tv = response["tv"],
			Books = response["books"],
			Games = response["games"],
			About = response["about"],
			Quotes = response["quotes"],
			InvitedBy = response["invited_by"],
			BanInfo = !response.ContainsKey("ban_info") ? null : JsonConvert.DeserializeObject<BanInfo>(response["ban_info"].ToString()),
			Deactivated = !response.ContainsKey("deactivated")?Deactivated.Activated:Utilities.Deserialize<Deactivated>(response["deactivated"]),
			MaidenName = response["maiden_name"],
			BirthdayVisibility = response["bdate_visibility"],
			HomeTown = response["home_town"],
			ChangeNameRequest = !response.ContainsKey("name_request") ? null : JsonConvert.DeserializeObject<ChangeNameRequest>(response["name_request"]
				.ToString()),
			Contacts = !response.ContainsKey("contacts") ? null : JsonConvert.DeserializeObject<Contacts>(response["contacts"]
				.ToString()),
			Hidden = response["hidden"],
			PhotoId = response["photo_id"],
			Verified = response["verified"],
			HasPhoto = response["has_photo"],
			Photo50 = response["photo_50"],
			Photo100 = response["photo_100"],
			Photo200Orig = response["photo_200_orig"],
			Photo200 = response["photo_200"],
			Photo400Orig = response["photo_400_orig"],
			PhotoMax = response["photo_max"],
			PhotoMaxOrig = response["photo_max_orig"],
			FollowersCount = response["followers_count"],
			Occupation = !response.ContainsKey("occupation")?null:JsonConvert.DeserializeObject<Occupation>(response["occupation"].ToString()),
			Exports = !response.ContainsKey("exports")?null:JsonConvert.DeserializeObject<Exports>(response["exports"].ToString()),
			WallComments = response["wall_comments"],
			CanSendFriendRequest = response["can_send_friend_request"],
			IsFavorite = response["is_favorite"],
			IsHiddenFromFeed = response["is_hidden_from_feed"],
			CropPhoto = !response.ContainsKey("crop_photo")?null:JsonConvert.DeserializeObject<CropPhoto>(response["crop_photo"].ToString()),
			IsFriend = response["is_friend"] == "1",
			FriendStatus = response["friend_status"],
			Career = !response.ContainsKey("career")?null:JsonConvert.DeserializeObject<ReadOnlyCollection<Career>>(response["career"].ToString()),
			Military = !response.ContainsKey("military")?null:JsonConvert.DeserializeObject<Military>(response["military"].ToString()),
			Blacklisted = response["blacklisted"],
			BlacklistedByMe = response["blacklisted_by_me"],
			Trending = response["trending"],
			FirstNameNom = response["first_name_nom"],
			FirstNameGen = response["first_name_gen"],
			FirstNameDat = response["first_name_dat"],
			FirstNameAcc = response["first_name_acc"],
			FirstNameIns = response["first_name_ins"],
			FirstNameAbl = response["first_name_abl"],
			LastNameNom = response["last_name_nom"],
			LastNameGen = response["last_name_gen"],
			LastNameDat = response["last_name_dat"],
			LastNameAcc = response["last_name_acc"],
			LastNameIns = response["last_name_ins"],
			LastNameAbl = response["last_name_abl"],
			IsClosed = response["is_closed"],
			CanAccessClosed = response["can_access_closed"],
			Count = response["count"]
		};

		user.IsDeactivated = user.Deactivated != null;

		if (response["name"] != null)
		{
			// Разделить имя и фамилию
			var parts = ((string) response["name"]).Split(' ');

			if (parts.Length < 2)
			{
				user.FirstName = response["name"];
			} else
			{
				user.FirstName = parts[0];
				user.LastName = parts[1];
			}
		}

		switch (response["role"]
					?.ToString())
		{
			case "creator":
				user.Role = ManagerRole.Creator;

				break;

			case "administrator":
				user.Role = ManagerRole.Administrator;

				break;

			case "editor":
				user.Role = ManagerRole.Editor;

				break;

			case "moderator":
				user.Role = ManagerRole.Moderator;

				break;
		}

		if (response["bdate_visibility"] == null)
		{
			if (!string.IsNullOrEmpty(user.BirthDate))
			{
				var birthdayParts = user.BirthDate.Split('.');

				user.BirthdayVisibility = birthdayParts.Length > 2
					? Enums.BirthdayVisibility.Full
					: Enums.BirthdayVisibility.OnlyDayAndMonth;
			}
		} else
		{
			user.BirthdayVisibility = response["bdate_visibility"];
		}

		return user;
	}

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => throw new NotImplementedException();
}