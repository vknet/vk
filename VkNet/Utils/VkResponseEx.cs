namespace VkNet.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    internal static class VkResponseEx
    {
        public static Collection<T> ToCollection<T>(this IEnumerable<T> source)
        {
            return new Collection<T>(new List<T>(source));
        }

        public static Collection<T> ToCollectionOf<T>(this VkResponse response, Func<VkResponse, T> selector) //where T : class
        {
            if (response == null)
                return new Collection<T>(new List<T>());

            var responseArray = (VkResponseArray) response;
            if (responseArray == null)
                return new Collection<T>(new List<T>());

            return responseArray.Select(selector).Where(i => i != null).ToCollection();
        }

        public static Collection<T> ToCollectionOf<T>(this IEnumerable<VkResponse> responses, Func<VkResponse, T> selector)
        {
            if (responses == null)
                return new Collection<T>(new List<T>());

            return responses.Select(selector).ToCollection();
        }

        // --------------------------------------------------------------------------------------------
        public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> source)
        {
            return new ReadOnlyCollection<T>(new List<T>(source));
        }

        public static ReadOnlyCollection<T> ToReadOnlyCollectionOf<T>(
            this VkResponse response, Func<VkResponse, T> selector) where T : class
        {
            if (response == null)
                return new ReadOnlyCollection<T>(new List<T>());

            var responseArray = (VkResponseArray)response;
            if (responseArray == null)
                return new ReadOnlyCollection<T>(new List<T>());

            return responseArray.Select(selector).Where(i => i != null).ToReadOnlyCollection();
        }

        public static ReadOnlyCollection<T> ToReadOnlyCollectionOf<T>(this IEnumerable<VkResponse> responses, Func<VkResponse, T> selector)
        {
            if (responses == null)
                return new ReadOnlyCollection<T>(new List<T>());

            return responses.Select(selector).ToReadOnlyCollection();
        }

        // --------------------------------------------------------------------------------------------
        public static List<T> ToListOf<T>(this VkResponse response, Func<VkResponse, T> selector)
        {
            if (response == null)
                return new List<T>();

            var responseArray = (VkResponseArray)response;
            if (responseArray == null)
                return new List<T>();

            return responseArray.Select(selector).Where(i => i != null).ToList();
        }

        public static List<T> ToListOf<T>(this IEnumerable<VkResponse> responses, Func<VkResponse, T> selector)
        {
            if (responses == null)
                return new List<T>();

            return responses.Select(selector).ToList();
        }
    }
}