---
layout: default
title: Метод Video.Edit
permalink: video/edit/
comments: true
---
# Метод Video.Edit
Редактирует данные видеозаписи на странице пользователя.

## Синтаксис
```csharp
public bool Edit(
	long videoId, 
	long? ownerId = null, 
	string name = null, 
	string desc = null, 
	string privacyView = null, 
	string privacyComment = null, 
	bool isRepeat = false
)
```

## Параметры
+ **videoId** - идентификатор видеозаписи.
+ **ownerId** - идентификатор пользователя или сообщества, которому принадлежит видеозапись.
+ **name** - новое название для видеозаписи.
+ **desc** - новое описание для видеозаписи.
+ **privacyView** - настройки приватности.
+ **privacyComment** - настройки приватности.
+ **isRepeat** - зацикливание воспроизведения видеозаписи.

## Результат
После успешного выполнения возвращает true.

## Исключения

## Пример
```csharp
// TODO:
```