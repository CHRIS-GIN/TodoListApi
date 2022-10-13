using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoListApi.Models;
using ToDoListApi.Models;

namespace TodoListApi.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly TodoContext _context;

        public TodoListService(TodoContext context)
        {
            _context = context;
        }

        public Task<ServiceResponse<List<ToDoItem>>> AddTodoList(ToDoItem newTodoList)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<ToDoItem>>> DeleteTodoList(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<ToDoItem>>> GetAllTodoLists()
        {
            var serviceResponse = new ServiceResponse<List<ToDoItem>>();
            var dbTodoItem = await _context.TodoItems.ToListAsync();
            serviceResponse.Data = dbTodoItem;
            return serviceResponse;
        }

        public Task<ServiceResponse<ToDoItem>> UpdateTodoList(ToDoItem updateTodoList)
        {
            throw new NotImplementedException();
        }
    }
}