using AllModels;
using AllModels.Interface;
using System;
using FileService.Interfaces;
namespace AllServices;
public class orderService: IOrder
{
    IfileService<string> _file;
   string _path=@"projectWebApi/pizza2/invoice.json";
   public  orderService(IfileService<string> file)
   {
       _file=file;
   }
     List <order> orderList=new List<order>
    {
        new order(0547,"01/02/2025",123456,12345,02,41),
        new order(548,"01/02/2025",32872782,12345,02,41),
        new order(854,"01/02/2025",5522852,12345,02,41),
        new order(7522,"01/02/2025",788,12345,02,41),
        new order(7225,"01/02/2025",28727832,12345,02,41),
    };
    public order GetId(int id)
    {
        
        foreach(var i in orderList)
        {
            if(i.coustomerId==id)
            {
               return i;
            }
           
        }
         return null;
    }
    public order GetOrderId(int orderId)
    {
        foreach(var i in orderList)
        {
            if(i.idOrder==orderId)
            {
                return i;
            }
            
        }
        return null;
    }
    public bool updateDate(int id,string data)
    {
        foreach(var i in orderList)
        {
            if(i.coustomerId==id)
            {
                i.data=data;
                return true;
            }
           
        }
         return false;
    }
     public async Task<bool> addOrder(int coustomerId,string date,int idOrder,int numCardit,int validity,int threeNumber)
    {
        // await this.processPreparation();
        orderList.Add(new order(coustomerId,date,idOrder,numCardit,validity,threeNumber));
        Task price=pay();
        await price;
        Task create=makePizza();
        await create;
        Task mailInvoice=invoice();
        return  true;
    }
    public order deleteOrder(int id)
    {
         foreach(var i in orderList)
        {
            if(i.idOrder==id)
            {
                orderList.Remove(i);
                return i;
            }
            
        }
        return null;
    }

    public async Task pay()
    {
       await Task.Delay(4000);
       Console.WriteLine("this pay");
    }

    public async Task makePizza()
    {
        Console.WriteLine("make the dough");
        await Task.Delay(4000);
        Console.WriteLine("Preparing the sauce");
        await Task.Delay(2000);
        Console.WriteLine("Preparing the toppings");
        await Task.Delay(1000);
        Console.WriteLine("baking....");
        await Task.Delay(5000);
    }

    public async Task invoice()
    {
        string i="thank you for the buy......";
        _file.Write(i,_path);
    }

    // public async Task<bool> processPreparation()
    // {
    //     await pay();
    //     await makePizza();
    //     await invoice();
    //     return true;
    // } 



}