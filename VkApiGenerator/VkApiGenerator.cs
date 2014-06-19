using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using RazorEngine;
using VkApiGenerator.Model;
using VkApiGenerator.Utils;
using VkNet;
using VkNet.Utils;

namespace VkApiGenerator
{
    public class VkApiGenerator
    {
        public string GenerateMethod(VkMethodInfo method)
        {   
            var model = new VkMethodViewModel(method);
            return Razor.Parse(Template.Method, model);
        }

        public string GetThrowIfNumberIsNegative(string paramName)
        {
            if (string.IsNullOrEmpty(paramName)) return string.Empty;

            return string.Format(Template.ThrowIfNumberIsNegative, paramName);
        }

        public string GenerateUnitTest(string categoryName)
        {
            // 1. read assembly
            // 2. find methods in particular category
            // 3. find methods with not input parameters (it's the most simple case)
            // 4. invoke a method
            // 5. construct unit-test
            // 6. return it

            Assembly dll = Assembly.LoadFrom("VkNet.dll");

            // todo refactor it later
            List<Type> classes = dll.GetTypes().Where(t => t.Name.Contains("Category") && t.Name.Contains(categoryName)).ToList();

            Type category = classes.FirstOrDefault();

            MethodInfo[] methods = category.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public);

            var genMethods = new List<VkMethodGenInfo>();
            foreach (var methodInfo in methods)
            {
//                if (methodInfo.GetParameters().Length == 0)
//                {

                var genInfo = GetMethodData(methodInfo);
                    Debug.WriteLine(genInfo.ToString());
                genMethods.Add(genInfo);
//                }
            }

            // invoke and get json and url
            var api = new VkApi();
            // TODO must be authorized

            var unittests = new List<UnitTestInfo>();
            foreach (var m in genMethods)
            {
                var test = new UnitTestInfo();
                test.Name = string.Format("{0}_{1}", m.Name, (new Random()).Next());
                test.Url = api.GetApiUrl(m.ApiMethod, m.Params);

                unittests.Add(test);
            }

            throw new NotImplementedException();
        }

        public VkMethodGenInfo GetMethodData(MethodInfo method)
        {
            var result = new VkMethodGenInfo {Name = method.Name};

            var apiNameAttr = method.GetCustomAttribute<ApiMethodNameAttribute>();
            if (apiNameAttr != null)
            {
                result.ApiMethod = apiNameAttr.Name;
                result.Order = apiNameAttr.Order;
            }

            var valuesAttrs = method.GetCustomAttributes<VkValueAttribute>();
            if (valuesAttrs != null)
            {
                foreach (var val in valuesAttrs)
                {
                    result.Params.Add(val.Name, val.Value.ToString());
                }
            }

            return result;
        }
    }

    // TODO move
    public class UnitTestInfo
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Json { get; set; }

        public override string ToString()
        {
            var test = string.Format(@"[Test]
public void {2}()
{{
    const string url = {0};
    const string json = {1};
    
    Assert.Fail(""undone"");
}}", Url, Json, Name);

            return test;
        }
    }

    // TODO move
    public class VkMethodGenInfo
    {
        public string Name { get; set; }
        public string ApiMethod { get; set; }
        public int Order { get; set; }
        public IDictionary<string, string> Params;

        public VkMethodGenInfo()
        {
            Params = new Dictionary<string, string>();
        }

        public override string ToString()
        {
            string m = string.Format("-- {0}: {1} [{2}] (", Name, ApiMethod, Order);
            int counter = 0;
            foreach (var p in Params)
            {
                counter++;
                m += string.Format("{{{0} : {1}}}", p.Key, p.Value);

                if (counter != Params.Count)
                    m += ", ";
            }
            m += ")";

            return m;
        }
    }
}