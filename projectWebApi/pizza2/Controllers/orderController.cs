using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using AllModels.Interface;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using AllModels;
using AllServices;
namespace pizza2.Controllers;

public class orderController : BaseController
{
    IOrder _order;
        public orderController(IOrder order)
        {
            _order=order;
        }

    [Route("[action]/{id}")]
    [HttpGet]
    public IActionResult GetId(int id)
    {
        var x=_order.GetId(id);
        if(x!=null)
           return Ok();
        return NotFound();   
    }

    [Route("[action]/{orderId}")]
    [HttpGet]
    public IActionResult GetOrderId(int orderId)
    {
      var x=_order.GetOrderId(orderId);
        if(x!=null)
           return Ok();
        return NotFound();   
    }

    [Route("[action]/{id}/{gluten}")]
    [HttpPut]
    public IActionResult updateDate(int id,string data)
    {
       var x=_order.updateDate(id,data);
            if(x!=null)
            {
               return Ok("the order id update in data");
            }
           return NotFound("the order is not found");
    }

    [Route("[action]/{coustomerId}/{date}/{idOrder}")]
    [HttpPost]
    public IActionResult addOrder(int coustomerId,string date,int idOrder, int numCardit, int validity,int threeNumber )

    {
    creditCard cc = new creditCard(numCardit, validity, threeNumber);
      var x=_order.addOrder(coustomerId,date,idOrder,numCardit, validity, threeNumber);
      return Created();
    }

     [Route("[action]/{id}")]
    [HttpDelete]
    public IActionResult deleteOrder(int id)
    {
       var x=_order.deleteOrder(id);
        if(x!=null)
           return Ok("the order is remove");
        return NotFound("the order is not found");   
    }  

    // [Route("[action]/{coustomerId}/{data}/{idOrder}/{numCardit}/{validity}/{threeNumber}")]
    // [HttpDelete]
    // public async Task<IActionResult> process(int coustomerId,string data,int idOrder,int numCardit,int validity,int threeNumber)
    // {
    //     order o1=new order(coustomerId,data,idOrder,numCardit,validity,threeNumber);
    //    bool result=await _order.processPreparation();
    //    if(result)
    //    {
    //         return Ok("order processad successfully");
    //    }
    //    else
    //    {
    //         return NotFound("order failed");
    //    } 
    // }                                                                                    
}
