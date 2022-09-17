using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerCode.DbaseContxt;
using ServerCode.Infrastructure.IRepository;
using ServerCode.Model;
//using ModelValidate.Models;


namespace ServerCode.Controllers
{
    [Route("api/project")]
    [ApiController]
    //[BindProperties]
    public class ProjectController : ControllerBase
    {
        //public IProject _project;
        public IUniteOfWork _uniteOfWork;
        

        public ProjectController(IUniteOfWork uniteOfWork )
        {
            _uniteOfWork = uniteOfWork; 
            
        }

        //Creating Project
        [HttpPost("create")]      
        public async Task<IActionResult> CreateProject( [FromBody] Project project )
        {
            if (project != null && ModelState.IsValid)
            {
                _uniteOfWork.Project.Create(project);
               await _uniteOfWork.SaveChange();

                return Ok("greate");
            }
            else
            {
                return BadRequest("No Valid");
            }

            
            
        }
        [HttpGet("getProject")]
        public IActionResult GetAllProject()
        {
            var data = _uniteOfWork.Project.getAll();   
                return Ok(data);    
            
        }
    }
}
