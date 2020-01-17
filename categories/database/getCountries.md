---
layout: default
title: Метод Database.GetCountries
permalink: database/getCountries/
comments: true
---
# Метод Database.GetCountries
Возвращает список стран.

Страница документации ВКонтакте [database.getCountries](https://vk.com/dev/database.getCountries).

## Синтаксис
``` csharp
public ReadOnlyCollection<Country> GetCountries(
	bool? needAll = null,
	List<Iso3166> codes = null,
	int? count = null,
	int? offset = null
)
```

## Параметры
+ **needAll** - 1 — вернуть список всех стран. флаг, может принимать значения 1 или 0
+ **code** - Перечисленные через запятую двухбуквенные коды стран в стандарте ISO 3166-1 alpha-2, для которых необходимо выдать информацию.
Пример значения code:
RU,UA,BY строка
+ **offset** - Отступ, необходимый для выбора определенного подмножества стран. положительное число
+ **count** - Количество стран, которое необходимо вернуть. положительное число, по умолчанию 100, максимальное значение 1000

## Результат
Возвращает массив стран, каждый из объектов которого содержит поля cid и title. Если не заданы параметры need_all и code, то возвращается краткий список стран, расположенных наиболее близко к стране текущего пользователя. Если задан параметр need_all, то будет возвращен список всех стран. Если задан параметр code, то будут возвращены только страны с перечисленными ISO 3166-1 alpha-2 кодами.

## Замечания
+ Если не заданы параметры needAll и code, то возвращается краткий список стран, расположенных наиболее близко к стране текущего пользователя. Если задан параметр needAll, то будет возвращен список всех стран. Если задан параметр code, то будут возвращены только страны с перечисленными ISO 3166-1 alpha-2 кодами.

## Пример
```csharp
// Россия и Германия
var countries = api.Database.GetCountries(codes: "ru, de");
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 12:42:38