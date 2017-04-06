using HeroCore.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// A list containing all interfaces of model repositories.
/// </summary>
namespace HeroCore.Api.Repositories.Abstract
{
    public interface IHeroRepository : IEntityBaseRepository<Hero> { }
    public interface IQuestRepository : IEntityBaseRepository<Quest> { }
}
