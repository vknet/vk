---
layout: default
title: Метод Fave.AddGroup
permalink: fave/addGroup/
comments: true
---
# Метод Fave.AddGroup
Добавляет сообщество в закладки.

Страница документации ВКонтакте [fave.addGroup](https://vk.com/dev/fave.addGroup).

## Синтаксис
``` csharp
public bool AddGroup(long groupId)
```

## Параметры
+ **groupId** - Идентификатор сообщества, которое нужно добавить в закладки. положительное число, обязательный параметр

## Результат
В случае успешного выполнения возвращает **true**.

## Пример
``` csharp
var addGroup = _api.Fave.AddGroup(groupId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 13:59:16
