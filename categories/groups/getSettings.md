---
layout: default
title: Метод Groups.GetSettings
permalink: groups/getSettings/
comments: true
---
# Метод Groups.GetSettings
Позволяет получать данные, необходимые для отображения страницы редактирования данных сообщества.

Страница документации ВКонтакте [groups.getSettings](https://vk.com/dev/groups.getSettings).

## Синтаксис
``` csharp
public GroupInfo GetSettings(long groupId)
```

## Параметры
+ **groupId** — Идентификатор сообщества, данные которого необходимо получить. положительное число, обязательный параметр

## Результат
В случае успешного выполнения метод вернет объект, содержащий данные сообщества, которые позволят отобразить форму редактирования для метода groups.edit.

## Пример
``` csharp
var getSettings = _api.Groups.GetSettings(groupId: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 19.01.2016 16:15:07
