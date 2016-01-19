---
layout: default
title: Метод Users.IsAppUser
permalink: users/isAppUser/
comments: true
---
# Метод Users.IsAppUser
Возвращает информацию о том, установил ли пользователь приложение.

Страница документации ВКонтакте [users.isAppUser](https://vk.com/dev/users.isAppUser).
## Синтаксис
``` csharp
public bool IsAppUser(long? userId)
```

## Параметры
+ **userId** - Идентификатор пользователя. целое число, по умолчанию идентификатор текущего пользователя

## Результат
После успешного выполнения возвращает **true** в случае, если пользователь установил у себя данное приложение, иначе **false**.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.

## Пример
```csharp
// Проверяем, установил ли Павел Дуров наше приложение.
bool isInstalled = vk.Users.IsAppUser(1);
```
