using HeroCore.Api.Models;

/// <summary>
/// A list containing all interfaces of model repositories.
/// </summary>
namespace HeroCore.Api.Repositories.Abstract
{
    public interface IHeroRepository : IEntityBaseRepository<Hero> { }
    public interface IQuestRepository : IEntityBaseRepository<Quest> { }
}
