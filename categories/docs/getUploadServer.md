---
layout: default
title: Метод Docs.GetUploadServer
permalink: docs/getUploadServer/
comments: true
---
# Метод Docs.GetUploadServer
Возвращает адрес сервера для загрузки документов.

Страница документации ВКонтакте [docs.getUploadServer](https://vk.com/dev/docs.getUploadServer).
## Синтаксис
``` csharp
public UploadServerInfo GetUploadServer(long? groupId = null)
```

## Параметры
+ **groupId** - Идентификатор сообщества (если необходимо загрузить документ в список документов сообщества). Если документ нужно загрузить в список пользователя, метод вызывается без дополнительных параметров. положительное число

## Результат
Возвращает объект с полем upload_url. После успешной загрузки документа необходимо воспользоваться методом docs.save.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 12:07:22
