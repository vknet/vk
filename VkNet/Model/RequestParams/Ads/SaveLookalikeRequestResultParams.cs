﻿using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model.RequestParams.Ads
{
	/// <summary>
	///
	/// </summary>
	[Serializable]
	public class SaveLookalikeRequestResultParams
	{
		/// <summary>
		/// Идентификатор рекламного кабинета.
		/// </summary>
		[JsonProperty("account_id")]
		public long AccountId { get; set; }

		/// <summary>
		/// Идентификатор клиента, для которого будут сохраняться аудитория.
		/// </summary>
		[JsonProperty("client_id")]
		public long? ClientId { get; set; }

		/// <summary>
		/// Идентификатор запроса на поиск похожей аудитории.
		/// </summary>
		[JsonProperty("request_id")]
		public long RequestId { get; set; }

		/// <summary>
		/// Уровень конкретного размера похожей аудитории для сохранения.
		/// </summary>
		[JsonProperty("level")]
		public long Level { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(SaveLookalikeRequestResultParams p)
		{
			var parameters = new VkParameters
			{
				{ "account_id", p.AccountId }
				, { "client_id", p.ClientId }
				, { "request_id", p.RequestId }
				, { "level", p.Level }
			};

			return parameters;
		}
	}
}