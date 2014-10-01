---
layout: default
title: Title for vknet
---

# hello world
## Авторизация
TODO add link

## Пользователи
+ [Users.Get](/users/get/) - Возвращает расширенную информацию о пользователях.
+ [Users.GetFollowers](/users/getFollowers/) - Возвращает список идентификаторов пользователей, которые являются подписчиками пользователя.
+ [Users.GetGroups](/users/getGroups/) - Возвращает список id групп пользователя.
+ [Users.GetGroupsFull](/users/getGroupsFull/) - Возвращает базовую информацию о группах текущего пользователя или о группах из списка gids.
+ [Users.GetSubscription](/users/getSubscription/) - Возвращает список идентификаторов пользователей и групп, которые входят в список подписок пользователя.
+ [Users.GetUserBalance](/users/getUserBalance/) - Возвращает баланс текущего пользователя на счету приложения в сотых долях голоса. Отличается от метода secure.getBalance тем, что не требует безопасного соединения с сервером API.
+ [Users.GetUserSettings](/users/getUserSettings/) - Получает настройки текущего пользователя в данном приложении.
+ [Users.IsAppUser](/users/isAppUser/) - Возвращает информацию о том, установил ли текущий пользователь приложение или нет.
+ [Users.Report](/users/report/) - Позволяет пожаловаться на пользователя.
+ [Users.Search](/users/search/) - Возвращает список пользователей в соответствии с заданным критерием поиска.

## Друзья
+ [Friends.Add](/friends/add/) - Одобряет или создает заявку на добавление в друзья.
+ [Friends.AddList](/friends/addList/) - Возвращает информацию о том добавлен ли текущий пользователь в друзья у указанных пользователей. Также возвращает информацию о наличии исходящей или входящей заявки в друзья (подписки).
+ [Friends.AreFriends](/friends/areFriends/) - Возвращает информацию о том добавлен ли текущий пользователь в друзья у указанных пользователей. Также возвращает информацию о наличии исходящей или входящей заявки в друзья (подписки).
+ [Friends.Delete](/friends/delete/) - Удаляет пользователя из списка друзей или отклоняет заявку в друзья.
+ [Friends.DeleteAllRequests](/friends/deleteAllRequests/) - Отмечает все входящие заявки на добавление в друзья как просмотренные.
+ [Friends.DeleteList](/friends/deleteList/) - Удаляет существующий список друзей текущего пользователя.
+ [Friends.Edit](/friends/edit/) - Редактирует списки друзей для выбранного друга.
+ [Friends.EditList](/friends/editList/) - Редактирует существующий список друзей текущего пользователя.
+ [Friends.Get](/friends/get/) - Возвращает список идентификаторов друзей пользователя или расширенную информацию о друзьях пользователя (при использовании параметра fields).
+ [Friends.GetAppUsers](/friends/getAppUsers/) - Возвращает список идентификаторов друзей текущего пользователя, которые установили данное приложение.
+ [Friends.GetLists](/friends/getLists/) - Возвращает список меток друзей текущего пользователя.
+ [Friends.GetMutual](/friends/getMutual/) - Возвращает список идентификаторов общих друзей между парой пользователей.
+ [Friends.GetOnline](/friends/getOnline/) - Возвращает список идентификаторов, находящихся на сайте друзей, пользователя.
+ [Friends.GetRecent](/friends/getRecent/) - Возвращает список идентификаторов недавно добавленных друзей текущего пользователя.
+ [Friends.GetRequests](/friends/getRequests/) - Возвращает информацию о полученных или отправленных заявках на добавление в друзья для текущего пользователя.

## Группы
+ [Groups.Get] (/groups/get/) - 
+ [Groups.GetById] (/groups/getById/) - 
+ [Groups.IsMember] (/groups/isMember/) - 
+ [Groups.GetMembers] (/groups/getMembers/) - 
+ [Groups.Search] (/groups/search/) - 
+ [Groups.Join] (/groups/join/) - 
+ [Groups.Leave] (/groups/leave/) - 
+ [Groups.GetInvites] (/groups/getInvites/) - 
+ [Groups.BanUser] (/groups/banUser/) - 
+ [Groups.GetBanned] (/groups/getBanned/) - 
+ [Groups.UnbanUser] (/groups/unbanUser/) - 

## Аудиозаписи
+ [Audio.Get](/audio/get/) -
+ [Audio.GetFromGroup](/audio/getFromGroup/) - 
+ [Audio.GetById](/audio/getById/) - 
+ [Audio.GetCount](/audio/getCount/) - 
+ [Audio.GetLyrics](/audio/getLyrics/) - 
+ [Audio.GetUploadServer](/audio/getUploadServer/) - 
+ [Audio.Search](/audio/search/) - 
+ [Audio.Add](/audio/add/) - 
+ [Audio.Delete](/audio/delete/) - 
+ [Audio.Edit](/audio/edit/) - 
+ [Audio.Restore](/audio/restore/) - 
+ [Audio.Reorder](/audio/reorder/) - 
+ [Audio.AddAlbum](/audio/addAlbum/) - 
+ [Audio.EditAlbum](/audio/editAlbum/) - 
+ [Audio.DeleteAlbum](/audio/deleteAlbum/) - 
+ [Audio.GetPopular](/audio/getPopular/) - 
+ [Audio.GetAlbums](/audio/getAlbums/) - 
+ [Audio.MoveToAlbum](/audio/moveToAlbum/) - 
+ [Audio.GetRecommendations](/audio/getRecommendations/) - 
+ [Audio.SetBroadcast](/audio/setBroadcast/) - 

