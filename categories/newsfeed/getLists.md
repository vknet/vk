---
layout: default
title: Метод Newsfeed.GetLists
permalink: newsfeed/getLists/
comments: true
---
# Метод Newsfeed.GetLists
Возвращает пользовательские списки новостей.

Страница документации ВКонтакте [newsfeed.getLists](https://vk.com/dev/newsfeed.getLists).
## Синтаксис
``` csharp
public ReadOnlyCollection<NewsUserListItem> GetLists(
	out int total,
	IEnumerable<long> listIds,
	bool? extended = null
)
```

## Параметры
+ **listIds** - Идентификаторы списков. список положительных чисел, разделенных запятыми
+ **extended** - 1 — вернуть дополнительную информацию о списке (значения source_ids и no_reposts). флаг, может принимать значения 1 или 0, по умолчанию 0

## Результат
Метод возвращает список объектов с полями: 

+ **id** – идентификатор списка; 
+ **title** – название списка, заданное пользователем. 

Если был передан параметр extended=1, дополнительно возвращаются поля: 

+ **no_reposts** — отключены ли копии постов; 
+ **source_ids** — идентификаторы пользователей и сообществ, включенных в список. 

Новости по отдельному списку могут быть получены методом newsfeed.get с использованием параметра **source_ids**.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 13:09:42
