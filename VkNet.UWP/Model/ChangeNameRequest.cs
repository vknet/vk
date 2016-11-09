using VkNet.Utils;
using System.Runtime.Serialization;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model
{
    /// <summary>
    /// Информация о заявке на смену имени.
    /// </summary>
    [DataContract]
    public class ChangeNameRequest
	{
		/// <summary>
		/// Идентификатор заявки, необходимый для её отмены (только если <see cref="ChangeNameRequest.Status"/> равен <see cref="ChangeNameStatus.Processing"/>)
		/// </summary>
		public int? Id { get; set; }

		/// <summary>
		/// Статус заявки
		/// </summary>
		public ChangeNameStatus Status { get; set; }

		/// <summary>
		/// Дата, после которой возможна повторная подача заявки.
		/// </summary>
		public string RepeatDate { get; set; }

		/// <summary>
		/// Имя пользователя, указанное в заявке
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Фамилия пользователя, указанная в заявке.
		/// </summary>
		public string LastName { get; set; }

		#region Методы
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		public static ChangeNameRequest FromJson(VkResponse response)
		{
			var request = new ChangeNameRequest
			{
				Id = response["id"],
				FirstName = response["first_name"],
				LastName = response["last_name"],
				Status = response["status"],
				RepeatDate = response["repeat_date"]
			};

			return request;
		}
        
		#endregion

	}
}