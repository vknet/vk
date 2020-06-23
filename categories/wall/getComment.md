---
layout: default
title: Метод Wall.GetComment
permalink: wall/getComment/
comments: true
---
# Метод Wall.GetComment
Получает информацию о комментарии на стене.

Страница документации ВКонтакте [wall.getComment](https://vk.com/dev/wall.getComment).  
Этот метод можно вызвать с [ключом доступа пользователя](https://vk.com/dev/access_token).  
Требуются [права доступа](https://vk.com/dev/permissions) wall.  

## Синтаксис
``` csharp
public WallGetCommentsResult GetComments(WallGetCommentsParams @params, bool skipAuthorization = false)
```

## Параметры
+ **OwnerId** - Идентификатор владельца стены  
+ **CommentId** - Идентификатор комментария.  
+ **Fields** - список дополнительных полей для [профилей](https://vk.com/dev/objects/user) и [сообществ](https://vk.com/dev/objects/group), которые необходимо вернуть.  
Обратите внимание, этот параметр учитывается только при `extended = 1`.  
+ **Extended** -   
**true** — в ответе будут возвращены дополнительные поля **profiles** и **groups**, содержащие информацию о [пользователях](https://vk.com/dev/objects/user) и [сообществах](https://vk.com/dev/objects/user).   
По умолчанию false.

## Результат
Возвращает объект комментария на стене.   
Если был передан параметр `extended = 1`, дополнительно возвращает поля **groups** и **profiles**, содержащие информацию о [пользователях](https://vk.com/dev/objects/user) и [сообществах](https://vk.com/dev/objects/user).
## Пример
``` csharp
//не реализовано
```

## Версия Вконтакте API v.5.110
Дата обновления: 23.06.2020 2:43
