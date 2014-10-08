---
layout: default
title: Метод Utils.GetServerTime
permalink: utils/getServerTime/
comments: true
---
# Метод Utils.GetServerTime
Возвращает текущее время на сервере ВКонтакте.

## Синтаксис
```csharp
public DateTime GetServerTime()
```

## Параметры
Данный метод не принимает параметров.

## Результат
Время на сервере ВКонтакте.

## Исключения

## Пример
```csharp
// Получение текущего времени на сервере ВКонтакте.
DateTime currentTime = api.Utils.GetServerTime();
```