using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class AuthCategory
	{
		/// <inheritdoc />
		public Task<bool> CheckPhoneAsync(string phone, string clientSecret, long? clientId = null, bool? authByPhone = null)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>
					CheckPhone(phone: phone, clientSecret: clientSecret, clientId: clientId, authByPhone: authByPhone));
		}

		/// <inheritdoc />
		public Task<string> SignupAsync(AuthSignupParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Signup(@params: @params));
		}

		/// <inheritdoc />
		public Task<AuthConfirmResult> ConfirmAsync(AuthConfirmParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Confirm(@params: @params));
		}

		/// <inheritdoc />
		public Task<string> RestoreAsync(string phone, string lastName)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () =>Restore(phone: phone, lastName: lastName));
		}
	}
}