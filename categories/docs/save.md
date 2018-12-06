---
layout: default
title: Метод Docs.Save
permalink: docs/save/
comments: true
---
# Метод Docs.Save
Сохраняет документ после его успешной загрузки на сервер.

Страница документации ВКонтакте [docs.save](https://vk.com/dev/docs.save).

## Синтаксис
``` csharp
public ReadOnlyCollection<Document> Save(
	string file,
	string title,
	string tags = null,
	long? captchaSid = null,
	string captchaKey = null
)
```

## Параметры
+ **file** - Параметр, возвращаемый в результате загрузки файла на сервер. строка, обязательный параметр
+ **title** - Название документа. строка
+ **tags** - Метки для поиска. строка
+ **captchaSid** - Id капчи (только если для вызова метода необходимо ввести капчу)
+ **captchaKey** - Текст капчи (только если для вызова метода необходимо ввести капчу)

## Результат
Возвращает массив с загруженными объектами.

## Пример
``` csharp
var save = _api.Docs.Save(file: "file");
```

## Пример загрузки документа как вложение для сообщения из локального файла?
``` csharp
// Получить адрес сервера для загрузки.
var uploadServer = Api.Docs.GetUploadServer(987654321);
// Загрузить файл.
var wc = new WebClient();
var responseFile = Encoding.ASCII.GetString(wc.UploadFile(uploadServer.UploadUrl, @"C:\Users\Raven\Downloads\https__vk_com_gif_fak.gif"));
// Сохранить загруженный файл
var photos = Api.Docs.Save(responseFile, "gif");
Api.Wall.Post(new WallPostParams
{
	Attachments = photos, Message = "Test", OwnerId = -123456789
});
```

## Версия Вконтакте API v.5.92
Дата обновления: 06.12.2018 21:49:22
