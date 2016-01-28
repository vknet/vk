---
layout: default
title: Метод Utils.GetServerTime
permalink: utils/getServerTime/
comments: true
---
# Метод Utils.GetServerTime
Возвращает текущее время на сервере ВКонтакте в unixtime.

Страница документации ВКонтакте [utils.getServerTime](https://vk.com/dev/utils.getServerTime).
## Синтаксис
``` csharp
public DateTime GetServerTime()
```

## Параметры
Метод не содержит входных параметров

## Результат
Возвращает значение переменной.

## Пример
```csharp
// Получение текущего времени на сервере ВКонтакте.
DateTime currentTime = api.Utils.GetServerTime();
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 14:46:21
