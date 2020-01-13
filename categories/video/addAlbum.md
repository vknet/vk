---
layout: default
title: Метод Video.AddAlbum
permalink: video/addAlbum/
comments: true
---
# Метод Video.AddAlbum
Создает пустой альбом видеозаписей.

Страница документации ВКонтакте [video.addAlbum](https://vk.com/dev/video.addAlbum).

## Синтаксис
``` csharp
public long AddAlbum(string title, long? groupId = null, IEnumerable<Privacy> privacy = null)
```

## Параметры
+ **groupId** — Идентификатор сообщества (если необходимо создать альбом в сообществе). положительное число
+ **title** — Название альбома. строка
+ **privacy** — Уровень доступа к альбому в специальном формате. 
Приватность доступна для альбомов с видео в профиле пользователя. список строк, разделенных через запятую

## Результат
После успешного выполнения возвращает  идентификатор созданного альбома (album_id).

## Пример
``` csharp
var addAlbum = _api.Video.AddAlbum();
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 14:50:41
