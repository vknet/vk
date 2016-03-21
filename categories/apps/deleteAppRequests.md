---
layout: default
title: Метод Apps.DeleteAppRequests
permalink: apps/deleteAppRequests/
comments: true
---
# Метод Apps.DeleteAppRequests
Удаляет все уведомления о запросах, отправленных из текущего приложения

Страница документации ВКонтакте [apps.deleteAppRequests](https://vk.com/dev/apps.deleteAppRequests).

## Синтаксис
``` csharp
public bool DeleteAppRequests()
```

## Параметры
Данный метод не имеет входных параметров.

## Результат
В случае успешного выполнения возвращает **true**.

## Пример
``` csharp
var deleteAppRequests = _api.Apps.DeleteAppRequests();
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 14:30:11
