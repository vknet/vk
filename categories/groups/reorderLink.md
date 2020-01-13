---
layout: default
title: Метод Groups.ReorderLink
permalink: groups/reorderLink/
comments: true
---
# Метод Groups.ReorderLink
Позволяет менять местоположение ссылки в списке.

Страница документации ВКонтакте [groups.reorderLink](https://vk.com/dev/groups.reorderLink).

## Синтаксис
``` csharp
public bool ReorderLink(long groupId, long linkId, long? after)
```

## Параметры
+ **groupId** — Идентификатор группы, внутри которой перемещается ссылка положительное число, обязательный параметр
+ **linkId** — Идентификатор ссылки, которую необходимо переместить положительное число, обязательный параметр
+ **after** — Идентификатор ссылки после которой необходимо разместить перемещаемую ссылку. 0 – если ссылку нужно разместить в начале списка. положительное число

## Результат
В случае успешного выполнение метод возвращает **true**.

## Пример
``` csharp
var reorderLink = _api.Groups.ReorderLink(groupId: 0, linkId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 19.01.2016 16:15:07
