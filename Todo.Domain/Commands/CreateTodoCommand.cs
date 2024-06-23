using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class CreateTodoCommand : Notifiable<Notification>, ICommand {

    public CreateTodoCommand(string title, string user, DateTime date)
    {
        Title = title;
        User = user;
        Date = date;
    }
    public string Title { get; set; }
    public string User { get; set; }
    public DateTime Date { get; set; }
    
    public void Validade()
    {
        AddNotifications(new Contract<CreateTodoCommand>()
            .Requires()
            .IsNotNullOrEmpty(Title, "Title", "O campo título é obrigatório")
            .IsGreaterOrEqualsThan(Title.Length, 3, "Title", "O título deve ter pelo menos 3 caracteres")
            .IsNotNullOrEmpty(User, "User", "O campo usuário é obrigatório"));
    }
}