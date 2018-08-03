using Newtonsoft.Json;
using System;

namespace VkNet.Model
{
	/// <summary>
	/// Количество голосов
	/// </summary>
	[Serializable]
    public class VotesAmount
    {
		/// <summary>
		/// Количество голосов
		/// </summary>
		[JsonProperty(propertyName: "votes")]
		public string Votes { get; set; }

		/// <summary>
		/// Общая сумма голосов, переведённая в валюту
		/// </summary>
		[JsonProperty(propertyName: "amount")]
		public int Amount { get; set; }

		/// <summary>
		/// Описание общей суммы с наименованием валюты
		/// </summary>
		[JsonProperty(propertyName: "description")]
		public string Description { get; set; }

		/// <summary>
		/// Название валюты
		/// </summary>
		[JsonProperty(propertyName: "currency")]
		public string Currency { get; set; }
	}
}
