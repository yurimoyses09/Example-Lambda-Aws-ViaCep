using Lambda.ViaCep.Domain.Models;
using Lambda.ViaCep.Domain.Utils;
using Newtonsoft.Json;
using System.Net;

namespace Lambda.ViaCep.Services.WebServices
{
    public class WebServices : IWebServices
    {
        public async Task<Response> ObterDadosCep(string cep)
        {
            Response response = new Response();
            
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://viacep.com.br/ws/{cep}/json/");
                request.AllowAutoRedirect = false;
                HttpWebResponse ChecaServidor = (HttpWebResponse)request.GetResponse();

                if (ChecaServidor.StatusCode != HttpStatusCode.OK) return null;

                using (Stream webStream = ChecaServidor.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            string retornoapi = responseReader.ReadToEnd();

                            response.Erro = string.Empty;
                            response.Data = JsonConvert.DeserializeObject<Localidade>(retornoapi);
                        };
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }

            return response;
        }
    }
}
