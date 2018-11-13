using System;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions.Core;

namespace VkNet.Utils
{
	public class RateLimiter : IRateLimiter
	{
		private readonly IAwaitableConstraint _awaitableConstraint;

		public RateLimiter(IAwaitableConstraint awaitableConstraint)
		{
			_awaitableConstraint = awaitableConstraint;
		}

		public Task Perform(Func<Task> perform)
		{
			return Perform(perform, CancellationToken.None);
		}

		public Task<T> Perform<T>(Func<Task<T>> perform)
		{
			return Perform(perform, CancellationToken.None);
		}

		public async Task Perform(Func<Task> perform, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			using (await _awaitableConstraint.WaitForReadiness(cancellationToken))
			{
				await perform();
			}
		}

		public async Task<T> Perform<T>(Func<Task<T>> perform, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			using (await _awaitableConstraint.WaitForReadiness(cancellationToken))
			{
				return await perform();
			}
		}

		public Task Perform(Action perform, CancellationToken cancellationToken)
		{
			var transformed = Transform(perform);

			return Perform(transformed, cancellationToken);
		}

		public Task Perform(Action perform)
		{
			var transformed = Transform(perform);

			return Perform(transformed);
		}

		public Task<T> Perform<T>(Func<T> perform)
		{
			var transformed = Transform(perform);

			return Perform(transformed);
		}

		public Task<T> Perform<T>(Func<T> perform, CancellationToken cancellationToken)
		{
			var transformed = Transform(perform);

			return Perform(transformed, cancellationToken);
		}

		public void SetRate(int count, TimeSpan timeSpan)
		{
			_awaitableConstraint.SetRate(count, timeSpan);
		}

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