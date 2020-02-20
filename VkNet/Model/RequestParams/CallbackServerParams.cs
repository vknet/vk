using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using VkNet.Infrastructure;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры настройки уведомлений о событиях в Callback API.
	/// </summary>
	[Serializable]
	public class CallbackServerParams
	{
		/// <summary>
		/// идентификатор сообщества.
		/// </summary>
		[JsonProperty(propertyName: "group_id")]
		public ulong? GroupId { get; set; }

		/// <summary>
		/// идентификатор сервера.
		/// </summary>
		[JsonProperty(propertyName: "server_id")]
		public long? ServerId { get; set; }

		/// <summary>
		/// Версия Callback API.
		/// </summary>
		[JsonProperty(propertyName: "api_version")]
		public VkApiVersionManager ApiVersion { get; set; }

		/// <summary>
		/// Настройки уведомлений
		/// </summary>
		[JsonProperty(propertyName: "callback_settings")]
		public CallbackSettings CallbackSettings { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> </returns>
		public static VkParameters ToVkParameters(CallbackServerParams p)
		{
			VkParameters res = new VkParameters
			{
				{ "group_id", p.GroupId },
				{ "server_id", p.ServerId },
			};

			if (p.CallbackSettings != null)
			{
				var props = p.CallbackSettings.GetType().GetProperties();
				for (int i = 0; i < props.Length; i++)
				{
					JsonPropertyAttribute jsonAttr = props[i].GetCustomAttributes(typeof(JsonPropertyAttribute), true).FirstOrDefault() as JsonPropertyAttribute;
					if (jsonAttr != null)
					{
						var propVal = props[i].GetValue(p.CallbackSettings, null) as bool?;
						if (propVal.HasValue)
						{
							res.Add(jsonAttr.PropertyName, propVal.Value);
						}
					}
				}
			}

			if (p.ApiVersion != null)
			{
				res["api_version"] = p.ApiVersion.Version;
			}

			return res;
		}
	}
}