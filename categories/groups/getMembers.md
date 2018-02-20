---
layout: default
title: Метод Groups.GetMembers
permalink: groups/getMembers/
comments: true
---
# Метод Groups.GetMembers
Возвращает список участников сообщества.

Страница документации ВКонтакте [groups.getMembers](https://vk.com/dev/groups.getMembers).

## Синтаксис
``` csharp
public ReadOnlyCollection<User> GetMembers(out int totalCount, GroupsGetMembersParams @params)
```

## Параметры
Класс **`GroupsGetMembersParams`** содержит следующие свойства:

+ **GroupId** - Идентификатор или короткое имя сообщества. строка
+ **Sort** - Сортировка, с которой необходимо вернуть список участников. Может принимать значения: 
id_asc — в порядке возрастания id; 
id_desc — в порядке убывания id; 
time_asc — в хронологическом порядке по вступлению в сообщество; 
time_desc — в антихронологическом порядке по вступлению в сообщество. 
Сортировка по time_asc и time_desc возможна только при вызове от модератора сообщества. строка, по умолчанию id_asc
+ **Offset** - Смещение, необходимое для выборки определенного подмножества участников. По умолчанию 0. положительное число
+ **Count** - Количество участников сообщества, информацию о которых необходимо получить. положительное число, по умолчанию 1000, максимальное значение 1000
+ **Fields** - Список дополнительных полей, которые необходимо вернуть. 
Доступные значения: sex, bdate, city, country, photo_50, photo_100, photo_200_orig, photo_200, photo_400_orig, photo_max, photo_max_orig, online, online_mobile, lists, domain, has_mobile, contacts, connections, site, education, universities, schools, can_post, can_see_all_posts, can_see_audio, can_write_private_message, status, last_seen, common_count, relation, relatives, counters список строк, разделенных через запятую
+ **Filter** - Friends — будут возвращены только друзья в этом сообществе. 
unsure — будут возвращены пользователи, которые выбрали «Возможно пойду» (если сообщество относится к мероприятиям). 
managers — будут возвращены только руководители сообщества (доступно при запросе с передачей access_token от имени администратора сообщества). 
строка

## Результат
Возвращает общее количество участников сообщества count и список идентификаторов пользователей items. 
Если был передан параметр filter=managers, возвращается дополнительное поле role, которое содержит уровень полномочий руководителя: 

moderator — модератор; 
editor — редактор; 
administrator — администратор; 
creator — создатель сообщества.

## Исключения
+ **AccessTokenInvalidException** - не задан или используется неверный AccessToken.
+ **InvalidParamException** - Неправильный идентификатор группы.

## Пример
```csharp
// Получаем идентификаторы и описание всех пользователей, состоящих в группе с id равным 1.
var ids = vk.Groups.GetMembers(new GroupsGetMembersParams() { GroupId = "1", Fields = UsersFields.All});

// Получаем идентификаторы 7 пользователей, начиная с 15 позиции, сортированных в порядке возрастания идентификаторов.
var ids = vk.Groups.GetMembers(new GroupsGetMembersParams() { GroupId = "1", Count=7, Offset=15, Sort = GroupsSort.IdAsc});

// Количество всех участников группы
ulong totalCount = ids.TotalCount;
```

## Версия Вконтакте API v.5.44
Дата обновления: 19.01.2016 16:15:07
