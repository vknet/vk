namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Падеж.
	/// </summary>
	public sealed class NameCase : SafetyEnum<NameCase>
	{
		/// <summary>
		/// Именительный.
		/// </summary>
		public static readonly NameCase Nom = RegisterPossibleValue(value: "nom");

		/// <summary>
		/// Родительный.
		/// </summary>
		public static readonly NameCase Gen = RegisterPossibleValue(value: "gen");

		/// <summary>
		/// Дательный.
		/// </summary>
		public static readonly NameCase Dat = RegisterPossibleValue(value: "dat");

		/// <summary>
		/// Винительный.
		/// </summary>
		public static readonly NameCase Acc = RegisterPossibleValue(value: "acc");

		/// <summary>
		/// Творительный.
		/// </summary>
		public static readonly NameCase Ins = RegisterPossibleValue(value: "ins");

		/// <summary>
		/// Предложный.
		/// </summary>
		public static readonly NameCase Abl = RegisterPossibleValue(value: "abl");
	}
}