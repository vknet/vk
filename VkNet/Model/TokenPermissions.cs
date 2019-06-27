using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Права токена
	/// </summary>
	[Serializable]
	public class TokenPermissions
	{
		/// <summary>
		/// Битовая масска
		/// </summary>
		[JsonProperty("mask")]
		public long Mask { get; set; }

		/// <summary>
		/// Права доступа
		/// </summary>
		[JsonProperty("settings")]
		public ReadOnlyCollection<SettingItem> Settings { get; set; }
	}
}