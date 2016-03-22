---
layout: default
title: Метод Video.HideCatalogSection
permalink: video/hideCatalogSection/
comments: true
---
# Метод Video.HideCatalogSection
Скрывает для пользователя раздел видеокаталога.

Страница документации ВКонтакте [video.hideCatalogSection](https://vk.com/dev/video.hideCatalogSection).

## Синтаксис
``` csharp
public bool HideCatalogSection(long sectionId)
```

## Параметры
+ **sectionId** - Значение id, полученное с блоком, который необходимо скрыть, в методе video.getCatalog обязательный параметр, целое число

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var hideCatalogSection = _api.Video.HideCatalogSection(sectionId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 26.01.2016 14:50:41
