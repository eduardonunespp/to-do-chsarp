using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;

public class TodoHandler : Notifiable<Notification>,
    IHandler<CreateTodoCommand>,
    IHandler<UpdateTodoCommand>,
    IHandler<MarkTodoAsDoneCommand>,
    IHandler<MarkTodoAsUndoneCommand>
{

    public TodoHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    private readonly ITodoRepository _repository;
    
    public ICommandResult Handle(CreateTodoCommand command)
    {
        command.Validade();
        if (!command.IsValid)
        {
            return new GenericCommandResult(false,
                "Ops, parece que sua tarefa está errada",
                command.Notifications);
        }

        var todo = new TodoItem(command.Title, command.User, command.Date);
        
        _repository.Create(todo);

        return new GenericCommandResult(true, "Tarefa salva", todo);
    }

    public ICommandResult Handle(UpdateTodoCommand command)
    {
        command.Validade();
        if (!command.IsValid)
        {
            return new GenericCommandResult(false,
                "Ops, parece que sua tarefa está errada",
                command.Notifications);
        }
        
        //Rehidratação
        var todo = _repository.GetById(command.Id, command.User);

        todo.UpdateTitle(command.Title);
        
        _repository.Update(todo);

        return new GenericCommandResult(true, "Tarefa Salva", todo);
        
    }

    public ICommandResult Handle(MarkTodoAsDoneCommand command)
    {
        command.Validade();
        if (!command.IsValid)
        {
            return new GenericCommandResult(false,
                "Ops, parece que sua tarefa está errada",
                command.Notifications);
        }

        var todo = _repository.GetById(command.Id, command.User);
        
        todo.MarkAsDone();
        
        _repository.Update(todo);

        return new GenericCommandResult(true, "A tarefa foi salva com sucesso!", todo);
    }

    public ICommandResult Handle(MarkTodoAsUndoneCommand command)
    {
        command.Validade();
        if (!command.IsValid)
        {
            return new GenericCommandResult(false,
                "Ops, parece que sua tarefa está errada",
                command.Notifications);
        }

        var todo = _repository.GetById(command.Id, command.User);
        
        todo.MarkAsUndone();
        
        _repository.Update(todo);

        return new GenericCommandResult(true, "A tarefa foi desmarcada como salva com sucesso!", todo);
    }
}