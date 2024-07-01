using Azure.Core;
using ControleFinanceiro.Core.Commands.Transactions;
using ControleFinanceiro.Core.Entities;
using ControleFinanceiro.Core.Extensions;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Core.Responses;
using ControleFinanceiro.Core.Services;
using ControleFinanceiro.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.API.Handlers
{
    public class TransactionHandler(AppDbContext _context) : ITransactionHandler
    {
        public async Task<Response<Transaction?>> CreateAsync(CreateTransactionCommand command)
        {
            try
            {
                var transaction = new Transaction
                {
                    UserId = command.UserId,
                    CategoryId = command.CategoryId,
                    CreatedAt = DateTime.UtcNow,
                    Amount = command.Amount,
                    PaidOrReceivedAt = command.PaidOrReceivedAt,
                    Title = command.Title,
                    TransactionType = command.TransactionType
                };

                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();

                return new Response<Transaction?>(transaction, 201, "Transacao adicionada com sucesso");
            }
            catch
            {
                return new Response<Transaction?>(null, 500, "Nao foi possivel adicionar a transacao");
            }
        }
        public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionCommand command)
        {

            try
            {
                var transaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == command.Id && x.UserId == command.UserId);

                transaction.CategoryId = command.CategoryId;
                transaction.Amount = command.Amount;
                transaction.TransactionType = command.TransactionType;
                transaction.PaidOrReceivedAt = command.PaidOrReceivedAt;
                transaction.Title = command.Title;

                _context.Transactions.Update(transaction);
                await _context.SaveChangesAsync();

                if (transaction == null) return new Response<Transaction?>(null, 404, "Transacao nao encontrada");
                return new Response<Transaction?>(transaction);
            }
            catch
            {
                return new Response<Transaction?>(null, 500, "Nao foi possivel recuperar sua transacao");
            }

        }

        public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionCommand command)
        {
            try
            {
                var transaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == command.Id && x.UserId == command.UserId);

                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();

                if (transaction == null) return new Response<Transaction?>(null, 404, "Transacao nao encontrada");
                return new Response<Transaction?>(transaction);
            }
            catch
            {
                return new Response<Transaction?>(null, 500, "Nao foi possivel recuperar sua transacao");
            }
        }

        public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdCommand command)
        {
            try
            {
                var transaction = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == command.Id && x.UserId == command.UserId);

                if (transaction == null) return new Response<Transaction?>(null, 404, "Transacao nao encontrada");
                return new Response<Transaction?>(transaction);
            }
            catch
            {
                return new Response<Transaction?>(null, 500, "Nao foi possivel recuperar sua transacao");
            }
        }

        public async Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionByPeriodCommand command)
        {
            try
            {
                command.StartDate ??= DateTime.Now.GetFirstDay();
                command.EndDate ??= DateTime.Now.GetLastDay();
            }
            catch
            {
                return new PagedResponse<List<Transaction>?>(null, 500, "Não foi possível encontrar uma data de início ou término");
            }

            try
            {
                var query = _context.Transactions.AsNoTracking().Where(x =>x.PaidOrReceivedAt >= command.StartDate && x.PaidOrReceivedAt <= command.EndDate && x.UserId == command.UserId)
                    .OrderBy(x => x.PaidOrReceivedAt);

                var transactions = await query.Skip((command.PageNumber - 1) * command.PageSize).Take(command.PageSize).ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Transaction>?>(transactions, count, command.PageNumber, command.PageSize);
            }
            catch
            {
                return new PagedResponse<List<Transaction>?>(null, 500, "Não foi possível obter suas transações");
            }
        }
    }
}
