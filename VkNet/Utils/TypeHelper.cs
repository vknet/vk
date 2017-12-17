using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NLog;
using NLog.Config;
using NLog.Targets;

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
        /// <summary>
        /// DI Register Default Dependencies
        /// </summary>
        /// <param name="container">DI container</param>
        public static void RegisterDefaultDependencies(this IServiceCollection container)
        {
            container.TryAddSingleton<IBrowser, Browser>();
            container.TryAddSingleton(InitLogger());
        }
        
        /// <summary>
        /// Initializes the logger.
        /// </summary>
        /// <returns></returns>
        private static ILogger InitLogger()
        {
            // Step 1. Create configuration object 
            var config = new LoggingConfiguration();
            // Step 2. Create targets and add them to the configuration 
            var consoleTarget = new ConsoleTarget();
            config.AddTarget("console", consoleTarget);
            // Step 3. Set target properties 
            consoleTarget.Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}";
            // Step 4. Define rules
#if DEBUG
            var rule1 = new LoggingRule("*", LogLevel.Debug, consoleTarget);
#elif UNIT_TEST
            var rule1 = new LoggingRule("*", LogLevel.Trace, consoleTarget);
#else
            var rule1 = new LoggingRule("*", LogLevel.Warn, consoleTarget);
#endif
            
            config.LoggingRules.Add(rule1);
            // Step 5. Activate the configuration
            LogManager.Configuration = config;
            // Example usage
            return LogManager.GetLogger("VkApi");
        }
    }
}