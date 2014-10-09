---
layout: default
title: Метод Groups.Search
permalink: groups/search/
comments: true
---
# Метод Groups.Search
Осуществляет поиск групп по заданной подстроке.

# Синтаксис
```csharp

```

## Параметры
+ **query** - Поисковый запрос по которому необходимо найти группу.
+ **totalCount** - Общее количество групп удовлетворяющих запросу.
+ **offset** - Смещение, необходимое для выборки определённого подмножества результатов поиска.
+ **count** - Количество результатов поиска которое необходимо вернуть.

## Результат
Возвращает список найденных групп.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.
+ **InvalidParamException** - Поисковый запрос не пуст или равен значению null.

## Пример
```csharp
// Поиск групп по запросу "Music".
int totalCount;
var groups = vk.Groups.Search("Music", out totalCount);

// Поиск трех групп, начиная с двадцатой, удовлетворяющих запросу "Music".
int totalCount;
var groups = vk.Groups.Search("Music", out totalCount, 20, 3);
```
