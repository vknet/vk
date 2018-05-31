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

			if (string.IsNullOrEmpty(value: value))
			{
				throw new ArgumentNullException(paramName: paramName, message: "Параметр не должен быть равен null");
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
			if (value.CompareTo(other: min) < 0 || value.CompareTo(other: max) > 0)
			{
				throw new ArgumentOutOfRangeException(
						paramName: $@"Значение {value} не должно выходить за пределы диапозона [{min}, {max}]");
			}
		}

		/// <summary>
		/// Ошибка если число отрицательное.
		/// </summary>
		/// <param name="expr"> Выражение. </param>
		/// <exception cref="System.ArgumentException"> Отрицательное значение. </exception>
		public static void ThrowIfNumberIsNegative(Expression<Func<long?>> expr)
		{
			var result = ThrowIfNumberIsNegative<Func<long?>>(expr: expr);

			var name = result.Item1;
			var value = result.Item2();

			if (value.HasValue && value < 0)
			{
				throw new ArgumentException(message: "Отрицательное значение.", paramName: name);
			}
		}

		/// <summary>
		/// Ошибка если число отрицательное.
		/// </summary>
		/// <param name="expr"> Выражение. </param>
		/// <exception cref="System.ArgumentException"> Отрицательное значение. </exception>
		public static void ThrowIfNumberIsNegative(Expression<Func<long>> expr)
		{
			var result = ThrowIfNumberIsNegative<Func<long>>(expr: expr);

			var name = result.Item1;
			var value = result.Item2();

			if (value < 0)
			{
				throw new ArgumentException(message: "Отрицательное значение.", paramName: name);
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
				throw new ArgumentNullException(paramName: nameof(expr), message: "Выражение не может быть равно null");
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

			return new Tuple<string, T>(item1: name, item2: func);
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
				obj = JObject.Parse(json: json);
			}
			catch (JsonReaderException ex)
			{
				throw new VkApiException(message: "Wrong json data.", innerException: ex);
			}

			var response = obj[propertyName: "error"];

			if (response == null)
			{
				return;
			}

			var error = new VkResponse(token: response) { RawJson = json };

			var code = (int) response[key: "error_code"];

			switch (code)
			{
				case ErrorCode.Unknown: // Error 1

				{
					throw new UnknownException(response: error);
				}
				case ErrorCode.AppOff: // Error 2

				{
					throw new AppOffException(response: error);
				}
				case ErrorCode.UnknownMethod: // Error 3

				{
					throw new UnknownMethodException(response: error);
				}
				case ErrorCode.InvalidSignature: // Error 4

				{
					throw new InvalidSignatureException(response: error);
				}
				case ErrorCode.AuthorizationFailed: // Error 5

				{
					throw new UserAuthorizationFailException(response: error);
				}
				case ErrorCode.TooManyRequestsPerSecond: // Error 6

				{
					throw new TooManyRequestsException(response: error);
				}
				case ErrorCode.PermissionToPerformThisAction: // Error 7

				{
					throw new PermissionToPerformThisActionException(response: error);
				}
				case ErrorCode.InvalidRequest: // Error 8

				{
					throw new InvalidRequestException(response: error);
				}
				case ErrorCode.TooMuchOfTheSameTypeOfAction: // Error 9

				{
					throw new TooMuchOfTheSameTypeOfActionException(response: error);
				}
				case ErrorCode.PublicServerError: // Error 10

				{
					throw new PublicServerErrorException(response: error);
				}
				case ErrorCode.OffAppOrLogin: // Error 11      

				{
					throw new OffAppOrLoginException(response: error);
				}
				case ErrorCode.ImpossibleToCompileCode: // Error 12

				{
					throw new ImpossibleToCompileCodeException(response: error);
				}
				case ErrorCode.ErrorExecutingCode: // Error 13

				{
					throw new ErrorExecutingCodeException(response: error);
				}
				case ErrorCode.CaptchaNeeded: // Error 14

				{
					throw new CaptchaNeededException(response: error);
				}
				case ErrorCode.CannotBlacklistYourself: // Error 15

				{
					throw new CannotBlacklistYourselfException(response: error);
				}
				case ErrorCode.NeedHttps: // Error 16

				{
					throw new NeedHttpsException(response: error);
				}
				case ErrorCode.NeedValidationOfUser: // Error 17

				{
					throw new NeedValidationException(response: error);
				}
				case ErrorCode.UserDeletedOrBanned: // Error 18

				{
					throw new UserDeletedOrBannedException(response: error);
				}
				case ErrorCode.ContentDenied: // Error 19

				{
					throw new ContentDeniedException(response: error);
				}
				case ErrorCode.NonStandaloneApplications: // Error 20

				{
					throw new NonStandaloneApplicationsException(response: error);
				}
				case ErrorCode.OnlySandaloneOrOpenApi: // Error 21

				{
					throw new OnlySandaloneOrOpenApiException(response: error);
				}
				case ErrorCode.LoadingError: // Error 22

				{
					throw new LoadingErrorException(response: error);
				}
				case ErrorCode.MethodHasBeenSwitchedOff: // Error 23

				{
					throw new MethodHasBeenSwitchedOffException(response: error);
				}
				case ErrorCode.ConfirmationUser: // Error 24   

				{
					throw new ConfirmationUserException(response: error);
				}
				case ErrorCode.GroupKeyInvalid: // Error 27   

				{
					throw new GroupKeyInvalidException(error: error);
				}
				case ErrorCode.AppKeyInvalid: // Error 28   

				{
					throw new AppKeyInvalidException(error: error);
				}
				case ErrorCode.RateLimitReached: // Error 29

				{
					throw new RateLimitReachedException(response: error);
				}
				case ErrorCode.ParameterMissingOrInvalid: // Error 100 

				{
					throw new ParameterMissingOrInvalidException(response: error);
				}
				case ErrorCode.InvalidAppId: // Error 101     

				{
					throw new InvalidAppIdException(response: error);
				}
				case ErrorCode.OutOfLimits: // Error 103

				{
					throw new OutOfLimitsException(response: error);
				}
				case ErrorCode.InvalidUserId: // Error 113

				{
					throw new InvalidUserIdException(response: error);
				}
				case ErrorCode.InvalidServer: // Error 118

				{
					throw new InvalidServerException(response: error);
				}
				case ErrorCode.InvalidParameter: // Error 120

				{
					throw new InvalidParameterException(response: error);
				}
				case ErrorCode.InvalidHash: // Error 121

				{
					throw new InvalidHashException(response: error);
				}
				case ErrorCode.InvalidGroupId: // Error 125

				{
					throw new InvalidGroupIdException(response: error);
				}
				case ErrorCode.AccessToMenuDenied: // Error 148

				{
					throw new AccessToMenuDeniedException(response: error);
				}
				case ErrorCode.InvalidTimestamp: // Error 150

				{
					throw new InvalidTimestampException(response: error);
				}
				case ErrorCode.UserAccessDenied: // Error 170

				{
					throw new UserAccessDeniedException(response: error);
				}
				case ErrorCode.ListIdInvalid: // Error 171

				{
					throw new ListIdInvalidException(response: error);
				}
				case ErrorCode.ListAmountMaximum: // Error 173

				{
					throw new ListAmountMaximumException(response: error);
				}
				case ErrorCode.CannotAddYourself: // Error 174

				{
					throw new CannotAddYourselfException(response: error);
				}
				case ErrorCode.CannotAddYouBlacklisted: // Error 175

				{
					throw new CannotAddYouBlacklistedException(response: error);
				}
				case ErrorCode.CannotAddUserBlacklisted: // Error 176

				{
					throw new CannotAddUserBlacklistedException(response: error);
				}
				case ErrorCode.CannotAddUserNotFound: // Error 177

				{
					throw new CannotAddUserNotFoundException(response: error);
				}
				case ErrorCode.AlbumAccessDenied: // Error 200

				{
					throw new AlbumAccessDeniedException(response: error);
				}
				case ErrorCode.AudioAccessDenied: // Error 201

				{
					throw new AudioAccessDeniedException(response: error);
				}
				case ErrorCode.GroupAccessDenied: // Error 203

				{
					throw new GroupAccessDeniedException(response: error);
				}
				case ErrorCode.VideoAccessDenied: // Error 204

				{
					throw new VideoAccessDeniedException(response: error);
				}
				case ErrorCode.PostAccessDenied: // Error 210

				{
					throw new PostAccessDeniedException(response: error);
				}
				case ErrorCode.CommentsWallAccessDenied: // Error 211

				{
					throw new CommentsWallAccessDeniedException(response: error);
				}
				case ErrorCode.CommentsPostAccessDenied: // Error 212

				{
					throw new CommentsPostAccessDeniedException(response: error);
				}
				case ErrorCode.AccessToCommentDenied: // Error 213

				{
					throw new AccessToCommentDeniedException(response: error);
				}
				case ErrorCode.AccessToAddingPostDenied: // Error 214

				{
					// Access to adding post denied: you can only add 50 posts a day.
					throw new PostLimitException(response: error);
				}
				case ErrorCode.AdsRecentlyPosted: // Error 219

				{
					throw new AdsRecentlyPostedException(response: error);
				}
				case ErrorCode.StatusAccessDenied: // Error 220

				{
					throw new StatusAccessDeniedException(response: error);
				}
				case ErrorCode.UserDisabledTrackNameBroadcast: // Error 221

				{
					throw new UserDisabledTrackNameBroadcastException(response: error);
				}
				case ErrorCode.PostLinksDenied: // Error 222

				{
					throw new PostLinksDeniedException(response: error);
				}
				case ErrorCode.CommentsLimitReached: // Error 223

				{
					throw new CommentsLimitReachedException(response: error);
				}
				case ErrorCode.ToomanyAdsPosts: // Error 224

				{
					throw new TooManyAdsPostsException(response: error);
				}
				case ErrorCode.GroupsListAccessDenied: // Error 260  

				{
					throw new GroupsListAccessDeniedException(response: error);
				}
				case ErrorCode.AlbumIsFull: // Error 300

				{
					throw new AlbumIsFullException(response: error);
				}
				case ErrorCode.VideoAlbumIsFull: // Error 302

				{
					throw new VideoAlbumIsFullException(response: error);
				}
				case ErrorCode.PermissionDenied: // Error 500

				{
					// Permission denied. You must enable votes processing in application settings.
					throw new AccessDeniedException(response: error);
				}
				case ErrorCode.AdsAccessDenied: // Error 600

				{
					throw new AdsAccessDeniedException(response: error);
				}
				case ErrorCode.ErrorWorkWithAds: // Error 603

				{
					throw new ErrorWorkWithAdsException(response: error);
				}
				case ErrorCode.VideoAlreadyAdded: // Error 800

				{
					throw new VideoAlreadyAddedException(response: error);
				}
				case ErrorCode.VideoCommentsClosed: // Error 801

				{
					throw new VideoCommentsClosedException(response: error);
				}
				case ErrorCode.CannotSendBlacklisted: // Error 900

				{
					throw new CannotSendBlacklistedException(response: error);
				}
				case ErrorCode.CannotSendToUserFirstly: // Error 901

				{
					throw new CannotSendToUserFirstlyException(response: error);
				}
				case ErrorCode.CannotSendDuePrivacy: // Error 902

				{
					throw new CannotSendDuePrivacyException(response: error);
				}
				case ErrorCode.TooMuchSentMessages: // Error 913

				{
					throw new TooMuchSentMessagesException(response: error);
				}
				case ErrorCode.MessageIsTooLong: // Error 914

				{
					throw new MessageIsTooLongException(response: error);
				}
				default:

				{
					throw new VkApiException(response: error);
				}
			}
		}
	}
}