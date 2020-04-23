using System.Threading.Tasks;
namespace DesignPatterns.Interfaces {
    public interface IFacadeService {
        Task<bool> Process();
    }
}