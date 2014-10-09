---
layout: default
title: Метод Users.IsAppUser
permalink: users/isAppUser/
comments: true
---
# Метод Users.IsAppUser

# Синтаксис
```csharp

```

## Параметры
+ **uid** - id пользователя

## Результат
Метод isAppUser возвращает true в случае, если пользователь установил у себя данное приложение, иначе false.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.

## Пример
```csharp
// Проверяем, установил ли Павел Дуров наше приложение.
bool isInstalled = vk.Users.IsAppUser(1);
```
