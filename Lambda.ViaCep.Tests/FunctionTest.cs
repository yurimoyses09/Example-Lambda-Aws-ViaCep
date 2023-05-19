using Xunit;
using Amazon.Lambda.TestUtilities;
using Lambda.ViaCep.Services.WebServices;

namespace Lambda.ViaCep.Tests;

public class FunctionTest
{
    private static WebServices _webservico = new WebServices();

    [Fact]
    public void TestObterLocalidadeFunction()
    {

        // Invoke the lambda function and confirm the string was upper cased.
        var function = new Functions();
        var context = new TestLambdaContext();
        var local = function.ObterLocalidade("01001000", context).Result;

        Assert.NotNull(local);
    }
}
