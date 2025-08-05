using System;
using Microsoft.Extensions.Logging;

namespace VkNet.Infrastructure;

/// <summary>
/// Minimalistic logger that does nothing.
/// </summary>
public class NullLogger : ILogger
{
	/// <summary>
	/// Returns an instance of <see cref="NullLogger" />.
	/// </summary>
	/// <returns> An instance of <see cref="NullLogger" />. </returns>
	public static readonly NullLogger Instance = new();

	/// <inheritdoc />
	public IDisposable BeginScope<TState>(TState state)
		where TState : notnull => NullScope.Instance;

	/// <inheritdoc />
	public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, System.Exception exception,
							Func<TState, System.Exception, string> formatter)
	{
	}

	/// <inheritdoc />
	public bool IsEnabled(LogLevel logLevel) => false;
}