using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using VkNet.Enums;
using VkNet.Exception;

namespace VkNet.Infrastructure.Authorization.ImplicitFlow
{
	/// <inheritdoc />
	public class AuthorizationFormFactory : IAuthorizationFormFactory
	{
		[NotNull]
		private readonly IEnumerable<IAuthorizationForm> _authorizationForms;

		/// <inheritdoc />
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