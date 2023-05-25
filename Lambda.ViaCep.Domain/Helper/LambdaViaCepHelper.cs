namespace Lambda.ViaCep.Domain.Helper
{
    public class LambdaViaCepHelper
    {
        public LambdaViaCepHelper() { }

        public static string ObterIdRegistro()
        {
            return new Random().Next().ToString();
        }
    }
}
