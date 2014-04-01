namespace VkNet.Utils.Tests
{
    using NUnit.Framework;

    public static class TestExtensions
    {
         public static void ShouldBeTrue(this bool source)
         {
             Assert.That(source, Is.True);
         }

        public static void ShouldBeFalse(this bool source)
        {
            Assert.That(source, Is.False);
        }

        public static T ShouldBeNull<T>(this T obj) where T : class
        {
            Assert.That(obj, Is.Null);
            return obj;
        }

        public static T ShouldNotBeNull<T>(this T obj) where T : class
        {
            Assert.That(obj, Is.Not.Null);
            return obj;
        }

        public static T ShouldEqual<T>(this T actual, T expected)
        {
            Assert.That(actual, Is.EqualTo(expected));
            return actual;
        }
    }
}