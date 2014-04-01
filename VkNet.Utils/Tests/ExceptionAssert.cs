namespace VkNet.Utils.Tests
{
    using System;
    using System.Reflection;

    using NUnit.Framework;

    public class ExceptionAssert
    {
        /// <summary>Executes a method and asserts that the specified exception is thrown.</summary>
        /// <param name="exceptionType">The type of exception to expect.</param>
        /// <param name="method">The method to execute.</param>
        /// <returns>The thrown exception.</returns>
        public static Exception Throws(Type exceptionType, Action method)
        {
            try
            {
                method.Invoke();
            }
            catch (Exception ex)
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
        public static T Throws<T>(Action method) where T : Exception
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
            catch (Exception ex)
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
        public static void InnerException<T>(Action method) where T : Exception
        {
            try
            {
                method.Invoke();
            }
            catch (Exception ex)
            {
                TypeAssert.AreEqual(typeof(T), ex.InnerException);
                return;
            }
            Assert.Fail("Expected exception '" + typeof(T).FullName + "' wasn't thrown.");
        }
    }
}