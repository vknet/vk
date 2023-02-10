using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Вариант ответа в опросе
/// </summary>
[Serializable]
public class PollAnswer
{
	/// <summary>
	/// Идентификатор варианта ответа
	/// </summary>
	[JsonProperty("id")]
	public long? Id { get; set; }

	/// <summary>
	/// Текст ответа
	/// </summary>
	[JsonProperty("text")]
	public string Text { get; set; }

	/// <summary>
	/// Кол-во проголосовавших
	/// </summary>
	[JsonProperty("votes")]
	public int? Votes { get; set; }

	/// <summary>
	/// Процент текущего ответа ко всем остальным вариантам
	/// </summary>
	[JsonProperty("rate")]
	public double? Rate { get; set; }

	/// <summary>
	/// Разобрать из json.
	/// </summary>
	/// <param name="response"> Ответ сервера. </param>
	/// <returns> </returns>
	public static PollAnswer FromJson(VkResponse response)
	{
		var answer = new PollAnswer
		{
			Id = response[key: "id"],
			Text = response[key: "text"],
			Votes = response[key: "votes"],
			Rate = response[key: "rate"]
		};

		return answer;
	}
}