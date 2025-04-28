using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using AllModels.Interface;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace pizza2.Controllers;

public class pizzamiri : BaseController
{
    IPizza _pizza;
        public pizzamiri(IPizza pizza)
        {
            _pizza=pizza; 
        }

    [Route("[action]/{id}")]
    [HttpGet]
    [Authorize(Policy = "Admin")]
    public IActionResult GetId(int id)
    { 
        throw new Exception("example for exeption");//תפיסת שגיאה!!!!!                
        var x=_pizza.GetId(id);
        if(x!=null)
           return Ok(x);
        return NotFound();   
    }

    [Route("[action]/{name}")]
    [HttpGet]
    public IActionResult GetName(string name)
    {
      var x=_pizza.GetName(name);
        if(x!=null)
           return Ok();
        return NotFound();   
    }

    [Route("[action]/{id}/{gluten}")]
    [HttpPut]
    public IActionResult updateGluten([StringLength(50, MinimumLength = 3, ErrorMessage = "The name must be between 3 and 50 characters long.")]int id,bool gluten)
    {
       var x=_pizza.updateGluten(id,gluten);
            if(x!=null)
            {
               return Ok("the pizza id update in gluten");
            }
           return NotFound("the pizza is not found");
    }

    [Route("[action]/{name}/{id}/{gluten}")]
    [HttpPost]
    public IActionResult addPizza([Required]string name,int id,bool gluten)
    {
      var x=_pizza.addPizza(name,id,gluten);
      return Created();
    }

     [Route("[action]/{id}")]
    [HttpDelete]
    public IActionResult deletePizza(int id)
    {
       var x=_pizza.deletePizza(id);
        if(x!=null)
           return Ok("the pizza is remove");
        return NotFound("the pizza is not found");   
    }                                                                                      
}
