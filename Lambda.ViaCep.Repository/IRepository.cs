using System.Threading.Tasks;

namespace Lambda.ViaCep.Repository
{
    public interface IRepository
    {
        Task<dynamic> AddItem(string json, string input);
    }
}
