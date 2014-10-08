---
layout: default
title: Метод Utils.CheckLink
permalink: utils/checkLink/
comments: true
---
# Метод Utils.CheckLink
Возвращает информацию о том, является ли внешняя ссылка заблокированной на сайте ВКонтакте.

## Синтаксис
```csharp
public LinkAccessType CheckLink(string url)
```

## Параметры
+ **url** - Внешняя ссылка, которую необходимо проверить.
## Результат

## Исключения
Статус ссылки.

## Пример
```csharp
// Проверка на блокировку сайта Кремля.
LinkAccessType type = utils.CheckLink("http://www.kreml.ru/‎");
```