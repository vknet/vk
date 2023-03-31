using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace VkNet.SourceGenerator
{
	public class VkResponseToAttachmentsReceiver : ISyntaxReceiver
	{
		private const string MediaAttachment = "MediaAttachment";

		private const string AttachmentsNamespace = "VkNet.Model.Attachments";

		public List<string> CandidateClasses { get; } = new();

		public List<string> CandidateUsingList { get; } = new();

		/// <inheritdoc />
		public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
		{
			if (syntaxNode is ClassDeclarationSyntax { BaseList: {} } classDeclarationSyntax
				&& classDeclarationSyntax.ChildNodes().OfType<MethodDeclarationSyntax>().Any(x => x.Identifier.Text == "FromJson")
				&& !classDeclarationSyntax.BaseList.IsMissing
				&& classDeclarationSyntax.BaseList.Types.Any(x =>
					x.Type is IdentifierNameSyntax syntax
					&& syntax.Identifier.Text == MediaAttachment)
				&& SyntaxNodeHelper.TryGetParentSyntax<NamespaceDeclarationSyntax>(classDeclarationSyntax,
					out var namespaceDeclarationSyntax)
				&& namespaceDeclarationSyntax.Name.ToString().StartsWith(AttachmentsNamespace)
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