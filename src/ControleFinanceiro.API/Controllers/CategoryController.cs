using ControleFinanceiro.Core.Commands.Categories;
using ControleFinanceiro.Core.Entities;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/categories")]
    public class CategoryController : MainController
    {
        private readonly ICategoryHandler _categoryHandler;
        public CategoryController(ICategoryHandler categoryHandler)
        {
            _categoryHandler = categoryHandler;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCategories()
        {
            var category = new GetAllCategoryCommand
            {
                UserId = "string"
            };

            var getAll = await _categoryHandler.GetAllAsync(category);
            return Ok(getAll);
        }


        [HttpGet("{id:long}")]
        public async Task<ActionResult> GetCategoryById(long id)
        {
            var command = new GetCategoryByIdCommand
            {
                Id = id,
                UserId = "string"
            };
            var getById = await _categoryHandler.GetByIdAsync(command);

            return Ok(getById);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(CreateCategoryCommand command)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var category = await _categoryHandler.CreateAsync(command);

            return Ok(category);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<UpdateCategoryCommand>> UpdateCategory(UpdateCategoryCommand command, long id)
        {
            command.Id = id;
            var updateCategory = await _categoryHandler.UpdateAsync(command);

            return Ok(updateCategory);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult> DeleteCategory(long id)
        {
            var command = new DeleteCategoryCommand
            {
                Id = id,
                UserId = "string"
            };

            var removeCategory = await _categoryHandler.DeleteAsync(command);

            return Ok(removeCategory);
        }
    }
}
