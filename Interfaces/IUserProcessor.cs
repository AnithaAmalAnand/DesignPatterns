using System.Threading.Tasks;
using DesignPatterns.Models;
namespace DesignPatterns.Interfaces {
     public interface IUserProcessor
    {
        Task<User> GetUser();
    }
}