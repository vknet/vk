---
layout: default
title: Метод Messages.SetChatPhoto
permalink: messages/setChatPhoto/
comments: true
---
# Метод Messages.SetChatPhoto
Позволяет установить фотографию мультидиалога, загруженную с помощью метода photos.getChatUploadServer.

Страница документации ВКонтакте [messages.setChatPhoto](https://vk.com/dev/messages.setChatPhoto).

## Синтаксис
``` csharp
public long SetChatPhoto(out long messageId, string file)
```

## Параметры
+ **messageId** - Идентификатор отправленного системного сообщения;
+ **file** - Содержимое поля response из ответа специального upload сервера, полученного в результате загрузки изображения на адрес, полученный методом photos.getChatUploadServer. строка, обязательный параметр

## Результат
После успешного выполнения возвращает объект, содержащий следующие поля: 
+ **message_id** — идентификатор отправленного системного сообщения; 
+ **chat** — объект мультидиалога.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 10:34:32
