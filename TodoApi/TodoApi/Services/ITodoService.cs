using TodoApi.Models;

namespace TodoApi.Services;

public interface ITodoService
{

    Task<IEnumerable<TodoItem>> GetAllTodosAsync();
    Task<TodoItem?> GetTodoByIdAsync(long id);
    Task<TodoItem> CreateTodoAsync(TodoItem todoItem);
    Task UpdateTodoAsync(TodoItem todoItem);
    Task<bool> DeleteTodoAsync(long id);


    Task<IEnumerable<TodoItem>> GetCompletedTodosAsync();
    Task<IEnumerable<TodoItem>> GetIncompleteTodosAsync();
    Task DeleteCompletedTodosAsync();
    Task<TodoItem> ToggleTodoStatusAsync(long id);

    Task<bool> TodoItemExitsAsync(long id);
}

