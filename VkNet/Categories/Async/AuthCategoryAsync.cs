using System.Threading;
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
		public async Task<bool> CheckPhoneAsync(string phone, string clientSecret, long? clientId = null, bool? authByPhone = null,
												CancellationToken cancellationToken = default)
		{
			var parameters = new VkParameters
			{
				{ "phone", phone },
				{ "client_id", clientId },
				{ "client_secret", clientSecret },
				{ "auth_by_phone", authByPhone }
			};

			return await _vk.CallAsync("auth.checkPhone", parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<string> SignupAsync(AuthSignupParams @params, CancellationToken cancellationToken = default)
		{
			return await _vk.CallAsync("auth.signup", @params, cancellationToken: cancellationToken).ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<AuthConfirmResult> ConfirmAsync(AuthConfirmParams @params, CancellationToken cancellationToken = default)
		{
			return await _vk.CallAsync("auth.confirm", @params, cancellationToken: cancellationToken).ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task<string> RestoreAsync(string phone, string lastName, CancellationToken cancellationToken = default)
		{
			var response = await _vk.CallAsync("auth.restore",
					new VkParameters
					{
						{ "phone", phone },
						{ "last_name", lastName }
					},
					cancellationToken: cancellationToken)
				.ConfigureAwait(false);

			return response[key: "sid"];
		}
	}
}