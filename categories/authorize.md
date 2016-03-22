---
layout: default
title: Авторизация
permalink: authorize/
comments: true
---
# Авторизация
Для возможности использования методов из [VK.NET](http://vknet.github.io/vk), необходимо получить AccessToken. Без него (или с неверным AccessToken) все методы будут выбрасывать исключение *AccessTokenInvalidException*. Если возникает такое исключение это говорит о том, что вы либо забыли авторизоваться, либо закончился срок действия ключа авторизации.

## Параметры
+ **appID** - ID приложения
+ **email** - Email или телефон
+ **password** - Пароль для авторизации
+ **settings** - Права доступа приложения. Тип параметра - Settings

## Результат
Метод Authorize получает и устанавливает значение свойства AccessToken. Метод ничего не возвращает.

## Исключения
+ **VkApiAuthorizationException** - неправильный логин или пароль.
+ **VkApiException** - неизвестная ошибка.

## Пример
```csharp
int appID = 12345;                     	// ID приложения
string email = "test@test.com";        	// email или телефон
string pass = "password";              	// пароль для авторизации
Settings scope = Settings.Friends;  	// Приложение имеет доступ к друзьям

var vk = new VkApi();
vk.Authorize(new ApiAuthParams
{
	ApplicationId = appID,
	Login = email,
	Password = pass,
	Settings = scope
};
```

### Пример двухфакторной авторизации
Для двухфакторной авторизации необходимо передать пятым параметром обработчик, возвращающий код авторизации.

```csharp
using System;
using VkNet;
using VkNet.Enums.Filters;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            // обработчик получения кода
            Func<string> code = () =>
            {
                Console.Write("Please enter code: ");
                string value = Console.ReadLine();

                return value;
            };

            var api = new VkApi();
            api.Authorize(new ApiAuthParams
			{
				ApplicationId = 12345678,
				Login = "my@email.com",
				Password = "pwd",
				Settings = Settings.All,				
				TwoFactorAuthorization = code
			};

            var records = api.Audio.Get(api.UserId.Value); // получаем список треков текущего пользователя

            Console.WriteLine("Records count: " + records.Count);
        }
    }
}
```

