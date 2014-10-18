---
layout: default
title: Метод Video.GetAlbums
permalink: video/getAlbums/
comments: true
---
# Метод Video.GetAlbums
Возвращает список альбомов видеозаписей пользователя или сообщества.

## Синтаксис
```csharp
public ReadOnlyCollection<VideoAlbum> GetAlbums(
	long ownerId, 
	int? count = null, 
	int? offset = null, 
	bool extended
)
```

## Параметры
+ **ownerId** - идентификатор владельца альбомов (пользователь или сообщество). По умолчанию — идентификатор текущего пользователя.
+ **count** - количество альбомов, информацию о которых нужно вернуть.
+ **offset** - смещение, необходимое для выборки определенного подмножества альбомов.
+ **extended** - true – позволяет получать поля count, photo320 и photo160 для каждого альбома.

## Результат
После успешного выполнения возвращает массив объектов Album.

## Исключения

## Пример
```csharp
// TODO:
```