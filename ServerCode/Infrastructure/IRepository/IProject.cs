using Microsoft.AspNetCore.Mvc;
using ServerCode.Model;

namespace ServerCode.Infrastructure.IRepository
{
    public interface IProject
    {
        IEnumerable<Project> getAll();
        void Create(Project project);
        Project Detail(int? id);
        void Update(int? id, Project entity);
        void Delete(int? id);
    }
}
