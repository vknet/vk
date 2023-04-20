using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Права пользователя в рекламном кабинете.
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum AsrStatus
{
	/// <summary>
	/// Аудиозапись обрабатывается
	/// </summary>
	Processing,

	/// <summary>
	/// Обработка аудиозаписи закончена.
	/// </summary>
	Finished,

	/// <summary>
	/// Внутренние ошибки сервиса распознавания речи ВКонтакте.
	/// </summary>
	InternalError,

	/// <summary>
	/// Ошибка перекодирования аудиозаписи во внутренний формат.
	/// Попробуйте загрузить аудиозапись в другом поддерживаемом формате.
	/// </summary>
	TranscodingError ,

	/// <summary>
	/// Ошибка распознавания речи, сложности в распознавании.
	/// Попробуйте говорить чётче или снизить фоновые шумы.
	/// </summary>
	RecognitionError
}