using System.Collections.Generic;

namespace CoreApiTest.Models.Hero
{
    public interface IHeroRepository
    {
        IEnumerable<Hero> GetAll();
        Hero GetById(int key);
        void Create(Hero item);
        void Update(Hero item);
        void Delete(int key);
    }
}