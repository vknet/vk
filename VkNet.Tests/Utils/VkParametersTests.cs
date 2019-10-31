﻿using System;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using VkNet.Utils;

namespace VkNet.Tests.Utils
{
	[TestFixture]
	[ExcludeFromCodeCoverage]
	public class VkParametersTests
	{
		[Test]
		public void AddNullableBoolean_FalseValue()
		{
			var @params = new VkParameters
			{
				{
					"NullableBoolean", false
				}
			};

			Assert.That(@params, Does.ContainKey("NullableBoolean"));
			var val = @params["NullableBoolean"];
			Assert.That(val, Is.EqualTo("0"));
		}

		[Test]
		public void AddNullableBoolean_NullValue()
		{
			var @params = new VkParameters
			{
				{
					"NullableBoolean", (bool?) null
				}
			};

			Assert.That(@params, Does.Not.ContainKey("NullableBoolean"));
		}

		[Test]
		public void AddNullableBoolean_TrueValue()
		{
			var @params = new VkParameters
			{
				{
					"NullableBoolean", true
				}
			};

			Assert.That(@params, Does.ContainKey("NullableBoolean"));
			var val = @params["NullableBoolean"];
			Assert.That(val, Is.EqualTo("1"));
		}

		[Test]
		public void AddDateTime()
		{
			var dateTimeNow = new DateTime(2019, 10, 31, 0, 21, 32, DateTimeKind.Utc);

			var @params = new VkParameters
			{
				{ "date_time", dateTimeNow }
			};

			Assert.DoesNotThrow(() =>
			{
				var value = @params["date_time"];
			});

			Assert.AreEqual("1572481292",  @params["date_time"]);
		}
	}
}