---
layout: default
title: Метод Pages.Save
permalink: pages/save/
comments: true
---
# Метод Pages.Save
Сохраняет текст вики-страницы.

Страница документации ВКонтакте [pages.save](https://vk.com/dev/pages.save).

## Синтаксис
``` csharp
public long Save(string text, long groupId, long userId, long? pageId = null, string title = "")
```

## Параметры
+ **text** — Новый текст страницы в вики-формате. строка
+ **pageId** — Идентификатор вики-страницы. Вместо page_id может быть передан параметр title. целое число
+ **groupId** — Идентификатор сообщества, которому принадлежит вики-страница. целое число
+ **userId** — Идентификатор пользователя, создавшего вики-страницу. целое число
+ **title** — Название вики-страницы. строка

## Результат
В случае успеха возвращает id созданной страницы.

## Пример
``` csharp
var save = _api.Pages.Save();
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 11:33:53
