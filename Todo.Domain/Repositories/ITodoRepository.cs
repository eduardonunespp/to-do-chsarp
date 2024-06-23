using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        void Create(TodoItem todoItem);
        void Update(TodoItem todoItem);
        public TodoItem GetById(Guid id, string user);

        IEnumerable<TodoItem> GetAll(string user);

        IEnumerable<TodoItem> GetAllDone(string user);

        IEnumerable<TodoItem> GetAllUnDone(string user);

        IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done);
    }
}