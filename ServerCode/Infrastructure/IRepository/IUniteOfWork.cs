namespace ServerCode.Infrastructure.IRepository
{
    public interface IUniteOfWork

        
    {
        IProject Project { get; }
        ITask Taask { get; }
        Task<bool> SaveChange();
    }
}
