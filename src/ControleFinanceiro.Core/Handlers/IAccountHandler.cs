using ControleFinanceiro.Core.Commands.Account;
using ControleFinanceiro.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Handlers
{
    public interface IAccountHandler
    {
        Task<Response<string>> LoginAsync(LoginCommand loginCommand);
        Task<Response<string>> RegisterAsync(RegisterCommand registerCommand);
        Task LogoutAsync();

    }
}
