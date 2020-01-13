---
layout: default
title: Метод Utils.CheckLink
permalink: utils/checkLink/
comments: true
---
# Метод Utils.CheckLink
Возвращает информацию о том, является ли внешняя ссылка заблокированной на сайте ВКонтакте.

Страница документации ВКонтакте [utils.checkLink](https://vk.com/dev/utils.checkLink).

## Синтаксис
``` csharp
public LinkAccessType CheckLink([NotNull] Uri url)
public LinkAccessType CheckLink([NotNull] string url)
```

## Параметры
+ **url** — Внешняя ссылка, которую необходимо проверить. 
Например, http://google.com строка, обязательный параметр

## Результат
Возвращает одно из трёх значений поля status: 

+ **not_banned** – ссылка не заблокирована 
+ **banned** – ссылка заблокирована 
+ **processing** – ссылка проверяется; необходимо выполнить повторный запрос через несколько секунд. 

В поле link возвращается исходная, либо конечная ссылка, если передана ссылка на сервис сокращения ссылок.

## Пример
```csharp
// Проверка на блокировку сайта Кремля.
var type = utils.CheckLink("http://www.kreml.ru/");
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 14:46:21
