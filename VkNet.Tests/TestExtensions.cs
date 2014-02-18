using System;
using System.Reflection;
using NUnit.Framework;

namespace VkNet.Tests
{
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

    public class ExceptionAssert
    {
        /// <summary>Executes a method and asserts that the specified exception is thrown.</summary>
        /// <param name="exceptionType">The type of exception to expect.</param>
        /// <param name="method">The method to execute.</param>
        /// <returns>The thrown exception.</returns>
        public static System.Exception Throws(Type exceptionType, Action method)
        {
            try
            {
                method.Invoke();
            }
            catch (System.Exception ex)
            {
                Assert.AreEqual(exceptionType, ex.GetType());
                return ex;
            }
            Assert.Fail("Expected exception '" + exceptionType.FullName + "' wasn't thrown.");
            return null;
        }

        /// <summary>Executes a method and asserts that the specified exception is thrown.</summary>
        /// <typeparam name="T">The type of exception to expect.</typeparam>
        /// <param name="method">The method to execute.</param>
        /// <returns>The thrown exception.</returns>
        public static T Throws<T>(Action method)
            where T : System.Exception
        {
            try
            {
                method.Invoke();
            }
            catch (TargetInvocationException ex)
            {
                Assert.That(ex.InnerException, Is.TypeOf(typeof(T)));
            }
            catch (T ex)
            {
                return ex;
            }
            catch (System.Exception ex)
            {
                Assert.Fail("Expected exception '" + typeof(T).FullName + "' but got exception '" + ex.GetType() + "'.");
                return null;
            }
            Assert.Fail("Expected exception '" + typeof(T).FullName + "' wasn't thrown.");
            return null;
        }

        /// <summary>Executes a method and asserts that the specified exception is thrown.</summary>
        /// <typeparam name="T">The type of exception to expect.</typeparam>
        /// <param name="method">The method to execute.</param>
        /// <returns>The thrown exception.</returns>
        public static void InnerException<T>(Action method)
            where T : System.Exception
        {
            try
            {
                method.Invoke();
            }
            catch (System.Exception ex)
            {
                TypeAssert.AreEqual(typeof(T), ex.InnerException);
                return;
            }
            Assert.Fail("Expected exception '" + typeof(T).FullName + "' wasn't thrown.");
        }
    }

    public static class TypeAssert
    {
        public static void AreEqual(object expected, object instance)
        {
            if (expected == null)
                Assert.IsNull(instance);
            else
                Assert.IsNotNull(instance, "Instance was null");
            Assert.AreEqual(expected.GetType(), instance.GetType(), "Expected: " + expected.GetType() + ", was: " + instance.GetType() + " was not of type " + instance.GetType());
        }

        public static void AreEqual(Type expected, object instance)
        {
            if (expected == null)
                Assert.IsNull(instance);
            else
                Assert.IsNotNull(instance, "Instance was null");
            Assert.AreEqual(expected, instance.GetType(), "Expected: " + expected.GetType() + ", was: " + instance.GetType() + " was not of type " + instance.GetType());
        }

        public static void Equals<T>(object instance)
        {
            AreEqual(typeof(T), instance);
        }

        public static void Is<T>(object instance)
        {
            Assert.IsTrue(instance is T, "Instance " + instance + " was not of type " + typeof(T));
        }
    }
}