using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace VkNet.SourceGenerator
{
	public abstract class VkResponseImplicitGeneratorBase<TReceiver> : ISourceGenerator
		where TReceiver : ISyntaxReceiver, new()
	{
		protected TReceiver Receiver;

		/// <inheritdoc />
		public void Initialize(GeneratorInitializationContext context)
		{
			context.RegisterForSyntaxNotifications(() => new TReceiver());
		}

		/// <inheritdoc />
		public void Execute(GeneratorExecutionContext context)
		{
			if (context.SyntaxReceiver is not TReceiver receiver)
			{
				return;
			}

			Receiver = receiver;

			context.AddSource($"{GetType().Name}.g.cs", SourceText.From(GetSourceCode(), Encoding.UTF8));
		}

		protected abstract string GetSourceCode();
	}
}