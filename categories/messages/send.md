---
layout: default
title: Метод Messages.Send
permalink: messages/send/
comments: true
---
# Метод Messages.Send
Отправляет сообщение.

Страница документации ВКонтакте [messages.send](https://vk.com/dev/messages.send).

## Синтаксис
``` csharp
public long Send(MessagesSendParams @params)
```

## Параметры
Класс **`MessagesSendParams`** содержит следующие свойства:

+ **UserId** - Идентификатор пользователя, которому отправляется сообщение. целое число
+ **PeerId** - Идентификатор назначения. 
Для групповой беседы: 
2000000000 + id беседы. 
Для сообщества: 
-id сообщества. 
 целое число, доступен начиная с версии 5.38
+ **Domain** - Короткий адрес пользователя (например, illarionov). строка
+ **ChatId** - Идентификатор беседы, к которой будет относиться сообщение. положительное число
+ **UserIds** - Идентификаторы получателей сообщения (при необходимости отправить сообщение сразу нескольким пользователям). список целых чисел, разделенных запятыми
+ **Message** - Текст личного cообщения (является обязательным, если не задан параметр attachment) строка
+ **Guid** - Уникальный идентификатор, предназначенный для предотвращения повторной отправки одинакового сообщения. целое число
+ **Lat** - Latitude, широта при добавлении местоположения. дробное число
+ **Long** - Longitude, долгота при добавлении местоположения. дробное число
+ **Attachment** - Медиавложения к личному сообщению, перечисленные через запятую. Каждое прикрепление представлено в формате:
&lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt;
&lt;type&gt; — тип медиавложения: 
photo — фотография; 
video — видеозапись; 
audio — аудиозапись; 
doc — документ; 
wall — запись на стене.
&lt;owner_id&gt; — идентификатор владельца медиавложения (обратите внимание, если объект находится в сообществе, этот параметр должен быть отрицательным).
&lt;media_id&gt; — идентификатор медиавложения.
Например:
photo100172_166443618
Параметр является обязательным, если не задан параметр message. 
В случае, если прикрепляется объект, принадлежащий другому пользователю следует добавлять к вложению его access_key в формате &lt;type&gt;&lt;owner_id&gt;_&lt;media_id&gt;_&lt;access_key&gt;, Например: video85635407_165186811_69dff3de4372ae9b6e строка
+ **ForwardMessages** - Идентификаторы пересылаемых сообщений, перечисленные через запятую. Перечисленные сообщения отправителя будут отображаться в теле письма у получателя.
Например:
123,431,544 строка
+ **StickerId** - Идентификатор стикера. положительное число

## Результат
После успешного выполнения возвращает идентификатор отправленного сообщения.

## Пример отправки сообщения Павлу Дурову
``` csharp
api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
{
    UserId = 1,
    Message = "message"
});
```

## Пример формирования вложения для сообщения
``` csharp
var albumid = 123456789;
var photos = Api.Photo.Get(new PhotoGetParams
{
	AlbumId = PhotoAlbumType.Id(albumid),
	OwnerId = Api.UserId.Value
});
Api.Messages.Send(new MessagesSendParams
{
	Attachments = photos,
	Message = "Message",
	PeerId = Api.UserId.Value
});
```

## Пример формирования вложения из локального файла
``` csharp
// Получить адрес сервера для загрузки.
var uploadServer = Api.Photo.GetUploadServer(123);
// Загрузить файл.
var wc = new WebClient();
var responseFile = Encoding.ASCII.GetString(wc.UploadFile(uploadServer.UploadUrl, @"fullPathToImage.jpg"));
// Сохранить загруженный файл
var photos = Api.Photo.Save(new PhotoSaveParams
{
	SaveFileResponse = responseFile,
	AlbumId = 123,
        GroupId = 12345678,
});
Api.Messages.Send(new MessagesSendParams
{
	Attachments = photos,
	Message = "Message",
	PeerId = Api.UserId.Value
});
```

## Пример формирования вложения для сообщения
``` csharp
var albumid = 123456789;
var photos = Api.Photo.Get(new PhotoGetParams
{
	AlbumId = PhotoAlbumType.Id(albumid),
	OwnerId = Api.UserId.Value
});
Api.Messages.Send(new MessagesSendParams
{
	Attachments = photos,
	Message = "Message",
	PeerId = Api.UserId.Value
});
```

## Версия Вконтакте API v.5.44
Дата обновления: 27.01.2016 19:50:49
