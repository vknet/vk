using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using VkNet.Exception;
using VkNet.Infrastructure.Authorization.ImplicitFlow.Forms;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	[UsedImplicitly]
	public sealed class AuthorizationFormFactory : IAuthorizationFormFactory
	{
		[NotNull]
		private readonly IEnumerable<IAuthorizationForm> _authorizationForms;

		/// <inheritdoc cref="AuthorizationFormFactory"/>
		public AuthorizationFormFactory([NotNull] IEnumerable<IAuthorizationForm> authorizationForms)
		{
			_authorizationForms = authorizationForms;
		}

		/// <inheritdoc />
		[NotNull]
		public IAuthorizationForm Create(ImplicitFlowPageType type)
		{
			return _authorizationForms.FirstOrDefault(x => x.GetPageType() == type) ?? throw new VkAuthorizationException();
		}
	}
}