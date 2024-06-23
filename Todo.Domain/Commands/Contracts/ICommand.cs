using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;
using Flunt.Validations;

namespace Todo.Domain.Commands.Contracts;

public interface ICommand
{
    void Validade();
    
}