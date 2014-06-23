using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using RazorEngine;
using VkApiGenerator.Model;
using VkApiGenerator.Utils;
using VkNet;
using VkNet.Enums.Filters;
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

        public string GenerateUnitTest(string categoryName, string accessToken)
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
                var genInfo = GetMethodData(methodInfo);

                if (string.IsNullOrEmpty(genInfo.ApiMethod)) continue;

                Debug.WriteLine(genInfo.ToString());

                genMethods.Add(genInfo);

            }

            // invoke and get json and url
            var api = new VkApi();

            

            api.Authorize(accessToken);
            // TODO must be authorized

            var unittests = new List<UnitTestInfo>();

            var testCategory = new StringBuilder();
            foreach (var m in genMethods)
            {
                if (m.Skip) continue;

                var test = new UnitTestInfo
                {
                    Name = string.Format("{0}_", m.Name),
                    Url = Utilities.PreetyPrintApiUrl(api.GetApiUrl(m.ApiMethod, m.Params))
                };

                // TODO refactor this shit
                int index = test.Url.IndexOf("access_token", StringComparison.InvariantCulture);
                if (index != -1)
                {
                    test.Url = test.Url.Substring(0, index) + "access_token=token\";";
                }

                test.Json = Utilities.PreetyPrintJson(api.Invoke(m.ApiMethod, m.Params));

                unittests.Add(test);

                testCategory.Append(test);
            }

            File.WriteAllText(@"d:\vk.txt", testCategory.ToString());

            return string.Empty;

            //throw new NotImplementedException();
        }

        public VkMethodGenInfo GetMethodData(MethodInfo method)
        {
            var result = new VkMethodGenInfo {Name = method.Name};

            var apiNameAttr = method.GetCustomAttribute<ApiMethodNameAttribute>();
            if (apiNameAttr != null)
            {
                result.ApiMethod = apiNameAttr.Name;
                result.Order = apiNameAttr.Order;
                result.Skip = apiNameAttr.Skip;
            }

            var valuesAttrs = method.GetCustomAttributes<VkValueAttribute>();
            if (valuesAttrs != null)
            {
                foreach (var val in valuesAttrs)
                {
                    result.Params.Add(val.Name, val.Value.ToString());
                }
            }

            result.Params.Add("v", "5.9");
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
{0}
{1}
    
    Assert.Fail(""undone"");
}}

", Url, Json, Name);

            return test;
        }
    }

    // TODO move
    public class VkMethodGenInfo
    {
        public string Name { get; set; }
        public string ApiMethod { get; set; }
        public int Order { get; set; }
        public bool Skip { get; set; }
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