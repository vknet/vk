using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Security.AccessControl;
using System.Threading;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Pdb;
using Mono.CompilerServices.SymbolWriter;

namespace Injector
{
	class Program
	{
		const string dllFile = "VkNet.dll";
		const string pdbFile = "VkNet.pdb";

		const string tempDllFile = "VkNet_temp.dll";
		const string tempPdbFile = "VkNet_temp.pdb";
		
		static void Main(string[] args)
		{
			try
			{
				Process();
			}
			catch (Exception e)
			{
				Console.WriteLine("Injector throws an exception:\n" + e.Message);
				throw;
			}
		}

		static void Process()
		{
		
			File.Copy(dllFile, tempDllFile, true);
			File.Delete(dllFile);
			File.Copy(pdbFile, tempPdbFile, true);
			File.Delete(pdbFile);

			var assembly = AssemblyDefinition.ReadAssembly(tempDllFile, new ReaderParameters {ReadSymbols = true});
			var assemblyRefl = Assembly.LoadFile(Environment.CurrentDirectory + @"\" + tempDllFile);
			
			Type attrType = assemblyRefl.GetTypes().First(t => t.IsSubclassOf(typeof(Attribute)) && t.Name == "ApiVersionAttribute");

			foreach (var type in assemblyRefl.GetTypes().Where(t => t.Name.Contains("Category") && t.Namespace.Contains("Categories")))
			{
				Console.WriteLine(type.Name);
				foreach (var info in type.GetMethods().Where(m => m.GetCustomAttributes(attrType, false).FirstOrDefault() != null))
				{
					dynamic attribute = info.GetCustomAttributes(attrType, false).First();
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

			
			assembly.Write(dllFile, new WriterParameters { WriteSymbols = true });
		}
	}
}
