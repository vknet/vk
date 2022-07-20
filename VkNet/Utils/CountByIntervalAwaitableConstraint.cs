using System;
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
		private int _count;

		private TimeSpan _timeSpan;

		private int _left;

		private DateTime _dateTime;

		private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

		/// <inheritdoc />
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="CountByIntervalAwaitableConstraint" /> class
		/// with default values.
		/// </summary>
		public CountByIntervalAwaitableConstraint() : this(3, TimeSpan.FromSeconds(1))
		{
		}

		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="CountByIntervalAwaitableConstraint" /> class,
		/// specifying the maximum number of requests per time interval.
		/// </summary>
		/// <param name="number">
		/// Maximum <paramref name="number" /> times per <paramref name="timeSpan" />.
		/// </param>
		/// <param name="timeSpan">
		/// Time interval.
		/// </param>
		/// <exception cref="ArgumentException">
		/// The <paramref name="number" /> and <paramref name="timeSpan" /> should be
		/// strictly positive.
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
			_left = number;
			_timeSpan = timeSpan;
		}

		/// <inheritdoc />
		public async Task<IDisposable> WaitForReadinessAsync(CancellationToken cancellationToken)
		{
			await _semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);

			if ((DateTime.Now - _dateTime) >= _timeSpan)
			{
				_left = _count;
				_dateTime = DateTime.Now;
			}

			if (_left > 0)
			{
				_left--;
			}
			else
			{
				var timeToWait = (int)Math.Ceiling((_timeSpan - (DateTime.Now - _dateTime)).TotalMilliseconds + 15);

				try
				{
					await Task.Delay(timeToWait, cancellationToken).ConfigureAwait(false);
				}
				catch { }

				_left = _count - 1;
				_dateTime = DateTime.Now;
			}

			_semaphore.Release();
			return new DisposableAction(() =>
			{
			});
		}

		/// <inheritdoc />
		public void SetRate(int number, TimeSpan timeSpan)
		{
			_count = number;
			_left = number;
			_timeSpan = timeSpan;
		}
	}
}