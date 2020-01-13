---
layout: default
title: Метод Photos.EditComment
permalink: photos/editComment/
comments: true
---
# Метод Photos.EditComment
Изменяет текст комментария к фотографии.

Страница документации ВКонтакте [photos.editComment](https://vk.com/dev/photos.editComment).

## Синтаксис
``` csharp
public bool EditComment(ulong commentId, string message, long? ownerId = null, IEnumerable<MediaAttachment> attachments = null)
```

## Параметры
+ **ownerId** — Идентификатор пользователя или сообщества, которому принадлежит фотография. Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, по умолчанию идентификатор текущего пользователя
+ **commentId** — Идентификатор комментария. целое число, обязательный параметр
+ **message** — Новый текст комментария (является обязательным, если не задан параметр attachments).  Максимальное количество символов: 2048. строка
+ **attachments** — Новый список объектов, приложенных к комментарию и разделённых символом ",". Поле attachments представляется в формате: &lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt;,&lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt; &lt;type&gt; — тип медиа-вложения: photo — фотография  video — видеозапись  audio — аудиозапись  doc — документ &lt;owner_id&gt; — идентификатор владельца медиа-вложения  &lt;media_id&gt; — идентификатор медиа-вложения.   Например: photo100172_166443618,photo66748_265827614 Параметр является обязательным, если не задан параметр message. список строк, разделенных через запятую

## Результат
После успешного выполнения возвращает 1.

## Пример
``` csharp
var editComment = _api.Photos.EditComment(commentId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 11:06:43
