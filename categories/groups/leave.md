---
layout: default
title: Метод Groups.Leave
permalink: groups/leave/
comments: true
---
# Метод Groups.Leave
Позволяет покинуть сообщество.

Страница документации ВКонтакте [groups.leave](https://vk.com/dev/groups.leave).

## Синтаксис
``` csharp
public bool Leave(long groupId)
```

## Параметры
+ **groupId** — Идентификатор сообщества. положительное число, обязательный параметр

## Результат
После успешного выполнения возвращает **true**.

## Исключения
+ **AccessTokenInvalidException** — не задан или используется неверный AccessToken.
+ **AccessDeniedException** — нет доступа для выполнение данного метода.

## Пример
```csharp
// Выходим из группы с id равным 2.
bool result = vk.Groups.Leave(2);
```

## Версия Вконтакте API v.5.44
Дата обновления: 19.01.2016 16:15:07
