using Microsoft.AspNetCore.Mvc;
using ServerCode.Infrastructure.IRepository;
using ServerCode.Model;

namespace ServerCode.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : Controller
    {
        public IUniteOfWork _uniteOfWork;

        public TaskController(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }



        [HttpPost("create")]
        public IActionResult Index([FromBody] Taask task)
        {
            if (ModelState.IsValid)
            {
                _uniteOfWork.Taask.Create(task);
                _uniteOfWork.SaveChange();


                return Ok("Grate");
            }
            else
            {
                return BadRequest();
            }
            
        }
    }
}
