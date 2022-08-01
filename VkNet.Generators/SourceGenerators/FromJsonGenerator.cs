using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace VkNet.Generators.SourceGenerators;

[Generator]
public class FromJsonGenerator : ISourceGenerator
{
	private const string ClassDefinition = @" // Auto-generated code
using System;
using VkNet.Utils;

namespace {0}
{{
    public  partial class {1}
    {{
        public static {2} FromJson(VkResponse response)
		{{
			return new {3}
			{{
				{4}
			}};
		}}
    }}
}}
";

	private const string PropertyDeclaration = "{0} = response[\"{1}\"],";

	private const string PropertyReadonlyCollection = "{0} = response[\"{1}\"].ToReadOnlyCollectionOf<{2}>(),";

	private const string PropertyReadonlyCollectionWithLambda = "{0} = response[\"{1}\"].ToReadOnlyCollectionOf<{2}>(x => x),";

	private const string PropertyVkCollection = "{0} = response[\"{1}\"].ToVkCollectionOf<{2}>(x => x),";

	public void Initialize(GeneratorInitializationContext context)
	{
	}

	public void Execute(GeneratorExecutionContext context)
	{
		var models =
			context.Compilation
				.SyntaxTrees
				.SelectMany(syntaxTree => syntaxTree.GetRoot().DescendantNodes())
				.Where(x => x is ClassDeclarationSyntax)
				.Cast<ClassDeclarationSyntax>()
				.Where(GetPartialModels)
				.Where(GetSerializableModels)
				.Where(NotHaveMethodFromJson)
				.ToImmutableList();

		foreach (var model in models)
		{
			var fields = GetAllProperties(model);
			var newClass = CreateNewPartialClassWithFromJsonMethod(model, fields);

			context.AddSource(model.Identifier.ValueText + ".g.cs",
				newClass.Item2);
		}
	}

	private (ClassDeclarationSyntax, string) CreateNewPartialClassWithFromJsonMethod(
		ClassDeclarationSyntax model, IEnumerable<(string PropertyName, string AttributeArgument, string PropertyType)> properties)
	{
		var className = model.Identifier.ValueText;
		var namespaceName = GetFullNamespace(model);
		var fieldDeclaration = GetPropertyDeclarations(properties);

		return (model, string.Format(ClassDefinition,
			namespaceName,
			className,
			className,
			className,
			fieldDeclaration));
	}

	private string GetPropertyDeclarations(IEnumerable<(string PropertyName, string AttributeArgument, string PropertyType)> properties)
	{
		var fieldDeclaration = new StringBuilder();

		foreach (var (propertyName, attributeArgument, type) in properties)
		{
			string baseExpression;
			string baseType;

			if (type.Contains("ReadOnlyCollection") || type.Contains("IEnumerable"))
			{
				var typeName = GetTypeFromGeneric(type);

				baseExpression = typeName[0] == char.ToLower(typeName[0])
					? PropertyReadonlyCollectionWithLambda
					: PropertyReadonlyCollection;

				baseType = typeName;
			} else if (type.Contains("VkCollection"))
			{
				baseExpression = PropertyVkCollection;
				baseType = GetTypeFromGeneric(type);
			} else
			{
				baseExpression = PropertyDeclaration;
				baseType = type;
			}

			fieldDeclaration.AppendFormat(baseExpression,
				propertyName,
				attributeArgument,
				baseType);
		}

		return fieldDeclaration.ToString();
	}

	public static string GetTypeFromGeneric(string type)
	{
		var localType = type.Split('<')[1].Replace(">", string.Empty);

		return localType;
	}

	/// <summary>
	/// Get all fields with JsonProperty attribute
	/// </summary>
	/// <param name="model">  </param>
	/// <returns>pairs from field name and JsonProperty annotation argument</returns>
	private IEnumerable<(string PropertyName, string AttributeArgument, string PropertyType)> GetAllProperties(TypeDeclarationSyntax model)
	{
		var dict = new List<(string, string, string)>();
		var properties = model.Members.OfType<PropertyDeclarationSyntax>();

		foreach (var property in properties)
		{
			var attributeArgument = property.AttributeLists.First()
				.Attributes.First(x => x.Name.ToString() == "JsonProperty")
				.ArgumentList?.Arguments.First()
				.Expression.DescendantTokens()
				.First()
				.Text.Replace("\"", string.Empty);

			if (attributeArgument == null)
			{
				continue;
			}

			var propertyType = property.Type.ToString();
			var propertyName = property.Identifier.ValueText;
			dict.Add((propertyName, attributeArgument, propertyType));
		}

		return dict;
	}

	/// <summary>
	/// Check that model don't have method FromJson
	/// </summary>
	/// <param name="arg"></param>
	/// <returns></returns>
	private bool NotHaveMethodFromJson(ClassDeclarationSyntax arg)
	{
		return !arg.Members.Any(x =>
			x.Kind() == SyntaxKind.MethodDeclaration && ((MethodDeclarationSyntax) x).Identifier.ValueText != "FromJSON");
	}

	private bool GetSerializableModels(ClassDeclarationSyntax arg)
	{
		return arg.AttributeLists.First().Attributes.Any(x => x.Name.ToString() == "Serializable");
	}

	private static bool GetPartialModels(ClassDeclarationSyntax x)
	{
		return GetFullName(x).Contains("Model") && x.Modifiers.Any(m => m.ValueText == "partial");
	}

	public const string NESTED_CLASS_DELIMITER = "+";

	public const string NAMESPACE_CLASS_DELIMITER = ".";

	public static string GetFullNamespace(ClassDeclarationSyntax source)
	{
		var items = new List<string>();
		var parent = source.Parent;

		while (parent.IsKind(SyntaxKind.ClassDeclaration))
		{
			var parentClass = parent as ClassDeclarationSyntax;
			items.Add(parentClass.Identifier.Text);

			parent = parent.Parent;
		}

		var nameSpace = parent as NamespaceDeclarationSyntax;

		return nameSpace.Name.ToString();
	}

	public static string GetFullName(ClassDeclarationSyntax source)
	{
		var items = new List<string>();
		var parent = source.Parent;

		while (parent.IsKind(SyntaxKind.ClassDeclaration))
		{
			var parentClass = parent as ClassDeclarationSyntax;
			items.Add(parentClass.Identifier.Text);

			parent = parent.Parent;
		}

		var nameSpace = parent as NamespaceDeclarationSyntax;
		var sb = new StringBuilder().Append(nameSpace.Name).Append(NAMESPACE_CLASS_DELIMITER);
		items.Reverse();

		items.ForEach(i =>
		{
			sb.Append(i).Append(NESTED_CLASS_DELIMITER);
		});

		sb.Append(source.Identifier.Text);

		var result = sb.ToString();

		return result;
	}
}