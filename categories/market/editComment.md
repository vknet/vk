---
layout: default
title: Метод Market.EditComment
permalink: market/editComment/
comments: true
---
# Метод Market.EditComment
Изменяет текст комментария к товару.

Страница документации ВКонтакте [market.editComment](https://vk.com/dev/market.editComment).

## Синтаксис
``` csharp
public bool EditComment(long ownerId, long commentId, string message, IEnumerable<MediaAttachment> attachments = null)
```

## Параметры
+ **ownerId** - Идентификатор владельца товара. 
Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр
+ **commentId** - Идентификатор комментария. положительное число, обязательный параметр
+ **message** - Новый текст комментария (является обязательным, если не задан параметр attachments). 
Максимальное количество символов: 2048. строка
+ **attachments** - Новый список объектов, приложенных к комментарию и разделённых символом ",". Поле attachments представляется в формате:
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
Параметр является обязательным, если не задан параметр message. список слов, разделенных через запятую

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var editComment = _api.Market.EditComment(ownerId: 0, commentId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 14:55:24
