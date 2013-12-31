namespace VkToolkit.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class VkResponseEx
    {
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