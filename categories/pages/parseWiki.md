---
layout: default
title: Метод Pages.ParseWiki
permalink: pages/parseWiki/
comments: true
---
# Метод Pages.ParseWiki
Возвращает html-представление вики-разметки.

Страница документации ВКонтакте [pages.parseWiki](https://vk.com/dev/pages.parseWiki).

## Синтаксис
``` csharp
public string ParseWiki(string text, ulong groupId)
```

## Параметры
+ **text** — Текст в вики-формате. строка, обязательный параметр
+ **groupId** — Идентификатор группы, в контексте которой интерпретируется данная страница. положительное число

## Результат
В случае успеха возвращает экранированный html, соответствующий вики-разметке.

## Пример
``` csharp
var parseWiki = _api.Pages.ParseWiki(text: "text");
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 11:33:53
