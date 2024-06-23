using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class UpdateTodoCommand: Notifiable<Notification>, ICommand
{

    public UpdateTodoCommand(string title, string user, Guid Id )
    {
        Id = Id;
        Title = title;
        User = user;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string User { get; set; }
    
    public void Validade()
    {
        AddNotifications(new Contract<UpdateTodoCommand>()
            .Requires()
            .IsNotNullOrEmpty(Title, "Title", "O campo é obrigatório")
            .IsMinValue(3, "Title", "O campo deve conter no mínimo 3 caracteres")
            .IsMinValue(3, User, "Usuário inválido!")
        );
    }
}