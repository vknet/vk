using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Новая запись на стене (<c>WallPost</c>, <c>WallRepost</c>)
/// (<c>Post</c> с дополнительными полями)
/// </summary>
[Serializable]
public class WallPost : Post, IGroupUpdate
{
	/// <summary>
	/// <c>Id</c> отложенной записи
	/// </summary>
	[JsonProperty("postponed_id")]
	public long? PostponedId { get; set; }
}