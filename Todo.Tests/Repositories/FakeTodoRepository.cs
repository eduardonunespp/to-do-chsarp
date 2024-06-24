using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories;

public class FakeTodoRepository : ITodoRepository
{
    public void Create(TodoItem todoItem)
    {
        
    }

    public void Update(TodoItem todoItem)
    {
       
    }

    public TodoItem GetById(Guid id, string user)
    {
        return new TodoItem("", "", DateTime.Now);
    }

    public IEnumerable<TodoItem> GetAll(string email)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAllDone(string email)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAllUnDone(string email)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetByPeriod(string email, DateTime date, bool done)
    {
        throw new NotImplementedException();
    }
}