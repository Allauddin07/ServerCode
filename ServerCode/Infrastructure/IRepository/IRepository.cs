using System.Linq.Expressions;

namespace ServerCode.Infrastructure.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
       IEnumerable<T> getAll (T entity);

       // T getDetail(Expression(Func<T , bool >)
        



    }
}
