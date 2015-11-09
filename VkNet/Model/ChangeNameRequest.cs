using System;
using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model
{
    using System;

    [Serializable]
	/// <summary>
	/// Информация о заявке на смену имени.
	/// </summary>
	public class ChangeNameRequest
	{
		/// <summary>
		/// Идентификатор заявки, необходимый для её отмены (только если <see cref="ChangeNameRequest.Status"/> равен <see cref="ChangeNameStatus.Processing"/>)
		/// </summary>
		public int? Id { get; set; }

		/// <summary>
		/// Статус заявки
		/// </summary>
		public ChangeNameStatus? Status { get; set; }

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

		internal static ChangeNameRequest FromJson(VkResponse response)
		{
			var request = new ChangeNameRequest();

			request.Id = response["id"];
			request.FirstName = response["first_name"];
			request.LastName = response["last_name"];
			
			//TODO: проверить на реальном аккаунте, так ли расположены эти поля в ответе
			request.Status = ParseStatus(response["status"]);
			request.RepeatDate = response["repeat_date"];

			return request;
		}									

		private static ChangeNameStatus? ParseStatus(string status)
		{
			if (string.IsNullOrEmpty(status))
				return null;
			switch (status)
			{
				case "success":
					return ChangeNameStatus.Success;
				case "processing":
					return ChangeNameStatus.Processing;
				case "declined":
					return ChangeNameStatus.Declined;
				case "was_accepted":
					return ChangeNameStatus.WasAccepted;
				case "was_declined":
					return ChangeNameStatus.WasDeclined;
				default:
					throw new ArgumentException(string.Format("Enum value {0} not defined!", status), "status");
			}
		}

		#endregion

	}
}