using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerCode.DbaseContxt;
using ServerCode.Infrastructure.IRepository;
using ServerCode.Model;

namespace ServerCode.Infrastructure.Repository
{
    public class ProjectRepository : IProject
    {
        public DbContxt _Dbtxt;

        public ProjectRepository(DbContxt dbtxt)
        {
            _Dbtxt = dbtxt;
        }

        public void Create(Project project)
        {
            _Dbtxt.projects.Add(project);
            
            

            
            
        }

        public void Delete(int? id)
        {
            var project = _Dbtxt.projects.Find(id);
            _Dbtxt.projects.Remove(project);
            _Dbtxt.SaveChanges();

        }

        public Project Detail(int? id)
        {

            var project= _Dbtxt.projects.Find(id);
            return project;

        }

        public IEnumerable<Project> getAll()
        {
            return _Dbtxt.projects.Include(p=>p.task).ToList();
        }

        public void Update(int? id, Project entity)
        {
            var project = _Dbtxt.projects.Find(id);
            _Dbtxt.projects.Update(entity);
            _Dbtxt.SaveChanges();

        }

       
    }
}
