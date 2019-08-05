using System;
using System.Linq;
using Newtonsoft.Json;
using VkNet.Model;

namespace VkNet.Utils
{
	/// <summary>
	/// Обработчик ошибок при вызове метода execute
	/// </summary>
	public static class ExecuteErrorsHandler
	{
		/// <summary>
		/// Получить <see cref="AggregateException" /> со всеми ошибками запроса execute
		/// </summary>
		/// <param name="response"> Json ответ </param>
		/// <returns> </returns>
		/// <exception cref="ArgumentException"> Параметр response должен иметь значение. </exception>
		public static AggregateException GetExecuteExceptions(string response)
		{
			if (string.IsNullOrWhiteSpace(response))
			{
				throw new ArgumentException($"{nameof(response)} should have value", nameof(response));
			}

			var executeErrorsResponse = JsonConvert.DeserializeObject<ExecuteErrorsResponse>(response);

			if (executeErrorsResponse?.ExecuteErrors == null)
			{
				return null;
			}

			var exceptionList = executeErrorsResponse.ExecuteErrors
				.Select(exception => VkErrorFactory.Create(new VkError
				{
					ErrorCode = exception.ErrorCode,
					ErrorMessage = exception.ErrorMessage,
					Method = exception.Method,
					RequestParams = exception.RequestParams
				}));

			return new AggregateException(exceptionList);
		}
	}
}