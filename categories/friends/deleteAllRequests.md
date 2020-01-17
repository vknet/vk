---
layout: default
title: Метод Friends.DeleteAllRequests
permalink: friends/deleteAllRequests/
comments: true
---
# Метод Friends.DeleteAllRequests
Отмечает все входящие заявки на добавление в друзья как просмотренные.

Этот метод можно вызвать с [ключом доступа пользователя](https://vk.com/dev/access_token). Требуются [права доступа](https://vk.com/dev/permissions): **friends**.

Страница документации ВКонтакте [friends.deleteAllRequests](https://vk.com/dev/friends.deleteAllRequests).

## Синтаксис
``` csharp
public bool DeleteAllRequests()
```

## Параметры
Данный метод не принимает параметров.

## Результат
После успешного выполнения возвращает **true**.

## Исключения
В ходе выполнения могут произойти общие ошибки. Их описание находится на [отдельной странице](https://vk.com/dev/errors).

## Пример
``` csharp
var deleteAllRequests = _api.Friends.DeleteAllRequests();
```

## Версия Вконтакте API v.5.103
Дата обновления: 17.01.2020 17:56.
