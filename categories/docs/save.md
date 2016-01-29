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
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 12:07:22
