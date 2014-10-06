---
layout: default
title: Авторизация
permalink: authorize/
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
vk.Authorize(appID, email, pass, scope);
```

