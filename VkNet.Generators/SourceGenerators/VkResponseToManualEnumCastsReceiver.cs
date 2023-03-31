using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace VkNet.SourceGenerator
{
	public class VkResponseToManualEnumCastsReceiver : ISyntaxReceiver
	{
		private const string VkNetIgnoreDefaultValue = "VkNetIgnoreDefaultValue";

		private const string VkNetDefaultValue = "VkNetDefaultValue";

		private const string VkNetEnumsNamespace = "VkNet.Enums";

		public Dictionary<string, string> CandidateClasses { get; } = new();

		public List<string> CandidateUsingList { get; } = new();

		/// <inheritdoc />
		public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
		{
			if (syntaxNode is EnumDeclarationSyntax enumDeclarationSyntax
				&& enumDeclarationSyntax.AttributeLists.SelectMany(al => al.Attributes)
					.All(x => x.Name.ToString() != $"{VkNetIgnoreDefaultValue}Attribute" && x.Name.ToString() != VkNetIgnoreDefaultValue)
				&& enumDeclarationSyntax.ChildNodes()
					.OfType<EnumMemberDeclarationSyntax>()
					.Any(x =>
						x.AttributeLists.SelectMany(al => al.Attributes)
							.Any(x => x.Name.ToString() == $"{VkNetDefaultValue}Attribute"
									|| x.Name.ToString() == VkNetDefaultValue))
				&& SyntaxNodeHelper.TryGetParentSyntax<NamespaceDeclarationSyntax>(enumDeclarationSyntax,
					out var namespaceDeclarationSyntax)
				&& namespaceDeclarationSyntax.Name.ToString().StartsWith(VkNetEnumsNamespace)
			)

			{
				var namespaceName = namespaceDeclarationSyntax.Name.ToString();

				if (!CandidateUsingList.Contains(namespaceName))
				{
					CandidateUsingList.Add(namespaceName);
				}

				var enumName = enumDeclarationSyntax.Identifier.Text;

				var field = enumDeclarationSyntax.ChildNodes()
					.OfType<EnumMemberDeclarationSyntax>()
					.FirstOrDefault(x =>
						x.AttributeLists.SelectMany(al => al.Attributes)
							.Any(x => x.Name.ToString() == $"{VkNetDefaultValue}Attribute"
									|| x.Name.ToString() == VkNetDefaultValue));

				if (field == null)
				{
					CandidateClasses.Add(enumName, string.Empty);

					return;
				}

				if (!CandidateClasses.ContainsKey(enumName))
				{
					CandidateClasses.Add(enumName, field.Identifier.Text);
				}
			}
		}
	}
}