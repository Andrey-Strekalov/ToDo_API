# 📝 Todo API (ASP.NET Core)

REST API для управления задачами (ToDo), реализованный на ASP.NET Core с использованием SQLite и сервисного слоя.

---

## 🚀 Возможности

* Получение списка задач
* Получение задачи по ID
* Создание новой задачи
* Обновление задачи
* Удаление задачи
* Переключение статуса выполнения
* Удаление всех выполненных задач

---

## 🛠 Технологии

* ASP.NET Core Web API
* Entity Framework Core
* SQLite
* Swagger

---

## 🏗 Архитектура

Проект разделён на слои:

* Controllers — обработка HTTP-запросов
* Services — бизнес-логика (ITodoService)
* Models — модель данных
* Data (DbContext) — работа с базой данных

---

## 📦 Модель данных

TodoItem содержит:

```
id: long  
content: string  
isComplete: bool  
```

---

## 🔗 Эндпоинты API

### Получить все задачи

GET /api/TodoItems

Ответ:

```
[
  {
    id: 1,
    content: "Купить продукты",
    isComplete: false
  }
]
```

---

### Получить задачу по ID

GET /api/TodoItems/{id}

Ответ:

```
{
  id: 1,
  content: "Купить продукты",
  isComplete: false
}
```

---

### Создать задачу

POST /api/TodoItems

Тело запроса:

```
{
  content: "Сделать домашку",
  isComplete: false
}
```

Ответ:

```
{
  id: 2,
  content: "Сделать домашку",
  isComplete: false
}
```

---

### Обновить задачу

PUT /api/TodoItems/{id}

Тело запроса:

```
{
  id: 2,
  content: "Сделать домашку по C#",
  isComplete: false
}
```

---

### Переключить статус задачи

PATCH /api/TodoItems/{id}/toggle-status

Ответ:

```
{
  id: 2,
  content: "Сделать домашку по C#",
  isComplete: true
}
```

---

### Удалить задачу

DELETE /api/TodoItems/{id}

Ответ:
204 No Content

---

### Удалить выполненные задачи

DELETE /api/TodoItems/completed

Ответ:

```
{
  message: "Удалено 3 задач",
  deletedCount: 3
}
```

---

## ▶️ Запуск проекта

### Клонирование

```
git clone https://github.com/Andrey-Strekalov/ToDo_API.git
cd ToDo_API
```

### Запуск

```
dotnet run
```

---

## 📍 Адреса

* [https://localhost:5001](https://localhost:5001)
* [http://localhost:5000](http://localhost:5000)

---

## 📘 Swagger

После запуска:

```
https://localhost:5001/swagger
```

---

## 💡 Дополнительно

* SQLite база создаётся автоматически
* Можно тестировать через Swagger или Postman
* Используется сервисный слой (разделение логики)

---

## 📌 Статус проекта

✔ Завершён (базовый функционал реализован)
🚀 Возможные улучшения:

* JWT авторизация
* DTO слой
* логирование
* расширение модели задач

---

