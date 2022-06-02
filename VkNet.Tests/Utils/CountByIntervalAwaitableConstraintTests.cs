using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using VkNet.Utils;

namespace VkNet.Tests.Utils
{
	public class CountByIntervalAwaitableConstraintTests
	{
		[Test]
		public async Task WaitForReadinessAsync()
		{
			int count = 3;
			var t = TimeSpan.FromSeconds(1);
			var awaitableConstraint = new CountByIntervalAwaitableConstraint(count, t);
			var token = new CancellationTokenSource().Token;
			var sw = Stopwatch.StartNew();
			for (int i = 0; i < count; i++)
			{
				await awaitableConstraint.WaitForReadinessAsync(token).ConfigureAwait(false);
			}

			await awaitableConstraint.WaitForReadinessAsync(token).ConfigureAwait(false);
			var t2 = sw.Elapsed;
			t.Should().BeGreaterThanOrEqualTo(t2);
		}
	}
}
