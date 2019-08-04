using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если действие разрешено только для
	/// Standalone и Open API приложений.
	/// Код ошибки - 21
	/// </summary>
	[Serializable]
	public sealed class OnlyStandaloneOrOpenApiException : VkApiMethodInvokeException
	{
		/// <inheritdoc />
		public OnlyStandaloneOrOpenApiException(VkError response) : base(response)
		{
		}

		/// <inheritdoc />
		internal override int ErrorCode => VkErrorCode.OnlySandaloneOrOpenApi;
	}
}