## Сообщения
+ [Messages.Get] (/messages/get/) -
+ [Messages.GetHistory] (/messages/getHistory/) - 
+ [Messages.GetById] (/messages/getById/) - 
+ [Messages.GetDialogs] (/messages/getDialogs/) - 
+ [Messages.SearchDialogs] (/messages/searchDialogs/) - 
+ [Messages.Search] (/messages/search/) - 
+ [Messages.Send] (/messages/send/) - 
+ [Messages.DeleteDialog] (/messages/deleteDialog/) - 
+ [Messages.Delete] (/messages/delete/) - 
+ [Messages.Restore] (/messages/restore/) - 
+ [Messages.MarkAsNew] (/messages/markAsNew/) - 
+ [Messages.MarkAsRead] (/messages/markAsRead/) - 
+ [Messages.SetActivity] (/messages/setActivity/) - 
+ [Messages.GetLastActivity] (/messages/getLastActivity/) - 
+ [Messages.GetChat] (/messages/getChat/) - 
+ [Messages.CraeteChat] (/messages/createChat/) - 
+ [Messages.EditChat] (/messages/editChat/) - 
+ [Messages.GetChatUsers] (/messages/getChatUsers/) - 
+ [Messages.AddChatUser] (/messages/addChatUser/) - 
+ [Messages.RemoveChatUser] (/messages/removeChatUser/) - 
+ [Messages.GetLongPollServer] (/messages/getLongPollServer/) - 

## Стена
+ [Wall.Get](/wall/get/) -
+ [Wall.GetComments](/wall/getComments/) - 
+ [Wall.GetById](/wall/getById/) - 
+ [Wall.Delete](/wall/delete/) - 

## Статус
+ [Status.Get](/status/get/) -
+ [Status.Set](/status/set/) - 

## Видео
+ [Video.Get](/video/get/) - 
+ [Video.Edit](/video/edit/) - 
+ [Video.Add](/video/add/) - 
+ [Video.Save](/video/save/) - 
+ [Video.Delete](/video/delete/) - 
+ [Video.Restore](/video/restore/) - 
+ [Video.Search](/video/search/) - 
+ [Video.GetUserVideos](/video/getUserVideos/) - 
+ [Video.GetAlbums](/video/getAlbums/) - 
+ [Video.AddAlbum](/video/addAlbum/) - 
+ [Video.EditAlbum](/video/editAlbum/) - 
+ [Video.DeleteAlbum](/video/deleteAlbum/) - 
+ [Video.MoveToAlbum](/video/moveToAlbum/) - 
+ [Video.GetComments](/video/getComments/) - 
+ [Video.CreateComment](/video/createComment/) - 
+ [Video.DeleteComment](/video/deleteComment/) - 
+ [Video.RestoreComment](/video/restoreComment/) - 
+ [Video.EditComment](/video/editComment/) -
+ [Video.GetTags](/video/getTags/) - 
+ [Video.PutTag](/video/putTag/) - 
+ [Video.RemoveTag](/video/removeTag/) - 
+ [Video.GetNewTags](/video/getNewTags/) - 
+ [Video.Report](/video/report/) - 
+ [Video.ReportComment](/video/reportComment/) - 

## Закладки
+ [Fave.GetUsers](/fave/getUsers/) -
+ [Fave.GetPhotos](/fave/getPhotos/) - 
+ [Fave.GetPosts](/fave/getPosts/) - 
+ [Fave.GetVideos](/fave/getVideos/) - 
+ [Fave.GetLinks](/fave/getLinks/) - 

## Служебные
+ [Utils.CheckLink](/utils/checkLink/) -
+ [Utils.ResolveScreenName](/utils/resolveScrennName/) - 
+ [Utils.GetServerTime](/utils/getServerTime/) - 

## Данные ВК
+ [Database.GetCountries](/database/getCountries/) - 
+ [Database.GetRegions](/database/getRegions/) - 
+ [Database.GetStreetsById](/database/getStreetsById/) - 
+ [Database.GetCountriesById](/database/getCountriesById/) - 
+ [Database.GetCities](/database/getCities/) - 
+ [Database.GetCitiesById](/database/getCitiesById/) - 
+ [Database.GetUniversities](/database/getUniversities/) - 
+ [Database.GetSchools](/database/getSchools/) - 
+ [Database.GetFaculties](/database/getFaculties/) - 
