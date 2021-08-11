using System.Threading.Tasks;

namespace Teste.Data
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}