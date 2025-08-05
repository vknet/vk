using System;

namespace VkNet.Infrastructure;

/// <summary>
/// An empty scope without any logic
/// </summary>
internal sealed class NullScope : IDisposable
{
	/// <summary>
	/// Initializes a new instance of the
	/// </summary>
	public static NullScope Instance { get; } = new();

	private NullScope()
	{
	}

	/// <inheritdoc />
	public void Dispose()
	{
	}
}