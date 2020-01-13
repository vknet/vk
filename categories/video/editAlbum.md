---
layout: default
title: Метод Video.EditAlbum
permalink: video/editAlbum/
comments: true
---
# Метод Video.EditAlbum
Редактирует название альбома видеозаписей.

Страница документации ВКонтакте [video.editAlbum](https://vk.com/dev/video.editAlbum).

## Синтаксис
``` csharp
public bool EditAlbum(long albumId, string title, long? groupId = null, Privacy privacy = null)
```

## Параметры
+ **groupId** — Идентификатор сообщества (если нужно отредактировать альбом, принадлежащий сообществу). положительное число
+ **albumId** — Идентификатор альбома. положительное число, обязательный параметр
+ **title** — Новое название для альбома. строка, обязательный параметр
+ **privacy** — Уровень доступа к альбому в специальном формате. 
Приватность доступна для альбомов с видео в профиле пользователя. целое число

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var editAlbum = _api.Video.EditAlbum(albumId: 0, title: "title");
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 14:50:41
