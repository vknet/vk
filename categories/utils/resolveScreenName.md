---
layout: default
title: Метод Utils.ResolveScreenName
permalink: utils/resolveScreenName/
comments: true
---
# Метод Utils.ResolveScreenName
Определяет тип объекта (пользователь, сообщество, приложение) и его идентификатор по короткому имени screen_name.

Страница документации ВКонтакте [utils.resolveScreenName](https://vk.com/dev/utils.resolveScreenName).

## Синтаксис
``` csharp
public VkObject ResolveScreenName([NotNull] string screenName)
```

## Параметры
+ **screenName** — Короткое имя пользователя, группы или приложения. Например, apiclub, andrew или rules_of_war. строка, обязательный параметр

## Результат
В случае успеха возвращает объект со следующими полями: 

type — тип объекта (user, group, application, page) 
object_id — идентификатор объекта 

Если короткое имя screen_name не занято, то будет возвращён пустой объект.

## Пример
```csharp
// Получаем идентификатор группы mdk.
VkObject obj = utils.ResolveScreenName("mdk");
long id = obj.Id // <--- идентификатор группы
```

## Версия Вконтакте API v.5.44
Дата обновления: 28.01.2016 14:46:21
