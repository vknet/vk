---
layout: default
title: Метод Video.EditComment
permalink: video/editComment/
comments: true
---
# Метод Video.EditComment
Изменяет текст комментария к видеозаписи.

Страница документации ВКонтакте [video.editComment](https://vk.com/dev/video.editComment).

## Синтаксис
``` csharp
public bool EditComment(long commentId, string message, long? ownerId = null, IEnumerable<MediaAttachment> attachments = null)
```

## Параметры
+ **ownerId** — Идентификатор пользователя или сообщества, которому принадлежит видеозапись. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя
+ **commentId** — Идентификатор комментария. целое число, обязательный параметр
+ **message** — Новый текст комментария (является обязательным, если не задан параметр attachments). строка
+ **attachments** — Новый список объектов, приложенных к комментарию и разделённых символом ",". Поле attachments представляется в формате:
&lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt;,&lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt;
&lt;type&gt; — тип медиа-вложения:
photo — фотография 
video — видеозапись 
audio — аудиозапись 
doc — документ
&lt;owner_id&gt; — идентификатор владельца медиа-вложения 
&lt;media_id&gt; — идентификатор медиа-вложения. 

Например:
photo100172_166443618,photo66748_265827614
Параметр является обязательным, если не задан параметр message. список строк, разделенных через запятую

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var editComment = _api.Video.EditComment(commentId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 14:50:41
