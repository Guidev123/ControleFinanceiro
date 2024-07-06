using ControleFinanceiro.Core.Commands.Transactions;
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
    public interface ITransactionHandler
    {
        Task<Response<Transaction?>> CreateAsync(CreateTransactionCommand command);
        Task<Response<Transaction?>> UpdateAsync(UpdateTransactionCommand command);
        Task<Response<Transaction?>> DeleteAsync(DeleteTransactionCommand command);
        Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdCommand command);
        Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionByPeriodCommand command);
    }
}
