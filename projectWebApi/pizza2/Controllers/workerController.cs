using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using AllModels.Interface;
using Microsoft.AspNetCore.Authorization;


namespace pizza2.Controllers
{
    public class workerController : BaseController
    {
        IWorker _worker;
        public workerController(IWorker worker)
        {
            _worker = worker;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IActionResult GetId(int id)
        {
            var x = _worker.GetId(id);
            if (x != null)
                return Ok();
            return NotFound();
        }

        [Route("[action]/{name}")]
        [HttpGet]
        public IActionResult GetNmae(string name)
        {
            var x = _worker.GetNmae(name);
            if (x != null)
                return Ok();
            return NotFound();
        }


        [Authorize(Roles = "admin")]
        [Route("[action]/{age}/{id}")]
        [HttpPut]
        public IActionResult updateAge(int age, int id)
        {
            var x = _worker.updateAge(age, id);
            if (x != null)
            {
                return Ok("the worker id update in age");
            }
            return NotFound("the worker is not found");
        }

        [Authorize(Policy = "Admin")]
        [Route("[action]/{name}/{age}/{id}/{role}/{password}")]
        [HttpPost]
        public IActionResult addWorker(string name, int age, int id, string role, string password)
        {
            var x = _worker.addWorker(name, age, id, role, password);
            return Created();
        }

        [Authorize(Policy = "Admin")]
        [Route("[action]/{id}")]
        [HttpDelete]
        public IActionResult deleteWorker(int id)
        {
            var x = _worker.deleteWorker(id);
            if (x != null)
                return Ok("the worker is remove");
            return NotFound("the worker is not found");
        }
    }
}
