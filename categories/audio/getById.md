---
layout: default
title: Метод Audio.GetById
permalink: audio/getById/
comments: true
---
# Метод Audio.GetById
Возвращает информацию об аудиозаписях.

Страница документации ВКонтакте [audio.getById](https://vk.com/dev/audio.getById).

## Синтаксис
``` csharp
public ReadOnlyCollection<Audio> GetById(IEnumerable<string> audios)
```

## Параметры
+ **audios** - Идентификаторы аудиозаписей, информацию о которых необходимо вернуть, в виде {owner_id}_{audio_id}. список строк, разделенных через запятую, обязательный параметр

## Результат
После успешного выполнения возвращает массив объектов audio. Обратите внимание, что ссылки на аудиозаписи привязаны к ip адресу.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.
+ **InvalidParamException** - Параметр audios равен значению null.

## Пример
```csharp
// Получаем информацию об аудиозаписях с id, заданными в переменной ids.

var ids = new string[] { "4793858_158073513", "2_63937759" };
var audios = vk.Audio.GetById(ids).ToList();
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 19:20:10
