using System.Threading;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class AuthCategory
{
	/// <inheritdoc />
	public Task<bool> CheckPhoneAsync(string phone,
									string clientSecret,
									long? clientId = null,
									bool? authByPhone = null,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CheckPhone(phone, clientSecret, clientId, authByPhone), token);

	/// <inheritdoc />
	public Task<string> SignupAsync(AuthSignupParams @params,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Signup(@params), token);

	/// <inheritdoc />
	public Task<AuthConfirmResult> ConfirmAsync(AuthConfirmParams @params,
												CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Confirm(@params), token);

	/// <inheritdoc />
	public Task<string> RestoreAsync(string phone,
									string lastName,
									CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Restore(phone, lastName), token);
}