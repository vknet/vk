---
layout: default
title: Метод Video.GetTags
permalink: video/getTags/
comments: true
---
# Метод Video.GetTags
Возвращает список отметок на видеозаписи. 

# Синтаксис
```csharp
public ReadOnlyCollection<Tag> GetTags(
	long videoId,
	long? ownerId
)
```

## Параметры
+ **videoId** - Идентификатор видеозаписи.
+ **ownerId** - Идентификатор владельца видеозаписи (пользователь или сообщество). 

## Результат
После успешного выполнения возвращает массив объектов Tag.

## Исключения

## Пример
```csharp

```
