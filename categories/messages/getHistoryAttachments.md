---
layout: default
title: Метод Messages.GetHistoryAttachments
permalink: messages/getHistoryAttachments/
comments: true
---
# Метод Messages.GetHistoryAttachments
Возвращает материалы диалога или беседы.

Страница документации ВКонтакте [messages.getHistoryAttachments](https://vk.com/dev/messages.getHistoryAttachments).
## Синтаксис
``` csharp
public ReadOnlyCollection<Attachment> GetHistoryAttachments(MessagesGetHistoryAttachmentsParams @params)
```

## Параметры
Класс **`MessagesGetHistoryAttachmentsParams`** содержит следующие свойства:

+ **PeerId** — Идентификатор назначения. Для групповой беседы: 
2000000000 + id беседы. 
Для email: 
id беседы &lt; -2000000000 
Для сообщества: 
-id сообщества. 
 целое число, обязательный параметр
+ **MediaType** — Тип материалов, который необходимо вернуть. 
Доступные значения: 
photo — фотографии; 
video — видеозаписи; 
audio — аудиозаписи; 
doc — документы; 
link — ссылки; 
market — товары; 
wall — записи; 
share — ссылки, товары и записи. 
Обратите внимание — существует ограничение по дате отправки вложений. Так, для получения доступны вложения типов photo,video,audio,doc , отправленные не ранее 25.03.2013, link — не ранее 20.05.13, market,wall — 01.02.2016. строка, по умолчанию photo
+ **StartFrom** — Смещение, необходимое для выборки определенного подмножества объектов. строка
+ **Count** — Количество объектов, которое необходимо получить (но не более 200). положительное число, максимальное значение 200, по умолчанию 30
+ **PhotoSizes** — Параметр, указывающий нужно ли возвращать ли доступные размеры фотографии в специальном формате. флаг, может принимать значения 1 или 0
+ **Fields** — Список слов, разделенных через запятую

## Результат
После успешного выполнения возвращает массив объектов **photo, video, audio** или **doc**, в зависимости от значения **media_type**, а также дополнительное поле **next_from**, содержащее новое значение **start_from**. 
Если в **media_type** передано значение **link**, возвращает список объектов-ссылок: 
**url URL** ссылки. 
 строка **title** заголовок сниппета. 
 строка **description** описание сниппета. 
 строка **image_src URL** изображения сниппета. 
 строка

## Пример
``` csharp
var getHistoryAttachments = _api.Messages.GetHistoryAttachments(new MessagesGetHistoryAttachmentsParams{
	peerId = 0
});
```

## Версия Вконтакте API v.5.50
Дата обновления: 21.03.2016 11:43:06
