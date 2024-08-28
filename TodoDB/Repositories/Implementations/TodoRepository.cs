using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoDB.Entities;
using TodoDB.Repositories.Interfaces;
using TodoDBContext;



namespace TodoDB.Repositories.Implementations
{
    public class TodoRepository : ITodoRepositoy
    {
        private readonly TodoDatabaseContext _context;
        public TodoRepository(TodoDatabaseContext context)
        {
           _context = context;
        }

        public async Task< IEnumerable<TodoEntity> >GetAll()
        {
            return await _context.TodoList.ToListAsync();
        }

        public async Task<TodoEntity?> GetTodoById(int id)
        {
            
            return await _context.TodoList.FindAsync(id);
        }
        public async Task<Task>  CreateTodo( TodoEntity entity)
        {
            
             await _context.TodoList.AddAsync(entity);
             await _context.SaveChangesAsync();
            return Task.CompletedTask;
           
        }
        public async Task<Task> UpdateTodo(TodoEntity entity)
        {
                  _context.TodoList.Update(entity);
           await  _context.SaveChangesAsync();
            return Task.CompletedTask;
        }
        public async Task<Task> Delete(int id)
        {


            var product = await _context.TodoList.FindAsync(id);
            if (product != null)
            {
                _context.TodoList.Remove(product);
                _context.SaveChanges();
            }
            return Task.CompletedTask;
        }
    }
}
