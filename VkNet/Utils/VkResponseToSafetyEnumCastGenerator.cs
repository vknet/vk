// DO NOT EDIT THIS FILE CAUSE ALL CHANGES WILL BE DELETED AUTOMATICALLY

using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Utils
{
	public partial class VkResponse
	{
		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator PollBackgroundType(VkResponse response)
		{
			return response == null ? null : PollBackgroundType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator OnlineStatusType(VkResponse response)
		{
			return response == null ? null : OnlineStatusType.FromJson(response: response);
		}

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static implicit operator AppWidgetImageType(VkResponse response)
		{
			return response == null ? null : AppWidgetImageType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator AppFilter(VkResponse response)
		{
			return response == null ? null : AppFilter.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator VideoView(VkResponse response)
		{
			return response == null ? null : VideoView.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator DocMessageType(VkResponse response)
		{
			return response == null ? null : DocMessageType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator VideoCatalogFilters(VkResponse response)
		{
			return response == null ? null : VideoCatalogFilters.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator CallbackServerStatus(VkResponse response)
		{
			return response == null ? null : CallbackServerStatus.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator AppPlatforms(VkResponse response)
		{
			return response == null ? null : AppPlatforms.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator AppRatingType(VkResponse response)
		{
			return response == null ? null : AppRatingType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator AppRequestType(VkResponse response)
		{
			return response == null ? null : AppRequestType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator AppSort(VkResponse response)
		{
			return response == null ? null : AppSort.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator AppType(VkResponse response)
		{
			return response == null ? null : AppType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator AppWidgetType(VkResponse response)
		{
			return response == null ? null : AppWidgetType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator ChangeNameStatus(VkResponse response)
		{
			return response == null ? null : ChangeNameStatus.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator CommentObjectType(VkResponse response)
		{
			return response == null ? null : CommentObjectType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator CommentsSort(VkResponse response)
		{
			return response == null ? null : CommentsSort.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator Deactivated(VkResponse response)
		{
			return response == null ? null : Deactivated.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator Display(VkResponse response)
		{
			return response == null ? null : Display.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator FeedType(VkResponse response)
		{
			return response == null ? null : FeedType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator FriendsFilter(VkResponse response)
		{
			return response == null ? null : FriendsFilter.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator FriendsOrder(VkResponse response)
		{
			return response == null ? null : FriendsOrder.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator GroupsMemberFilters(VkResponse response)
		{
			return response == null ? null : GroupsMemberFilters.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator GroupsSort(VkResponse response)
		{
			return response == null ? null : GroupsSort.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator GroupType(VkResponse response)
		{
			return response == null ? null : GroupType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator LikeObjectType(VkResponse response)
		{
			return response == null ? null : LikeObjectType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator LikesFilter(VkResponse response)
		{
			return response == null ? null : LikesFilter.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator LinkAccessType(VkResponse response)
		{
			return response == null ? null : LinkAccessType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator ManagerRole(VkResponse response)
		{
			return response == null ? null : ManagerRole.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator MediaType(VkResponse response)
		{
			return response == null ? null : MediaType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator NameCase(VkResponse response)
		{
			return response == null ? null : NameCase.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator NewsObjectTypes(VkResponse response)
		{
			return response == null ? null : NewsObjectTypes.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator NewsTypes(VkResponse response)
		{
			return response == null ? null : NewsTypes.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator OccupationType(VkResponse response)
		{
			return response == null ? null : OccupationType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator PhotoAlbumType(VkResponse response)
		{
			return response == null ? null : PhotoAlbumType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator PhotoFeedType(VkResponse response)
		{
			return response == null ? null : PhotoFeedType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator PhotoSearchRadius(VkResponse response)
		{
			return response == null ? null : PhotoSearchRadius.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator PhotoSizeType(VkResponse response)
		{
			return response == null ? null : PhotoSizeType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator Platform(VkResponse response)
		{
			return response == null ? null : Platform.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator PostSourceType(VkResponse response)
		{
			return response == null ? null : PostSourceType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator PostType(VkResponse response)
		{
			return response == null ? null : PostType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator PostTypeOrder(VkResponse response)
		{
			return response == null ? null : PostTypeOrder.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator Privacy(VkResponse response)
		{
			return response == null ? null : Privacy.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator RelativeType(VkResponse response)
		{
			return response == null ? null : RelativeType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator ReportType(VkResponse response)
		{
			return response == null ? null : ReportType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator Services(VkResponse response)
		{
			return response == null ? null : Services.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator UserSection(VkResponse response)
		{
			return response == null ? null : UserSection.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator VideoCatalogItemType(VkResponse response)
		{
			return response == null ? null : VideoCatalogItemType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator VideoCatalogType(VkResponse response)
		{
			return response == null ? null : VideoCatalogType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator WallFilter(VkResponse response)
		{
			return response == null ? null : WallFilter.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator AccountType(VkResponse response)
		{
			return response == null ? null : AccountType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator AccessRole(VkResponse response)
		{
			return response == null ? null : AccessRole.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator CampaignType(VkResponse response)
		{
			return response == null ? null : CampaignType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator KeyboardButtonActionType(VkResponse response)
		{
			return response == null ? null : KeyboardButtonActionType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator KeyboardButtonColor(VkResponse response)
		{
			return response == null ? null : KeyboardButtonColor.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator MarketItemButtonTitle(VkResponse response)
		{
			return response == null ? null : MarketItemButtonTitle.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator CarouselElementActionType(VkResponse response)
		{
			return response == null ? null : CarouselElementActionType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator AdPlatform(VkResponse response)
		{
			return response == null ? null : AdPlatform.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator SourceType(VkResponse response)
		{
			return response == null ? null : SourceType.FromJson(response: response);
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator AdRequestStatus(VkResponse response)
		{
			return response == null ? null : AdRequestStatus.FromJson(response: response);
		}
	}
}