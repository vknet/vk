// DO NOT EDIT THIS FILE CAUSE ALL CHANGES WILL BE DELETED AUTOMATICALLY

using VkNet.Model;
using VkNet.Model.Attachments;

namespace VkNet.Utils;

public partial class VkResponse
{
	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator Attachment(VkResponse response) => response?._token == null || !response._token.HasValues
		? null
		: Attachment.FromJson(response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator Group(VkResponse response) => response?._token == null || !response._token.HasValues
		? null
		: Group.FromJson(response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator Market(VkResponse response) => response?._token == null || !response._token.HasValues
		? null
		: Market.FromJson(response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator PushSettings(VkResponse response) => response?._token == null || !response._token.HasValues
		? null
		: PushSettings.FromJson(response);

	/// <summary>
	/// Преобразовать из VkResponse
	/// </summary>
	/// <param name="response"> Ответ. </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator User(VkResponse response) => response?._token == null || !response._token.HasValues
		? null
		: User.FromJson(response);
}