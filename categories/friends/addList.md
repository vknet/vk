---
layout: default
title: Метод Friends.AddList
permalink: friends/addList/
comments: true
---
# Метод Friends.AddList
Создает новый список друзей у текущего пользователя.

Этот метод можно вызвать с [ключом доступа пользователя](https://vk.com/dev/access_token), полученным в [Standalone-приложении](https://vk.com/dev/standalone) через [Implicit Flow](https://vk.com/dev/implicit_flow_user). Требуются [права доступа](https://vk.com/dev/permissions): **friends**.

Страница документации ВКонтакте [friends.addList](https://vk.com/dev/friends.addList).

## Синтаксис
``` csharp
public long AddList(string name, IEnumerable<long> userIds)
```

## Параметры
+ **name** — Название создаваемого списка друзей. Строка, обязательный параметр.
+ **user_ids** — Идентификаторы пользователей, которых необходимо поместить в созданный список. Список положительных чисел, разделенных запятыми.

## Результат
После успешного выполнения возвращает идентификатор (list_id) созданного списка друзей.

## Исключения
+ **173** — Создано максимальное количество списков. 
+ В ходе выполнения могут произойти общие ошибки. Их описание находится на [отдельной странице](https://vk.com/dev/errors).

## Пример
``` csharp
var addList = _api.Friends.AddList(name: "name");
```

## Версия Вконтакте API v.5.103
Дата обновления: 17.01.2020 15:30.
