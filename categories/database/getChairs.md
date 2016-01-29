---
layout: default
title: Метод Database.GetChairs
permalink: database/getChairs/
comments: true
---
# Метод Database.GetChairs
Возвращает список кафедр университета по указанному факультету.

Страница документации ВКонтакте [database.getChairs](https://vk.com/dev/database.getChairs).
## Синтаксис
``` csharp
public ReadOnlyCollection<Chair> GetChairs(long facultyId, int? count = null, int? offset = null)
```

## Параметры
+ **facultyId** - Идентификатор факультета, кафедры которого необходимо получить. положительное число, обязательный параметр
+ **offset** - Отступ, необходимый для получения определенного подмножества кафедр. положительное число
+ **count** - Количество кафедр которое необходимо получить. положительное число, по умолчанию 100, максимальное значение 10000

## Результат
Метод возвращает список кафедр, содержащих поля id и title.

## Пример
``` csharp
// Пример кода
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 12:42:38
