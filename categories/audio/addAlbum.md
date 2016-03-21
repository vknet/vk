---
layout: default
title: Метод Audio.AddAlbum
permalink: audio/addAlbum/
comments: true
---
# Метод Audio.AddAlbum
Создает пустой альбом аудиозаписей.

Страница документации ВКонтакте [audio.addAlbum](https://vk.com/dev/audio.addAlbum).

## Синтаксис
``` csharp
public long AddAlbum(string title, long? groupId = null)
```

## Параметры
+ **groupId** - Идентификатор сообщества (если альбом нужно создать в сообществе). положительное число
+ **title** - Название альбома. строка, обязательный параметр

## Результат
После успешного выполнения возвращает идентификатор (album_id) созданного альбома.

## Пример
``` csharp
var addAlbum = _api.Audio.AddAlbum(title: "title");
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 19:20:10
