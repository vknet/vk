---
layout: default
title: Метод Docs.GetById
permalink: docs/getById/
comments: true
---
# Метод Docs.GetById
Возвращает информацию о документах по их идентификаторам.

Страница документации ВКонтакте [docs.getById](https://vk.com/dev/docs.getById).

## Синтаксис
``` csharp
public ReadOnlyCollection<Document> GetById(IEnumerable<Document> docs)
```

## Параметры
+ **docs** — Идентификаторы документов, информацию о которых нужно вернуть. Пример значения docs: 
66748_91488,66748_91455. список слов, разделенных через запятую, обязательный параметр

## Результат
После успешного выполнения возвращает список объектов документов.

## Пример
``` csharp
var getById = _api.Docs.GetById(docs: );
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 12:07:22
