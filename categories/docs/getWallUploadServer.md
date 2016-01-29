---
layout: default
title: Метод Docs.GetWallUploadServer
permalink: docs/getWallUploadServer/
comments: true
---
# Метод Docs.GetWallUploadServer
Возвращает адрес сервера для загрузки документов в папку Отправленные, для последующей отправки документа на стену или личным сообщением.

Страница документации ВКонтакте [docs.getWallUploadServer](https://vk.com/dev/docs.getWallUploadServer).
## Синтаксис
``` csharp
public UploadServerInfo GetWallUploadServer(long? groupId = null)
```

## Параметры
+ **groupId** - Идентификатор сообщества, в которое нужно загрузить документ. положительное число

## Результат
Возвращает объект с полем upload_url. После успешной загрузки документа необходимо воспользоваться методом docs.save.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 12:07:22
