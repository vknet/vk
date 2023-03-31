using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace VkNet.SourceGenerator
{
	public class VkResponseToSafetyEnumCastReceiver : ISyntaxReceiver
	{
		private const string SafetyEnum = "SafetyEnum";

		private const string Namespace = "VkNet.Enums.SafetyEnum";

		public List<string> CandidateClasses { get; } = new();

		public List<string> CandidateUsingList { get; } = new();

		/// <inheritdoc />
		public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
		{
			if (syntaxNode is ClassDeclarationSyntax { BaseList: {} } classDeclarationSyntax
				&& SyntaxNodeHelper.TryGetParentSyntax<NamespaceDeclarationSyntax>(classDeclarationSyntax,
					out var namespaceDeclarationSyntax)
				&& namespaceDeclarationSyntax.Name.ToString().StartsWith(Namespace)
				&& !classDeclarationSyntax.BaseList.IsMissing
				&& classDeclarationSyntax.BaseList.Types.Any(x =>
					x.Type is GenericNameSyntax syntax
					&& syntax.IsKind(SyntaxKind.GenericName)
					&& syntax.Identifier.Text == SafetyEnum)
			)
			{
				var namespaceName = namespaceDeclarationSyntax.Name.ToString();

				if (!CandidateUsingList.Contains(namespaceName))
				{
					CandidateUsingList.Add(namespaceName);
				}

				CandidateClasses.Add(classDeclarationSyntax.Identifier.Text);
			}
		}
	}
}