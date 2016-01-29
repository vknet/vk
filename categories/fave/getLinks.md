---
layout: default
title: Метод Fave.GetLinks
permalink: fave/getLinks/
comments: true
---
# Метод Fave.GetLinks
Возвращает ссылки, добавленные в закладки текущим пользователем.

Страница документации ВКонтакте [fave.getLinks](https://vk.com/dev/fave.getLinks).
## Синтаксис
``` csharp
public ReadOnlyCollection<ExternalLink> GetLinks(int? count = null, int? offset = null)
```

## Параметры
+ **offset** - Смещение, необходимое для выборки определенного подмножества ссылок. положительное число
+ **count** - Количество ссылок, информацию о которых необходимо вернуть. положительное число, по умолчанию 50

## Результат
После успешного выполнения возвращает общее количество ссылок и массив объектов link, каждый из которых содержит поля id, url, title, description, photo_50 и photo_100.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 13:59:16
