using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Владельцы настроек приватности
	/// </summary>
	[Serializable]
	public class PrivacyOwners
	{
		/// <summary>
		/// Список id пользователей, которым разрешен доступ
		/// </summary>
		[JsonProperty("allowed")]
		public ReadOnlyCollection<ulong> Allowed { get; set; }

		/// <summary>
		/// Список id пользователей, которым запрещен доступ
		/// </summary>
		[JsonProperty("excluded")]
		public ReadOnlyCollection<ulong> Excluded { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">
		/// Ответ сервера.
		/// </param>
		/// <returns></returns>
		public static PrivacyOwners FromJson(VkResponse response)
		{
			return new PrivacyOwners
			{
				Allowed = response["allowed"].ToReadOnlyCollectionOf<ulong>(x => x),
				Excluded = response["excluded"].ToReadOnlyCollectionOf<ulong>(x => x)
			};
		}

		/// <summary>
		/// Преобразовать в строку.
		/// </summary>
		public override string ToString()
		{
			var allowed = Allowed?.Select(x => (long) x) ?? Enumerable.Empty<long>();
			var excluded = Excluded?.Select(x => -(long) x) ?? Enumerable.Empty<long>();
			return string.Join(",", allowed.Concat(excluded));
		}

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator PrivacyOwners(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}
	}
}