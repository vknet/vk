---
layout: default
title: Метод Audio.EditAlbum
permalink: audio/editAlbum/
comments: true
---
# Метод Audio.EditAlbum
Редактирует название альбома аудиозаписей.

Страница документации ВКонтакте [audio.editAlbum](https://vk.com/dev/audio.editAlbum).

## Синтаксис
``` csharp
public bool EditAlbum(string title, long albumId, long? groupId = null)
```

## Параметры
+ **groupId** — Идентификатор сообщества, которому принадлежит альбом. положительное число
+ **albumId** — Идентификатор альбома. положительное число, обязательный параметр
+ **title** — Новое название для альбома. строка, обязательный параметр

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var editAlbum = _api.Audio.EditAlbum(albumId: 0, title: "title");
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 19:20:10
