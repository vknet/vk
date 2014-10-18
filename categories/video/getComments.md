---
layout: default
title: Метод Video.GetComments
permalink: video/getComments/
comments: true
---
# Метод Video.GetComments
Возвращает список комментариев к видеозаписи.

## Синтаксис
```csharp
public ReadOnlyCollection<Comment> GetComments(
	long videoId, 
	long? ownerId = null, 
	bool needLikes, 
	int? count = null, 
	int? offset = null, 
	CommentsSort sort = null
)
```

## Параметры
+ **videoId** - идентификатор видеозаписи.
+ **ownerId** - идентификатор пользователя или сообщества, которому принадлежит видеозапись.
+ **needLikes** - true — будет возвращено дополнительное поле likes. По умолчанию поле likes не возвращается.
+ **count** - количество комментариев, информацию о которых необходимо вернуть.
+ **offset** - смещение, необходимое для выборки определенного подмножества комментариев.
+ **sort** - порядок сортировки комментариев (asc — от старых к новым, desc — от новых к старым).

## Результат
идентификатор видеозаписи.

## Исключения

## Пример
```csharp
// TODO:
```