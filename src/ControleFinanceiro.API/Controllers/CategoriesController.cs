using ControleFinanceiro.Core.Commands.Categories;
using ControleFinanceiro.Core.Models;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Core.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/categories")]
    [Authorize]
    public class CategoriesController : MainController
    {
        private readonly ICategoryHandler _categoryHandler;
        private readonly ClaimsPrincipal _user;
        public CategoriesController(ICategoryHandler categoryHandler,
                                    ClaimsPrincipal user)
        {
            _categoryHandler = categoryHandler;
            _user = user;
        }

        [HttpGet]
        public async Task<IResult> GetAllCategories( [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 25)
        {
            var category = new GetAllCategoryCommand
            {
                UserId = _user.Identity?.Name ?? string.Empty,
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
                UserId = _user.Identity?.Name ?? string.Empty,
            };
            var result = await _categoryHandler.GetByIdAsync(command);
            if (!result.IsSuccess) return Results.BadRequest(result);

            return Results.Ok(result);
        }

        [HttpPost]
        public async Task<IResult> CreateCategory(CreateCategoryCommand command)
        {
            command.UserId = _user.Identity?.Name ?? string.Empty;

            var result = await _categoryHandler.CreateAsync(command);

            if(!result.IsSuccess) return Results.BadRequest(result);

            return Results.Created($"/{result.Data?.Id}", result);
        }

        [HttpPut("{id:long}")]
        public async Task<IResult> UpdateCategory(UpdateCategoryCommand command, long id)
        {
            command.Id = id;
            command.UserId = _user.Identity?.Name ?? string.Empty;

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
                UserId = _user.Identity?.Name ?? string.Empty
            };

            var result = await _categoryHandler.DeleteAsync(command);
            if(!result.IsSuccess) return Results.BadRequest(result);

            return Results.Ok(result);
        }
    }
}
