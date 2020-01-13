---
layout: default
title: Метод Groups.EditLink
permalink: groups/editLink/
comments: true
---
# Метод Groups.EditLink
Позволяет редактировать ссылки в сообществе.

Страница документации ВКонтакте [groups.editLink](https://vk.com/dev/groups.editLink).

## Синтаксис
``` csharp
public bool EditLink(long groupId, long linkId, string text)
```

## Параметры
+ **groupId** — Идентификатор сообщества, в которое добавляется ссылка положительное число, обязательный параметр
+ **linkId** — Идентификатор редактируемой ссылки положительное число, обязательный параметр
+ **text** — Новое описание ссылки строка

## Результат
В случае успешного редактирования ссылки метод возвращает **true**.

## Пример
``` csharp
var editLink = _api.Groups.EditLink(groupId: 0, linkId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 19.01.2016 16:15:07
