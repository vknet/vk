using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	///
	/// </summary>
	[Serializable]
	public class Acl
	{
		/// <summary>
		///
		/// </summary>
		[JsonProperty("can_invite")]
		public bool CanInvite { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("can_change_info")]
		public bool CanChangeInfo { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("can_change_pin")]
		public bool CanChangePin { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("can_promote_users")]
		public bool CanPromoteUsers { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("can_see_invite_link")]
		public bool CanSeeInviteLink { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("can_change_invite_link")]
		public bool CanChangeInviteLink { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("can_moderate")]
		public bool CanModerate { get; set; }

		/// <summary>
		///
		/// </summary>
		[JsonProperty("can_copy_chat")]
		public bool CanCopyChat { get; set; }
	}
}