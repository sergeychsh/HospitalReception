# HospitalReception
## Описание
Приложение представляет из себя asp.net core web api.  

Реализовано 2 контроллера для редактирования таблиц пациентов и врачей:
- DoctorsController
- PatientsController

Контроллеры поддерживают операции:
- Добавление записи
- Редактирование записи
- Удаление записи
- Получения списка записей для формы списка с поддержкой сортировки и постраничного возврата данных (реализована возможность через параметры указать, по какому полю 
список должен быть отсортирован, и так же через параметры указать, какой фрагмент списка (страницу) необходимо вернуть)
- Получение записи по id для редактирования

## Запуск проекта
1. Для запуска проекта необходимо в appsettings.json изменить ConnectionString для подключения к Sql Server
2. При первом запуске приложения произойдет инициализация бд с заполнением тестовыми данными
3. Запускается Swagger с описанием методов

## Примеры запросов
1. Получение записей с постраничным возвратом и сортировкой
  
  GET
  - http://localhost:5000/api/patients?pageNumber=1&pageSize=2&orderBy=FirstName asc
  - http://localhost:5000/api/doctors?pageNumber=1&pageSize=10&orderBy=fio asc
2. Получение записи по id для редактирования
  
  GET
  - http://localhost:5000/api/patients/1
  - http://localhost:5000/api/doctors/1
3. Добавление записи
  
  POST
  - http://localhost:5000/api/patients
  
  {
      "firstName": "Иванов",
      "lastName": "Иван",
      "middleName": "Иванович",
      "address": "Улица",
      "birthDate": "2000-01-01T00:00:00",
      "gender": 1,
      "siteId": 1
  }
  - http://localhost:5000/api/doctors/
  
  {
      "fio": "Лемешова А.Н.",
      "cabinetId": 1,
      "specializationId": 1,
      "siteId": 1
  }
 4. Редактирование записи
  
  PUT
  - http://localhost:5000/api/patients/1

  {
      "firstName": "Иванов",
      "lastName": "Иван",
      "middleName": "Иванович",
      "address": "Улица Иванова",
      "birthDate": "2000-01-01T00:00:00",
      "gender": 1,
      "siteId": 1
  }
  - http://localhost:5000/api/doctors/1

  {
      "fio": "Лемешова А.Н.",
      "cabinetId": 2,
      "specializationId": 1,
      "siteId": 0
  }
 5. Удаление записи

  DELETE
  - http://localhost:5000/api/patients/1
  - http://localhost:5000/api/doctors/1
