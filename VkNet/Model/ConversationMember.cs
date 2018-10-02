using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VkNet.Model
{
	/// <summary>
	/// Члены обсуждения
	/// </summary>
	[Serializable]
	public class ConversationMember
	{
		/// <summary>
		/// Идентификатор участника беседы
		/// </summary>
		[JsonProperty("member_id")]
		public long MemberId { get; set; }

		/// <summary>
		/// Идентификатор пользователя, который пригласил участника;
		/// </summary>
		[JsonProperty("invited_by")]
		public long InvitedBy { get; set; }

		/// <summary>
		/// Дата добавления в беседу;
		/// </summary>
		[JsonProperty("join_date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime JoinDate { get; set; }

		/// <summary>
		/// Является ли пользователь администратором
		/// </summary>
		[JsonProperty("is_admin")]
		public bool IsAdmin { get; set; }

		/// <summary>
		/// Может ли текущий пользователь исключить участника.
		/// </summary>
		[JsonProperty("can_kick")]
		public bool CanKick { get; set; }
	}
}