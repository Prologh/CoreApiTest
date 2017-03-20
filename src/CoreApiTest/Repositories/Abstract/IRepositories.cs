using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreApiTest.Models;

/// <summary>
/// A list containing all interfaces of model repositories.
/// </summary>
namespace CoreApiTest.Repositories.Abstract
{
    public interface IHeroRepository : IEntityBaseRepository<Hero> { }
    public interface IQuestRepository : IEntityBaseRepository<Quest> { }
}
