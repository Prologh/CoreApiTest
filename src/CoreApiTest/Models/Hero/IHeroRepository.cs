using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreApiTest.Models.Hero
{
    public interface IHeroRepository
    {
        Task<IEnumerable<Hero>> GetAll();
        Task<Hero> GetById(int key);
        Task Add(Hero item);
        Task Update(Hero item);
        Task Delete(int key);
    }
}