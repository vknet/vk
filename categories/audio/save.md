---
layout: default
title: Метод Audio.Save
permalink: audio/save/
comments: true
---
# Метод Audio.Save
Сохраняет аудиозаписи после успешной загрузки.

Страница документации ВКонтакте [audio.save](https://vk.com/dev/audio.save).

## Синтаксис
``` csharp
public Audio Save(string response, string artist = null, string title = null)
```

## Параметры
+ **response** - Параметр, возвращаемый в результате загрузки аудиофайла на сервер. строка
+ **artist** - Автор композиции. По умолчанию берется из ID3 тегов. строка
+ **title** - Название композиции. По умолчанию берется из ID3 тегов. строка

## Результат
Возвращает массив из объектов с загруженными аудиозаписями, каждый из которых имеет поля id, owner_id, artist, title, url.

## Пример
``` csharp
var save = _api.Audio.Save(server: 0, audio: "audio");
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 19:20:10
