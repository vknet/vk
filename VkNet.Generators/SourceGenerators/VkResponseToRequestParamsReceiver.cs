using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace VkNet.SourceGenerator
{
	public class VkResponseToRequestParamsReceiver : ISyntaxReceiver
	{
		private const string Namespace = "VkNet.Model.RequestParams";

		public List<string> CandidateClasses { get; } = new();

		public List<string> CandidateUsingList { get; } = new();

		/// <inheritdoc />
		public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
		{
			if (syntaxNode is ClassDeclarationSyntax { TypeParameterList: null } classDeclarationSyntax
				&& classDeclarationSyntax.ChildNodes().OfType<MethodDeclarationSyntax>().Any(x => x.Identifier.Text == "FromJson")
				&& SyntaxNodeHelper.TryGetParentSyntax<NamespaceDeclarationSyntax>(classDeclarationSyntax,
					out var namespaceDeclarationSyntax)
				&& namespaceDeclarationSyntax.Name.ToString().StartsWith(Namespace))
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