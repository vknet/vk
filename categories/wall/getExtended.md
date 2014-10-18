---
layout: default
title: Метод Wall.GetExtended
permalink: wall/getExtended/
comments: true
---
# Метод Wall.GetExtended
Возвращает три  коллекции в out параметрах wallPosts, profiles и groups. 

## Синтаксис
```csharp
public int GetExtended(
	long ownerId, 
	out ReadOnlyCollection<Post> wallPosts, 
	out ReadOnlyCollection<User> profiles, 
	out ReadOnlyCollection<Group> groups, 
	int? count = null, 
	int? offset = null, 
	WallFilter filter = WallFilter.All)
```

## Параметры
+ **ownerId** - Идентификатор пользователя. Чтобы получить записи со стены группы (публичной страницы, встречи), укажите её идентификатор со знаком "минус": например, owner_id=-1 соответствует группе с идентификатором 1.
+ **wallPosts** - Коллекция записей на стене.
+ **profiles** - Коллекция профилей, так или иначе связанных с полученными в wallPosts записями.
+ **groups** - Коллекция групп, так или иначе связанных с полученными в wallPosts записями.
+ **count** - Количество сообщений, которое необходимо получить (но не более 100).
+ **offset** - Смещение, необходимое для выборки определенного подмножества сообщений.
+ **filter** - Типы сообщений, которые необходимо получить (по умолчанию возвращаются все сообщения).

## Результат
В случае успеха возвращается количество записей на стене.

## Исключения

## Пример
```csharp
// TODO:
```