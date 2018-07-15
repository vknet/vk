using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VkNet.Exception;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Вызов методов VkApi
	/// </summary>
	public interface IVkApiInvoke
	{
		/// <summary>
		/// Время вызова последнего метода этим объектом
		/// </summary>
		DateTimeOffset? LastInvokeTime { get; }

		/// <summary>
		/// Время, прошедшее с момента последнего обращения к API этим объектом
		/// </summary>
		TimeSpan? LastInvokeTimeSpan { get; }

		/// <summary>
		/// Вызвать метод.
		/// </summary>
		/// <param name="methodName"> Название метода. </param>
		/// <param name="parameters"> Параметры. </param>
		/// <param name="skipAuthorization"> Если <c> true </c> то пропустить авторизацию. </param>
		/// <returns> </returns>
		VkResponse Call(string methodName, VkParameters parameters, bool skipAuthorization = false);

		/// <summary>
		/// Вызвать метод.
		/// </summary>
		/// <param name="methodName"> Название метода. </param>
		/// <param name="parameters"> Параметры. </param>
		/// <param name="skipAuthorization"> Если <c> true </c> то пропустить авторизацию. </param>
		/// <param name="jsonConverters"> JsonConverters </param>
		/// <returns> </returns>
		T Call<T>(string methodName, VkParameters parameters, bool skipAuthorization = false, params JsonConverter[] jsonConverters);

		/// <summary>
		/// Вызвать метод.
		/// </summary>
		/// <param name="methodName"> Название метода. </param>
		/// <param name="parameters"> Параметры. </param>
		/// <param name="skipAuthorization"> Если <c> true </c> то пропустить авторизацию. </param>
		/// <returns> </returns>
		Task<VkResponse> CallAsync(string methodName, VkParameters parameters, bool skipAuthorization = false);

		/// <summary>
		/// Вызвать метод.
		/// </summary>
		/// <param name="methodName"> Название метода. </param>
		/// <param name="parameters"> Параметры. </param>
		/// <param name="skipAuthorization"> Если <c> true </c> то пропустить авторизацию. </param>
		/// <returns> </returns>
		Task<T> CallAsync<T>(string methodName, VkParameters parameters, bool skipAuthorization = false);

		/// <summary>
		/// Прямой вызов API-метода
		/// </summary>
		/// <param name="methodName"> Название метода. Например, "wall.get". </param>
		/// <param name="parameters"> Вход. параметры метода. </param>
		/// <param name="skipAuthorization">
		/// Флаг, что метод можно вызывать без
		/// авторизации.
		/// </param>
		/// <exception cref="AccessTokenInvalidException"> </exception>
		/// <returns> Ответ сервера в формате JSON. </returns>
		string Invoke(string methodName, IDictionary<string, string> parameters, bool skipAuthorization = false);

		/// <summary>
		/// Прямой вызов API-метода в асинхронном режиме
		/// </summary>
		/// <param name="methodName"> Название метода. Например, "wall.get". </param>
		/// <param name="parameters"> Вход. параметры метода. </param>
		/// <param name="skipAuthorization">
		/// Флаг, что метод можно вызывать без
		/// авторизации.
		/// </param>
		/// <returns> Ответ сервера в формате JSON. </returns>
		Task<string> InvokeAsync(string methodName, IDictionary<string, string> parameters, bool skipAuthorization = false);
	}
}