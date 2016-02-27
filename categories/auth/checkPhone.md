---
layout: default
title: Метод Auth.CheckPhone
permalink: auth/checkPhone/
comments: true
---
# Метод Auth.CheckPhone
Проверяет правильность введённого номера.

Страница документации ВКонтакте [auth.checkPhone](https://vk.com/dev/auth.checkPhone).

## Синтаксис
``` csharp
public bool CheckPhone(string phone, string clientSecret, long? clientId = null, bool? authByPhone = null)
```

## Параметры
+ **phone** - Номер телефона регистрируемого пользователя. строка, обязательный параметр
+ **clientId** - Идентификатор Вашего приложения. целое число
+ **clientSecret** - Секретный ключ приложения, доступный в разделе редактирования приложения. строка, обязательный параметр
+ **authByPhone** - Флаг, может принимать значения 1 или 0

## Результат
В случае, если номер пользователя является правильным, будет возвращён **true**.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 14:06:14
