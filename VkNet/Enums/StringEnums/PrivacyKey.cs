using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Тип родственных связей.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter),
	typeof(SnakeCaseNamingStrategy))]
public enum PrivacyKey
{
	BdateVisibility,
	PhotosWith,
	PhotosSaved,
	Groups,
	Audios,
	Gifts,
	Places,
	HiddenFriends,
	Wall,
	WallSend,
	RepliesView,
	StatusReplies,
	PhotosTagme,
	MailSend,
	Calls,
	Appscall,
	GroupsInvite,
	AppsInvite,
	FriendsRequests,
	Search_by_reg_phone,
	Stories,
	StoriesReplies,
	StoriesQuestions,
	StoriesBirthdayWishes,
	Lives,
	LivesReplies,
	Online,
	ChatInviteUser,
	MessageRequests,
	Vkrun_Steps,
	GamesFeed,
	MiniApps,
	CallsIp,
	Questions,
	PageAccess,
	CompanyMessages,
	ClosedProfile,
	IsRecognizePhotoMeEnabled,
	ContactAvatar,
	CallsFromCommunity,
	CallsHasMessages,
	CallsInContacts,
	Mobile,
	Home
}