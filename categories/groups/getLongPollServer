---
layout: default
title: Метод Groups.GetLongPollServer
permalink: groups/getLongPollServer/
comments: true
---
# Метод Groups.GetLongPollServer
Возвращает данные для подключения к Bots Longpoll API.

Страница документации ВКонтакте [groups.getLongPollServer](https://vk.com/dev/groups.getLongPollServer).

## Синтаксис
``` csharp
public bool GetLongPollServer(ulong groupId)
```

## Параметры
+ **groupId** - Идентификатор сообщества. Положительное число, обязательный параметр

## Результат
Возвращает объект, который содержит следующие поля:
key (string) — ключ;
server (string) — url сервера;
ts (integer) — timestamp.

## Пример
```csharp
// Проверяем состоит ли Павел Дуров в группе с id равным 2.
var collection = vk.Groups.GetLongPollServer(123456);
```

## Версия Вконтакте API v.5.44
Дата обновления: 11.08.2018 17:46:07
