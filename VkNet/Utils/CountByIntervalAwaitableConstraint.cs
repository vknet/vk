using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions.Core;

namespace VkNet.Utils
{
	/// <summary>
	/// Represents the behavior for the constraint.
	/// </summary>
	public class CountByIntervalAwaitableConstraint : IAwaitableConstraint
	{
		private readonly LimitedSizeStack<DateTime> _timeStamps;

		private int _count;

		private TimeSpan _timeSpan;
	#if NET40
		private readonly AsyncSemaphoreSlim _semaphore = new AsyncSemaphoreSlim(1);
	#else
		private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
	#endif

		private readonly object _sync = new object();

		/// <summary>
		/// Initializes a new instance of the <see cref="CountByIntervalAwaitableConstraint"/> class
		/// with default values.
		/// </summary>
		public CountByIntervalAwaitableConstraint()
		{
			_count = 3;
			_timeSpan = TimeSpan.FromSeconds(1);
			_timeStamps = new LimitedSizeStack<DateTime>(_count);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CountByIntervalAwaitableConstraint"/> class,
		/// specifying the maximum number of requests per time interval.
		/// </summary>
		/// <param name="number">
		/// Maximum <paramref name="number"/> times per <paramref name="timeSpan"/>.
		/// </param>
		/// <param name="timeSpan">
		/// Time interval.
		/// </param>
		/// <exception cref="ArgumentException">
		/// The <paramref name="number"/> and <paramref name="timeSpan"/> should be strictly positive.
		/// </exception>
		public CountByIntervalAwaitableConstraint(int number, TimeSpan timeSpan)
		{
			if (number <= 0)
			{
				throw new ArgumentException("count should be strictly positive", nameof(number));
			}

			if (timeSpan.TotalMilliseconds <= 0)
			{
				throw new ArgumentException("timeSpan should be strictly positive", nameof(timeSpan));
			}

			_count = number;
			_timeSpan = timeSpan;
			_timeStamps = new LimitedSizeStack<DateTime>(_count);
		}

		/// <inheritdoc />
		public async Task<IDisposable> WaitForReadiness(CancellationToken cancellationToken)
		{
			await _semaphore.WaitAsync(cancellationToken);
			var count = 0;
			var now = DateTime.Now;
			var target = now - _timeSpan;

			LinkedListNode<DateTime> element = _timeStamps.First,
				last = null;

			while (element?.Value > target)
			{
				last = element;
				element = element.Next;
				count++;
			}

			if (count < _count)
			{
				return new DisposableAction(OnEnded);
			}

			var timeToWait = last.Value.Add(_timeSpan) - now;

			try
			{
			#if NET40
				await TaskEx.Delay(timeToWait, cancellationToken);
			#else
				await Task.Delay(timeToWait, cancellationToken);
			#endif
			}
			catch (System.Exception)
			{
				_semaphore.Release();

				throw;
			}

			return new DisposableAction(OnEnded);
		}

		/// <inheritdoc />
		public void SetRate(int number, TimeSpan timeSpan)
		{
			lock (_sync)
			{
				_count = number;
				_timeSpan = timeSpan;
			}
		}

		private void OnEnded()
		{
			var now = DateTime.Now;
			_timeStamps.Push(now);
			_semaphore.Release();
		}
	}
}