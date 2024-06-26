﻿using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests;

[TestClass]
public class TodoQuery
{

    public TodoQuery()
    {
        _items.Add(new TodoItem("Tarefa 1", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 2", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 3", "sim", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 4", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 5", "sim", DateTime.Now));
    }

    private List<TodoItem> _items = new List<TodoItem>();
    
    [TestMethod]
    public void Data_a_consulta_deve_retornar_tarefas_apenas_do_usuario_userSim()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("sim"));
        
        Assert.AreEqual(2, result.Count());
    }
}