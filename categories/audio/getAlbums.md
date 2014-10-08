---
layout: default
title: Метод Audio.GetAlbums
permalink: audio/getAlbums/
comments: true
---
# Метод Audio.GetAlbums
Возвращает список альбомов аудиозаписей пользователя или группы.

## Синтаксис
```csharp
public ReadOnlyCollection<AudioAlbum> GetAlbums(long ownerid, int? count = null, int? offset = null)
```

## Параметры
+ **ownerId** - идентификатор пользователя или сообщества, у которого необходимо получить список альбомов с аудио.
+ **count** - количество альбомов, которое необходимо вернуть.
+ **offset** - смещение, необходимое для выборки определенного подмножества альбомов.

## Результат
Список объектов типа AudioAlbum.

## Исключения

## Пример
```csharp
// TODO:
```