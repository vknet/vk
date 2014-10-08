---
layout: default
title: Метод Video.MoveToAlbum
permalink: video/moveToAlbum/
comments: true
---
# Метод Video.MoveToAlbum
Перемещает видеозаписи в альбом.

## Синтаксис
```csharp
public bool MoveToAlbum(IEnumerable<long> videoIds, long albumId, long? groupId = null)
```

## Параметры
+ **videoIds** - список идентификаторов видеороликов.
+ **albumId** - идентификатор альбома, в который перемещаются видеозаписи.
+ **groupId** - идентификатор сообщества, которому принадлежат видеозаписи. Если параметр не указан, то работа ведется с альбомом текущего пользователя.

## Результат
После успешного выполнения возвращает true.

## Исключения

## Пример
```csharp
// TODO:
```