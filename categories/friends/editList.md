---
layout: default
title: Метод Friends.EditList
permalink: friends/editList/
comments: true
---
# Метод Friends.EditList
Редактирует существующий список друзей текущего пользователя.

Этот метод можно вызвать с [ключом доступа пользователя](https://vk.com/dev/access_token). Требуются [права доступа](https://vk.com/dev/permissions): **friends**.

Страница документации ВКонтакте [friends.editList](https://vk.com/dev/friends.editList).

## Синтаксис
``` csharp
public bool EditList(long listId, string name = null, IEnumerable<long> userIds = null, IEnumerable<long> addUserIds = null, IEnumerable<long> deleteUserIds = null)
```

## Параметры
+ **name** — название списка друзей.
+ **list_id** — идентификатор списка друзей. 
+ **user_ids** — идентификаторы пользователей, включенных в список. 
+ **add_user_ids** — идентификаторы пользователей, которых необходимо добавить в список. (в случае если не передан *user_ids*).
+ **delete_user_ids** — идентификаторы пользователей, которых необходимо изъять из списка. (в случае если не передан *user_ids*).

## Результат
После успешного выполнения возвращает **true**.

## Исключения
+ **171** — недопустимый идентификатор списка. 
+ В ходе выполнения могут произойти общие ошибки. Их описание находится на [отдельной странице](https://vk.com/dev/errors).

## Пример
``` csharp
var editList = _api.Friends.EditList(listId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 25.01.2016 13:09:06
