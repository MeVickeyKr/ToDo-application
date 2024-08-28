
using Microsoft.Extensions.DependencyInjection;
using Todo_Model.Services.Interfaces;
using Todo_Services.Services.Models;
using TodoDB.Entities;
using TodoDB.Repositories.Interfaces;

namespace Todo_Model.Services.Implementations
{
      public class TodoService : ITodoService
      {
        private readonly ITodoRepositoy _todoRepository;

        public TodoService(IServiceProvider serviceProvider)
        {
            _todoRepository = serviceProvider.GetRequiredService<ITodoRepositoy>();
       }



        public async Task<IEnumerable<Todoresponse>> GetAllTodo()
        {
            var products = await _todoRepository.GetAll();

            return  products.Select( p => new Todoresponse
            {
                  Id = p.Id,
                  Task  = p.Task,

                Iscompleted = p.Iscompleted,
                ModifieduserId = p.ModifieduserId,

                ModifiedDateTime = p.ModifiedDateTime,
            });
            
        }
        public async Task<Todoresponse> GetTodoById(int id)
        {

            var product = await _todoRepository.GetTodoById(id);

                if (product == null)
                {

                return null;
                }
                
                return new Todoresponse
                {
                    Id = product.Id,
                    Task = product.Task,
                    Iscompleted = product.Iscompleted,
                    ModifieduserId = product.ModifieduserId,
                    ModifiedDateTime = product.ModifiedDateTime,

                };
            
        }

        public async Task<Task> CreateItem( TodoRequest requestModel)
        {
            TodoEntity? todoEntity = new TodoEntity()
            {
                CreatedUserId = "system",
                CreatedDateTime = DateTime.Now,
                ModifiedDateTime= DateTime.Now,
                ModifieduserId="system",
                Id = requestModel.Id,
                Task = requestModel.Task,
                Iscompleted = requestModel.Iscompleted,
            };
           await  _todoRepository.CreateTodo( todoEntity);
            return Task.CompletedTask;
        }
        public async Task<Task> Update(int id, TodoRequest requestModel)
        {
            var product = await _todoRepository.GetTodoById(id);
            if (product != null)
            {
                product.Id = requestModel.Id;
                product.Task = requestModel.Task;
                product.Iscompleted = requestModel.Iscompleted;
               await _todoRepository.UpdateTodo(product);
            }
            return Task.CompletedTask;
        }
       public  async Task<Task> DeleteItem(int id)
        {
           await _todoRepository.Delete(id);
            return Task.CompletedTask;
        }

        
    }
}


