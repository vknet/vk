namespace VkNet.Enums.SafetyEnums
{
	/// <summary>
	/// Статус транскрипции голосового сообщения
	/// </summary>
	public sealed class TranscriptStates : SafetyEnum<TranscriptStates>
	{
		/// <summary>
		/// Транскрипция в обработке
		/// </summary>
		public static readonly TranscriptStates InProgress = RegisterPossibleValue(value: "in_progress");

		/// <summary>
		/// Транскрипция завершена
		/// </summary>
		public static readonly TranscriptStates Done = RegisterPossibleValue(value: "done");
	}
}