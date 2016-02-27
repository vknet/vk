---
layout: default
title: Метод Pages.GetVersion
permalink: pages/getVersion/
comments: true
---
# Метод Pages.GetVersion
Возвращает текст одной из старых версий страницы.

Страница документации ВКонтакте [pages.getVersion](https://vk.com/dev/pages.getVersion).

## Синтаксис
``` csharp
public Page GetVersion(long versionId, long groupId, bool needHtml = false, long? userId = null)
```

## Параметры
+ **versionId** - Идентификатор версии. целое число, обязательный параметр
+ **groupId** - Идентификатор сообщества, которому принадлежит вики-страница. целое число
+ **userId** - Идентификатор пользователя, который создал страницу. целое число
+ **needHtml** - Определяет, требуется ли в ответе html-представление вики-страницы. флаг, может принимать значения 1 или 0

## Результат
Возвращает объект вики-страницы.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 11:33:53
