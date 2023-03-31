using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace VkNet.Generators.Tests
{
	[UsedImplicitly]
	public abstract class BaseSourceGeneratorTests
	{
		protected static string GetVkNetRootDirectory()
		{
			return Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.ToString(), "VkNet");
		}

		[UsedImplicitly]
		protected static Compilation CreateCompilation(IEnumerable<string> sources,
														OutputKind outputKind = OutputKind.DynamicallyLinkedLibrary)
			=> CSharpCompilation.Create("compilation",
				sources.Select(x => CSharpSyntaxTree.ParseText(x, new CSharpParseOptions(LanguageVersion.Preview))),
				new[]
				{
					MetadataReference.CreateFromFile(Assembly.Load("System.Runtime").Location),
					MetadataReference.CreateFromFile(typeof(string).Assembly.Location),
					MetadataReference.CreateFromFile(typeof(UsedImplicitlyAttribute).Assembly.Location),
					MetadataReference.CreateFromFile(typeof(JsonProperty).Assembly.Location),
					MetadataReference.CreateFromFile(typeof(JsonConverter<>).Assembly.Location),
					MetadataReference.CreateFromFile(typeof(JsonConverter).Assembly.Location),
					MetadataReference.CreateFromFile(typeof(Regex).Assembly.Location),
					//MetadataReference.CreateFromFile(typeof(VkApi).Assembly.Location)
				},
				new CSharpCompilationOptions(outputKind));

		[UsedImplicitly]
		protected static GeneratorDriver CreateDriver(Compilation compilation, params ISourceGenerator[] generators) =>
			CSharpGeneratorDriver.Create(generators, parseOptions: (CSharpParseOptions) compilation.SyntaxTrees.First().Options);

		[UsedImplicitly]
		protected static Compilation RunGenerators(Compilation currentCompilation, out ImmutableArray<Diagnostic> diagnostics,
													params ISourceGenerator[] generators)
		{
			CreateDriver(currentCompilation, generators)
				.RunGeneratorsAndUpdateCompilation(currentCompilation, out var outputCompilation, out diagnostics);

			return outputCompilation;
		}
	}
}