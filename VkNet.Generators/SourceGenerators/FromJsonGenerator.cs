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

	/// <inheritdoc />
	public void Initialize(GeneratorInitializationContext context)
	{
	}

	/// <inheritdoc />
	public void Execute(GeneratorExecutionContext context)
	{
		var models =
			context.Compilation
				.SyntaxTrees
				.SelectMany(syntaxTree => syntaxTree.GetRoot()
					.DescendantNodes())
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

	private static string GetTypeFromGeneric(string type)
	{
		var localType = type.Split('<')[1]
			.Replace(">", string.Empty);

		return localType;
	}

	/// <summary>
	/// Получить все поля с атрибутом JsonProperty
	/// </summary>
	/// <param name="model"> Модель </param>
	/// <returns>
	/// Пары из имени поля и аргумента аннотации JsonProperty
	/// </returns>
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
	/// Убедитесь, что у модели нет метода FromJson
	/// </summary>
	/// <param name="arg"> Объявление класса </param>
	/// <returns>
	/// true, если у модели нет метода FromJson
	/// </returns>
	private bool NotHaveMethodFromJson(ClassDeclarationSyntax arg) => !arg.Members.Any(x =>
		x.Kind() == SyntaxKind.MethodDeclaration && ((MethodDeclarationSyntax) x).Identifier.ValueText != "FromJSON");

	private bool GetSerializableModels(ClassDeclarationSyntax arg) => arg.AttributeLists.First()
		.Attributes.Any(x => x.Name.ToString() == "Serializable");

	private static bool GetPartialModels(ClassDeclarationSyntax x) => GetFullName(x)
																		.Contains("Model")
																	&& x.Modifiers.Any(m => m.ValueText == "partial");

	private const string NestedClassDelimiter = "+";

	private const string NamespaceClassDelimiter = ".";

	private static string GetFullNamespace(SyntaxNode source)
	{
		var items = new List<string>();
		var parent = source.Parent;

		while (parent.IsKind(SyntaxKind.ClassDeclaration))
		{
			var parentClass = parent as ClassDeclarationSyntax;

			if (parentClass?.Identifier.Text != null)
			{
				items.Add(parentClass.Identifier.Text);
			}

			parent = parent.Parent;
		}

		var nameSpace = parent as NamespaceDeclarationSyntax;

		return nameSpace?.Name.ToString() ?? string.Empty;
	}

	private static string GetFullName(BaseTypeDeclarationSyntax source)
	{
		var items = new List<string>();
		var parent = source.Parent;

		while (parent.IsKind(SyntaxKind.ClassDeclaration))
		{
			var parentClass = parent as ClassDeclarationSyntax;

			if (parentClass?.Identifier.Text != null)
			{
				items.Add(parentClass.Identifier.Text);
			}

			parent = parent.Parent;
		}

		var nameSpace = parent as NamespaceDeclarationSyntax;

		var sb = new StringBuilder().Append(nameSpace?.Name)
			.Append(NamespaceClassDelimiter);

		items.Reverse();

		items.ForEach(i =>
		{
			sb.Append(i)
				.Append(NestedClassDelimiter);
		});

		sb.Append(source.Identifier.Text);

		var result = sb.ToString();

		return result;
	}
}