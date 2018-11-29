using System;
using System.Linq.Expressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Exception;

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
		/// Ошибки авторизации VK.
		/// </summary>
		/// <param name="json"> JSON. </param>
		public static void IfAuthErrorThrowException(string json)
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

			var error = obj["error"];

			if (error == null)
			{
				return;
			}

			var errorDescription = obj["error_description"] ?? string.Empty;

			switch (error.ToString())
			{
				case "need_captcha":
					var sid = obj["captcha_sid"].Value<long>();
					var imgUrl = obj["captcha_img"].ToString();

					throw new CaptchaNeededException(sid, imgUrl);
				default:

					throw new VkApiException($"{error}{Environment.NewLine}{errorDescription}");
			}
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

			var response = obj["error"];

			if (response == null)
			{
				return;
			}

			var error = new VkResponse(response) { RawJson = json };

			var code = (int) response["error_code"];

			switch (code)
			{
				case ErrorCode.Unknown: // Error 1

				{
					throw new UnknownException(error);
				}
				case ErrorCode.AppOff: // Error 2

				{
					throw new AppOffException(error);
				}
				case ErrorCode.UnknownMethod: // Error 3

				{
					throw new UnknownMethodException(error);
				}
				case ErrorCode.InvalidSignature: // Error 4

				{
					throw new InvalidSignatureException(error);
				}
				case ErrorCode.AuthorizationFailed: // Error 5

				{
					throw new UserAuthorizationFailException(error);
				}
				case ErrorCode.TooManyRequestsPerSecond: // Error 6

				{
					throw new TooManyRequestsException(error);
				}
				case ErrorCode.PermissionToPerformThisAction: // Error 7

				{
					throw new PermissionToPerformThisActionException(error);
				}
				case ErrorCode.InvalidRequest: // Error 8

				{
					throw new InvalidRequestException(error);
				}
				case ErrorCode.TooMuchOfTheSameTypeOfAction: // Error 9

				{
					throw new TooMuchOfTheSameTypeOfActionException(error);
				}
				case ErrorCode.PublicServerError: // Error 10

				{
					throw new PublicServerErrorException(error);
				}
				case ErrorCode.OffAppOrLogin: // Error 11

				{
					throw new OffAppOrLoginException(error);
				}
				case ErrorCode.ImpossibleToCompileCode: // Error 12

				{
					throw new ImpossibleToCompileCodeException(error);
				}
				case ErrorCode.ErrorExecutingCode: // Error 13

				{
					throw new ErrorExecutingCodeException(error);
				}
				case ErrorCode.CaptchaNeeded: // Error 14

				{
					throw new CaptchaNeededException(error);
				}
				case ErrorCode.CannotBlacklistYourself: // Error 15

				{
					throw new CannotBlacklistYourselfException(error);
				}
				case ErrorCode.NeedHttps: // Error 16

				{
					throw new NeedHttpsException(error);
				}
				case ErrorCode.NeedValidationOfUser: // Error 17

				{
					throw new NeedValidationException(error);
				}
				case ErrorCode.UserDeletedOrBanned: // Error 18

				{
					throw new UserDeletedOrBannedException(error);
				}
				case ErrorCode.ContentDenied: // Error 19

				{
					throw new ContentDeniedException(error);
				}
				case ErrorCode.NonStandaloneApplications: // Error 20

				{
					throw new NonStandaloneApplicationsException(error);
				}
				case ErrorCode.OnlySandaloneOrOpenApi: // Error 21

				{
					throw new OnlySandaloneOrOpenApiException(error);
				}
				case ErrorCode.LoadingError: // Error 22

				{
					throw new LoadingErrorException(error);
				}
				case ErrorCode.MethodHasBeenSwitchedOff: // Error 23

				{
					throw new MethodHasBeenSwitchedOffException(error);
				}
				case ErrorCode.ConfirmationUser: // Error 24

				{
					throw new ConfirmationUserException(error);
				}
				case ErrorCode.GroupKeyInvalid: // Error 27

				{
					throw new GroupKeyInvalidException(error);
				}
				case ErrorCode.AppKeyInvalid: // Error 28

				{
					throw new AppKeyInvalidException(error);
				}
				case ErrorCode.RateLimitReached: // Error 29

				{
					throw new RateLimitReachedException(error);
				}
				case ErrorCode.ParameterMissingOrInvalid: // Error 100

				{
					throw new ParameterMissingOrInvalidException(error);
				}
				case ErrorCode.InvalidAppId: // Error 101

				{
					throw new InvalidAppIdException(error);
				}
				case ErrorCode.OutOfLimits: // Error 103

				{
					throw new OutOfLimitsException(error);
				}
				case ErrorCode.InvalidUserId: // Error 113

				{
					throw new InvalidUserIdException(error);
				}
				case ErrorCode.InvalidServer: // Error 118

				{
					throw new InvalidServerException(error);
				}
				case ErrorCode.InvalidParameter: // Error 120

				{
					throw new InvalidParameterException(error);
				}
				case ErrorCode.InvalidHash: // Error 121

				{
					throw new InvalidHashException(error);
				}
				case ErrorCode.InvalidGroupId: // Error 125

				{
					throw new InvalidGroupIdException(error);
				}
				case ErrorCode.AccessToMenuDenied: // Error 148

				{
					throw new AccessToMenuDeniedException(error);
				}
				case ErrorCode.InvalidTimestamp: // Error 150

				{
					throw new InvalidTimestampException(error);
				}
				case ErrorCode.UserAccessDenied: // Error 170

				{
					throw new UserAccessDeniedException(error);
				}
				case ErrorCode.ListIdInvalid: // Error 171

				{
					throw new ListIdInvalidException(error);
				}
				case ErrorCode.ListAmountMaximum: // Error 173

				{
					throw new ListAmountMaximumException(error);
				}
				case ErrorCode.CannotAddYourself: // Error 174

				{
					throw new CannotAddYourselfException(error);
				}
				case ErrorCode.CannotAddYouBlacklisted: // Error 175

				{
					throw new CannotAddYouBlacklistedException(error);
				}
				case ErrorCode.CannotAddUserBlacklisted: // Error 176

				{
					throw new CannotAddUserBlacklistedException(error);
				}
				case ErrorCode.CannotAddUserNotFound: // Error 177

				{
					throw new CannotAddUserNotFoundException(error);
				}
				case ErrorCode.AlbumAccessDenied: // Error 200

				{
					throw new AlbumAccessDeniedException(error);
				}
				case ErrorCode.AudioAccessDenied: // Error 201

				{
					throw new AudioAccessDeniedException(error);
				}
				case ErrorCode.GroupAccessDenied: // Error 203

				{
					throw new GroupAccessDeniedException(error);
				}
				case ErrorCode.VideoAccessDenied: // Error 204

				{
					throw new VideoAccessDeniedException(error);
				}
				case ErrorCode.PostAccessDenied: // Error 210

				{
					throw new PostAccessDeniedException(error);
				}
				case ErrorCode.CommentsWallAccessDenied: // Error 211

				{
					throw new CommentsWallAccessDeniedException(error);
				}
				case ErrorCode.CommentsPostAccessDenied: // Error 212

				{
					throw new CommentsPostAccessDeniedException(error);
				}
				case ErrorCode.AccessToCommentDenied: // Error 213

				{
					throw new AccessToCommentDeniedException(error);
				}
				case ErrorCode.AccessToAddingPostDenied: // Error 214

				{
					// Access to adding post denied: you can only add 50 posts a day.
					throw new PostLimitException(error);
				}
				case ErrorCode.AdsRecentlyPosted: // Error 219

				{
					throw new AdsRecentlyPostedException(error);
				}
				case ErrorCode.StatusAccessDenied: // Error 220

				{
					throw new StatusAccessDeniedException(error);
				}
				case ErrorCode.UserDisabledTrackNameBroadcast: // Error 221

				{
					throw new UserDisabledTrackNameBroadcastException(error);
				}
				case ErrorCode.PostLinksDenied: // Error 222

				{
					throw new PostLinksDeniedException(error);
				}
				case ErrorCode.CommentsLimitReached: // Error 223

				{
					throw new CommentsLimitReachedException(error);
				}
				case ErrorCode.ToomanyAdsPosts: // Error 224

				{
					throw new TooManyAdsPostsException(error);
				}
				case ErrorCode.GroupsListAccessDenied: // Error 260

				{
					throw new GroupsListAccessDeniedException(error);
				}
				case ErrorCode.AlbumIsFull: // Error 300

				{
					throw new AlbumIsFullException(error);
				}
				case ErrorCode.VideoAlbumIsFull: // Error 302

				{
					throw new VideoAlbumIsFullException(error);
				}
				case ErrorCode.PermissionDenied: // Error 500

				{
					// Permission denied. You must enable votes processing in application settings.
					throw new AccessDeniedException(error);
				}
				case ErrorCode.AdsAccessDenied: // Error 600

				{
					throw new AdsAccessDeniedException(error);
				}
				case ErrorCode.ErrorWorkWithAds: // Error 603

				{
					throw new ErrorWorkWithAdsException(error);
				}
				case ErrorCode.VideoAlreadyAdded: // Error 800

				{
					throw new VideoAlreadyAddedException(error);
				}
				case ErrorCode.VideoCommentsClosed: // Error 801

				{
					throw new VideoCommentsClosedException(error);
				}
				case ErrorCode.CannotSendBlacklisted: // Error 900

				{
					throw new CannotSendBlacklistedException(error);
				}
				case ErrorCode.CannotSendToUserFirstly: // Error 901

				{
					throw new CannotSendToUserFirstlyException(error);
				}
				case ErrorCode.CannotSendDuePrivacy: // Error 902

				{
					throw new CannotSendDuePrivacyException(error);
				}
				case ErrorCode.TooMuchSentMessages: // Error 913

				{
					throw new TooMuchSentMessagesException(error);
				}
				case ErrorCode.MessageIsTooLong: // Error 914

				{
					throw new MessageIsTooLongException(error);
				}
				case ErrorCode.ConversationAccessDenied: // Error 914

				{
					throw new ConversationAccessDeniedException(error);
				}
				default:

				{
					throw new VkApiException(error);
				}
			}
		}
	}
}