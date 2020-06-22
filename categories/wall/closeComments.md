---
layout: default
title: Метод Wall.CloseComments
permalink: wall/closecomments/
comments: true
---
# Метод Wall.CloseComments
Выключает комментирование записи

Страница документации ВКонтакте [wall.closeComments](https://vk.com/dev/wall.closeComments).

Этот метод можно вызвать с ключом доступа пользователя, полученным в [Standalone-приложении](https://vk.com/dev/standalone) через [Implicit Flow](https://vk.com/dev/implicit_flow_user).
Этот метод можно вызвать с [ключом доступа сообщества](https://vk.com/dev/access_token). 
Требуются [права доступа](https://vk.com/dev/permissions) wall.

## Синтаксис
``` csharp
public bool CloseComments(long ownerId, long postId)
```

## Параметры
+ **ownerId** - Идентификатор пользователя или сообщества, на стене которого находится запись.
Обязательный параметр.
+ **postId** - Идентификатор записи на стене. положительное число, обязательный параметр
Обязательный параметр.

## Результат
В случае успеха метод вернет **true**.

## Пример
``` csharp
var result = Api.Wall.CloseComments(3, 3);
Console.WriteLine(result);
```

## Версия Вконтакте API v.5.110
Дата обновления: 22.06.2020 23:08