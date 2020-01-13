---
layout: default
title: Метод Pages.GetTitles
permalink: pages/getTitles/
comments: true
---
# Метод Pages.GetTitles
Возвращает список вики-страниц в группе.

Страница документации ВКонтакте [pages.getTitles](https://vk.com/dev/pages.getTitles).

## Синтаксис
``` csharp
public ReadOnlyCollection<Page> GetTitles(long groupId)
```

## Параметры
+ **groupId** — Идентификатор сообщества, которому принадлежит вики-страница. целое число

## Результат
Возвращает массив объектов вики-страниц.

## Пример
``` csharp
var getTitles = _api.Pages.GetTitles();
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 11:33:53
