using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoListApi.Models;
using TodoListApi.Services;
using ToDoListApi.Models;

namespace TodoListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoListController : ControllerBase
    {

        private readonly ITodoListService _todoListService;

        public TodoListController(ITodoListService todoListService)
        {

            _todoListService = todoListService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<ToDoItem>>>> GetAll()
        {
            return Ok(await _todoListService.GetAllTodoLists());
        }
    }
}