using System;
using System.Linq.Expressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Utils
{
	/// <summary>
	/// Ошибки VK
	/// </summary>
	public static class VkErrors
	{
		/// <summary>
		/// Ошибка если строка null или пустая.
		/// </summary>
		/// <param name="expr"> Выражение. </param>
		/// <exception cref="System.ArgumentNullException">
		/// Параметр не должен быть равен
		/// null
		/// </exception>
		public static void ThrowIfNullOrEmpty(Expression<Func<string>> expr)
		{
			if (!(expr.Body is MemberExpression body))
			{
				return;
			}

			var paramName = body.Member.Name;
			var value = expr.Compile()();

			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentNullException(paramName, "Параметр не должен быть равен null");
			}
		}

		/// <summary>
		/// Ошибка если число не в диапозоне.
		/// </summary>
		/// <typeparam name="T"> Тип данных </typeparam>
		/// <param name="value"> Значение. </param>
		/// <param name="min"> Минимальное значение. </param>
		/// <param name="max"> Максимальное значение. </param>
		/// <exception cref="System.ArgumentOutOfRangeException">
		/// Значение {value} не должно выходить за пределы диапозона [{min},
		/// {max}]
		/// </exception>
		public static void ThrowIfNumberNotInRange<T>(T value, T min, T max)
			where T : struct, IComparable<T>
		{
			if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
			{
				throw new ArgumentOutOfRangeException($@"Значение {value} не должно выходить за пределы диапозона [{min}, {max}]");
			}
		}

		/// <summary>
		/// Ошибка если число отрицательное.
		/// </summary>
		/// <param name="expr"> Выражение. </param>
		/// <exception cref="System.ArgumentException"> Отрицательное значение. </exception>
		public static void ThrowIfNumberIsNegative(Expression<Func<long?>> expr)
		{
			var result = ThrowIfNumberIsNegative<Func<long?>>(expr);

			var name = result.Item1;
			var value = result.Item2();

			if (value.HasValue && value < 0)
			{
				throw new ArgumentException("Отрицательное значение.", name);
			}
		}

		/// <summary>
		/// Ошибка если число отрицательное.
		/// </summary>
		/// <param name="expr"> Выражение. </param>
		/// <exception cref="System.ArgumentException"> Отрицательное значение. </exception>
		public static void ThrowIfNumberIsNegative(Expression<Func<long>> expr)
		{
			var result = ThrowIfNumberIsNegative<Func<long>>(expr);

			var name = result.Item1;
			var value = result.Item2();

			if (value < 0)
			{
				throw new ArgumentException("Отрицательное значение.", name);
			}
		}

		/// <summary>
		/// Ошибка если число отрицательное.
		/// </summary>
		/// <typeparam name="T"> Тип данных </typeparam>
		/// <param name="expr"> Выражение. </param>
		/// <returns> Результат проверки </returns>
		/// <exception cref="System.ArgumentNullException">
		/// Выражение не может быть равно
		/// null
		/// </exception>
		private static Tuple<string, T> ThrowIfNumberIsNegative<T>(Expression<T> expr)
		{
			if (expr == null)
			{
				throw new ArgumentNullException(nameof(expr), "Выражение не может быть равно null");
			}

			var name = string.Empty;

			// Если значение передатеся из вызывающего метода
			var unary = expr.Body as UnaryExpression;

			if (unary?.Operand is MemberExpression member)
			{
				name = member.Member.Name;
			}

			// Если в метод передается значение напрямую
			if (expr.Body is MemberExpression body)
			{
				name = body.Member.Name;
			}

			var func = expr.Compile();

			return new Tuple<string, T>(name, func);
		}

		/// <summary>
		/// Ошибки VK.
		/// </summary>
		/// <param name="json"> JSON. </param>
		/// <exception cref="VkApiException">
		/// Неправильный данные JSON.
		/// </exception>
		public static void IfErrorThrowException(string json)
		{
			JObject obj;

			try
			{
				obj = JObject.Parse(json);
			}
			catch (JsonReaderException ex)
			{
				throw new VkApiException("Wrong json data.", ex);
			}

			var exceptions = ExecuteErrorsHandler.GetExecuteExceptions(json);

			if (exceptions != null)
			{
				throw exceptions;
			}

			var vkError = JsonConvert.DeserializeObject<VkError>(json);

			if (vkError == null || vkError.ErrorCode == 0)
			{
				return;
			}

			var error = vkError;

			switch (vkError.ErrorCode)
			{
				case VkErrorCode.Unknown: // Error 1

				{
					throw new UnknownException(error);
				}

				case VkErrorCode.AppOff: // Error 2

				{
					throw new AppOffException(error);
				}

				case VkErrorCode.UnknownMethod: // Error 3

				{
					throw new UnknownMethodException(error);
				}

				case VkErrorCode.InvalidSignature: // Error 4

				{
					throw new InvalidSignatureException(error);
				}

				case VkErrorCode.AuthorizationFailed: // Error 5

				{
					throw new UserAuthorizationFailException(error);
				}

				case VkErrorCode.TooManyRequestsPerSecond: // Error 6

				{
					throw new TooManyRequestsException(error);
				}

				case VkErrorCode.PermissionToPerformThisAction: // Error 7

				{
					throw new PermissionToPerformThisActionException(error);
				}

				case VkErrorCode.InvalidRequest: // Error 8

				{
					throw new InvalidRequestException(error);
				}

				case VkErrorCode.TooMuchOfTheSameTypeOfAction: // Error 9

				{
					throw new TooMuchOfTheSameTypeOfActionException(error);
				}

				case VkErrorCode.PublicServerError: // Error 10

				{
					throw new PublicServerErrorException(error);
				}

				case VkErrorCode.OffAppOrLogin: // Error 11

				{
					throw new OffAppOrLoginException(error);
				}

				case VkErrorCode.ImpossibleToCompileCode: // Error 12

				{
					throw new ImpossibleToCompileCodeException(error);
				}

				case VkErrorCode.ErrorExecutingCode: // Error 13

				{
					throw new ErrorExecutingCodeException(error);
				}

				case VkErrorCode.CaptchaNeeded: // Error 14

				{
					throw new CaptchaNeededException(error);
				}

				case VkErrorCode.CannotBlacklistYourself: // Error 15

				{
					throw new CannotBlacklistYourselfException(error);
				}

				case VkErrorCode.NeedHttps: // Error 16

				{
					throw new NeedHttpsException(error);
				}

				case VkErrorCode.NeedValidationOfUser: // Error 17

				{
					throw new NeedValidationException(error);
				}

				case VkErrorCode.UserDeletedOrBanned: // Error 18

				{
					throw new UserDeletedOrBannedException(error);
				}

				case VkErrorCode.ContentDenied: // Error 19

				{
					throw new ContentDeniedException(error);
				}

				case VkErrorCode.NonStandaloneApplications: // Error 20

				{
					throw new NonStandaloneApplicationsException(error);
				}

				case VkErrorCode.OnlySandaloneOrOpenApi: // Error 21

				{
					throw new OnlyStandaloneOrOpenApiException(error);
				}

				case VkErrorCode.LoadingError: // Error 22

				{
					throw new LoadingErrorException(error);
				}

				case VkErrorCode.MethodHasBeenSwitchedOff: // Error 23

				{
					throw new MethodHasBeenSwitchedOffException(error);
				}

				case VkErrorCode.ConfirmationUser: // Error 24

				{
					throw new ConfirmationUserException(error);
				}

				case VkErrorCode.GroupKeyInvalid: // Error 27

				{
					throw new GroupKeyInvalidException(error);
				}

				case VkErrorCode.AppKeyInvalid: // Error 28

				{
					throw new AppKeyInvalidException(error);
				}

				case VkErrorCode.RateLimitReached: // Error 29

				{
					throw new RateLimitReachedException(error);
				}

				case VkErrorCode.ParameterMissingOrInvalid: // Error 100

				{
					throw new ParameterMissingOrInvalidException(error);
				}

				case VkErrorCode.InvalidAppId: // Error 101

				{
					throw new InvalidAppIdException(error);
				}

				case VkErrorCode.OutOfLimits: // Error 103

				{
					throw new OutOfLimitsException(error);
				}

				case VkErrorCode.InvalidUserId: // Error 113

				{
					throw new InvalidUserIdException(error);
				}

				case VkErrorCode.InvalidServer: // Error 118

				{
					throw new InvalidServerException(error);
				}

				case VkErrorCode.InvalidParameter: // Error 120

				{
					throw new InvalidParameterException(error);
				}

				case VkErrorCode.InvalidHash: // Error 121

				{
					throw new InvalidHashException(error);
				}

				case VkErrorCode.InvalidGroupId: // Error 125

				{
					throw new InvalidGroupIdException(error);
				}

				case VkErrorCode.AccessToMenuDenied: // Error 148

				{
					throw new AccessToMenuDeniedException(error);
				}

				case VkErrorCode.InvalidTimestamp: // Error 150

				{
					throw new InvalidTimestampException(error);
				}

				case VkErrorCode.UserAccessDenied: // Error 170

				{
					throw new UserAccessDeniedException(error);
				}

				case VkErrorCode.ListIdInvalid: // Error 171

				{
					throw new ListIdInvalidException(error);
				}

				case VkErrorCode.ListAmountMaximum: // Error 173

				{
					throw new ListAmountMaximumException(error);
				}

				case VkErrorCode.CannotAddYourself: // Error 174

				{
					throw new CannotAddYourselfException(error);
				}

				case VkErrorCode.CannotAddYouBlacklisted: // Error 175

				{
					throw new CannotAddYouBlacklistedException(error);
				}

				case VkErrorCode.CannotAddUserBlacklisted: // Error 176

				{
					throw new CannotAddUserBlacklistedException(error);
				}

				case VkErrorCode.CannotAddUserNotFound: // Error 177

				{
					throw new CannotAddUserNotFoundException(error);
				}

				case VkErrorCode.AlbumAccessDenied: // Error 200

				{
					throw new AlbumAccessDeniedException(error);
				}

				case VkErrorCode.AudioAccessDenied: // Error 201

				{
					throw new AudioAccessDeniedException(error);
				}

				case VkErrorCode.GroupAccessDenied: // Error 203

				{
					throw new GroupAccessDeniedException(error);
				}

				case VkErrorCode.VideoAccessDenied: // Error 204

				{
					throw new VideoAccessDeniedException(error);
				}

				case VkErrorCode.PostAccessDenied: // Error 210

				{
					throw new PostAccessDeniedException(error);
				}

				case VkErrorCode.CommentsWallAccessDenied: // Error 211

				{
					throw new CommentsWallAccessDeniedException(error);
				}

				case VkErrorCode.CommentsPostAccessDenied: // Error 212

				{
					throw new CommentsPostAccessDeniedException(error);
				}

				case VkErrorCode.AccessToCommentDenied: // Error 213

				{
					throw new AccessToCommentDeniedException(error);
				}

				case VkErrorCode.AccessToAddingPostDenied: // Error 214

				{
					// Access to adding post denied: you can only add 50 posts a day.
					throw new PostLimitException(error);
				}

				case VkErrorCode.AdsRecentlyPosted: // Error 219

				{
					throw new AdsRecentlyPostedException(error);
				}

				case VkErrorCode.StatusAccessDenied: // Error 220

				{
					throw new StatusAccessDeniedException(error);
				}

				case VkErrorCode.UserDisabledTrackNameBroadcast: // Error 221

				{
					throw new UserDisabledTrackNameBroadcastException(error);
				}

				case VkErrorCode.PostLinksDenied: // Error 222

				{
					throw new PostLinksDeniedException(error);
				}

				case VkErrorCode.CommentsLimitReached: // Error 223

				{
					throw new CommentsLimitReachedException(error);
				}

				case VkErrorCode.ToomanyAdsPosts: // Error 224

				{
					throw new TooManyAdsPostsException(error);
				}

				case VkErrorCode.GroupsListAccessDenied: // Error 260

				{
					throw new GroupsListAccessDeniedException(error);
				}

				case VkErrorCode.AlbumIsFull: // Error 300

				{
					throw new AlbumIsFullException(error);
				}

				case VkErrorCode.VideoAlbumIsFull: // Error 302

				{
					throw new VideoAlbumIsFullException(error);
				}

				case VkErrorCode.PermissionDenied: // Error 500

				{
					// Permission denied. You must enable votes processing in application settings.
					throw new AccessDeniedException(error);
				}

				case VkErrorCode.AdsAccessDenied: // Error 600

				{
					throw new AdsAccessDeniedException(error);
				}

				case VkErrorCode.ErrorWorkWithAds: // Error 603

				{
					throw new ErrorWorkWithAdsException(error);
				}

				case VkErrorCode.VideoAlreadyAdded: // Error 800

				{
					throw new VideoAlreadyAddedException(error);
				}

				case VkErrorCode.VideoCommentsClosed: // Error 801

				{
					throw new VideoCommentsClosedException(error);
				}

				case VkErrorCode.CannotSendBlacklisted: // Error 900

				{
					throw new CannotSendBlacklistedException(error);
				}

				case VkErrorCode.CannotSendToUserFirstly: // Error 901

				{
					throw new CannotSendToUserFirstlyException(error);
				}

				case VkErrorCode.CannotSendDuePrivacy: // Error 902

				{
					throw new CannotSendDuePrivacyException(error);
				}

				case VkErrorCode.TooMuchSentMessages: // Error 913

				{
					throw new TooMuchSentMessagesException(error);
				}

				case VkErrorCode.MessageIsTooLong: // Error 914

				{
					throw new MessageIsTooLongException(error);
				}

				case VkErrorCode.ConversationAccessDenied: // Error 914

				{
					throw new ConversationAccessDeniedException(error);
				}

				case VkErrorCode.UserNotFoundInChat: // Error 935

				{
					throw new UserNotFoundInChatException(error);
				}

				default:

				{
					throw new VkApiException(error);
				}
			}
		}
	}
}