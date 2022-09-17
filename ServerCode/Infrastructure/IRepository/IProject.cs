using Microsoft.AspNetCore.Mvc;
using ServerCode.Model;

namespace ServerCode.Infrastructure.IRepository
{
    public interface IProject
    {
        Task <IEnumerable<Project>> getAll();
        Task<bool> Create(Project project);
        Task<Project> Detail(int? id);
        Task<bool> Update(int? id, Project entity);
        Task<bool> Delete(int? id);
    }
}
