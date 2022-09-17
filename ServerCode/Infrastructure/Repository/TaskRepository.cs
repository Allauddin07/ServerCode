

using ServerCode.DbaseContxt;
using ServerCode.Infrastructure.IRepository;
using ServerCode.Model;

namespace ServerCode.Infrastructure.Repository
{
    public class TaskRepository:ITask
    {
        public DbContxt _Dbtxt;

        public TaskRepository(DbContxt dbtxt)
        {
            _Dbtxt = dbtxt;
        }

        public void Create(Taask task)
        {
            _Dbtxt.tasks.Add(task);

            


        }

        public void Delete(int? id)
        {
            var project = _Dbtxt.tasks.Find(id);
            _Dbtxt.tasks.Remove(project);
            _Dbtxt.SaveChanges();

        }

        public Taask Detail(int? id)
        {

            var project = _Dbtxt.tasks.Find(id);
            return project;

        }

        public IEnumerable<Taask> getAll()
        {
            return _Dbtxt.tasks.ToList();
        }

        public void Update(int? id, Taask entity)
        {
            var project = _Dbtxt.tasks.Find(id);
            _Dbtxt.tasks.Update(entity);
            _Dbtxt.SaveChanges();

        }

    }
}
