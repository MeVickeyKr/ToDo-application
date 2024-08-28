using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoDB.Entities;

namespace TodoDB.Repositories.Interfaces
{
    public interface ITodoRepositoy
    {
        Task<IEnumerable<TodoEntity>> GetAll();
        Task<TodoEntity?> GetTodoById(int id);
        Task<Task> CreateTodo(TodoEntity entity);
        Task<Task> UpdateTodo(TodoEntity entity);

        Task<Task> Delete(int id);
    }
}
