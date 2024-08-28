
using Microsoft.AspNetCore.Mvc;
using Todo_Model.Services.Interfaces;
using Todo_Services.Services.Models;



namespace TODOList.Controller

{

    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }


        // GET: api/TodoLists
        [HttpGet]
        public async Task< ActionResult<IEnumerable<Todoresponse>> >GetAllAsync()
        {
            return Ok(await _todoService.GetAllTodo());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var product = await _todoService.GetTodoById(id);
            if (product == null)
            {
                return NotFound($"no todo found with this {id}");
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync ([FromBody] TodoRequest requestModel)
        {
            await _todoService.CreateItem( requestModel);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] TodoRequest requestModel)
        {
           await _todoService.Update(id, requestModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _todoService.DeleteItem(id);
            return NoContent();
        }
    }
}
