---
layout: default
title: Метод Pages.GetHistory
permalink: pages/getHistory/
comments: true
---
# Метод Pages.GetHistory
Возвращает список всех старых версий вики-страницы.

Страница документации ВКонтакте [pages.getHistory](https://vk.com/dev/pages.getHistory).

## Синтаксис
``` csharp
public ReadOnlyCollection<History> GetHistory(long pageId, long groupId, long? userId = null)
```

## Параметры
+ **pageId** — Идентификатор вики-страницы. целое число, обязательный параметр
+ **groupId** — Идентификатор сообщества, которому принадлежит вики-страница. целое число
+ **userId** — Идентификатор пользователя, создавшего вики-страницу. целое число

## Результат
Возвращает массив объектов page_version, имеющих следующую структуру: 

+ **id** — идентификатор версии страницы; 
+ **length**  длина версии страницы в байтах; 
+ **edited** — дата редактирования страницы; 
+ **editor_id** — идентификатор редактора; 
+ **editor_name** — имя редактора.

## Пример
``` csharp
var getHistory = _api.Pages.GetHistory(pageId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 11:33:53
