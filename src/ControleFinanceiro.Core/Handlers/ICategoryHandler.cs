using ControleFinanceiro.Core.Commands;
using ControleFinanceiro.Core.Commands.Categories;
using ControleFinanceiro.Core.Models;
using ControleFinanceiro.Core.Responses;
using ControleFinanceiro.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Handlers
{
    public interface ICategoryHandler
    {
        Task<Response<Category?>> CreateAsync(CreateCategoryCommand command);
        Task<Response<Category?>> UpdateAsync(UpdateCategoryCommand command);
        Task<Response<Category?>> DeleteAsync(DeleteCategoryCommand command);
        Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoryCommand command);
        Task<Response<Category?>> GetByIdAsync(GetCategoryByIdCommand command);
    }
}
