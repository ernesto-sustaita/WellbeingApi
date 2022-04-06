using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IActivityRepository
    {
        Task<IEnumerable<Activity>> GetAll();

        Task<Activity> GetById(int id);

        Task<Activity> Save(Activity activity);

        Task<Activity> Update(int id, Activity activity);

        Task<bool> DeleteById(int id);
    }
}
