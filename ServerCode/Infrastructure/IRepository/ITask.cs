using ServerCode.Model;

namespace ServerCode.Infrastructure.IRepository
{
    public interface ITask
    {
        Task <IEnumerable<Taask>> GetAll();
        Task<bool> Create(Taask task);
        Task<Taask> Detail(int? id);
        Task<bool> Update(int? id, Taask entity);
        Task<bool> Delete(int? id);
    }
}
