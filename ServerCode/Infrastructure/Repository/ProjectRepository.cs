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

        public async Task<bool> Create(Project project)
        {
            await _Dbtxt.projects.AddAsync(project);

            return true;   
            
        }

        public async Task<bool> Delete(int? id)
        {
            var project = await _Dbtxt.projects.FindAsync(id);
            if (project == null)
            {
                return false;   
            }
            _Dbtxt.projects.Remove(project);
           //await _Dbtxt.SaveChangesAsync();
           return true;

        }

        public async Task<Project> Detail(int? id)
        {

            //var project = await _Dbtxt.projects.FindAsync(id);
            var project = await _Dbtxt.projects.Include(p => p.task).FirstOrDefaultAsync(p => p.ProjectId == id);



            if (project == null)
            {
                return null;
            }
            return project;

        }

        public async Task<IEnumerable<Project>> getAll()
        { 
            var data = await _Dbtxt.projects.Include(p => p.task).ToListAsync();
            if (data == null)
            {
                throw new Exception("No Data Available");
            }
            return data;
        }

        public async Task<bool> Update(int? id, Project entity)
        {
            ///var data = await _Dbtxt.projects.FindAsync(id);
            var data = await _Dbtxt.projects.Include(p =>  p.task).FirstOrDefaultAsync(p=>p.ProjectId==id);
            if(data != null)
            {
                // _Dbtxt.projects.Update(entity);
                //_Dbtxt.Entry(entity) = ApartmentState.Modified()
                 _Dbtxt.projects.Attach(data);
                data.ProjectId = data.ProjectId;  
                data.Name = entity.Name;
                data.Description = entity.Description;
                data.Progres = entity.Progres;
                data.S_Date = entity.S_Date;    
                data.Deadline= entity.Deadline;
                //data.task.Add(new Taask (entity.task));


                return true;    
                
            }
            

            return false;

        }

    }
}
