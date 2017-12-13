using System;
using System.Collections.Generic;
using System.Reflection;
using SimpleInjector;

namespace VkNet.Utils
{
    public static class TypeHelper
    {
#if NET40
    public static Type GetTypeInfo(this Type type)
    {
      return type;
    }

    public static IEnumerable<FieldInfo> GetRuntimeFields(this Type type)
    {
      return type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
    }
#endif
        public static TService TryGetInstance<TService>(
            this Container container)
            where TService : class
        {
            IServiceProvider provider = container;
            return (TService) provider.GetService(typeof(TService));
        }
    }
}