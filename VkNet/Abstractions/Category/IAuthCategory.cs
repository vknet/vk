using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IAuthCategoryAsync" />
	public interface IAuthCategory : IAuthCategoryAsync
	{
		/// <inheritdoc cref="IAuthCategoryAsync.CheckPhoneAsync"/>
		bool CheckPhone(string phone, string clientSecret, long? clientId = null, bool? authByPhone = null);

		/// <inheritdoc cref="IAuthCategoryAsync.SignupAsync"/>
		string Signup(AuthSignupParams @params);

		/// <inheritdoc cref="IAuthCategoryAsync.ConfirmAsync"/>
		AuthConfirmResult Confirm(AuthConfirmParams @params);

		/// <inheritdoc cref="IAuthCategoryAsync.RestoreAsync"/>
		string Restore(string phone, string lastName);
	}
}