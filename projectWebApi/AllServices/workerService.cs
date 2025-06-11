using AllModels;
using AllModels.Interface;
using FileService.Interfaces;
namespace AllServices;
public class workerService: IWorker
{
IfileService<worker> _file;
string _path=@"WorkerFile.json";
public workerService(IfileService<worker> file)
{
    _file=file;
}

     List <worker> workerList=new List<worker>
    {
        new worker("chaim",20,1548,"superWorker","111"),
        new worker("moshe",25,45987,"worker","123"),
        new worker("tamir",30,46546,"admin","157"),
        new worker("shlomo",40,746874,"worker","785"),
        new worker("rami",30,17467,"superWorker","741"),
    };
    public worker GetId(int id)
    {
        List <worker> w= _file.Read(_path);
        foreach(var i in w)
        {
            if(i.id==id)
            {
               return i;
            }
           
        }
         return null;
    }
    public worker GetNmae(string name)
    {
        List <worker> w= _file.Read(_path);
        foreach(var i in w)
        {
            if(i.name==name)
            {
                return i;
            }
            
        }
        return null;
    }
    public bool updateAge(int age,int id)
    {
        List <worker> w= _file.Read(_path);
        foreach(var i in w)
        {
            if(i.id==id)
            {
                i.age=age;
                _file.Write(i,_path);
                return true;
            }
           
        }
         return false;
    }
     public bool addWorker(string name,int age,int id,string role,string password)
    {
        worker x=new worker(name,age,id,role,password);
        // workerList.Add(new worker(name,age,id,role));
        _file.Write(x,_path);
        return  true;
    }
    public worker deleteWorker(int id)
    {
        List <worker> w= _file.Read(_path);

         foreach(var i in w)
        {
            if(i.id==id)
            {
                workerList.Remove(i);
                return i;
            }
        }
        return null;
    }

    public bool isWorkerExist(string name, string password){
        return true;
    }

}
