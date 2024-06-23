using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories;

public class TodoRepository : ITodoRepository
{

    private readonly TodoContext _context;
    
    public TodoRepository(TodoContext context)
    {
        _context = context;
    }
    
    public void Create(TodoItem todoItem)
    {
        _context.Todos.Add(todoItem);
        _context.SaveChanges();
    }

    public void Update(TodoItem todoItem)
    {
        _context.Entry(todoItem).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public TodoItem GetById(Guid id, string user)
    {
        return _context.Todos.FirstOrDefault(x => x.Id == id && x.User == user);
    }

    public IEnumerable<TodoItem> GetAll(string user)
    {
        return _context.Todos.AsNoTracking().Where(TodoQueries.GetAll(user)).OrderBy(x => x.Date);
    }

    public IEnumerable<TodoItem> GetAllDone(string user)
    {
        return _context.Todos.AsNoTracking().Where(TodoQueries.GetAllDone(user)).OrderBy(x => x.Date);
    }

    public IEnumerable<TodoItem> GetAllUnDone(string user)
    {
        return _context.Todos.AsNoTracking().Where(TodoQueries.GetAllUndone(user)).OrderBy(x => x.Date);
    }

    public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
    {
        return _context.Todos.AsNoTracking().Where(TodoQueries.GetByPeriod(user, date, done));
    }
}