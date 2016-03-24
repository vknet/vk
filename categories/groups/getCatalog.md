---
layout: default
title: Метод Groups.GetCatalog
permalink: groups/getCatalog/
comments: true
---
# Метод Groups.GetCatalog
Возвращает список сообществ выбранной категории каталога.

Страница документации ВКонтакте [groups.getCatalog](https://vk.com/dev/groups.getCatalog).

## Синтаксис
``` csharp
public VkCollection<Group> GetCatalog(ulong? categoryId = null, ulong? subcategoryId = null)
```

## Параметры
+ **categoryId** - Идентификатор категории, полученный в методе groups.getCatalogInfo. положительное число
+ **subcategoryId** - Идентификатор подкатегории, полученный в методе groups.getCatalogInfo. положительное число, максимальное значение 99

## Результат
Возвращает список объектов сообществ в соответствии с выбранной категорией каталога.

## Пример
``` csharp
var getCatalog = _api.Groups.GetCatalog();
```

## Версия Вконтакте API v.5.50
Дата обновления: 24.03.2016 15:42:35
