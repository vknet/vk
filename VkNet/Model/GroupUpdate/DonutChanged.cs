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
	public class DonutChanged : IGroupUpdate
	{
		/// <summary>
		/// Идентификатор пользователя
		/// </summary>
		public long? UserId { get; set; }

		/// <summary>
		/// Старая цена в рублях
		/// </summary>
		public int? AmountOld { get; set; }

		/// <summary>
		/// Новая цена в рублях
		/// </summary>
		public int? AmountNew { get; set; }

		/// <summary>
		/// Сумма доплаты в рублях
		/// </summary>
		public float? AmountDiff { get; set; }

		/// <summary>
		/// Cумма доплаты без комиссии (в рублях)
		/// </summary>
		public float? AmountDiffWithoutFee { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		public static DonutChanged FromJson(VkResponse response)
		{
			var groupJoin = JsonConvert.DeserializeObject<DonutChanged>(response.ToString(), JsonConfigure.JsonSerializerSettings);
			groupJoin.UserId = response["user_id"];
			groupJoin.AmountOld = response["amount_old"];
			groupJoin.AmountNew = response["amount_new"];
			groupJoin.AmountDiff = response["amount_diff"];
			groupJoin.AmountDiffWithoutFee = response["amount_diff_without_fee"];

			return groupJoin;
		}

		/// <summary>
		/// Преобразование класса <see cref="DonutChanged" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> Результат преобразования в <see cref="DonutChanged" /> </returns>
		public static implicit operator DonutChanged(VkResponse response)
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
