using System;
using Newtonsoft.Json;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;
using VkNet.Enums.SafetyEnums;
namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Изменение настроек сообщества
	/// </summary>
	[Serializable]
    public class Change
    {
		/// <summary>
		/// Название секции или раздела, который был изменён
		/// </summary>
		[JsonProperty("{FIELD}")]
		public string Field { get; set; }

		/// <summary>
		/// Новое значение
		/// </summary>
		[JsonProperty("new_value")]
		public string NewValue { get; set; }

		/// <summary>
		/// Старое значение
		/// </summary>
		[JsonProperty("old_value")]
		public string OldValue { get; set; }

		#region Методы

		/// <summary>
		/// </summary>
		/// <param name="response"> </param>
		/// <returns> </returns>
		public static Change FromJson(VkResponse response)
		{
			var field = "";
			if(response["title"]!=null)
			field = "title";
			else if(response["description"]!=null)
			field = "description";
			else if(response["access"]!=null)
			field = "access";
			else if(response["screen_name"]!=null)
			field = "screen_name";
			else if(response["public_category"]!=null)
			field = "public_category";
			else if(response["age_limits"]!=null)
			field = "age_limits";
			else if(response["website"]!=null)
			field = "website";
			else if(response["public_subcategory"]!=null)
			field = "public_subcategory";

			else if(response["enable_status_default"]!=null)
			field = "enable_status_default";
			else if(response["enable_audio"]!=null)
			field = "enable_audio";
			else if(response["enable_photo"]!=null)
			field = "enable_photo";
			else if(response["enable_video"]!=null)
			field = "enable_video";
			else if(response["enable_market"]!=null)
			field = "enable_market";
			if(field!="")
			return new Change
			{
				Field = field,
				NewValue = response[field]["new_value"],
				OldValue = response[field]["old_value"]
			}; else return new Change
			{
				Field = field,
				NewValue = null,
				OldValue = null
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="Change" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="Change" /></returns>
		public static implicit operator Change(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}

		#endregion
    }
}