using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreApiTest.Models.Quest
{
    public interface IQuestRepository
    {
        Task<IEnumerable<Quest>> GetAll();
        Task<Quest> GetById(int key);
        Task Add(Quest item);
        Task Update(Quest item);
        Task Delete(int key);
    }
}