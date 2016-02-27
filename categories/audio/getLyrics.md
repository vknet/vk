---
layout: default
title: Метод Audio.GetLyrics
permalink: audio/getLyrics/
comments: true
---
# Метод Audio.GetLyrics
Возвращает текст аудиозаписи.

Страница документации ВКонтакте [audio.getLyrics](https://vk.com/dev/audio.getLyrics).

## Синтаксис
``` csharp
public Lyrics GetLyrics(long lyricsId)
```

## Параметры
+ **lyricsId** - Идентификатор текста аудиозаписи, информацию о котором необходимо вернуть. целое число, обязательный параметр

## Результат
После успешного выполнения возвращает объект lyrics c полями lyrics_id — идентификатор текста и text — текст аудиозаписи.. 
В качестве переводов строк в тексте используется /n.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.

## Пример
```csharp
// Получаем текст песни с id равным 2662381.
Lyrics lyrics = vk.Audio.GetLyrics(2662381);
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 19:20:10
