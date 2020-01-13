---
layout: default
title: Метод Docs.GetTypes
permalink: docs/getTypes/
comments: true
---
# Метод Docs.GetTypes
Возвращает доступные типы документы для пользователя

Страница документации ВКонтакте [docs.getTypes](https://vk.com/dev/docs.getTypes).

## Синтаксис
``` csharp
public ReadOnlyCollection<DocumentType> GetTypes(long ownerId)
```

## Параметры
+ **ownerId** — Идентификатор пользователя или сообщества, которому принадлежат документы. целое число, по умолчанию идентификатор текущего пользователя, обязательный параметр

## Результат
После успешного выполнения возвращает список объектов type. 
+ **type** — тип документов.  
+ **id** идентификатор типа.  положительное число name название типа. 
+ **count** число документов.  int (числовое значение)

## Пример
``` csharp
var getTypes = _api.Docs.GetTypes(ownerId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 12:07:22
