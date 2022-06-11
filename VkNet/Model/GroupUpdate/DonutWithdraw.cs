using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;
using VkNet.Infrastructure;
using VkNet.Utils;

namespace VkNet.Model.GroupUpdate
{
	/// <summary>
	/// Добавление участника или заявки на вступление в сообщество
	/// </summary>
	[Serializable]
	public class DonutWithdraw : IGroupUpdate
	{
		/// <summary>
		/// Произошла ли ошибка
		/// </summary>
		public bool Error { get; set; }

		/// <summary>
		/// Cумма  в рублях
		/// </summary>
		public float? Amount { get; set; }

		/// <summary>
		/// Cумма  без комиссии (в рублях)
		/// </summary>
		public float? AmountWithoutFee { get; set; }

		/// <summary>
		/// Причина ошибки
		/// </summary>
		public string Reason { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static DonutWithdraw FromJson(VkResponse response)
		{
			var groupJoin = JsonConvert.DeserializeObject<DonutWithdraw>(response.ToString(), JsonConfigure.JsonSerializerSettings);

			groupJoin.Amount = response["amount"];
			groupJoin.AmountWithoutFee = response["amount_without_fee"];

			groupJoin.Reason = response["reason"];
			groupJoin.Error = !string.IsNullOrEmpty(groupJoin.Reason);

			return groupJoin;
		}

		/// <summary>
		/// Преобразование класса <see cref="DonutWithdraw" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> Результат преобразования в <see cref="DonutWithdraw" /> </returns>
		public static implicit operator DonutWithdraw(VkResponse response)
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
