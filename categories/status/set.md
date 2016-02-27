---
layout: default
title: Метод Status.Set
permalink: status/set/
comments: true
---
# Метод Status.Set
Устанавливает новый статус текущему пользователю или сообществу.

Страница документации ВКонтакте [status.set](https://vk.com/dev/status.set).

## Синтаксис
``` csharp
public bool Set(string text, long? groupId = null)
```

## Параметры
+ **text** - Текст нового статуса. строка
+ **groupId** - Идентификатор сообщества, в котором будет установлен статус. По умолчанию статус устанавливается текущему пользователю. положительное число

## Результат
В случае успешной установки или очистки статуса возвращает **true**.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.
+ **AccessDeniedException** - нет доступа для выполнение данного метода.

## Пример
```csharp
// Устанавливаем простой статус "test test test".
bool result = vk.Status.Set("test test test");

```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 14:36:11
