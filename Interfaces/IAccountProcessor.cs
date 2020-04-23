using System.Threading.Tasks;
using System.Collections.Generic;

namespace DesignPatterns.Interfaces {
     public interface IAccountProcessor
    {
        Task<List<T>> GetRecords<T>();
    }
}