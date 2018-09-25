---
layout: default
title: Авторизация
permalink: authorize/
comments: true
---
# Авторизация
Для возможности использования методов из [VK.NET](http://vknet.github.io/vk), необходимо получить [AccessToken](https://goo.gl/N2gpoV). Без него (или с неверным [AccessToken](https://goo.gl/N2gpoV)) все методы будут выбрасывать исключение *AccessTokenInvalidException*. Если возникает такое исключение это говорит о том, что вы либо забыли авторизоваться, либо закончился срок действия ключа авторизации.

## Параметры
+ **appID** - ID приложения
+ **email** - Email или телефон
+ **password** - Пароль для авторизации
+ **settings** - [Права доступа приложения](https://vk.com/dev/permissions). Тип параметра - Settings

## Результат
Метод Authorize получает и устанавливает значение свойства [AccessToken](https://goo.gl/N2gpoV). Метод ничего не возвращает.

## Исключения
+ **VkApiAuthorizationException** - неправильный логин или пароль.
+ **VkApiException** - неизвестная ошибка.

## Примеры

### Пример простой авторизации
```csharp
static void Main(string[] args)
{
	var api = new VkApi();
	
	api.Authorize(new ApiAuthParams
	{
		ApplicationId = 123456,
		Login = "Login",
		Password = "Password",
		Settings = Settings.All
	});
	Console.WriteLine(api.Token);
	var res = api.Groups.Get(new GroupsGetParams());

	Console.WriteLine(res.TotalCount);

	Console.ReadLine();
}

```

### Пример двухфакторной авторизации
Для двухфакторной авторизации необходимо передать пятым параметром обработчик, возвращающий код авторизации.

```csharp
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;

static void Main(string[] args)
{
    var api = new VkApi();

    api.Authorize(new ApiAuthParams
    {
        ApplicationId = 123456,
        Login = "Login",
        Password = "Password",
        Settings = Settings.All
    });

    Console.WriteLine(api.Token);

    // Отправка сообщения себе
    api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
    {
        ChatId = api.UserId.Value,
        Message = "message"
    });

    Console.ReadLine();
}
```

### Пример авторизации через [AccessToken](https://goo.gl/N2gpoV)
```csharp
static void Main(string[] args)
{
    var api = new VkApi();
    
    api.Authorize(new ApiAuthParams
    {
        AccessToken = "access_token"
    });
    Console.WriteLine(api.Token);
    var res = api.Groups.Get(new GroupsGetParams());

    Console.WriteLine(res.TotalCount);

    Console.ReadLine();
}
```

### Пример с [Dependency Injection](https://docs.microsoft.com/ru-ru/aspnet/core/fundamentals/dependency-injection)
```csharp
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NLog;
using NLog.Config;
using NLog.Targets;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
	    // Контейнер для инверсии зависимостей
            var serviceCollection = new ServiceCollection();
	    // Регистрация логгера
            serviceCollection.TryAddSingleton(InitLogger());
	    // Создание экземпляра API с использование контейнера для инверсии зависимостей
            var api = new VkApi(serviceCollection);
            
            api.Authorize(new ApiAuthParams
            {
                AccessToken = "access_token"
            });
            Console.WriteLine(api.Token);
            var res = api.Groups.Get(new GroupsGetParams());

            Console.WriteLine(res.TotalCount);

            Console.ReadLine();
        }
        
        /// <summary>
        /// Инициализация логгера.
        /// </summary>
        /// <returns>Логгер</returns>
        private static ILogger InitLogger()
        {
            var consoleTarget = new ConsoleTarget
            {
                Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}"
            };

            var config = new LoggingConfiguration();
            config.AddTarget("console", consoleTarget);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, consoleTarget));
            LogManager.Configuration = config;
            return LogManager.GetLogger("VkApi");
        }
    }
}
```
