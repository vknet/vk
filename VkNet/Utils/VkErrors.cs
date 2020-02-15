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
		/// Ошибка если число не в диапазоне.
		/// </summary>
		/// <typeparam name="T"> Тип данных </typeparam>
		/// <param name="value"> Значение. </param>
		/// <param name="min"> Минимальное значение. </param>
		/// <param name="max"> Максимальное значение. </param>
		/// <exception cref="System.ArgumentOutOfRangeException">
		/// Значение {value} не должно выходить за пределы диапазона [{min},
		/// {max}]
		/// </exception>
		public static void ThrowIfNumberNotInRange<T>(T value, T min, T max)
			where T : struct, IComparable<T>
		{
			if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
			{
				throw new ArgumentOutOfRangeException($@"Значение {value} не должно выходить за пределы диапазона [{min}, {max}]");
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

			// Если значение передаётся из вызывающего метода
			var unary = expr.Body as UnaryExpression;

			if (unary?.Operand is MemberExpression member)
			{
				name = member.Member.Name;
			}

			// Если в метод передаётся значение напрямую
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

			if (!obj.TryGetValue("error", StringComparison.InvariantCulture, out var error))
			{
				return;
			}

			var vkError = JsonConvert.DeserializeObject<VkError>(error.ToString());

			if (vkError == null || vkError.ErrorCode == 0)
			{
				return;
			}

			throw VkErrorFactory.Create(vkError);
		}
	}
}