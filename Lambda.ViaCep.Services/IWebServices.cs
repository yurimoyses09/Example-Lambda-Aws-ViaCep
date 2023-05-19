using Lambda.ViaCep.Domain.Utils;

namespace Lambda.ViaCep.Services
{
    public interface IWebServices
    {
        Task<Response> ObterDadosCep(string cep);
    }
}
