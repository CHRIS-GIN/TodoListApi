using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListApi.Models;
using ToDoListApi.Models;

namespace TodoListApi.Services
{
    public interface ITodoListService
    {
        Task<ServiceResponse<List<ToDoItem>>> GetAllTodoLists();
        //Task<ServiceResponse<GetCharacterDto>> GetTodoListById(int id);
        Task<ServiceResponse<List<ToDoItem>>> AddTodoItem(ToDoItem newTodoItem);
        Task<ServiceResponse<ToDoItem>> UpdateTodoItem(ToDoItem updateTodoItem);
        Task<ServiceResponse<List<ToDoItem>>> DeleteTodoList(int id);
        

    }
}