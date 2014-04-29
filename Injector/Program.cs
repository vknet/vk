using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Injector
{
	class Program
	{
		static void Main(string[] args)
		{
			Process();
		}

		static void Process()
		{
			const string fileName = "VkNet.dll"; 
			const string tempFileName = fileName + "_temp";
			
			File.Copy(fileName, tempFileName, true);
			File.Delete(fileName);

			var assembly = AssemblyDefinition.ReadAssembly(tempFileName);
			var assemblyRefl = Assembly.LoadFile(Environment.CurrentDirectory + @"\" + tempFileName);
			
			Type attrType = assemblyRefl.GetTypes().First(t => t.IsSubclassOf(typeof(Attribute)) && t.Name == "ApiVersionAttribute");

			foreach (var type in assemblyRefl.GetTypes().Where(t => t.Name.Contains("Category") && t.Namespace.Contains("Categories")))
			{
				Console.WriteLine(type.Name);
				foreach (var info in type.GetMethods().Where(m => m.GetCustomAttribute(attrType) != null))
				{
					dynamic attribute = info.GetCustomAttribute(attrType);
					string version = attribute.Version;
					Console.WriteLine("\t" + info.Name + " : " + version);
					var apiMethod = assembly.MainModule.Types.First(t => t.FullName == type.FullName).Methods.First(m => m.FullName == assembly.MainModule.Import(info).FullName);
					
					var instruction = apiMethod.Body.Instructions
						.FirstOrDefault(i => 
							i.OpCode == OpCodes.Callvirt 
							&& i.Operand.GetType().Name == "MethodDefinition" 
							&& i.Operand.ToString().Contains("VkNet.VkApi::Call"));
					
					if(instruction == null)
						continue;

					if (instruction.Previous.OpCode == OpCodes.Ldnull)
					{
						apiMethod.Body.Instructions.Remove(instruction.Previous);
						apiMethod.Body.Instructions.Insert(apiMethod.Body.Instructions.IndexOf(instruction), Instruction.Create(OpCodes.Ldstr, version));
					}
				}
			}
			
			assembly.Write(fileName);
		}
	}
}
