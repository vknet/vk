---
layout: default
title: Метод Video.PutTag
permalink: video/putTag/
comments: true
---
# Метод Video.PutTag
Добавляет отметку на видеозапись. 

## Синтаксис
```csharp
public long PutTag(
	long videoId, 
	long userId, 
	long? ownerId, 
	string taggedName
)
```

## Параметры
+ **videdId** - Идентификатор видеозаписи.
+ **userId** - Идентификатор пользователя, которого нужно отметить.
+ **ownerId** - Идентификатор владельца видеозаписи (пользователь или сообщество).
+ **taggedName** - Текст отметки.

## Результат
После успешного выполнения возвращает идентификатор созданной отметки.

## Исключения

## Пример
```csharp

```
