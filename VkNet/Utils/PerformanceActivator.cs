using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace VkNet.Utils
{
	/// <summary>
	/// Высокопроизводительное динамическое создание объектов
	/// </summary>
	/// <remarks>
	/// <a href="https://rogerjohansson.blog/2008/02/28/linq-expressions-creating-objects/">link</a>
	/// </remarks>
	public static class PerformanceActivator
	{
		private delegate T ObjectActivator<out T>(params object[] args);

		/// <inheritdoc cref="CreateInstance{TResult}(Func{ConstructorInfo, bool},object[])"/>
		internal static TResult CreateInstance<TResult>(params object[] args)
			where TResult : class
		{
			return CreateInstance<TResult>(_ => true, args);
		}

		/// <summary>
		/// Создать экземпляр объекта
		/// </summary>
		/// <param name="constructorFilter">Фильтр конструктора объекта</param>
		/// <param name="args">Параметры конструктора</param>
		/// <typeparam name="TResult">Возвращаемый тип</typeparam>
		/// <returns>Экземпляр класса <typeparamref name="TResult"/></returns>
		private static TResult CreateInstance<TResult>(Func<ConstructorInfo, bool> constructorFilter, params object[] args)
			where TResult : class
		{
			return CreateInstance<TResult>(typeof(TResult), constructorFilter, args);
		}

		/// <summary>
		/// Создать экземпляр объекта
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="constructorFilter">Фильтр конструктора объекта</param>
		/// <param name="args">Параметры конструктора</param>
		/// <typeparam name="TResult">Возвращаемый тип</typeparam>
		/// <returns>Экземпляр класса <typeparamref name="TResult"/></returns>
		internal static TResult CreateInstance<TResult>(Type obj, Func<ConstructorInfo, bool> constructorFilter, params object[] args)
			where TResult : class
		{
			var ctor = obj.GetConstructors().FirstOrDefault(constructorFilter);

			if (ctor == null)
			{
				return null;
			}

			var paramsInfo = ctor.GetParameters();

			//create a single param of type object[]
			var param = Expression.Parameter(typeof(object[]), nameof(args));

			var argsExp = new Expression[paramsInfo.Length];

			//pick each arg from the params array
			//and create a typed expression of them
			for (var i = 0; i < paramsInfo.Length; i++)
			{
				Expression index = Expression.Constant(i);
				var paramType = paramsInfo[i].ParameterType;

				Expression paramAccessorExp =
					Expression.ArrayIndex(param, index);

				Expression paramCastExp =
					Expression.Convert(paramAccessorExp, paramType);

				argsExp[i] = paramCastExp;
			}

			//make a NewExpression that calls the
			//ctor with the args we just created
			var newExp = Expression.New(ctor, argsExp);

			//create a lambda with the New
			//Expression as body and our param object[] as arg
			var lambda = Expression.Lambda(typeof(ObjectActivator<TResult>), newExp, param);

			//compile it
			var compiled = (ObjectActivator<TResult>) lambda.Compile();

			return compiled(args);
		}
	}
}