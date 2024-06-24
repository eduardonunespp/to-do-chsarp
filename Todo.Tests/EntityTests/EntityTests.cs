using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests;

[TestClass]
public class EntityTests
{
    private readonly TodoItem _todo = new TodoItem("Novo Título", "Sim, um usuário", DateTime.Now);
            
    [TestMethod]
    public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_concluido()
    {
        Assert.AreEqual(_todo.Done, false);
    }
}