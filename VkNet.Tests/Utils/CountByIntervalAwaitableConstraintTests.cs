using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using VkNet.Utils;
using Xunit;

namespace VkNet.Tests.Utils;

public class CountByIntervalAwaitableConstraintTests
{
	[Fact]
	public async Task WaitForReadinessAsync()
	{
		const int count = 3;
		var t = TimeSpan.FromSeconds(1);
		var awaitableConstraint = new CountByIntervalAwaitableConstraint(count, t);
		var token = new CancellationTokenSource().Token;
		var sw = Stopwatch.StartNew();

		for (var i = 0; i < count; i++)
		{
			await awaitableConstraint.WaitForReadinessAsync(token);
		}

		await awaitableConstraint.WaitForReadinessAsync(token);

		var t2 = sw.Elapsed;

		t2.Should()
			.BeGreaterThanOrEqualTo(t);
	}
}