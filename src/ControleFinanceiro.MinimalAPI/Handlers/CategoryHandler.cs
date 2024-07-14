using ControleFinanceiro.Core.Commands.Categories;
using ControleFinanceiro.Core.Models;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Core.Responses;
using ControleFinanceiro.Core.Services;
using ControleFinanceiro.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.MinimalAPI.Handlers
{
    public class CategoryHandler(AppDbContext _context) : ICategoryHandler
    {
        public async Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoryCommand command)
        {
            try 
            {
                var query = _context.Categories.AsNoTracking().Where(x => x.UserId == command.UserId).OrderBy(x => x.Title);

                var categories = await query.Skip((command.PageNumber - 1) * command.PageSize).Take(command.PageSize).ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Category>>(categories, count, command.PageNumber, command.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Category>>(null, 500, "Nao foi possivel consultar as suas categorias");
            }

        }
        public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdCommand command)
        {
            var category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == command.Id && c.UserId == command.UserId);
            try
            {
                return category is null ? new Response<Category?>(null, 404, "Categoria não encontrada.")
                    : new Response<Category?>(category, 200);
            }
            catch
            {
                return new Response<Category?>(null, 500, $"Nao foi possivel obter a categoria {category?.Title}");
            }
        }
        public async Task<Response<Category?>> CreateAsync(CreateCategoryCommand command)
        {
            try
            {
                var category = new Category
                {
                    UserId = command.UserId,
                    Title = command.Title,
                    Description = command.Description
                };
                await _context.AddAsync(category);
                await _context.SaveChangesAsync();
                return new Response<Category?>(category, 201, $"A categoria {category.Title} foi criada com sucesso.");
            }
            catch 
            {
                return new Response<Category?>(null, 500, "Nao foi possivel criar a categoria.");
            }
        }
        public async Task<Response<Category?>> UpdateAsync(UpdateCategoryCommand command)
        {
            var category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == command.Id && x.UserId == command.UserId);
            try 
            {
                if (category == null) return new Response<Category?>(null, 404, $"Categoria {category?.Title} nao encontrada.");

                category.Title = command.Title;
                category.Description = command.Description;

                _context.Categories.Update(category);
                await _context.SaveChangesAsync();

                return new Response<Category?>(category, 200, $"Categoria atualizada com sucesso.");
            }
            catch
            {
                return new Response<Category?>(null, 500, $"Nao foi possivel alterar a categoria {category?.Title}.");
            }
        }
        public async Task<Response<Category?>> DeleteAsync(DeleteCategoryCommand command)
        {
            var category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == command.Id && x.UserId == command.UserId);
            
            try
            {
                if (category == null) return new Response<Category?>(null, 404, "Categoria nao encontrada.");
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                return new Response<Category?>(category, 200, $"Categoria {category.Title} foi excluida com sucesso");
            }
            catch
            {
                return new Response<Category?>(null, 500, $"Nao foi possivel excluir a categoria {category?.Title}.");
            }
        }
    }
}
