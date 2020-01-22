---
layout: default
title: Метод Friends.Edit
permalink: friends/edit/
comments: true
---
# Метод Friends.Edit
Редактирует списки друзей для выбранного друга.

Этот метод можно вызвать с [ключом доступа пользователя](https://vk.com/dev/access_token). Требуются [права доступа](https://vk.com/dev/permissions): **friends**.

Страница документации ВКонтакте [friends.edit](https://vk.com/dev/friends.edit).

## Синтаксис
``` csharp
public bool Edit(long userId, IEnumerable<long> listIds)
```

## Параметры
+ **user_id** — идентификатор пользователя (из числа друзей), для которого необходимо отредактировать списки друзей.
+ **list_ids** — идентификаторы списков друзей, в которые нужно добавить пользователя. 

## Результат
После успешного выполнения возвращает **true**.

## Исключения
+ В ходе выполнения могут произойти общие ошибки. Их описание находится на [отдельной странице](https://vk.com/dev/errors).

## Пример
``` csharp
var edit = _api.Friends.Edit(userId: 0);
```

## Версия Вконтакте API v.5.103
Дата обновления: 17.01.2020 13:18.
