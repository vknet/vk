using System;
using System.Linq;
using System.Runtime.Serialization;
using JetBrains.Annotations;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception;

/// <summary>
/// Базовый класс для всех исключений, выбрасываемых библиотекой.
/// </summary>
[Serializable]
public class VkApiException : System.Exception
{
	/// <summary>
	/// Инициализирует новый экземпляр класса VkApiException
	/// </summary>
	public VkApiException()
	{
	}

	/// <inheritdoc />
	protected VkApiException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext) : base()
	{

	}

	/// <summary>
	/// Инициализирует новый экземпляр класса VkApiException
	/// </summary>
	/// <param name="message"> Описание исключения. </param>
	public VkApiException(string message) : base(message: message)
	{
	}

	/// <summary>
	/// Инициализирует новый экземпляр класса VkApiException
	/// </summary>
	public VkApiException(VkError error) : base(error.ErrorMessage)
	{
		ErrorCode = error.ErrorCode;
		RequestParams = new(error.RequestParams.ToDictionary(x => x.Key, v => v.Value));
	}

	/// <summary>
	/// Инициализирует новый экземпляр класса VkApiException
	/// </summary>
	/// <param name="response"> Ответ от сервера vk </param>
	public VkApiException(VkResponse response) : base(message: response[key: "error_msg"]) => ErrorCode = response[key: "error_code"];

	/// <summary>
	/// Инициализирует новый экземпляр класса InvalidParameterException
	/// </summary>
	/// <param name="message"> Описание исключения. </param>
	/// <param name="innerException"> Внутреннее исключение. </param>
	public VkApiException(string message, System.Exception innerException) : base(message, innerException)
	{
	}

	/// <inheritdoc />
	[UsedImplicitly]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
	}

	/// <summary>
	/// Код ошибки
	/// </summary>
	public int ErrorCode { get; internal set; }

	/// <summary>
	/// Параметры запроса
	/// </summary>
	public VkParameters RequestParams { get; set; }
}