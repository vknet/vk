---
layout: default
title: Метод Wall.Delete
permalink: wall/delete/
comments: true
---
# Метод Wall.Delete
Удаляет запись со стены.

Страница документации ВКонтакте [wall.delete](https://vk.com/dev/wall.delete).

Этот метод можно вызвать с ключом доступа пользователя, полученным в [Standalone-приложении](https://vk.com/dev/standalone) через [Implicit Flow](https://vk.com/dev/implicit_flow_user).

## Синтаксис
``` csharp
public bool Delete(long? ownerId = null, long? postId = null)
```

## Параметры
+ **ownerId** - Идентификатор пользователя или сообщества, на стене которого находится запись. По умолчанию идентификатор текущего пользователя.
+ **postId** - Идентификатор записи на стене. положительное число.

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
//не реализовано
```

## Версия Вконтакте API v.5.110
Дата обновления: 22.06.2020 23:58
