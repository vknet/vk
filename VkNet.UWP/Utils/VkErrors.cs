﻿using System;
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
		/// <param name="expr">Выражение.</param>
		/// <exception cref="System.ArgumentNullException">Параметр не должен быть равен null</exception>
		public static void ThrowIfNullOrEmpty(Expression<Func<string>> expr)
		{
			var body = expr.Body as MemberExpression;
			if (body == null)
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
		/// <typeparam name="T">Тип данных</typeparam>
		/// <param name="value">Значение.</param>
		/// <param name="min">Минимальное значение.</param>
		/// <param name="max">Максимальное значение.</param>
		/// <exception cref="System.ArgumentOutOfRangeException">Значение {value} не должно выходить за пределы диапозона [{min}, {max}]</exception>
		public static void ThrowIfNumberNotInRange<T>(T value, T min, T max) where T : struct, IComparable<T>
		{
			if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
			{
				throw new ArgumentOutOfRangeException($@"Значение {value} не должно выходить за пределы диапозона [{min}, {max}]");
			}
		}

		/// <summary>
		/// Ошибка если число отрицательное.
		/// </summary>
		/// <param name="expr">Выражение.</param>
		/// <exception cref="System.ArgumentException">Отрицательное значение.</exception>
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
		/// <param name="expr">Выражение.</param>
		/// <exception cref="System.ArgumentException">Отрицательное значение.</exception>
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
		/// <typeparam name="T">Тип данных</typeparam>
		/// <param name="expr">Выражение.</param>
		/// <returns>Результат проверки</returns>
		/// <exception cref="System.ArgumentNullException">Выражение не может быть равно null</exception>
		private static Tuple<string, T> ThrowIfNumberIsNegative<T>(Expression<T> expr)
		{
			if (expr == null)
			{
				throw new ArgumentNullException(nameof(expr), "Выражение не может быть равно null");
			}

			var name = string.Empty;

			// Если значение передатеся из вызывающего метода
			var unary = expr.Body as UnaryExpression;
			var member = unary?.Operand as MemberExpression;

			if (member != null)
			{
				name = member.Member.Name;
			}

			// Если в метод передается значение напрямую
			var body = expr.Body as MemberExpression;
			if (body != null)
			{
				name = body.Member.Name;
			}

			var func = expr.Compile();

			return new Tuple<string, T>(name, func);
		}

		/// <summary>
		/// Ошибки VK.
		/// </summary>
		/// <param name="json">JSON.</param>
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

			var code = (int)response["error_code"];

			switch (code)
			{
				case ErrorCode.CaptchaNeeded:
					{
						throw new CaptchaNeededException(error);
					}
				case ErrorCode.NeedValidationOfUser:
					{
						throw new NeedValidationException(error);
					}
				case ErrorCode.AuthorizationFailed:
					{
						throw new UserAuthorizationFailException(error);
					}

				case ErrorCode.InvalidSignature:
				case ErrorCode.InvalidUserId:
				case ErrorCode.InvalidGroupId:
				case ErrorCode.ParameterMissingOrInvalid:
				case ErrorCode.InvalidParameter:
					{
						throw new InvalidParameterException(error);
					}
				case ErrorCode.TooManyRequestsPerSecond:
					{
						throw new TooManyRequestsException(error);
					}
				case ErrorCode.PermissionToPerformThisAction:
				case ErrorCode.CannotBlacklistYourself:
				case ErrorCode.AccessToMenuDenied:
				case ErrorCode.UserAccessDenied:
				case ErrorCode.CannotAddYourself:
					{
						throw new CannotAddYourselfException(error);
					}
                case ErrorCode.CannotAddYouBlacklisted:
                    {
                        throw new CannotAddYouBlacklistedException(error);
                    }
                case ErrorCode.CannotAddUserBlacklisted:
                    {
                        throw new CannotAddUserBlacklistedException(error);
                    }
                case ErrorCode.CannotAddUserNotFound:
                    {
                        throw new CannotAddUserNotFoundException(error);
                    }
                case ErrorCode.AudioAccessDenied:
				case ErrorCode.GroupAccessDenied:
				case ErrorCode.StatusAccessDenied:
				case ErrorCode.UserDisabledTrackNameBroadcast:
				case ErrorCode.GroupsListAccessDenied:
				case ErrorCode.PermissionDenied:
					{
						// Permission denied. You must enable votes processing in application settings.
						throw new AccessDeniedException(error);
					}
				case ErrorCode.AccessToAddingPostDenied:
					{
						// Access to adding post denied: you can only add 50 posts a day.
						throw new PostLimitException(error);
					}
				case ErrorCode.OutOfLimits:
					{
						throw new OutOfLimitsException(error);
					}
				default:
					{
						throw new VkApiException(error);
					}
			}
		}
	}
}