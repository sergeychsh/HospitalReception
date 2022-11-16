# HospitalReception
## Описание
Приложение представляет из себя asp.net core web api.
Реализовано 2 контроллера для редактирования таблиц пациентов и врачей.
Контроллер должен поддерживать операции:
-Добавление записи
-Редактирование записи
-Удаление записи
-Получения списка записей для формы списка с поддержкой сортировки и постраничного возврата данных (должна быть возможность через параметры указать по какому полю 
список должен быть отсортирован и так же через параметры указать какой фрагмент списка (страницу) необходимо вернуть)
-Получение записи по ид для редактирования

Объект, возвращаемый методом получения записи для редактирования и объекты, возвращаемые методом получения списка должны быть разными:
объект для редактирования должен содержать только поля редактируемой таблицы и ссылки (id) связанных записей из других таблиц,
объект списка не должен содержать внешних ссылок, вместо них необходимо возвращать значение из связанной таблицы (т.е. не id специализации врача, а название).
Никаких лишних полей в объектах быть не должно.

## Запуск проекта
1. Для запуска проекта необходимо в appsettings.json изменить ConnectionString для подключения к Sql Server
2. При первом запуске приложения произойдет инициализация бд с заполнением тестовыми данными
3. Запускается Swagger с описанием методов
