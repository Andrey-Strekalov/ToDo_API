using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using TodoApi.Models;

namespace TodoApi.Services;

public class TodoService : ITodoService
{

    private readonly TodoContext _context;

    public TodoService(TodoContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TodoItem>> GetAllTodosAsync()
    {
        return await _context.TodoItems.ToListAsync();
    }

    public async Task<TodoItem?> GetTodoByIdAsync(long id)
    {
        return await _context.TodoItems.FindAsync(id);
    }

    public async Task<TodoItem> CreateTodoAsync(TodoItem todoItem)
    {
        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();
        return todoItem;
    }
    public async Task UpdateTodoAsync(TodoItem todoItem)
    {
        _context.Entry(todoItem).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    public async Task<bool> DeleteTodoAsync(long id)
    {
        var todoToDelete = await _context.TodoItems.FindAsync(id);
        if (todoToDelete == null) return false;

        _context.TodoItems.Remove(todoToDelete);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<TodoItem>> GetCompletedTodosAsync()
    {

        return await _context.TodoItems.Where(t => t.isComplete).ToListAsync();
    }
    public async Task<IEnumerable<TodoItem>> GetIncompleteTodosAsync()
    {
        return await _context.TodoItems.Where(t => !t.isComplete).ToListAsync();

    }

    public async Task DeleteCompletedTodosAsync()
    {
        var completedItems = await _context.TodoItems.Where(t => t.isComplete).ToListAsync();

        _context.TodoItems.RemoveRange(completedItems);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> TodoItemExitsAsync(long id)
    {
        return await _context.TodoItems.AnyAsync(e => e.Id == id);
    }

    public async Task<TodoItem> ToggleTodoStatusAsync(long id)
    {
        var todoItem = await _context.TodoItems.FindAsync(id);

        if (todoItem == null)
        {
            throw new ArgumentException($"Todo item with id {id} not found");
        }

        // Меняем статус на противоположный
        todoItem.isComplete = !todoItem.isComplete;

        await _context.SaveChangesAsync();

        return todoItem;
    }

}

