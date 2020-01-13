---
layout: default
title: Метод Market.ReportComment
permalink: market/reportComment/
comments: true
---
# Метод Market.ReportComment
Позволяет оставить жалобу на комментарий к товару.

Страница документации ВКонтакте [market.reportComment](https://vk.com/dev/market.reportComment).

## Синтаксис
``` csharp
public bool ReportComment(long ownerId, long commentId, ReportReason reason)
```

## Параметры
+ **ownerId** — Идентификатор владельца товара. 
Обратите внимание, идентификатор сообщества в параметре owner_id необходимо указывать со знаком "-" — например, owner_id=-1 соответствует идентификатору сообщества ВКонтакте API (club1)  целое число, обязательный параметр
+ **commentId** — Идентификатор комментария. положительное число, обязательный параметр
+ **reason** — Причина жалобы: 
0 — спам; 
1 — детская порнография; 
2 — экстремизм; 
3 — насилие; 
4 — пропаганда наркотиков; 
5 — материал для взрослых; 
6 — оскорбление. 
положительное число, обязательный параметр

## Результат
После успешного выполнения возвращает **true**.

## Пример
``` csharp
var reportComment = _api.Market.ReportComment(ownerId: 0, commentId: 0, reason: 0);
```

## Версия Вконтакте API v.5.44
Дата обновления: 29.01.2016 14:55:24
