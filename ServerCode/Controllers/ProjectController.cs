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


        public ProjectController(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;

        }

        //-------------------Creating Project------------------->
        [HttpPost("create")]
        public async Task<IActionResult> CreateProject([FromBody] Project project)
        {

            try
            {
                if (project != null && ModelState.IsValid)
                {
                    await _uniteOfWork.Project.Create(project);
                    await _uniteOfWork.SaveChange();

                    return Ok("greate");
                }
                else
                {
                    return BadRequest("No Valid");
                }

            }
            catch (Exception)
            {

                return BadRequest("Server error");
            }



        }

        //--------------Getting All Project-------------------->
        [HttpGet("getProject")]
        public async Task<IActionResult> GetAllProject()
        {
            try
            {
                IEnumerable<Project> data = await _uniteOfWork.Project.getAll();

                if(data != null)
                {
                    return Ok(data);
                }
                return BadRequest("No Data Available");
                


            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error getting data");
            }

        }


        //-----------------Deleting Project--------------------->
        [HttpPost("delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            try
            {
                bool data = await _uniteOfWork.Project.Delete(id);
                if (data)
                {
                    await _uniteOfWork.SaveChange();
                    return Ok("Deleted Successfully");
                }
                return NotFound("Not Found");
               
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error deleting data");
            }

        }

        //-----------------Updating Project---------------------->
        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int? id, Project entity)
        {
            try
            {
                var data = await _uniteOfWork.Project.Update(id, entity);
                if (data)
                {
                    await _uniteOfWork.SaveChange();
                    return Ok("Updated Successfully");

                }
                return NotFound($"this id {id} not found");  
                
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error updating data");
            }


        }

        //-------------------Detail of A project------------------>
        [HttpGet("detail/{id:int}")]
        public async Task<IActionResult> Detail([FromRoute] int? id)
        {
            try
            {
               var data = await _uniteOfWork.Project.Detail(id);
                if(data != null)
                {
                    return Ok(data);
                }
                return NotFound("Not Found");  
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error detail data");
            }


        }

    }
}