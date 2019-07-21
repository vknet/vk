using System.Threading;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class AuthCategory : IAuthCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// Методы для работы с подарками.
		/// </summary>
		/// <param name="vk"> API. </param>
		public AuthCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public bool CheckPhone(string phone, string clientSecret, long? clientId = null, bool? authByPhone = null)
		{
			return CheckPhoneAsync(phone, clientSecret, clientId, authByPhone, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public string Signup(AuthSignupParams @params)
		{
			return SignupAsync(@params, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public AuthConfirmResult Confirm(AuthConfirmParams @params)
		{
			return ConfirmAsync(@params, CancellationToken.None).GetAwaiter().GetResult();
		}

		/// <inheritdoc />
		public string Restore(string phone, string lastName)
		{
			return RestoreAsync(phone, lastName, CancellationToken.None).GetAwaiter().GetResult();
		}
	}
}