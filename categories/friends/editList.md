---
layout: default
title: Метод Friends.EditList
permalink: friends/editList/
comments: true
---
# Метод Friends.EditList
Редактирует существующий список друзей текущего пользователя.

Страница документации ВКонтакте [friends.editList](https://vk.com/dev/friends.editList).

## Синтаксис
``` csharp
public bool EditList(long listId, string name = null, IEnumerable<long> userIds = null, IEnumerable<long> addUserIds = null, IEnumerable<long> deleteUserIds = null)
```

## Параметры
+ **name** — Название списка друзей. строка
+ **listId** — Идентификатор списка друзей. положительное число, обязательный параметр
+ **userIds** — Идентификаторы пользователей, включенных в список. список положительных чисел, разделенных запятыми
+ **addUserIds** — Идентификаторы пользователей, которых необходимо добавить в список. (в случае если не передан user_ids) список положительных чисел, разделенных запятыми
+ **deleteUserIds** — Идентификаторы пользователей, которых необходимо изъять из списка. (в случае если не передан user_ids) список положительных чисел, разделенных запятыми

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var editList = _api.Friends.EditList(listId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 25.01.2016 13:09:06
