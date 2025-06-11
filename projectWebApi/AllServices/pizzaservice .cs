using AllModels.Interface;
using AllModels;
using AllModels.Interface;
using FileService.Interfaces;
namespace AllServices;
public class pizzaService: IPizza
{
   IfileService<pizzamiri1> _file;
   string _path=@"file.json";
   public  pizzaService(IfileService<pizzamiri1> file)
   {
       _file=file;
   }
     List <pizzamiri1> pizzaList=new List<pizzamiri1>
    {
        new pizzamiri1("italkit",123,true),
        new pizzamiri1("big",456,false),
        new pizzamiri1("muzarela",789,true),
        new pizzamiri1("shamenet",852,false),
        new pizzamiri1("small",741,true)
    };
    public pizzamiri1 GetId(int id)
    {
        List<pizzamiri1> p= _file.Read(_path);
        foreach(var i in p)
        {
            if(i.id==id)
            {
               return i;
            }           
        }
         return null;
    }
    public pizzamiri1 GetName(string name)
    {
        List<pizzamiri1> p= _file.Read(_path);
        foreach(var i in p)
        {
            if(i.name==name)
            {
                return i;
            }
            
        }
        return null;
    }
    public bool updateGluten(int id,bool gluten)
    {
        List<pizzamiri1> p= _file.Read(_path);
        foreach(var i in p)
        {
            if(i.id==id)
            {
                i.gluten=gluten;
                _file.Write(i,_path);
                return true;
            }
           
        }
         return false;
    }
     public bool addPizza(string name,int id,bool gluten)
    {
        pizzamiri1 x=new pizzamiri1(name,id,gluten);
        // pizzaList.Add(x);
        _file.Write(x,_path);
        return true;
    }
    public pizzamiri1 deletePizza(int id)
    {
        List<pizzamiri1> p= _file.Read(_path);
         foreach(var i in p)
        {
            if(i.id==id)
            {
                pizzaList.Remove(i);
                return i;
            }
            
        }
        return null;
    }

}