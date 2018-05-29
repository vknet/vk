using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// данные о профиле.
	/// </summary>
	[Serializable]
	public class SearchProfile
	{
		/// <summary>
		/// идентификатор пользователя
		/// </summary>
		[JsonProperty(propertyName: "id")]
		public long Id { get; set; }

		/// <summary>
		/// имя пользователя;
		/// </summary>
		[JsonProperty(propertyName: "first_name")]
		public string FirstName { get; set; }

		/// <summary>
		/// фамилия пользователя
		/// </summary>
		[JsonProperty(propertyName: "last_name")]
		public string LastName { get; set; }
	}
}