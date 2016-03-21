---
layout: default
title: Метод Friends.DeleteList
permalink: friends/deleteList/
comments: true
---
# Метод Friends.DeleteList
Удаляет существующий список друзей текущего пользователя.

Страница документации ВКонтакте [friends.deleteList](https://vk.com/dev/friends.deleteList).

## Синтаксис
``` csharp
public bool DeleteList(long listId)
```

## Параметры
+ **listId** - Идентификатор списка друзей, который необходимо удалить. положительное число, обязательный параметр

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var deleteList = _api.Friends.DeleteList(listId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 25.01.2016 13:09:06
