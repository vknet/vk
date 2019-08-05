using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Права токена
	/// </summary>
	[Serializable]
	public class TokenPermissionsResult
	{
		/// <summary>
		/// Битовая масска
		/// </summary>
		[JsonProperty("mask")]
		public long Mask { get; set; }

		/// <summary>
		/// Права доступа
		/// </summary>
		[JsonProperty("permissions")]
		public ReadOnlyCollection<TokenPermission> Permissions { get; set; }
	}
}