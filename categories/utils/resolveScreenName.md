---
layout: default
title: Метод Utils.ResolveScreenName
permalink: utils/resolveScreenName/
comments: true
---
# Метод Utils.ResolveScreenName
Определяет тип объекта (пользователь, сообщество, приложение) и его идентификатор по короткому имени screenName.

## Синтаксис
```csharp
public VkObject ResolveScreenName(string screenName)
```

## Параметры
+ **screenName** - Короткое имя.

## Результат
Тип объекта. 

## Исключения

## Пример
```csharp
// Получаем идентификатор группы mdk.
VkObject obj = utils.ResolveScreenName("mdk");
long id = obj.Id // <--- идентификатор группы
```