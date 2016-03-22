---
layout: default
title: Метод Video.RemoveFromAlbum
permalink: video/removeFromAlbum/
comments: true
---
# Метод Video.RemoveFromAlbum
Позволяет убрать видеозапись из альбома.

Страница документации ВКонтакте [video.removeFromAlbum](https://vk.com/dev/video.removeFromAlbum).

## Синтаксис
``` csharp
public bool RemoveFromAlbum(
	long ownerId,
	long videoId,
	IEnumerable<string> albumIds,
	long? targetId = null,
	long? albumId = null
)
```

## Параметры
+ **targetId** - Идентификатор владельца альбома. Обратите внимание, идентификатор сообщества в параметре target_id необходимо указывать со знаком "-" — например, target_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя
+ **albumId** - Идентификатор альбома, из которого нужно убрать видео. целое число
+ **albumIds** - Идентификаторы альбомов, из которых нужно убрать видео. список целых чисел, разделенных запятыми
+ **ownerId** - Идентификатор владельца видеозаписи. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр
+ **videoId** - Идентификатор видеозаписи. положительное число, обязательный параметр

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var removeFromAlbum = _api.Video.RemoveFromAlbum(ownerId: 0, videoId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 14:50:41
