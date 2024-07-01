using ControleFinanceiro.Core.Commands.Categories;
using ControleFinanceiro.Core.Entities;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : MainController
    {
        private readonly ICategoryHandler _categoryHandler;
        public CategoriesController(ICategoryHandler categoryHandler)
        {
            _categoryHandler = categoryHandler;
        }

        [HttpGet]
        public async Task<IResult> GetAllCategories( [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 25)
        {
            var category = new GetAllCategoryCommand
            {
                UserId = "string",
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await _categoryHandler.GetAllAsync(category);
            if (!result.IsSuccess) return Results.BadRequest(result);

            return Results.Ok(result);
        }


        [HttpGet("{id:long}")]
        public async Task<IResult> GetCategoryById(long id)
        {
            var command = new GetCategoryByIdCommand
            {
                Id = id,
                UserId = "string"
            };
            var result = await _categoryHandler.GetByIdAsync(command);
            if (!result.IsSuccess) return Results.BadRequest(result);

            return Results.Ok(result);
        }

        [HttpPost]
        public async Task<IResult> CreateCategory(CreateCategoryCommand command)
        {
            command.UserId = "string";

            var result = await _categoryHandler.CreateAsync(command);

            if(!result.IsSuccess) return Results.BadRequest(result);

            return Results.Created($"/{result.Data?.Id}", result);
        }

        [HttpPut("{id:long}")]
        public async Task<IResult> UpdateCategory(UpdateCategoryCommand command, long id)
        {
            command.Id = id;
            command.UserId = "string";

            var result = await _categoryHandler.UpdateAsync(command);
            if (!result.IsSuccess) return Results.BadRequest(result);

            return Results.Ok(result);
        }

        [HttpDelete("{id:long}")]
        public async Task<IResult> DeleteCategory(long id)
        {
            var command = new DeleteCategoryCommand
            {
                Id = id,
                UserId = "string"
            };

            var result = await _categoryHandler.DeleteAsync(command);
            if(!result.IsSuccess) return Results.BadRequest(result);

            return Results.Ok(result);
        }
    }
}
