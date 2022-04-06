using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IActivityService
    {
        Task<IEnumerable<Activity>> GetAll();

        Task<Activity> GetById(int id);

        Task<Activity> Save(Activity activity);

        Task<Activity> Update(int id, Activity activity);

        Task<bool> DeleteById(int id);
    }
}
