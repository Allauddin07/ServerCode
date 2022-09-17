

using Microsoft.EntityFrameworkCore;
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

        

        public async Task<bool> Create(Taask task)
        {
            await _Dbtxt.AddAsync(task);
            return true;
        }

        public async Task<bool> Delete(int? id)
        {
            var task = await _Dbtxt.tasks.FindAsync(id);
            _Dbtxt.tasks.Remove(task);
            await _Dbtxt.SaveChangesAsync();
            return true;
        }

        public async Task<Taask> Detail(int? id)
        {
            var task = await _Dbtxt.tasks.FindAsync(id);
            if (task == null)
            {
                 throw new Exception("Not Found");
            }
            return task;
        }

       public async Task<IEnumerable<Taask>> GetAll()
        {
            var data = await _Dbtxt.tasks.ToListAsync();
            if (data == null)
            {
                throw new Exception("No Data Available");
            }
            return data;
        }

       public async Task<bool> Update(int? id, Taask entity)
        {
            await _Dbtxt.tasks.FindAsync(id);
            _Dbtxt.tasks.Update(entity);
            await _Dbtxt.SaveChangesAsync();

            return true;
        }
    }
}
