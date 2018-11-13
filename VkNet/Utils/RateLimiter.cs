using System;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions.Core;

namespace VkNet.Utils
{
	/// <summary>
	/// Represents a client-side rate limiting utility.
	/// </summary>
	public class RateLimiter : IRateLimiter
	{
		private readonly IAwaitableConstraint _awaitableConstraint;

		/// <summary>
		/// Initializes a new instance of the <see cref="RateLimiter"/> class,
		/// specifying the behavior for the constraint.
		/// </summary>
		/// <param name="awaitableConstraint">
		/// The behavior that will be used for the constraint.
		/// </param>
		public RateLimiter(IAwaitableConstraint awaitableConstraint)
		{
			_awaitableConstraint = awaitableConstraint;
		}

		/// <inheritdoc />
		public Task Perform(Func<Task> perform)
		{
			return Perform(perform, CancellationToken.None);
		}

		/// <inheritdoc />
		public Task<T> Perform<T>(Func<Task<T>> perform)
		{
			return Perform(perform, CancellationToken.None);
		}

		/// <inheritdoc />
		public async Task Perform(Func<Task> perform, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			using (await _awaitableConstraint.WaitForReadiness(cancellationToken))
			{
				await perform();
			}
		}

		/// <inheritdoc />
		public async Task<T> Perform<T>(Func<Task<T>> perform, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			using (await _awaitableConstraint.WaitForReadiness(cancellationToken))
			{
				return await perform();
			}
		}

		/// <inheritdoc />
		public Task Perform(Action perform, CancellationToken cancellationToken)
		{
			var transformed = Transform(perform);

			return Perform(transformed, cancellationToken);
		}

		/// <inheritdoc />
		public Task Perform(Action perform)
		{
			var transformed = Transform(perform);

			return Perform(transformed);
		}

		/// <inheritdoc />
		public Task<T> Perform<T>(Func<T> perform)
		{
			var transformed = Transform(perform);

			return Perform(transformed);
		}

		/// <inheritdoc />
		public Task<T> Perform<T>(Func<T> perform, CancellationToken cancellationToken)
		{
			var transformed = Transform(perform);

			return Perform(transformed, cancellationToken);
		}

		/// <inheritdoc />
		public void SetRate(int number, TimeSpan timeSpan)
		{
			_awaitableConstraint.SetRate(number, timeSpan);
		}

		/// <summary>
		/// Performs a transformation.
		/// </summary>
		/// <param name="act">
		/// The action.
		/// </param>
		/// <returns>
		/// Transformed function.
		/// </returns>
		private static Func<Task> Transform(Action act)
		{
			return () =>
			{
				act();
			#if NET40
				return TaskEx.FromResult(0);
			#else
				return Task.FromResult(0);
			#endif
			};
		}

		/// <summary>
		/// Performs a transformation.
		/// </summary>
		/// <param name="compute">
		/// The func.
		/// </param>
		/// <returns>
		/// Transformed function.
		/// </returns>
		private static Func<Task<T>> Transform<T>(Func<T> compute)
		{
			return () =>
			{
			#if NET40
				return TaskEx.FromResult(compute());
			#else
				return Task.FromResult(compute());
			#endif
			};
		}
	}
}