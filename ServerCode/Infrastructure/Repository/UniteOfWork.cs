using ServerCode.DbaseContxt;
using ServerCode.Infrastructure.IRepository;

namespace ServerCode.Infrastructure.Repository
{
    public class UniteOfWork : IUniteOfWork
    {
        public DbContxt _DContxt { get; }
        public UniteOfWork(DbContxt DContxt)
        {
            _DContxt = DContxt;
        }

        

        IProject IUniteOfWork.Project => new ProjectRepository(_DContxt);

        public ITask Taask => new TaskRepository(_DContxt);

        public async Task<bool> SaveChange()
        {
            return await _DContxt.SaveChangesAsync() > 0; 
        }
    }
}
