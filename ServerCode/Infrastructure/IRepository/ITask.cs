using ServerCode.Model;

namespace ServerCode.Infrastructure.IRepository
{
    public interface ITask
    {
        IEnumerable<Taask> getAll();
        void Create(Taask task);
        Taask Detail(int? id);
        void Update(int? id, Taask entity);
        void Delete(int? id);
    }
}
