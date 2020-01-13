---
layout: default
title: Метод Docs.Delete
permalink: docs/delete/
comments: true
---
# Метод Docs.Delete
Удаляет документ пользователя или группы.

Страница документации ВКонтакте [docs.delete](https://vk.com/dev/docs.delete).

## Синтаксис
``` csharp
public bool Delete(long ownerId, long docId)
```

## Параметры
+ **ownerId** — Идентификатор пользователя или сообщества, которому принадлежит документ. целое число, обязательный параметр
+ **docId** — Идентификатор документа. положительное число, обязательный параметр

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var delete = _api.Docs.Delete(ownerId: 0, docId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 12:07:22
