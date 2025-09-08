namespace VkNet.Exception;

/// <summary>
/// Ошибка устаревшей версии API
/// </summary>
/// <param name="message">Сообщение об ошибке</param>
public class VersionDeprecatedException(string message) : VkApiException(message);