using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Обобщенная модель ответа vk
	/// </summary>
	/// <typeparam name="TModel">Тип ответа</typeparam>
	[Serializable]
	public class VkResponseObject<TModel>
	{

		[JsonProperty("response")]
		public TModel Response { get; set; }
	}
}