using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;
using Lambda.ViaCep.Domain.Models;
using Lambda.ViaCep.Services.WebServices;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(DefaultLambdaJsonSerializer))]

namespace Lambda.ViaCep;

public class Functions
{
    private static WebServices _webservico = new WebServices();

    /// <summary>
    /// Função responsavel por obter dados do cep informado
    /// </summary>
    /// <param name="cep"></param>
    /// <param name="lambdaContext"></param>
    /// <returns></returns>
    public async Task<dynamic> ObterLocalidade(string cep, ILambdaContext lambdaContext)
    {
        try
        {
            if (cep != null) return await _webservico.ObterDadosCep(cep);
        }
        catch (Exception e)
        {
            throw e;
        }

        return new { data = new Localidade() };
    }
}
