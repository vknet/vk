---
layout: default
title: Метод Friends.DeleteList
permalink: friends/deleteList/
comments: true
---
# Метод Friends.DeleteList
Удаляет существующий список друзей текущего пользователя.

Этот метод можно вызвать с [ключом доступа пользователя](https://vk.com/dev/access_token). Требуются [права доступа](https://vk.com/dev/permissions): **friends**.

Страница документации ВКонтакте [friends.deleteList](https://vk.com/dev/friends.deleteList).

## Синтаксис
``` csharp
public bool DeleteList(long listId)
```

## Параметры
+ **list_id** — Идентификатор списка друзей, который необходимо удалить.

## Результат
После успешного выполнения возвращает **true**.

## Исключения
В ходе выполнения могут произойти общие ошибки. Их описание находится на [отдельной странице](https://vk.com/dev/errors).

## Пример
``` csharp
var deleteList = _api.Friends.DeleteList(listId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 25.01.2016 13:09:06
