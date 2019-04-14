using System;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Неизвестное вложение
	/// </summary>
	[Serializable]
	public class UnknownAttachment : MediaAttachment
	{
		/// <inheritdoc />
		protected override string Alias => nameof(UnknownAttachment);

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static UnknownAttachment FromJson(VkResponse response)
		{
			return new UnknownAttachment
			{
				Id = response["id"]
			};
		}

		/// <summary>
		/// Преобразование класса <see cref="MoneyTransfer" /> в <see cref="VkParameters" />
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns>Результат преобразования в <see cref="MoneyTransfer" /></returns>
		public static implicit operator UnknownAttachment(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}
	}
}