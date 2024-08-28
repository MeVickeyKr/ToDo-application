
using Todo_Services.Services.ApiResponse;
using Todo_Services.Services.Models;
using TodoDB.Entities;

namespace Todo_Model.Services.Interfaces
{
    public interface ITodoService
    {
        public Task<IEnumerable<Todoresponse>> GetAllTodo();
        public Task<Todoresponse> GetTodoById(int id);
        public Task<Task> CreateItem( TodoRequest requestModel);
       public  Task<Task> Update(int id, TodoRequest requestModel);
        public Task<Task> DeleteItem(int id);


    }
}
