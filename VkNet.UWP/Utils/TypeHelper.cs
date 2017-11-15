#if NET40
using System;
using System.Collections.Generic;
using System.Reflection;

namespace VkNet.Utils
{
  public static class TypeHelper
  {
    public static Type GetTypeInfo(this Type type)
    {
      return type;
    }

    public static IEnumerable<FieldInfo> GetRuntimeFields(this Type type)
    {
      return type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
    }
  }
}
#endif