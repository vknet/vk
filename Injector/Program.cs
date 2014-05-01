using System;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

namespace Injector
{
	static class Program
	{
		const string DllFile = "VkNet.dll";
		const string AttributeName = "ApiVersionAttribute";
		const string CategoriesNamespace = "VkNet.Categories";
		
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
			Console.WriteLine("Loading assembly...");
			var assembly = AssemblyDefinition.ReadAssembly(DllFile, new ReaderParameters { ReadSymbols = true });
			Console.WriteLine("Assembly loaded.");

			var categoryTypes = assembly.MainModule.Types.Where(t => t.Name.Contains("Category") && t.Namespace == CategoriesNamespace).ToArray();
			Console.WriteLine("{0} categories was founded at {1} namespace.", categoryTypes.Count(), CategoriesNamespace);
			
			foreach (var type in categoryTypes)
			{
				Console.WriteLine(type.Name);

				foreach (var info in type.GetMethods().Where(m => m.CustomAttributes.Any(a => a.AttributeType.Name == AttributeName)))
				{
					var version = (string)info.CustomAttributes.First(a => a.AttributeType.Name == AttributeName).ConstructorArguments[0].Value;
					Console.Write("\t{0,-17} : {1,6}", info.Name, version);

					var instructions = (from i in info.Body.Instructions
										where i.OpCode == OpCodes.Callvirt && i.Operand is MethodDefinition
										let operand = (MethodDefinition)i.Operand
										where operand.Name == "Call"
											&& operand.ReturnType == assembly.MainModule.Types.Single(t => t.Name == "VkResponse")
											&& operand.Parameters.Count == 4
												&& operand.Parameters[0].ParameterType.Name == "String"
												&& operand.Parameters[1].ParameterType.Name == "VkParameters"
												&& operand.Parameters[2].ParameterType.Name == "Boolean"
												&& operand.Parameters[3].ParameterType.Name == "String" && operand.Parameters[3].HasDefault
										select i)
										.ToArray();
					
					if (!instructions.Any())
					{
						Console.WriteLine(" - call invocations not found.");
						continue;
					}

					int count = 0;
					foreach (var instruction in instructions.Where(instruction => instruction.Previous.OpCode == OpCodes.Ldnull))
					{
						info.Body.Instructions.Remove(instruction.Previous);
						info.Body.Instructions.Insert(info.Body.Instructions.IndexOf(instruction), Instruction.Create(OpCodes.Ldstr, version));
						count++;
					}

					Console.WriteLine(" - injected to {0} of {1} call invocation(s)", count, instructions.Length);
				}
			}

			Console.WriteLine("Rewriting assembly...");
			assembly.Write(DllFile, new WriterParameters { WriteSymbols = true });
			Console.WriteLine("Assembly rewrited.");
		}
	}
}
