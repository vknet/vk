// DO NOT EDIT THIS FILE CAUSE ALL CHANGES WILL BE DELETED AUTOMATICALLY

using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Utils;

public partial class VkResponse
{
	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator PollBackgroundType(VkResponse response) => response == null
		? null
		: PollBackgroundType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator OnlineStatusType(VkResponse response) => response == null
		? null
		: OnlineStatusType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator PostSourceData(VkResponse response) => response == null
		? null
		: PostSourceData.FromJson(response: response);

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static implicit operator AppWidgetImageType(VkResponse response) => response == null
		? null
		: AppWidgetImageType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator AppFilter(VkResponse response) => response == null
		? null
		: AppFilter.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator DocMessageType(VkResponse response) => response == null
		? null
		: DocMessageType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator CallbackServerStatus(VkResponse response) => response == null
		? null
		: CallbackServerStatus.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator AppPlatforms(VkResponse response) => response == null
		? null
		: AppPlatforms.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator AppRequestType(VkResponse response) => response == null
		? null
		: AppRequestType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator AppSort(VkResponse response) => response == null
		? null
		: AppSort.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator AppType(VkResponse response) => response == null
		? null
		: AppType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator AppWidgetType(VkResponse response) => response == null
		? null
		: AppWidgetType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator ChangeNameStatus(VkResponse response) => response == null
		? null
		: ChangeNameStatus.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator CommentObjectType(VkResponse response) => response == null
		? null
		: CommentObjectType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator CommentsSort(VkResponse response) => response == null
		? null
		: CommentsSort.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator Deactivated(VkResponse response) => response == null
		? null
		: Deactivated.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator Display(VkResponse response) => response == null
		? null
		: Display.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator FeedType(VkResponse response) => response == null
		? null
		: FeedType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator FriendsFilter(VkResponse response) => response == null
		? null
		: FriendsFilter.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator FriendsOrder(VkResponse response) => response == null
		? null
		: FriendsOrder.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator GroupsMemberFilters(VkResponse response) => response == null
		? null
		: GroupsMemberFilters.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator GroupType(VkResponse response) => response == null
		? null
		: GroupType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator LikeObjectType(VkResponse response) => response == null
		? null
		: LikeObjectType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator LikesFilter(VkResponse response) => response == null
		? null
		: LikesFilter.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator ManagerRole(VkResponse response) => response == null
		? null
		: ManagerRole.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator MediaType(VkResponse response) => response == null
		? null
		: MediaType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator NameCase(VkResponse response) => response == null
		? null
		: NameCase.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator NewsObjectTypes(VkResponse response) => response == null
		? null
		: NewsObjectTypes.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator NewsTypes(VkResponse response) => response == null
		? null
		: NewsTypes.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator OccupationType(VkResponse response) => response == null
		? null
		: OccupationType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator PhotoAlbumType(VkResponse response) => response == null
		? null
		: PhotoAlbumType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator PhotoFeedType(VkResponse response) => response == null
		? null
		: PhotoFeedType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator PhotoSearchRadius(VkResponse response) => response == null
		? null
		: PhotoSearchRadius.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator PhotoSizeType(VkResponse response) => response == null
		? null
		: PhotoSizeType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator Platform(VkResponse response) => response == null
		? null
		: Platform.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator PostSourceType(VkResponse response) => response == null
		? null
		: PostSourceType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator PostType(VkResponse response) => response == null
		? null
		: PostType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator PostTypeOrder(VkResponse response) => response == null
		? null
		: PostTypeOrder.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator Privacy(VkResponse response) => response == null
		? null
		: Privacy.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator RelativeType(VkResponse response) => response == null
		? null
		: RelativeType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator ReportType(VkResponse response) => response == null
		? null
		: ReportType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator Services(VkResponse response) => response == null
		? null
		: Services.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator CampaignType(VkResponse response) => response == null
		? null
		: CampaignType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator KeyboardButtonActionType(VkResponse response) => response == null
		? null
		: KeyboardButtonActionType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator KeyboardButtonColor(VkResponse response) => response == null
		? null
		: KeyboardButtonColor.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator MarketItemButtonTitle(VkResponse response) => response == null
		? null
		: MarketItemButtonTitle.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator CarouselElementActionType(VkResponse response) => response == null
		? null
		: CarouselElementActionType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator SourceType(VkResponse response) => response == null
		? null
		: SourceType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator AdRequestStatus(VkResponse response) => response == null
		? null
		: AdRequestStatus.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator IdsType(VkResponse response) => response == null
		? null
		: IdsType.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator TranscriptStates(VkResponse response) => response == null
		? null
		: TranscriptStates.FromJson(response: response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator MessageEventType(VkResponse response) => response == null
		? null
		: MessageEventType.FromJson(response: response);
}