using System.Runtime.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.SafetyEnums;

/// <inheritdoc />
public class StoryType : SafetyEnum<StoryType>
{
	/// <summary>
	/// Фотография
	/// </summary>
	[EnumMember(Value = "photo")]
	public static readonly StoryType Photo = RegisterPossibleValue("photo");

	/// <summary>
	/// Видеозапись
	/// </summary>
	[EnumMember(Value = "video")]
	public static readonly StoryType Video = RegisterPossibleValue("video");

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator StoryType(VkResponse response) => response != null && response.HasToken()
		? FromJson(response)
		: null;
}