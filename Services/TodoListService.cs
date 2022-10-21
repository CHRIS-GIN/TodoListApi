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

        public async Task<ServiceResponse<List<ToDoItem>>> AddTodoItem(ToDoItem newTodoItem)
        {
            var serviceResponse = new ServiceResponse<List<ToDoItem>>();
            _context.TodoItems.Add(newTodoItem);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.TodoItems.ToListAsync();
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<ToDoItem>>> DeleteTodoList(int id)
        {
            ServiceResponse<List<ToDoItem>> response = new ServiceResponse<List<ToDoItem>>();
            try
            {
                ToDoItem toDoItem = await _context.TodoItems.FirstAsync(c => c.Id == id);
                _context.TodoItems.Remove(toDoItem);
                await _context.SaveChangesAsync();
                response.Data = _context.TodoItems.ToList();


            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

            }
            return response;
        }

        public async Task<ServiceResponse<List<ToDoItem>>> GetAllTodoLists()
        {
            var serviceResponse = new ServiceResponse<List<ToDoItem>>();
            var dbTodoItem = await _context.TodoItems.ToListAsync();
            serviceResponse.Data = dbTodoItem;
            return serviceResponse;
        }

        public async Task<ServiceResponse<ToDoItem>> UpdateTodoItem(ToDoItem updateTodoItem)
        {
            ServiceResponse<ToDoItem> response = new ServiceResponse<ToDoItem>();

            try
            {
                var toDoItem = await _context.TodoItems.FirstOrDefaultAsync(c => c.Id == updateTodoItem.Id);
                //toDoItem.Id=updateTodoItem.Id;
                toDoItem.Timestamp = updateTodoItem.Timestamp;
                toDoItem.Text = updateTodoItem.Text;
                toDoItem.Done = updateTodoItem.Done;
                await _context.SaveChangesAsync();

                response.Data = toDoItem;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

            }
            return response;
        }
    }
}