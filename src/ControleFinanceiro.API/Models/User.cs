using Microsoft.AspNetCore.Identity;

namespace ControleFinanceiro.API.Models
{
    public class User : IdentityUser<long>
    {
        /* RBAC */
        public List<IdentityRole<long>>? Roles { get; set; }
    }
}
