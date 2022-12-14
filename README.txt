Проект представляет собой взаимодействие с базой данных Аквапарка с помощью EntityFramework.

На главном экране находятся четыре вкладки.

Первая взаимодействует с операциями по оплате.
На данной вкладке реализованы операции CRUD.

Вторая взаимодействует браслетами покупателей.
На этой вкладке реализована бизнес-функция выдачи браслета покупателю, причем если у клиента уже есть браслет, он ему не выдастся.

На третьей вкладке сделан запрос к базе данных по определенной зоне отдыха через LINQ.

На четвертой вкладке совершается запрос к базе данных через хранимую процедуру.

В проекте реализована трехслойная архитектура (Presentation layer, Business layer, Data Access layer), 
а также паттерны IUnitOfWork и IRepository. Взаимодействие слоев происходит через интерфейсы, а ссылку
на объект интерфейса каждый слой получает через инъекцию.

Чтобы создать базу данных нужно выполнить файл CreateDB.sql, который находится в корне папки.
Исполняемый файл находится в EF\Lab1Ado.NET\bin\Debug
