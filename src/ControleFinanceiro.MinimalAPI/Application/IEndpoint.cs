namespace ControleFinanceiro.MinimalAPI.Application
{
    public interface IEndpoint
    {
        static abstract void Map(IEndpointRouteBuilder app);
    }
}
