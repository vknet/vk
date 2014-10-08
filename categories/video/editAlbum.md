---
layout: default
title: Метод Video.EditAlbum
permalink: video/editAlbum/
comments: true
---
# Метод Video.EditAlbum
Редактирует название альбома видеозаписей.

## Синтаксис
```csharp
public bool EditAlbum(long albumId, string title, long? groupId = null)
```

## Параметры
+ **albumId** - идентификатор альбома.
+ **title** - новое название для альбома.
+ **groupId** - идентификатор сообщества (если нужно отредактировать альбом, принадлежащий сообществу).

## Результат
После успешного выполнения возвращает true.

## Исключения

## Пример
```csharp
// TODO:
```