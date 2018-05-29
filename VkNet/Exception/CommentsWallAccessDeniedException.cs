using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, которое выбрасывается, если доступ к комментариям на стене
	/// запрещен.
	/// Код ошибки - 211
	/// </summary>
	[Serializable]
	public class CommentsWallAccessDeniedException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса CommentsWallAccessDeniedException
		/// </summary>
		public CommentsWallAccessDeniedException()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса CommentsWallAccessDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		public CommentsWallAccessDeniedException(string message) : base(message: message)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса CommentsWallAccessDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="innerException"> Внутреннее исключение. </param>
		public CommentsWallAccessDeniedException(string message, System.Exception innerException) : base(message: message
				, innerException: innerException)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса CommentsWallAccessDeniedException
		/// </summary>
		/// <param name="message"> Описание исключения. </param>
		/// <param name="code"> Код ошибки, полученный от сервера ВКонтакте. </param>
		public CommentsWallAccessDeniedException(string message, int code) : base(message: message, code: code)
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public CommentsWallAccessDeniedException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
		}
	}
}