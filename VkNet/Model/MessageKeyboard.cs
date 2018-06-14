using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Объект клавиатуры, отправляемой ботом.
	/// </summary>
	[Serializable]
	[JsonObject(MemberSerialization.OptOut)]
	public class MessageKeyboard
    {
		/// <summary>
		/// Скрыть клавиатуру сразу же после нажатия на кнопку.
		/// </summary>
		[JsonProperty(propertyName: "one_time")]
		public bool OneTime { get; set; }

		/// <summary>
		/// Массив кнопок отправляемых ботом, размером до 4х10
		/// </summary>
		[JsonProperty(propertyName: "buttons")]
		public ReadOnlyCollection<ReadOnlyCollection<MessageKeyboardButton>> Buttons { get; set; }
		
	    /// <summary>
	    /// Разобрать из json.
	    /// </summary>
	    /// <param name="response"> Ответ сервера. </param>
	    /// <returns> </returns>
	    public static MessageKeyboard FromJson(VkResponse response)
	    {
		    return new MessageKeyboard
		    {
			    OneTime = response[key: "one_time"]
				,
			    Buttons = response[key: "buttons"]
				    .ToReadOnlyCollectionOf(
					    x => x.ToReadOnlyCollectionOf<MessageKeyboardButton>(y => y))
		    };
		}
    }
}
