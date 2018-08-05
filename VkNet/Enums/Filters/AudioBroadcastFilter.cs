namespace VkNet.Enums.Filters
{
	/// <summary>
	/// Определяет, какие типы объектов необходимо получить.
	/// </summary>
	public sealed class AudioBroadcastFilter : MultivaluedFilter<AudioBroadcastFilter>
	{
		/// <summary>
		/// Только друзья.
		/// </summary>
		public static readonly AudioBroadcastFilter Friends = RegisterPossibleValue(value: "friends");
		/// <summary>
		/// Только сообщества.
		/// </summary>
		public static readonly AudioBroadcastFilter Groups = RegisterPossibleValue(value: "groups");
		/// <summary>
		/// Друзья и сообщества.
		/// </summary>
		public static readonly AudioBroadcastFilter All = RegisterPossibleValue(value: "all");
	}
}