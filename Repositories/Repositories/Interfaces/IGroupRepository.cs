



using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IGroupRepository : IBaseRepository<Group>
    {
        Task<IEnumerable<Group>> GetAllWithIncludesAsync();
        Task<IEnumerable<Group>> GetAllForUIAsync();

    }
}
