using Todo.Domain.Commands;

namespace Todo.Domain.Tests.CommandTests;

[TestClass]
public class CreateTodoCommandTests
{
    private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
    
    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Título da tarefa", "Sim, user", DateTime.Now);

    public CreateTodoCommandTests()
    {
        _invalidCommand.Validade();
        _validCommand.Validade();
    }
    
    [TestMethod]
    public void Dado_um_comando_invalido()
    {
        Assert.AreEqual(_invalidCommand.IsValid, false);
    }
    
    [TestMethod]
    public void Dado_um_comando_valido()
    {
        Assert.AreEqual(_validCommand.IsValid, true);
    }
}