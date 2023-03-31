using Microsoft.CodeAnalysis;

namespace VkNet.SourceGenerator
{
	public static class SyntaxNodeHelper
	{
		public static bool TryGetParentSyntax<T>(SyntaxNode syntaxNode, out T result)
			where T : SyntaxNode
		{
			// set defaults
			result = null;

			if (syntaxNode == null)
			{
				return false;
			}

			try
			{
				syntaxNode = syntaxNode.Parent;

				if (syntaxNode == null)
				{
					return false;
				}

				if (syntaxNode.GetType() != typeof(T))
				{
					return TryGetParentSyntax(syntaxNode, out result);
				}

				result = syntaxNode as T;

				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}