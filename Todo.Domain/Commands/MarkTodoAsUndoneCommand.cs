using Flunt.Notifications;
using Flunt.Validations;

namespace Todo.Domain.Commands.Contracts;

public class MarkTodoAsUndoneCommand: Notifiable<Notification>, ICommand
{
    public Guid Id { get; set; }
    public string User { get; set; }
    
    public void Validade()
    {
        AddNotifications(new Contract<MarkTodoAsDoneCommand>()
            .Requires()
            .IsMinValue(3, User, "O valor mínimo deve ser de 3 caracteres")
        );
    }
}