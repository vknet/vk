﻿namespace VkNet.Utils
{
    using System;
    using System.Linq.Expressions;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using Exception;

    internal static class VkErrors
    {
        public static void ThrowIfNullOrEmpty(Expression<Func<string>>  expr)
        {
            var body = expr.Body as MemberExpression;
            if (body != null)
            {
                var paramName = body.Member.Name;
                var value = expr.Compile()();

                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(paramName);
            }
        }

        public static void ThrowIfNumberNotInRange<T>(T value, T min, T max) where T : struct, IComparable<T>
        {
            if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
                throw new ArgumentOutOfRangeException();
        }

        public static void ThrowIfNumberIsNegative(Expression<Func<long?>> expr)
        {
            var result = ThrowIfNumberIsNegative<Func<long?>>(expr);

            var name = result.Item1;
            var value = result.Item2();

            if (value.HasValue && value < 0) throw new ArgumentException("Отрицательное значение.", name);
        }

        public static void ThrowIfNumberIsNegative(Expression<Func<long>> expr)
        {
            var result = ThrowIfNumberIsNegative<Func<long>>(expr);

            var name = result.Item1;
            var value = result.Item2();

            if (value < 0) throw new ArgumentException("Отрицательное значение.", name);
        }

        private static Tuple<string, T> ThrowIfNumberIsNegative<T>(Expression<T> expr)
        {
            if (expr == null)
                throw new ArgumentNullException("expr");

            var name = string.Empty;

            // Если значение передатеся из вызывающего метода
            var unary = expr.Body as UnaryExpression;
            if (unary != null)
            {
                var member = unary.Operand as MemberExpression;
                if (member != null)
                {
                    name = member.Member.Name;
                }
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
                return;

            var code = (int)response["error_code"];
            var message = (string)response["error_msg"];

            switch (code)
            {
                case 14:
                    var sid = Convert.ToInt64((string)response["captcha_sid"]);
                    var img = Convert.ToString(response["captcha_img"]);
                    throw new CaptchaNeededException(sid, img);

                case 5:
                    throw new UserAuthorizationFailException(message, code);

                case 4: // Incorrect signature.
                case 113: // Invalid user id.
                case 125: // Invalid group id.
                case 100: // One of the parameters specified was missing or invalid.
                case 120: // Invalid message.
                    throw new InvalidParameterException(message, code);

                case 6: // Too many requests per second.
                    throw new TooManyRequestsException(message, code);

                case 7: // Permission to perform this action is denied by user.
				case 15: // Access denied: 1) groups list of this user are under privacy.	2) cannot blacklist yourself
				case 148: // Access to the menu of the user denied
                case 170: // Access to user's friends list denied.
                case 201: // Access denied.
                case 203: // Access to the group is denied.
                case 220: // Access to status denied.
                case 221: // User disabled track name broadcast.
                case 260: // Access to the groups list is denied due to the user's privacy settings.
                case 500: // Permission denied. You must enable votes processing in application settings.
                    throw new AccessDeniedException(message, code);
                case 214: // Access to adding post denied: you can only add 50 posts a day.
                    throw new PostLimitException(message);
/*
                case 1: // Unknown error occurred.
                case 2: // Application is disabled. Enable your application or use test mode.
                case 10: // Internal server error.
                case 103: // Out of limits.
                case 202:
 */
                default:
                    throw new VkApiException(message);
            }
        }
    }
}