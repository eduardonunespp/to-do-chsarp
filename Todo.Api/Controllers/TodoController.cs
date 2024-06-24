using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers;

    [ApiController]
    [Route("v1/todos")]
    [Authorize]
    public class TodoController: ControllerBase
{

    [HttpPost()]
    public GenericCommandResult CreateTodo(
        [FromBody] CreateTodoCommand command,
        [FromServices] TodoHandler handler
        )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        command.User = user;
        return (GenericCommandResult)handler.Handle(command);
    }
    
    [HttpPut()]
    public GenericCommandResult UpdateTodo(
        [FromBody] UpdateTodoCommand command,
        [FromServices] TodoHandler handler
    )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        command.User = user;
        return (GenericCommandResult)handler.Handle(command);
    }
    
    [HttpPatch("mark-as-done")]
    public GenericCommandResult MarkAsDoneTodo(
        [FromBody] MarkTodoAsDoneCommand command,
        [FromServices] TodoHandler handler
    )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        command.User = user;
        return (GenericCommandResult)handler.Handle(command);
    }
    
    [HttpPatch("mark-as-undone")]
    public GenericCommandResult MarkAsUndoneTodo(
        [FromBody] MarkTodoAsUndoneCommand command,
        [FromServices] TodoHandler handler
    )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return (GenericCommandResult)handler.Handle(command);
    }

    [HttpGet()]
    public IEnumerable<TodoItem> GetAll([FromServices]ITodoRepository repository)
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetAll(user);
    }
    
    
    [HttpGet("done")]
    public IEnumerable<TodoItem> GetAllDone([FromServices]ITodoRepository repository)
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetAllDone(user);
    }
    
    [HttpGet("undone")]
    public IEnumerable<TodoItem> GetAllUndone([FromServices]ITodoRepository repository)
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetAllUnDone(user);
    }

    [Route("done/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForToday(
        [FromServices] ITodoRepository repository
        )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetByPeriod(user, DateTime.Now.Date, true);
    }
    
    [Route("undone/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetInactiveForToday(
        [FromServices] ITodoRepository repository
    )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetByPeriod(user, DateTime.Now.Date, false);
    }
    
    [Route("done/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForTomorrow(
        [FromServices] ITodoRepository repository
    )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), true);
    }
    
    [Route("undone/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUndoneForTomorrow(
        [FromServices] ITodoRepository repository
    )
    {
        var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
        return repository.GetByPeriod(user, DateTime.Now.Date.AddDays(1), false);
    }
    
}