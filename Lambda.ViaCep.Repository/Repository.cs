using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Lambda.ViaCep.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.ViaCep.Repository
{
    public class Repository : IRepository
    {
        private readonly static AmazonDynamoDBClient client = new AmazonDynamoDBClient();

        public async Task<dynamic> AddItem(string json, string input)
        {
            try
            {
                using (DynamoDBContext context = new DynamoDBContext(client))
                {
                    var item = PutItem(json, input);

                    var resp = await client.PutItemAsync(item);

                    return resp;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private PutItemRequest PutItem(string txt, string input)
        {
            try
            {
                var request = new PutItemRequest
                {
                    TableName = "TB_INFO_VIACEP",
                    Item = new Dictionary<string, AttributeValue>()
                    {
                        { "ID_REGISTRO", new AttributeValue { N = LambdaViaCepHelper.ObterIdRegistro().ToString() } },
                        { "DS_ENDPOINT", new AttributeValue { S = string.Empty } }, 
                        { "JSON_RETORNO", new AttributeValue { S = txt} },
                        { "REGISTRO_CEP", new AttributeValue { S =  input} }
                    }
                };

                return request;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
