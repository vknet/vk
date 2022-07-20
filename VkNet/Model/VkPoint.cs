using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Объект с двумя координатами точки x, y.
	/// </summary>
	[Serializable]
	public class VkPoint
	{
		/// <summary>
		/// x координата.
		/// </summary>
		[JsonProperty("x")]
		public int X { get; set; }

		/// <summary>
		/// y координата.
		/// </summary>
		[JsonProperty("y")]
		public int Y { get; set; }
	}
}